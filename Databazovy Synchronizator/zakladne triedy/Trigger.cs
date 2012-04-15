using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
   public class Trigger :IDbsyncCompare<Trigger>
    {
        private string trigger_name;
        private string trigger_owner;
        //private string trigger_schema; // treba odstranit
        private string table_name;
        private string onAction;
        private List<string> sqlText;
        private bool isAfter;
        private bool isInsteadOf;
        private bool disabled;

        public List<string> SqlText
        {
            get { return sqlText; }
            set { sqlText = value; }
        }
        public bool IsInsteadOf
        {
            get { return isInsteadOf; }
            set { isInsteadOf = value; }
        }
        public string Trigger_name
        {
            get { return trigger_name; }
            set { trigger_name = value; }
        }
        public string Trigger_owner
        {
            get { return trigger_owner; }
            set { trigger_owner = value; }
        }
        public string Table_name
        {
            get { return table_name; }
            set { table_name = value; }
        }
        public string OnAction
        {
            get { return onAction; }
            set { onAction = value; }
        }
        public bool IsAfter
        {
            get { return isAfter; }
            set { isAfter = value; }
        }
        public bool Disabled
        {
            get { return disabled; }
            set { disabled = value; }
        }

        public bool DBSyncCompareTO(Trigger trg)
        {
            ComparatorOfSQL s = new ComparatorOfSQL(this.sqlText,trg.sqlText); 
            bool ress = true;
            if (this.Disabled != trg.Disabled) ress = false;
            if (this.IsAfter != trg.IsAfter) ress = false;
            if (this.IsInsteadOf != trg.IsInsteadOf) ress = false;
            if (this.OnAction != trg.OnAction) ress = false;
            if (s.IsDifferent) ress = false; 
            if (this.Table_name != trg.Table_name) ress = false;
            if (this.Trigger_name != trg.Trigger_name) ress = false;
            if (this.Trigger_owner != trg.Trigger_owner) ress = false;
            return ress;
        }


       

        public string getName()
        {
            return this.trigger_name;
        }
    }
}
