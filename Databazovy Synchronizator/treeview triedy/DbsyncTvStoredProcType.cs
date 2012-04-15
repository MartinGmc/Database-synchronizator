using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    class DbsyncTvStoredProcType : DBsyncTreeview
    {
        private SProcedure sp;

        public DbsyncTvStoredProcType(SProcedure spp)
        {
            
            this.sp = spp;
            this.Text = spp.NazovProcedury;
            this.typIkony = StoredProcedureIcon;
            this.Name = this.Text;

        }
        
        public override string ToString()
        {
            return "";
        }
    }
}
