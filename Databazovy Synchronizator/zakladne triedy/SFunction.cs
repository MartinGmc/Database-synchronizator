using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
   public class SFunction :IDbsyncCompare<SFunction>
    {
        private string nazovFunkcie;
        private string returnType;
        private List<Privilege> privileges;
        private List<string> sqlText;

        public SFunction()
        {
            privileges = new List<Privilege>();
        }
       
       public string ReturnType
        {
            get { return returnType; }
            set { returnType = value; }
        }
       public string NazovFunkcie
        {
            get { return nazovFunkcie; }
            set { nazovFunkcie = value; }
        }
       public List<string> SqlText
        {
            get { return sqlText; }
            set { sqlText = value; }
        }
       internal List<Privilege> Privileges
        {
            get { return privileges; }
            set { privileges = value; }
        }

        private bool porovnajPrivileges(List<Privilege> privA, List<Privilege> privB)
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

        public bool DBSyncCompareTO(SFunction sf)
        {
            ComparatorOfSQL s = new ComparatorOfSQL(this.sqlText, sf.sqlText); 
            bool ress = true;
            if (this.NazovFunkcie != sf.NazovFunkcie) ress = false;
            if (this.ReturnType != sf.ReturnType) ress = false;
            if (s.IsDifferent) ress = false;
            if (!porovnajPrivileges(this.Privileges, sf.Privileges)) ress = false;
            return ress;
        }

       

       public string getName()
       {
           return this.nazovFunkcie;
       }
    }
}
