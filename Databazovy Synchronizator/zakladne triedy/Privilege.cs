using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    public class Privilege : IDbsyncCompare<Privilege>
    {
        private string grantee;
        private string table_name;
        private string privilege_type;
        private List<string> privilege_type_list;

        #region temporary disabled properties
        //private string grantor;
        //private string table_catalog;
        // private string table_schema;
        // private bool is_grantable;
        #endregion

        #region Outside visible methods
        #region get+Set encapsulation
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
        public List<string> Privitege_type_list
        {
            get { return privilege_type_list; }
        }
        #endregion

        #region methods
        public bool addPriviege(string priv)
        {
            bool found = false;
            foreach (string s in privilege_type_list)
            {
                if (s.Equals(privilege_type))
                {
                    found = true;
                }
            }
            
            if (!found)
            {
                privilege_type_list.Add(priv);
            }

            return false;
        }

        
        public string getName()
        {
            return this.grantee + " " + this.privilege_type;
        }
        #endregion

        #endregion



        public bool DBSyncCompareTO(Privilege priv)
        {
            bool ress = true;
            if (this.Grantee != priv.Grantee) ress = false;
           // if (this.Is_grantable != priv.Is_grantable) ress = false;
            if (this.Privilege_type != priv.Privilege_type) ress = false;
            if (this.Table_name != priv.Table_name) ress = false;
            return ress;

        }

        
    }
}
