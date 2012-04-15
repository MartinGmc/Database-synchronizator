using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    class DbsyncTvFunctionType : DBsyncTreeview
    {
        private SFunction sf;

        public DbsyncTvFunctionType(SFunction sff)
        {
            this.sf = sff;
            this.Text = sf.NazovFunkcie;
            this.typIkony = FunctionIcon;
            this.Name = this.Text;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
