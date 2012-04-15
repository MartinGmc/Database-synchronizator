using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    //interface na porovnavanie objektov
    interface IDbsyncCompare<Objj>
    {
        bool DBSyncCompareTO(Objj obj);

        string getName();

        
    }
}
