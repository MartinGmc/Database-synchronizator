using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    class DbsyncTvPrivilegeType : DBsyncTreeview
    {
        private Privilege priv;

        public DbsyncTvPrivilegeType(Privilege pr)
        {
            this.priv = pr;
            this.Text = pr.Grantee;
            this.typIkony = GrantIcon;
            this.Name = this.Text;
        }
        
        public override string ToString()
        {
            return this.Text;
        }
    }
}
