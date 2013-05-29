using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    class DbsyncTvColumnType : DBsyncTreeview
    {
        private Columnn s;

        public Columnn S
        {
            get { return s; }
            set { s = value; }
        }

        public DbsyncTvColumnType(Columnn stl)
        {
            this.s = stl;
            this.Text = s.COULUMN_NAME1;
            this.typeOfIcon = ColumnIcon;
            this.Name = this.Text;
        }


        
        public override string ToString()
        {
            return s.ToString();
        }
    }
}
