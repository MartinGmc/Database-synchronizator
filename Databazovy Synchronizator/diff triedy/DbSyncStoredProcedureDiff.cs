using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
   public class DbSyncStoredProcedureDiff
    {
        private SProcedure procA;
        private SProcedure procB;

        private List<Privilege> grantsMissingDb1;
        private List<Privilege> grantsMissingDb2;
        private List<DbSyncPrivilegeDiff> grantsDifferent; 

        private List<DbSyncPrivilegeDiff> privilegeDifList;

        private List<ObjectAtribute> storedProcDiffListA;
        private List<ObjectAtribute> storedProcDiffListB;

        private SqlTextHighlited sqlTextListA;
        private SqlTextHighlited sqlTextListB;

        public SqlTextHighlited SqlTextListB
        {
            get { return sqlTextListB; }
            
        }

        public SqlTextHighlited SqlTextListA
        {
            get { return sqlTextListA; }
           
        }

        internal List<ObjectAtribute> StoredProcDiffListA
        {
            get { return storedProcDiffListA; }
           
        }
        internal List<ObjectAtribute> StoredProcDiffListB
        {
            get { return storedProcDiffListB; }
           
        }

        private string procedureName;

        private bool diffPrivileges = false;
        private bool diffNameOfProcedure = false;
        private bool diffSqlText = false;
        private bool different = false;

        public bool DiffPrivileges
        {
            get { return diffPrivileges; }

        } 
        public bool DiffNameOfProcedure
        {
            get { return diffNameOfProcedure; }

        } 
        public bool DiffSqlText
        {
            get { return diffSqlText; }

        }

        public List<DbSyncPrivilegeDiff> PrivilegeDifList()
        {
            return privilegeDifList;
        }
        public SProcedure getProcA()
        {
            return procA;
        }
        public SProcedure getProcB()
        {
            return procB;
        }
        
        public DbSyncStoredProcedureDiff(SProcedure procAin, SProcedure procBin)
        {
            this.procA = procAin;
            this.procB = procBin;

            storedProcDiffListA = new List<ObjectAtribute>();
            storedProcDiffListB = new List<ObjectAtribute>();
            privilegeDifList = new List<DbSyncPrivilegeDiff>();

            grantsMissingDb1 = new List<Privilege>();
            grantsMissingDb2 = new List<Privilege>();
            grantsDifferent = new List<DbSyncPrivilegeDiff>();

            fulfillLists();

            ComparatorOfSQL compSQL;
            
            if (procA == null || procB == null)
            {
                if (procA != null)
                {
                    procedureName = procA.NazovProcedury;
                    storedProcDiffListA.Add(new ObjectAtribute("Procedure name", procedureName, false));
                    storedProcDiffListA.Add(new ObjectAtribute("Sql text ", "Click button", false, true));
                    compSQL = new ComparatorOfSQL(procA.SqlText, null);
                    sqlTextListA = compSQL.TextA;
                    sqlTextListB = null;
                }
                else if (procB != null)
                {
                    procedureName = procB.NazovProcedury;
                    storedProcDiffListB.Add(new ObjectAtribute("Procedure name", procedureName, false));
                    storedProcDiffListB.Add(new ObjectAtribute("Sql text ", "Click button", false, true));
                    compSQL = new ComparatorOfSQL(null, procB.SqlText);
                    sqlTextListA = null;
                    sqlTextListB = compSQL.TextB;
                }
                else procedureName = "UNDEFINED";
            }
            if (procA != null && procB != null)
            {
                compSQL = new ComparatorOfSQL(procA.SqlText, procB.SqlText);
                sqlTextListA = compSQL.TextA;
                sqlTextListB = compSQL.TextB;
                
                procedureName = procB.NazovProcedury;
                storedProcDiffListA.Add(new ObjectAtribute("Procedure name", procedureName,false));
                storedProcDiffListB.Add(new ObjectAtribute("Procedure name", procedureName,false));

                if (procA.NazovProcedury != procB.NazovProcedury) diffNameOfProcedure = true;
                if (compSQL.IsDifferent) diffSqlText = true;
                if (!ComparePrivileges(procA.Privieges, procB.Privieges)) diffPrivileges = true;

                if (diffNameOfProcedure || diffPrivileges || diffSqlText) different = true;
                else different = false;

                //vytvorim privileges
                foreach (Privilege privA in procA.Privieges)
                {
                    bool found = false;
                    foreach (Privilege privB in procB.Privieges)
                    {
                        if (privA.DBSyncCompareTO(privB))
                        {
                            found = true;
                            this.privilegeDifList.Add(new DbSyncPrivilegeDiff(privA, privB));
                        }

                    }
                    if (!found) this.privilegeDifList.Add(new DbSyncPrivilegeDiff(privA, null));
                }
                foreach (Privilege privB in procB.Privieges)
                {
                    bool found = false;
                    foreach (DbSyncPrivilegeDiff priv in privilegeDifList)
                    {
                        if (privB.getName() == priv.getName())
                        {
                            found = true;
                        }
                    }
                    if (!found) this.privilegeDifList.Add(new DbSyncPrivilegeDiff(null, privB));
                }

                if (diffSqlText)
                {
                    ObjectAtribute sqlA = new ObjectAtribute("Sql text ", "Click button", true, true);
                    storedProcDiffListA.Add(sqlA);
                    ObjectAtribute sqlB = new ObjectAtribute("Sql text  ", "Click button", true, true);
                    storedProcDiffListB.Add(sqlB);
                }
                else
                {
                    ObjectAtribute sql = new ObjectAtribute("Sql text  ", "Click button", false, true);
                    storedProcDiffListA.Add(sql);
                    storedProcDiffListB.Add(sql);
                }

            }
            else different = true;

        }

        private void fulfillLists()
        {
            if (this.diffPrivileges)
            {
                foreach (DbSyncPrivilegeDiff priv in this.privilegeDifList)
                {
                    if (priv.isDifferent())
                    {
                        if ((priv.getPrivA() != null) && (priv.getPrivB() != null))
                        {
                            grantsDifferent.Add(priv);
                        }
                        else if (priv.getPrivA() == null)
                        {
                            grantsMissingDb1.Add(priv.getPrivB());
                        }
                        else
                        {
                            grantsMissingDb2.Add(priv.getPrivA());
                        }
                    }
                }
            }
        }

        public string getName()
        {
            return procedureName;
        }

        public bool isDifferent()
        {
            return different;
        }

        private bool ComparePrivileges(List<Privilege> privA, List<Privilege> privB)
        {
            bool ress = true;

            foreach (Privilege pA in privA)
            {
                bool nasiel = false;
                foreach (Privilege pB in privB)
                {
                    if (pA.DBSyncCompareTO(pB)) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            return ress;
        }
       

    }
}
