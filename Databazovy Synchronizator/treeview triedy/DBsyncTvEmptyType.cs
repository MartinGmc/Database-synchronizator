using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    class DBsyncTvEmptyType : DBsyncTreeview
    {
        public DBsyncTvEmptyType(string text, int IconType)
        {
            this.typIkony = IconType;
            this.Text = text;
            this.Name = this.Text;
        }

        
        public override string ToString()
        {
            return "";
        }
    }
}
