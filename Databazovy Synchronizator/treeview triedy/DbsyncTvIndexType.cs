using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    class DbsyncTvIndexType : DBsyncTreeview
    {
        private Index ind;

        public DbsyncTvIndexType(Index ii)
        {
            this.ind = ii;
            this.Text = ii.Name;
            this.typIkony = IndexIcon;
            this.Name = this.Text;
        }


        public override string ToString()
        {
            return this.Text;
        }
    }
}
