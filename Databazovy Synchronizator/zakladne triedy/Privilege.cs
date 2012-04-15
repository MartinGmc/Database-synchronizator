using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    public class Privilege : IDbsyncCompare<Privilege>
    {
        //private string grantor;
        private string grantee;
        //private string table_catalog;
        // private string table_schema;
        private string table_name;
        private string privilege_type;
       // private bool is_grantable;




        public string Grantee
        {
            get { return grantee; }
            set { grantee = value; }
        }
        public string Table_name
        {
            get { return table_name; }
            set { table_name = value; }
        }
        public string Privilege_type
        {
            get { return privilege_type; }
            set { privilege_type = value; }
        }


       

        public bool DBSyncCompareTO(Privilege priv)
        {
            bool ress = true;
            if (this.Grantee != priv.Grantee) ress = false;
           // if (this.Is_grantable != priv.Is_grantable) ress = false;
            if (this.Privilege_type != priv.Privilege_type) ress = false;
            if (this.Table_name != priv.Table_name) ress = false;
            return ress;

        }

        public string getName()
        {
            return this.grantee + " " + this.privilege_type;
        }
    }
}
