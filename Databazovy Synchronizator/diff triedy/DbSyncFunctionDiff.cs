using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
   public class DbSyncFunctionDiff
    {
        private SFunction functionA;
        private SFunction functionB;

        private List<Privilege> grantsMissingDb1;
        private List<Privilege> grantsMissingDb2;
        private List<DbSyncPrivilegeDiff> grantsDifferent;
        
        private List<ObjectAtribute> functionAtributesA;
        private List<ObjectAtribute> functionAtributesB;

        private SqlTextHighlited sqlTextListA;
        private SqlTextHighlited sqlTextListB; 

        public SqlTextHighlited SqlTextListA
        {
            get { return sqlTextListA; }
           
        }
        public SqlTextHighlited SqlTextListB
        {
            get { return sqlTextListB; }
           
        }

        private List<DbSyncPrivilegeDiff> privilegeDiffList;

        public List<DbSyncPrivilegeDiff> PrivilegeDiffList
        {
            get { return privilegeDiffList; }

        }
        internal List<ObjectAtribute> FunctionAtributesA
        {
            get { return functionAtributesA; }
           
        }
        internal List<ObjectAtribute> FunctionAtributesB
        {
            get { return functionAtributesB; }
           
        }
       
        private string functionName;
        
        private bool diffNAmeOfFunction = false;
        private bool diffReturnType = false;
        private bool diffPrivileges = false;

     
        private bool diffSqlText = false;
        private bool different;

        public bool DiffPrivileges
        {
            get { return diffPrivileges; }

        } 

        public SFunction getFunctionA()
        {
            return functionA;
        }
        public SFunction getFunctionB()
        {
            return functionB;
        }
        
        public DbSyncFunctionDiff(SFunction functionAin, SFunction functionBin)
        {
            this.functionA = functionAin;
            this.functionB = functionBin;

            functionAtributesA = new List<ObjectAtribute>();
            functionAtributesB = new List<ObjectAtribute>();

            privilegeDiffList = new List<DbSyncPrivilegeDiff>();

            grantsMissingDb1 = new List<Privilege>();
            grantsMissingDb2 = new List<Privilege>();
            grantsDifferent = new List<DbSyncPrivilegeDiff>();

            fulfillLists();

            ComparatorOfSQL compSQL;
            
            if (functionA == null || functionB == null)
            {
                if (functionA != null)
                {
                    functionName = functionA.NazovFunkcie;
                    functionAtributesA.Add(new ObjectAtribute("Name of function ",functionName, true));
                    functionAtributesA.Add(new ObjectAtribute("Sql text ", "Click button", true,true));
                    functionAtributesA.Add(new ObjectAtribute("Return type ", functionA.ReturnType, true));
                    compSQL = new ComparatorOfSQL(functionA.SqlText, null);
                    sqlTextListA = compSQL.TextA;
                    sqlTextListB = null;
                }
                if (functionB != null)
                {
                    functionName = functionB.NazovFunkcie;
                    functionAtributesB.Add(new ObjectAtribute("Name of function ", functionName, true));
                    functionAtributesB.Add(new ObjectAtribute("Sql text ", "Click button", true, true));
                    functionAtributesB.Add(new ObjectAtribute("Return type ", functionB.ReturnType, true));
                    compSQL = new ComparatorOfSQL(null, functionB.SqlText);
                    sqlTextListA = null;
                    sqlTextListB = compSQL.TextA;
                }
                else functionName = "UNDEFINED";

            }
            if (functionA != null && functionB != null)
            {
                compSQL = new ComparatorOfSQL(functionA.SqlText, functionB.SqlText);
                sqlTextListA = compSQL.TextA;
                sqlTextListB = compSQL.TextB;
               
                if (functionA.NazovFunkcie != functionB.NazovFunkcie) diffNAmeOfFunction = true;
                if (functionA.ReturnType != functionB.ReturnType) diffReturnType = true;
                if (compSQL.IsDifferent) diffSqlText = true;
                if (!ComparePrivileges(functionA.Privileges, functionB.Privileges)) diffPrivileges = true;

                if (diffNAmeOfFunction || diffPrivileges || diffReturnType || diffSqlText) different = true;
                else different = false;

                //vytvorim privileges
                foreach (Privilege privA in functionA.Privileges)
                {
                    bool found = false;
                    foreach (Privilege privB in functionB.Privileges)
                    {
                        if (privA.DBSyncCompareTO(privB))
                        {
                            found = true;
                            privilegeDiffList.Add(new DbSyncPrivilegeDiff(privA, privB));
                        }

                    }
                    if (!found) privilegeDiffList.Add(new DbSyncPrivilegeDiff(privA, null));
                }
                foreach (Privilege privB in functionB.Privileges)
                {
                    bool found = false;
                    foreach (DbSyncPrivilegeDiff priv in privilegeDiffList)
                    {
                        if (privB.getName() == priv.getName())
                        {
                            found = true;
                        }
                    }
                    if (!found) this.privilegeDiffList.Add(new DbSyncPrivilegeDiff(null, privB));
                }

                functionName = functionA.NazovFunkcie;
                functionAtributesA.Add(new ObjectAtribute("Name of function ", functionName, false));
                functionAtributesB.Add(new ObjectAtribute("Name of function ", functionName, false));

                if (diffSqlText)
                {
                    ObjectAtribute sqlA = new ObjectAtribute("Sql text ", "Click button", true, true);
                    functionAtributesA.Add(sqlA);
                    ObjectAtribute sqlB = new ObjectAtribute("Sql text  ", "Click button", true, true);
                    functionAtributesB.Add(sqlB);
                }
                else
                {
                    ObjectAtribute sql = new ObjectAtribute("Sql text  ", "Click button", false, true);
                    functionAtributesA.Add(sql);
                    functionAtributesB.Add(sql);
                }

                if (diffReturnType)
                {
                    ObjectAtribute sqlA = new ObjectAtribute("Return type ", functionA.ReturnType, true);
                    functionAtributesA.Add(sqlA);
                    ObjectAtribute sqlB = new ObjectAtribute("Return type  ", functionB.ReturnType, true);
                    functionAtributesB.Add(sqlB);
                }
                else
                {
                    ObjectAtribute sql = new ObjectAtribute("Return type  ", functionA.ReturnType, false);
                    functionAtributesA.Add(sql);
                    functionAtributesB.Add(sql);
                }


            }
            else different = true;


        }

        private void fulfillLists()
        {
            if (this.diffPrivileges)
            {
                foreach (DbSyncPrivilegeDiff priv in this.privilegeDiffList)
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
            return functionName;
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
