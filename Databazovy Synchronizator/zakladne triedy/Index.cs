using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
   public class Index :IDbsyncCompare<Index>
    {
        private bool unique;
        private string type;
        private string name;
        private List<string> columns;
        private bool isPrmaryKey;

        public bool IsPrmaryKey
        {
            get { return isPrmaryKey; }
            set { isPrmaryKey = value; }
        }

        public List<string> Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        public bool Unique
        {
            get { return unique; }
            set { unique = value; }
        }
       

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Index(string namein, string typein, bool uniquein, bool isPrimary)
        {
            this.name = namein;
            this.type = typein;
            this.unique = uniquein;
            this.columns = new List<string>();
            this.isPrmaryKey = isPrimary;
        }

        public bool DBSyncCompareTO(Index indB)
        {
            bool ress = true;
            if (this.Name != indB.Name) ress = false;
            if (this.Type != indB.Type) ress = false;
            if (this.Unique != indB.Unique) ress = false;

            return ress;
        }

        

        public string getName()
        {
            return this.name;
        }
    }
}
