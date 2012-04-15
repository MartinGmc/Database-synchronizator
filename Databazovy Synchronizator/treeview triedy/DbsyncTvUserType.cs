using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    class DbsyncTvUserType : DBsyncTreeview
    {
        private User u;

        public DbsyncTvUserType(User usr)
        {
            this.u = usr;
            this.Text = u.UserName;
            this.typIkony = UserIcon;
            this.Name = this.Text;
        }
        
        public override string ToString()
        {
            return this.Text;
        }
    }
}
