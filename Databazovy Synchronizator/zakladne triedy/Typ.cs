using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
   public class Typ : IDbsyncCompare<Typ>
    {
        private string nazov;
        private string datatyp;
        private string precision;

       
        private string scale;

       
        private bool canBeNull;

        
        //private string char_octet_length;

        public string Nazov
        {
            get { return nazov; }
            set { nazov = value; }
        }
        
        public string Datatyp
        {
            get { return datatyp; }
            set { datatyp = value; }
        }

        public string Precision
        {
            get { return precision; }
            set { precision = value; }
        }
        public string Scale
        {
            get { return scale; }
            set { scale = value; }
        }
        public bool CanBeNull
        {
            get { return canBeNull; }
            set { canBeNull = value; }
        }

        public bool DBSyncCompareTO(Typ tt)
        {
            bool ress = true;

            if (this.Datatyp != tt.Datatyp) ress = false;
            if (this.precision != tt.precision) ress = false;
            if (this.scale != tt.scale) ress = false;
            if (this.canBeNull != tt.canBeNull) ress = false;
            if (this.Nazov != tt.Nazov) ress = false;
            return ress;
        }

        public string getName()
        {
            return this.nazov;
        }
    }
}
