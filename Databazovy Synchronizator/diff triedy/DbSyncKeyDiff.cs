using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
   public class DbSyncKeyDiff
    {
        private Key keyA;
        private Key keyB;

        private List<ObjectAtribute> keyAtributesListA;
        private List<ObjectAtribute> keyAtributesListB;

        internal List<ObjectAtribute> KeyAtributesListA
        {
            get { return keyAtributesListA; }
         
        }
        internal List<ObjectAtribute> KeyAtributesListB
        {
            get { return keyAtributesListB; }
           
        }

        private bool diffNameOfColumn = false;
        private bool diffNameOfFkCol = false;
        private bool diffNAmeOfFtable = false;
        private bool diffPrimaryKey = false;

        private bool different = false;

        public bool Different
        {
            get { return different; }
           
        }
       

        private bool isPrimary;
        private string nameOfKey;

        public DbSyncKeyDiff(Key keyAin, Key keyBin)
        {
            this.keyA = keyAin;
            this.keyB = keyBin;

            keyAtributesListA = new List<ObjectAtribute>();
            keyAtributesListB = new List<ObjectAtribute>();

            if (keyA != null && keyB != null)
            {
                if (!CompareColumns(keyA.NameOfColumns, keyB.NameOfColumns)) diffNameOfColumn = true;
                if (keyA.NameOfFcolumn != keyB.NameOfFcolumn) diffNameOfFkCol = true;
                if (keyA.NameofFTable != keyB.NameofFTable) diffNAmeOfFtable = true;
                if (keyA.PrimaryKey != keyB.PrimaryKey) diffPrimaryKey = true;

                if (diffNameOfColumn || diffNameOfFkCol || diffNAmeOfFtable || diffPrimaryKey) different = true;

                nameOfKey = keyA.NameOfKey;
                isPrimary = keyA.PrimaryKey;
                ObjectAtribute name = new ObjectAtribute("Name of key ",nameOfKey, false);
                keyAtributesListA.Add(name);
                keyAtributesListB.Add(name);

                keyAtributesListA.Add(new ObjectAtribute("Is primary key", keyA.PrimaryKey.ToString(), false));
                keyAtributesListB.Add(new ObjectAtribute("Is primary key", keyB.PrimaryKey.ToString(), false));

                if (diffNameOfColumn)
                {
                    foreach (string nam in keyA.NameOfColumns)
                    {
                        keyAtributesListA.Add(new ObjectAtribute("Name of column", nam, true));
                    }
                    foreach (string nam in keyB.NameOfColumns)
                    {
                        keyAtributesListB.Add(new ObjectAtribute("Name of column", nam, true));
                    }
                }
                else
                {
                    foreach (string nam in keyA.NameOfColumns)
                    {
                        keyAtributesListA.Add(new ObjectAtribute("Name of column", nam, false));
                        keyAtributesListB.Add(new ObjectAtribute("Name of column", nam, false));
                    }
                }

                if (!isPrimary)
                {
                    if (diffNAmeOfFtable)
                    {
                        keyAtributesListA.Add(new ObjectAtribute("Name of Forein table", keyA.NameofFTable, true));
                        keyAtributesListB.Add(new ObjectAtribute("Name of Forein table", keyB.NameofFTable, true));
                    }
                    else
                    {
                        keyAtributesListA.Add(new ObjectAtribute("Name of Forein table", keyA.NameofFTable, false));
                        keyAtributesListB.Add(new ObjectAtribute("Name of Forein table", keyA.NameofFTable, false));
                    }

                    if (diffNameOfFkCol)
                    {
                        keyAtributesListA.Add(new ObjectAtribute("Name of Forein column", keyA.NameOfFcolumn, true));
                        keyAtributesListB.Add(new ObjectAtribute("Name of Forein column", keyB.NameOfFcolumn, true));
                    }
                    else
                    {
                        keyAtributesListA.Add(new ObjectAtribute("Name of Forein column", keyA.NameOfFcolumn, false));
                        keyAtributesListB.Add(new ObjectAtribute("Name of Forein column", keyA.NameOfFcolumn, false));
                    }
                }

            }
            else
            {
                if (keyA != null)
                {
                    different = true;
                    nameOfKey = keyA.NameOfKey;
                    isPrimary = keyA.PrimaryKey;
                    ObjectAtribute name = new ObjectAtribute("Name of key ", nameOfKey, false);
                    keyAtributesListA.Add(name);
                    keyAtributesListA.Add(new ObjectAtribute("Is primary key", keyA.PrimaryKey.ToString(), true));
                    foreach (string nam in keyA.NameOfColumns)
                    {
                        keyAtributesListA.Add(new ObjectAtribute("Name of column", nam, true));
                    }
                          if (!isPrimary)
                    {
                        keyAtributesListA.Add(new ObjectAtribute("Name of Forein table", keyA.NameofFTable, true));
                        keyAtributesListA.Add(new ObjectAtribute("Name of Forein column", keyA.NameOfFcolumn, true));
                    }
                }
                if (keyB != null)
                {
                    different = true;
                    nameOfKey = keyB.NameOfKey;
                    isPrimary = keyB.PrimaryKey;
                    ObjectAtribute name = new ObjectAtribute("Name of key ", nameOfKey, false);
                    keyAtributesListB.Add(name);
                    keyAtributesListB.Add(new ObjectAtribute("Is primary key", keyB.PrimaryKey.ToString(), true));
                    foreach (string nam in keyB.NameOfColumns)
                    {
                        keyAtributesListB.Add(new ObjectAtribute("Name of column", nam, true));
                    }
                          if (!isPrimary)
                    {
                        keyAtributesListB.Add(new ObjectAtribute("Name of Forein table", keyB.NameofFTable, true));
                        keyAtributesListB.Add(new ObjectAtribute("Name of Forein column", keyB.NameOfFcolumn, true));
                    }
                }
            }

        }

        public Key getKeyA()
        {
            return keyA;
        }

        public Key getKeyB()
        {
            return keyB;
        }
        
        public string getName()
        {
            return this.nameOfKey;
        }

        private bool CompareColumns(List<string> colA, List<string> colB)
        {
            bool ress = true;

            foreach (string sA in colA)
            {
                bool nasiel = false;
                foreach (string sB in colB)
                {
                    if (sA == sB) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            
            foreach (string sA in colB)
            {
                bool nasiel = false;
                foreach (string sB in colA)
                {
                    if (sA == sB) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }

            return ress;
        } 

    }
}
