using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    class DbsyncTvTypeType : DBsyncTreeview
    {
        Typ t;

        public DbsyncTvTypeType(Typ tt)
        {
            this.t = tt;
            this.Text = t.Nazov;
            this.typeOfIcon = TypeIcon;
            this.Name = this.Text;
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
