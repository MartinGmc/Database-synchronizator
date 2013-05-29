using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
   public class ComparatorSettings
    {
        private bool isDbAPriority;

        private int comparisonMethod;

        private bool syncUsers = false;
        private bool syncTables = false;
        private bool syncProcedures = false;
        private bool syncFunctions = false;
        private bool syncTypes = false;

        public bool IsDbAPriority
        {
            get { return isDbAPriority; }
            set { isDbAPriority = value; }
        }
        public int ComparisonMethod
        {
            get { return comparisonMethod; }
            set { comparisonMethod = value; }
        }
        public bool SyncTables
        {
            get { return syncTables; }
            set { syncTables = value; }
        }
        public bool SyncProcedures
        {
            get { return syncProcedures; }
            set { syncProcedures = value; }
        }
        public bool SyncFunctions
        {
            get { return syncFunctions; }
            set { syncFunctions = value; }
        }
        public bool SyncTypes
        {
            get { return syncTypes; }
            set { syncTypes = value; }
        }
        public bool SyncUsers
        {
            get { return syncUsers; }
            set { syncUsers = value; }
        }
       
       public ComparatorSettings()
       {
           //constructor
       }
       
       public const int LeftRightDel = 0,
                         LeftRight = 1,
                         RightLeftDel = 2,
                         RightLeft = 3,
                         TwoWay = 4;
                         
    }
}
