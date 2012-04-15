using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    class DbsyncTvConstraintType : DBsyncTreeview
    {
        private Constraintt constr;

        public DbsyncTvConstraintType(Constraintt cs)
        {
            this.constr = cs;
            this.Text = cs.Constraint_nam;
            this.typIkony = ConstraintIcon;
            this.Name = this.Text;
            
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
