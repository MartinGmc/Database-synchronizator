using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    class DBsyncTvTableType : DBsyncTreeview
    {
        private Tablee tab;

        public DBsyncTvTableType(Tablee tab)
        {
            this.tab = tab;
            this.Text = tab.NazovTabulky;
            this.typeOfIcon = TableIcon;
            this.Name = this.Text;
        }

        public Tablee dajTabulku()
        {
            return this.tab;
        }

        public override string ToString()
        {
            return tab.ToString();
        }
    }
}
