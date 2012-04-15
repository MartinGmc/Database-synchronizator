using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    public class DbSyncIndexDiff
    {
        private Index indexA;
        private Index indexB;

        private string nameOfIndex;
        
        private bool different = false;
        private bool diffindexName = false;
        private bool diffindexType = false;
        private bool diffIndexUnique = false;
        private bool diffColumns = false;

        private List<ObjectAtribute> indexAtributesListA;
        private List<ObjectAtribute> indexAtributesListB;

        internal List<ObjectAtribute> IndexAtributesListA
        {
            get { return indexAtributesListA; }
        }
        internal List<ObjectAtribute> IndexAtributesListB
        {
            get { return indexAtributesListB; }
        }

        public Index getIndexA()
        {
            return indexA;
        }
        public Index getIndexB()
        {
            return indexB;
        }

        public bool isDifferent()
        {
            return different;
        }
        
        public DbSyncIndexDiff(Index indexAin, Index indexBin)
        {
            this.indexA = indexAin;
            this.indexB = indexBin;

            indexAtributesListA = new List<ObjectAtribute>();
            indexAtributesListB = new List<ObjectAtribute>();

            if (indexA == null || indexB == null)
            {
                if (indexA != null)
                {
                    nameOfIndex = indexA.Name;
                    indexAtributesListA.Add(new ObjectAtribute("Index name", indexA.Name, true));
                    indexAtributesListA.Add(new ObjectAtribute("Index type", indexA.Type, true));
                    indexAtributesListA.Add(new ObjectAtribute("Is unique", indexA.Unique.ToString(), true));
                    foreach (string s in indexA.Columns)
                    {
                        indexAtributesListA.Add(new ObjectAtribute("Column ", s, true));
                    }
                }
                else if (indexB != null)
                {
                    nameOfIndex = indexB.Name;
                    indexAtributesListB.Add(new ObjectAtribute("Index name", indexB.Name, true));
                    indexAtributesListB.Add(new ObjectAtribute("Index type", indexB.Type, true));
                    indexAtributesListB.Add(new ObjectAtribute("Is unique", indexB.Unique.ToString(), true));
                    foreach (string s in indexB.Columns)
                    {
                        indexAtributesListB.Add(new ObjectAtribute("Column ", s, true));
                    }
                }
                else nameOfIndex = "UNDEFINED";

            }
            if (indexA != null && indexB != null)
            {
                nameOfIndex = indexA.Name;
                if (indexA.Name != indexB.Name) diffindexName = true;
                if (indexA.Type != indexB.Type) diffindexType = true;
                if (indexA.Unique != indexB.Unique) diffIndexUnique = true;
                if (!CompareColumns(indexA.Columns, indexB.Columns)) diffColumns = true; 
                if (diffindexName || diffindexType || diffIndexUnique) different = true;
                else different = false;

                ObjectAtribute Iname = new ObjectAtribute("Index name", indexA.Name, false);
                indexAtributesListA.Add(Iname);
                indexAtributesListB.Add(Iname);


                if (diffindexType)
                {
                    ObjectAtribute ItypeA = new ObjectAtribute("Index type ", indexA.Type, true);
                    indexAtributesListA.Add(ItypeA);
                    ObjectAtribute ItypeB = new ObjectAtribute("Index type ", indexB.Type, true);
                    indexAtributesListB.Add(ItypeB);
                }
                else
                {
                    ObjectAtribute Itype = new ObjectAtribute("Index type ", indexA.Type, false);
                    indexAtributesListA.Add(Itype);
                    indexAtributesListB.Add(Itype);
                }

                if (diffIndexUnique)
                {
                    ObjectAtribute IuniqueA = new ObjectAtribute("Is unique ", indexA.Unique.ToString(), true);
                    indexAtributesListA.Add(IuniqueA);
                    ObjectAtribute IuniqueB = new ObjectAtribute("Is unique ", indexB.Unique.ToString(), true);
                    indexAtributesListB.Add(IuniqueB);
                }
                else
                {
                    ObjectAtribute Iunique = new ObjectAtribute("Is unique ", indexA.Unique.ToString(), false);
                    indexAtributesListA.Add(Iunique);
                    indexAtributesListB.Add(Iunique);
                }
                if (diffColumns)
                {
                    foreach (string s in indexA.Columns)
                    {
                        indexAtributesListA.Add(new ObjectAtribute("Column ", s, true));
                    }
                    foreach (string s in indexB.Columns)
                    {
                        indexAtributesListB.Add(new ObjectAtribute("Column ", s, true));
                    }


                }
                else
                {
                    foreach (string s in indexA.Columns)
                    {
                        indexAtributesListB.Add(new ObjectAtribute("Column ", s, false));
                        indexAtributesListA.Add(new ObjectAtribute("Column ", s, false));
                    }
                }


            }
            else different = true;
        }

        public string getName()
        {
            return this.nameOfIndex;
        }

        public override string ToString()
        {
            return this.nameOfIndex + " " + this.different.ToString();
        }

        private bool CompareColumns(List<string> roleA, List<string> roleB)
        {
            bool ress = true;

            foreach (string sA in roleA)
            {
                bool nasiel = false;
                foreach (string sB in roleB)
                {
                    if (sA == sB) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            return ress;
        } 

    }
}
