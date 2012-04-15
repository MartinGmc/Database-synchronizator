using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Databazovy_Synchronizator
{
   public class Tablee : IDbsyncCompare<Tablee>
    {
        private string nazovTabulky;
        private List<Columnn> stlpce;
        private bool odlisneStlpce = false;
        private List<Index> indexy;
        private bool odlisneIndexy = false;
        private List<Constraintt> constrainty;
        private bool odlisneConstrainty = false;
        private List<Trigger> trigre;
        private bool odlisneTrigre = false;
        private List<Privilege> privileges;
        private bool odlisnePrivileges = false;
        private List<Key> keys;

        internal List<Key> Keys
        {
            get { return keys; }
            set { keys = value; }
        }
        
       


        //metody
        public bool OdlisnePrivileges
        {
            get { return odlisnePrivileges; }
            set { odlisnePrivileges = value; }
        }
        public bool OdlisneTrigre
        {
            get { return odlisneTrigre; }
            set { odlisneTrigre = value; }
        }
        public bool OdlisneConstrainty
        {
            get { return odlisneConstrainty; }
            set { odlisneConstrainty = value; }
        }
        public bool OdlisneIndexy
        {
            get { return odlisneIndexy; }
            set { odlisneIndexy = value; }
        } 
        public bool OdlisneStlpce
        {
            get { return odlisneStlpce; }
            set { odlisneStlpce = value; }
        }
       
        internal List<Privilege> Privileges
        {
            get { return privileges; }
            set { privileges = value; }
        }

        internal List<Trigger> Trigre
        {
            get { return trigre; }
            set { trigre = value; }
        }

        internal List<Constraintt> Constrainty
        {
            get { return constrainty; }
            set { constrainty = value; }
        }

        internal List<Index> Indexy
        {
            get { return indexy; }
            set { indexy = value; }
        }

        public Tablee()
        {
            stlpce = new List<Columnn>();
            indexy = new List<Index>();
            constrainty = new List<Constraintt>();
            trigre = new List<Trigger>();
            privileges = new List<Privilege>();
            keys = new List<Key>();
        }

        internal List<Columnn> Stlpce
        {
            get { return stlpce; }
            set { stlpce = value; }
        }

        public string NazovTabulky
        {
            get { return nazovTabulky; }
            set { nazovTabulky = value; }
        }

        public override string ToString()
        {
            string res = "";
            res += "Odlisne Stlpce :" + odlisneStlpce.ToString() + Environment.NewLine;
            res += "Odlisne Indexy :" + odlisneIndexy.ToString() + Environment.NewLine;
            res += "Odlisne privileges :" + odlisnePrivileges.ToString() + Environment.NewLine;
            res += "Odlisne trigre :" + odlisneTrigre.ToString() + Environment.NewLine;

            res += "tabulka :" + NazovTabulky + Environment.NewLine;
            res += "stlpce :" + Environment.NewLine;
            foreach (Columnn s in stlpce)
            {
                res += " " + s.COULUMN_NAME1 + Environment.NewLine;
            }
            res += "indexy :" + Environment.NewLine;
            foreach (Index i in indexy)
            {
                res += "    " + i.Name + Environment.NewLine;
            }
            res += "constrainty :" + Environment.NewLine;
            foreach (Constraintt c in constrainty)
            {
                res += "    " + c.Constraint_nam + Environment.NewLine;
            }
            res += "trigre :" + Environment.NewLine;
            foreach (Trigger t in trigre)
            {
                res += "    " + t.Trigger_name + Environment.NewLine;
            }
            return res;
        }


        private bool porovnajStlpce(List<Columnn> stlpceA, List<Columnn> stlpceB)
        {
            bool ress = true;

            foreach (Columnn s in stlpceA)
            {
                bool nasiel = false;
                foreach (Columnn k in stlpceB)
                {
                    if (s.DBSyncCompareTO(k)) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            return ress;
        }

        private bool porovnajIndexy(List<Index> indA, List<Index> indB)
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
            return ress;
        }

        private bool porovnajConstrainty(List<Constraintt> conA, List<Constraintt> conB)
        {
            bool ress = true;

            foreach (Constraintt cA in conA)
            {
                bool nasiel = false;
                foreach (Constraintt cB in conB)
                {
                    if (cA.DBSyncCompareTO(cB)) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            return ress;
        }

        private bool porovnajTRiggre(List<Trigger> trigA, List<Trigger> trigB)
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
            return ress;
        }

        private bool porovnajKeys(List<Key> keyA, List<Key> keyB)
        {
            bool ress = true;

            foreach (Key tA in keyA)
            {
                bool nasiel = false;
                foreach (Key tB in keyB)
                {
                    if (tA.DBSyncCompareTO(tB)) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            return ress;
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

        public bool DBSyncCompareTO(Tablee tab)
        {
            bool ress = true;
            if (this.NazovTabulky == tab.NazovTabulky)
            {
                if (!porovnajStlpce(stlpce, tab.stlpce)) ress = false;
                if (!porovnajIndexy(indexy, tab.indexy)) ress = false;
                if (!porovnajConstrainty(constrainty, tab.constrainty)) ress = false;
                if (!porovnajTRiggre(trigre, tab.trigre)) ress = false;
                if (!porovnajPrivileges(privileges, tab.privileges)) ress = false;
                if (!porovnajKeys(keys, tab.keys)) ress = false;
            }
            else ress = false;
            return ress;

        }


        public string getName()
        {
            return this.NazovTabulky;
        }
    }
}
