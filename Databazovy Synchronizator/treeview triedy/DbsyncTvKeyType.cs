using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    class DbsyncTvKeyType : DBsyncTreeview
    {
        private Columnn s;
        private Key k;

        public DbsyncTvKeyType(Columnn stl)
        {
            this.s = stl;
            if (s.Is_primaryKey())
            {
                this.Text = stl.Name_of_PK;
                this.typIkony = PrimaryKeyIcon;
            }
            if (s.Is_foreinKey())
            {
                this.Text = stl.Name_of_FK;
                this.typIkony = ForeinKeyIcon;
            }

        }

        public DbsyncTvKeyType(Key kIn)
        {
            this.k = kIn;

            if (k.PrimaryKey)
            {
                this.Text = k.NameOfKey;
                this.typIkony = PrimaryKeyIcon;
                this.Name = this.Text;
            }
            else
            {
                this.Text = k.NameOfKey;
                this.typIkony = ForeinKeyIcon;
                this.Name = this.Text;
            }
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
