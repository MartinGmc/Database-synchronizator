using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
   public class Constraintt :IDbsyncCompare<Constraintt>
    {
        private string Constraint_name;
        private string Constraint_type;
        private List<string> column;
        private string condition;
        private bool Is_deferable;
        private bool initialy_deferred;

        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        } 
       
       public List<string> Column
        {
            get { return column; }
            set { column = value; }
        }
       
        public string Constraint_nam
        {
            get { return Constraint_name; }
            set { Constraint_name = value; }
        }
      
        public string Constraint_typ
        {
            get { return Constraint_type; }
            set { Constraint_type = value; }
        }
       
        public bool Is_deferabl
        {
            get { return Is_deferable; }
            set { Is_deferable = value; }
        }
       
        public bool Initialy_deferre
        {
            get { return initialy_deferred; }
            set { initialy_deferred = value; }
        }

       public Constraintt ()
        {
            this.column = new List<string>();
        }
       
       public bool DBSyncCompareTO(Constraintt con)
        {
         bool ress = true;
         if (this.Constraint_nam != con.Constraint_nam) ress = false;
         if (this.Constraint_typ != con.Constraint_typ) ress = false;
         if (this.Initialy_deferre != con.Initialy_deferre) ress = false;
         if (this.Is_deferabl != con.Is_deferabl) ress  = false;
            return ress;
        }

       

        public string getName()
        {
            return this.Constraint_nam;
        }
    }
}
