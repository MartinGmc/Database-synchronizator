using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    public class DbSyncTableDiff
    {
        private Tablee tabA;
        private Tablee tabB;

        private List<Columnn> columnsMissingDb1;
        private List<Columnn> columnsMissingDb2;
        private List<DbSyncColumnDiff> columnsDifferent;
        private List<Key> keysMissingDb1;
        private List<Key> keysMissingDb2;
        private List<DbSyncKeyDiff> keysDifferent;
        private List<Constraintt> constraintsMissingDb1;
        private List<Constraintt> constraintsMissingDb2;
        private List<DbSyncConstraintDiff> constraintsDifferent;
        private List<Trigger> triggersMissingDb1;
        private List<Trigger> triggersMissingDb2;
        private List<DbSyncTriggerDiff> triggersDifferent;
        private List<Privilege> grantsMissingDb1;
        private List<Privilege> grantsMissingDb2;
        private List<DbSyncPrivilegeDiff> grantsDifferent;
        private List<Index> indexesMissingDb1;
        private List<Index> indexesMissingDb2;
        private List<DbSyncIndexDiff> indexesDifferent;

        public List<DbSyncColumnDiff> ColumnsDifferent
        {
            get { return columnsDifferent; }
            set { columnsDifferent = value; }
        }
        public List<Key> KeysMissingDb1
        {
            get { return keysMissingDb1; }
            set { keysMissingDb1 = value; }
        }
        public List<Key> KeysMissingDb2
        {
            get { return keysMissingDb2; }
            set { keysMissingDb2 = value; }
        }
        public List<DbSyncKeyDiff> KeysDifferent
        {
            get { return keysDifferent; }
            set { keysDifferent = value; }
        }
        public List<Constraintt> ConstraintsMissingDb1
        {
            get { return constraintsMissingDb1; }
            set { constraintsMissingDb1 = value; }
        }
        public List<Constraintt> ConstraintsMissingDb2
        {
            get { return constraintsMissingDb2; }
            set { constraintsMissingDb2 = value; }
        }
        public List<DbSyncConstraintDiff> ConstraintsDifferent
        {
            get { return constraintsDifferent; }
            set { constraintsDifferent = value; }
        }
        public List<Trigger> TriggersMissingDb1
        {
            get { return triggersMissingDb1; }
            set { triggersMissingDb1 = value; }
        }
        public List<Trigger> TriggersMissingDb2
        {
            get { return triggersMissingDb2; }
            set { triggersMissingDb2 = value; }
        }
        public List<DbSyncTriggerDiff> TriggersDifferent
        {
            get { return triggersDifferent; }
            set { triggersDifferent = value; }
        }
        public List<Columnn> ColumnsMissingDb2
        {
            get { return columnsMissingDb2; }
            set { columnsMissingDb2 = value; }
        }
        public List<DbSyncIndexDiff> IndexesDifferent
        {
            get { return indexesDifferent; }
            set { indexesDifferent = value; }
        }
        public List<Index> IndexesMissingDb2
        {
            get { return indexesMissingDb2; }
            set { indexesMissingDb2 = value; }
        }
        public List<Index> IndexesMissingDb1
        {
            get { return indexesMissingDb1; }
            set { indexesMissingDb1 = value; }
        }
        public List<DbSyncPrivilegeDiff> GrantsDifferent
        {
            get { return grantsDifferent; }
            set { grantsDifferent = value; }
        }
        public List<Privilege> GrantsMissingDb2
        {
            get { return grantsMissingDb2; }
            set { grantsMissingDb2 = value; }
        }
        public List<Privilege> GrantsMissingDb1
        {
            get { return grantsMissingDb1; }
            set { grantsMissingDb1 = value; }
        }

        private List<DbSyncColumnDiff> columnsDifList;
        private List<DbSyncConstraintDiff> constraintDifList;
        private List<DbSyncTriggerDiff> triggerDifList;
        private List<DbSyncPrivilegeDiff> privilegeDifList;
        private List<DbSyncIndexDiff> indexesDifList;
        private List<DbSyncKeyDiff> keysDifList;

        private string TableName;

        private bool different;
        private bool diffTableName;
        private bool diffCoulumns;
        private bool diffIndexes;
        private bool diffConstraints;
        private bool diffTriggers;
        private bool diffPrivileges;
        private bool diffKeys;

        public List<Columnn> ColumnsMissingDb1
        {
            get { return columnsMissingDb1; }
            set { columnsMissingDb1 = value; }
        }
        
        public Tablee getTabA()
        {
            return tabA;
        }
        public Tablee getTabB()
        {
            return tabB;
        }

        public bool isDifferent()
        {
            return different;
        }

        public bool DiffCoulumns()
        {
            return diffCoulumns;
        }
        public bool DiffIndexes()
        {
            return diffIndexes;
        }
        public bool DiffConstraints()
        {
            return diffConstraints;
        }
        public bool DiffTriggers()
        {
            return diffTriggers;
        }
        public bool DiffPrivileges()
        {
            return diffPrivileges;
        }
        public bool DiffKeys()
        {
            return diffKeys;
        }

        public List<DbSyncColumnDiff> ColumnsDifList()
        {
            return columnsDifList;
        }
        public List<DbSyncConstraintDiff> ConstraiontDifList()
        {
            return constraintDifList;
        }
        public List<DbSyncTriggerDiff> TriggerDiffList()
        {
            return triggerDifList;
        }
        public List<DbSyncPrivilegeDiff> PrivilegeDifList()
        {
            return privilegeDifList;
        }
        public List<DbSyncIndexDiff> IndexesDifList()
        {
            return indexesDifList;
        }
        public List<DbSyncKeyDiff> KeysDifList()
        {
            return keysDifList;
        }

        public DbSyncTableDiff(Tablee tabAin, Tablee tabBin)
        {
            columnsDifList = new List<DbSyncColumnDiff>();
            constraintDifList = new List<DbSyncConstraintDiff>();
            triggerDifList = new List<DbSyncTriggerDiff>();
            privilegeDifList = new List<DbSyncPrivilegeDiff>();
            indexesDifList = new List<DbSyncIndexDiff>();
            keysDifList = new List<DbSyncKeyDiff>();

            columnsMissingDb1 = new List<Columnn>();
            columnsMissingDb2 = new List<Columnn>();
            columnsDifferent = new List<DbSyncColumnDiff>();
            keysMissingDb1 = new List<Key>();
            keysMissingDb2 = new List<Key>();
            keysDifferent = new List<DbSyncKeyDiff>();
            constraintsMissingDb1 = new List<Constraintt>();
            constraintsMissingDb2 = new List<Constraintt>();
            constraintsDifferent = new List<DbSyncConstraintDiff>();
            triggersMissingDb1 = new List<Trigger>();
            triggersMissingDb2 = new List<Trigger>();
            triggersDifferent = new List<DbSyncTriggerDiff>();
            grantsMissingDb1 = new List<Privilege>();
            grantsMissingDb2 = new List<Privilege>();
            grantsDifferent = new List<DbSyncPrivilegeDiff>();
            indexesMissingDb1 = new List<Index>();
            indexesMissingDb2 = new List<Index>();
            indexesDifferent = new List<DbSyncIndexDiff>();

           

            this.tabA = tabAin;
            this.tabB = tabBin;
            if (tabA != null) TableName = tabA.NazovTabulky;
            else if (tabB != null) TableName = tabB.NazovTabulky;
            else TableName = "UNDEFINED";

            if (tabA != null && tabB != null)
            {
                if (tabA.NazovTabulky == tabB.NazovTabulky)
                {

                    diffTableName = false;
                    if (!compareKeys(tabA.Keys, tabB.Keys)) diffKeys = true;
                    if (!compareCoulumns(tabA.Stlpce, tabB.Stlpce)) diffCoulumns = true;
                    if (!CompareIndexes(tabA.Indexy, tabB.Indexy)) diffIndexes = true;
                    if (!CompareConstraints(tabA.Constrainty, tabB.Constrainty)) diffConstraints = true;
                    if (!CompareTriggers(tabA.Trigre, tabB.Trigre)) diffTriggers = true;
                    if (!ComparePrivileges(tabA.Privileges, tabB.Privileges)) diffPrivileges = true;
                }
                else diffTableName = true;

                if (diffTableName || diffCoulumns || diffIndexes || diffConstraints || diffTriggers || diffPrivileges || diffKeys) different = true;
                else different = false;
            }
            else different = true;

            //to by sme mali vytvorenie samotnej tabulky, treba este vytvorit jej stlpce, procedury atd atd...

            //vytvorenie stlpcov
            if (tabA != null && tabB != null)
            {
                foreach (Columnn colA in tabA.Stlpce)
                {
                    bool found = false;
                    foreach (Columnn colB in tabB.Stlpce)
                    {
                        if (colA.COULUMN_NAME1 == colB.COULUMN_NAME1)
                        {
                            found = true;
                            this.columnsDifList.Add(new DbSyncColumnDiff(colA, colB));
                        }

                    }
                    if (!found) this.columnsDifList.Add(new DbSyncColumnDiff(colA, null));
                }
                foreach (Columnn colB in tabB.Stlpce)
                {
                    bool found = false;
                    foreach (DbSyncColumnDiff col in columnsDifList)
                    {
                        if (colB.COULUMN_NAME1 == col.getName())
                        {
                            found = true;
                        }
                    }
                    if (!found) this.columnsDifList.Add(new DbSyncColumnDiff(null, colB));
                }
                //stlpce hotove

                //vytvorim indexy
                foreach (Index indA in tabA.Indexy)
                {
                    bool found = false;
                    foreach (Index indB in tabB.Indexy)
                    {
                        if (indA.Name == indB.Name)
                        {
                            found = true;
                            this.indexesDifList.Add(new DbSyncIndexDiff(indA, indB));
                        }

                    }
                    if (!found) this.indexesDifList.Add(new DbSyncIndexDiff(indA, null));
                }
                foreach (Index indB in tabB.Indexy)
                {
                    bool found = false;
                    foreach (DbSyncIndexDiff ind in indexesDifList)
                    {
                        if (indB.Name == ind.getName())
                        {
                            found = true;
                        }
                    }
                    if (!found) this.indexesDifList.Add(new DbSyncIndexDiff(null, indB));
                }

                //vytvorim constrainty
                foreach (Constraintt conA in tabA.Constrainty)
                {
                    bool found = false;
                    foreach (Constraintt conB in tabB.Constrainty)
                    {
                        if (conA.Constraint_nam == conB.Constraint_nam)
                        {
                            found = true;
                            this.constraintDifList.Add(new DbSyncConstraintDiff(conA, conB));
                        }

                    }
                    if (!found) this.constraintDifList.Add(new DbSyncConstraintDiff(conA, null));
                }
                foreach (Constraintt conB in tabB.Constrainty)
                {
                    bool found = false;
                    foreach (DbSyncConstraintDiff con in constraintDifList)
                    {
                        if (conB.Constraint_nam == con.getName())
                        {
                            found = true;
                        }
                    }
                    if (!found) this.constraintDifList.Add(new DbSyncConstraintDiff(null, conB));
                }

                //vytvorim trigre
                foreach (Trigger trigA in tabA.Trigre)
                {
                    bool found = false;
                    foreach (Trigger trigB in tabB.Trigre)
                    {
                        if (trigA.Trigger_name == trigB.Trigger_name)
                        {
                            found = true;
                            this.triggerDifList.Add(new DbSyncTriggerDiff(trigA, trigB));
                        }

                    }
                    if (!found) this.triggerDifList.Add(new DbSyncTriggerDiff(trigA, null));
                }
                foreach (Trigger trigB in tabB.Trigre)
                {
                    bool found = false;
                    foreach (DbSyncTriggerDiff trig in triggerDifList)
                    {
                        if (trigB.Trigger_name == trig.getName())
                        {
                            found = true;
                        }
                    }
                    if (!found) this.triggerDifList.Add(new DbSyncTriggerDiff(null, trigB));
                }


                //vytvorim kluce
                foreach (Key keyA in tabA.Keys)
                {
                    bool found = false;
                    foreach (Key keyB in tabB.Keys)
                    {
                        if (keyA.NameOfKey == keyB.NameOfKey)
                        {
                            found = true;
                            this.keysDifList.Add(new DbSyncKeyDiff(keyA, keyB));
                        }

                    }
                    if (!found) this.keysDifList.Add(new DbSyncKeyDiff(keyA, null));
                }
                foreach (Key keyB in tabB.Keys)
                {
                    bool found = false;
                    foreach (DbSyncKeyDiff k in keysDifList)
                    {
                        if (keyB.NameOfKey == k.getName())
                        {
                            found = true;
                        }
                    }
                    if (!found) this.keysDifList.Add(new DbSyncKeyDiff(null, keyB));
                }

                //vytvorim privileges
                foreach (Privilege privA in tabA.Privileges)
                {
                    bool found = false;
                    foreach (Privilege privB in tabB.Privileges)
                    {
                        if (privA.DBSyncCompareTO(privB))
                        {
                            found = true;
                            this.privilegeDifList.Add(new DbSyncPrivilegeDiff(privA, privB));
                        }

                    }
                    if (!found) this.privilegeDifList.Add(new DbSyncPrivilegeDiff(privA, null));
                }
                foreach (Privilege privB in tabB.Privileges)
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
            }

            if (tabA == null )
            {
                foreach (Columnn colB in tabB.Stlpce)
                {
                    this.columnsDifList.Add(new DbSyncColumnDiff(null, colB));
                }
                
                foreach (Index indB in tabB.Indexy)
                {
                    this.indexesDifList.Add(new DbSyncIndexDiff(null, indB));
                    
                }
                
                foreach (Constraintt conB in tabB.Constrainty)
                {
                    this.constraintDifList.Add(new DbSyncConstraintDiff(null, conB));
                    
                }
                
                foreach (Trigger trigB in tabB.Trigre)
                {
                    this.triggerDifList.Add(new DbSyncTriggerDiff(null, trigB));
                    
                }
                           //vytvorim kluce
                foreach (Key keyB in tabB.Keys)
                {
                    this.keysDifList.Add(new DbSyncKeyDiff(null, keyB));
                    
                }
                
                //vytvorim privileges
                foreach (Privilege privB in tabB.Privileges)
                {
                    this.privilegeDifList.Add(new DbSyncPrivilegeDiff(null, privB));
                    
                }
                
            }

            if (tabB == null)
            {
                foreach (Columnn colA in tabA.Stlpce)
                {
                    this.columnsDifList.Add(new DbSyncColumnDiff(colA, null));
                }

                foreach (Index indA in tabA.Indexy)
                {
                    this.indexesDifList.Add(new DbSyncIndexDiff(indA, null));

                }

                foreach (Constraintt conA in tabA.Constrainty)
                {
                    this.constraintDifList.Add(new DbSyncConstraintDiff(conA, null));

                }

                foreach (Trigger trigA in tabA.Trigre)
                {
                    this.triggerDifList.Add(new DbSyncTriggerDiff(trigA, null));

                }
                //vytvorim kluce
                foreach (Key keyA in tabA.Keys)
                {
                    this.keysDifList.Add(new DbSyncKeyDiff(keyA, null));

                }

                //vytvorim privileges
                foreach (Privilege privA in tabA.Privileges)
                {
                    this.privilegeDifList.Add(new DbSyncPrivilegeDiff(privA, null));

                }

            }
            fulfillLists();

        }

        private void fulfillLists()
        {
            if (this.diffCoulumns)
            {
                foreach (DbSyncColumnDiff col in columnsDifList)
                {
                    if (col.isDifferent())
                    {
                        if ((col.getColumnA() != null) && (col.getColumnB() != null))
                        {
                            columnsDifferent.Add(col);
                        }
                        else if (col.getColumnA() == null)
                        {
                            columnsMissingDb1.Add(col.getColumnB());
                        }
                        else
                        {
                            columnsMissingDb2.Add(col.getColumnA());
                        }

                    }
                }
            }
            if (this.diffKeys)
            {
                foreach (DbSyncKeyDiff key in this.keysDifList)
                {
                    if (key.Different)
                    {
                        if ((key.getKeyA() != null) && (key.getKeyB() != null))
                        {
                            keysDifferent.Add(key);
                        }
                        else if (key.getKeyA() == null)
                        {
                            keysMissingDb1.Add(key.getKeyB());
                        }
                        else
                        {
                            keysMissingDb2.Add(key.getKeyA());
                        }
                    }
                }
            }
            if (this.diffConstraints)
            {
                foreach (DbSyncConstraintDiff con in this.constraintDifList)
                {
                    if (con.isDifferent())
                    {
                        if ((con.getConstA() != null) && (con.getConstB() != null))
                        {
                            constraintsDifferent.Add(con);
                        }
                        else if (con.getConstA() == null)
                        {
                            constraintsMissingDb1.Add(con.getConstB());
                        }
                        else
                        {
                            constraintsMissingDb2.Add(con.getConstA());
                        }
                    }
                }
            }
            if (this.diffTriggers)
            {
                foreach (DbSyncTriggerDiff trg in this.triggerDifList)
                {
                    if (trg.isDiffirent())
                    {
                        if ((trg.getTrigA() != null) && (trg.getTrigB() != null))
                        {
                            triggersDifferent.Add(trg);
                        }
                        else if (trg.getTrigA() == null)
                        {
                            triggersMissingDb1.Add(trg.getTrigB());
                        }
                        else
                        {
                            triggersMissingDb2.Add(trg.getTrigA());
                        }
                    }
                }
            }
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
            if (this.diffIndexes)
            {
                foreach (DbSyncIndexDiff ind in this.indexesDifList)
                {
                    if (ind.isDifferent())
                    {
                        if ((ind.getIndexA() != null) && (ind.getIndexB() != null))
                        {
                            indexesDifferent.Add(ind);
                        }
                        else if (ind.getIndexA() == null)
                        {
                            indexesMissingDb1.Add(ind.getIndexB());
                        }
                        else
                        {
                            indexesMissingDb2.Add(ind.getIndexA());
                        }
                    }
                }
            }
            
        }

        private bool compareKeys(List<Key> keysA, List<Key> keysB)
        {
            bool ress = true;

            foreach (Key s in keysA)
            {
                bool nasiel = false;
                foreach (Key k in keysB)
                {
                    if (s.DBSyncCompareTO(k)) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            foreach (Key s in keysB)
            {
                bool nasiel = false;
                foreach (Key k in keysA)
                {
                    if (s.DBSyncCompareTO(k)) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            return ress;
        }
        private bool compareCoulumns(List<Columnn> columnsA, List<Columnn> columnsB)
        {
            bool ress = true;

            foreach (Columnn s in columnsA)
            {
                bool nasiel = false;
                foreach (Columnn k in columnsB)
                {
                    if (s.DBSyncCompareTO(k)) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            foreach (Columnn s in columnsB)
            {
                bool nasiel = false;
                foreach (Columnn k in columnsA)
                {
                    if (s.DBSyncCompareTO(k)) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }

            return ress;
        }
        private bool CompareIndexes(List<Index> indA, List<Index> indB)
        {
            bool ress = true;

            foreach (Index iA in indA)
            {
                bool nasiel = false;
                foreach (Index iB in indB)
                {
                    if (iA.DBSyncCompareTO(iB)) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            foreach (Index iA in indB)
            {
                bool nasiel = false;
                foreach (Index iB in indA)
                {
                    if (iA.DBSyncCompareTO(iB)) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            return ress;
        }
        private bool CompareConstraints(List<Constraintt> conA, List<Constraintt> conB)
        {
            bool ress = true;

            foreach (Constraintt cA in conA)
            {
                if (cA.Constraint_typ != "DEFAULT")
                {
                    bool nasiel = false;
                    foreach (Constraintt cB in conB)
                    {
                        if (cA.DBSyncCompareTO(cB)) nasiel = true;
                    }
                    if (nasiel == false) ress = false;
                }
                else ress = true;
            }
            foreach (Constraintt cA in conB)
            {
                if (cA.Constraint_typ != "DEFAULT")
                {
                    bool nasiel = false;
                    foreach (Constraintt cB in conA)
                    {
                        if (cA.DBSyncCompareTO(cB)) nasiel = true;
                    }
                    if (nasiel == false) ress = false;
                }
                else ress = true;
            }
            return ress;
        }
        private bool CompareTriggers(List<Trigger> trigA, List<Trigger> trigB)
        {
            bool ress = true;

            foreach (Trigger tA in trigA)
            {
                bool nasiel = false;
                foreach (Trigger tB in trigB)
                {
                    if (tA.DBSyncCompareTO(tB)) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            foreach (Trigger tA in trigB)
            {
                bool nasiel = false;
                foreach (Trigger tB in trigA)
                {
                    if (tA.DBSyncCompareTO(tB)) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            return ress;
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
            foreach (Privilege pA in privB)
            {
                bool nasiel = false;
                foreach (Privilege pB in privA)
                {
                    if (pA.DBSyncCompareTO(pB)) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            return ress;
        }

        public string getTableName()
        {
            return this.TableName;
        }

        public override string ToString()
        {
            return this.TableName ;
        }
    }
}
