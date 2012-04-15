using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    public class SProcedure :IDbsyncCompare<SProcedure>
    {
        private string nazovProcedury;
        private List<Privilege> privieges;
        private List<string> sqlText;


        public SProcedure()
        {
            privieges = new List<Privilege>();
        }

        public string NazovProcedury
        {
            get { return nazovProcedury; }
            set { nazovProcedury = value; }
        }
        
        internal List<Privilege> Privieges
        {
            get { return privieges; }
            set { privieges = value; }
        }
        
        public List<string> SqlText
        {
            get { return sqlText; }
            set { sqlText = value; }
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

        public bool DBSyncCompareTO(SProcedure spp)
        {
            ComparatorOfSQL s = new ComparatorOfSQL(this.sqlText, spp.sqlText);
            bool ress = true;
            if (this.NazovProcedury != spp.NazovProcedury) ress = false;
            if (s.IsDifferent) ress = false;
            if (!porovnajPrivileges(privieges,spp.Privieges)) ress = false;
            return ress;
        }

        

        public string getName()
        {
            return this.nazovProcedury;
        }
    }
}
