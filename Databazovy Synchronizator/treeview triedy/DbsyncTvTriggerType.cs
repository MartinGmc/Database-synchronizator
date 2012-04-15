using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    class DbsyncTvTriggerType : DBsyncTreeview
    {
        private Trigger trig;

        public DbsyncTvTriggerType(Trigger trg)
        {
            this.trig = trg;
            this.Text = trg.Trigger_name;
            this.typIkony = TriggerIcon;
            this.Name = this.Text;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
