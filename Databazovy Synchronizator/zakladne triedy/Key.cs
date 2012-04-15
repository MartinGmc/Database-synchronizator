using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
   public class Key : IDbsyncCompare<Key>
    {
        bool primaryKey;
        string nameOfKey;
        List<string> nameOfColumns;
        string nameofFTable;
        string nameOfFcolumn;

        public string NameOfFcolumn
        {
            get { return nameOfFcolumn; }
           
        }
        public bool PrimaryKey
        {
            get { return primaryKey; }

        }
        public string NameOfKey
        {
            get { return nameOfKey; }

        }
        public List<string> NameOfColumns
        {
            get { return nameOfColumns; }

        }
        public string NameofFTable
        {
            get { return nameofFTable; }

        }

        public Key(string NameOfKeyp, List<string> nameOfColumnp)
        {
            this.primaryKey = true;
            this.nameOfKey = NameOfKeyp;
            this.nameOfColumns = nameOfColumnp;
        }

        public Key(string NameOfKeyp, List<string> nameOfColumnp, string nameOfFtablein, string nameofFcolumnin)
        {
            this.primaryKey = false;
            this.nameOfKey = NameOfKeyp;
            this.nameOfColumns = nameOfColumnp;
            this.nameOfFcolumn = nameofFcolumnin;
            this.nameofFTable = nameOfFtablein;
        }

        public bool DBSyncCompareTO(Key k)
        {
             bool ress = true;
            //porovnam nazvy stlpcov
             foreach (string  nam1 in this.nameOfColumns)
             {
                 bool found = false;
                 foreach (string nam2 in k.nameOfColumns)
                 {
                     if (nam1 == nam2) found = true;
                 }
                 if (!found) ress = false;
            }
             foreach (string nam1 in this.nameOfColumns)
             {
                 bool found = false;
                 foreach (string nam2 in k.nameOfColumns)
                 {
                     if (nam1 == nam2) found = true;
                 }
                 if (!found) ress = false;
             }

            //if (this.NameOfColumn != k.NameOfColumn) ress = false;
            if (this.NameOfFcolumn != k.NameOfFcolumn) ress = false;
            if (this.NameofFTable != k.NameofFTable) ress = false;
            if (this.NameOfKey != k.NameOfKey) ress = false;
            if (this.PrimaryKey != k.PrimaryKey) ress = false;
            return ress;
        }

      
       

        public string getName()
        {
            return this.NameOfKey;
        }
    }
}
