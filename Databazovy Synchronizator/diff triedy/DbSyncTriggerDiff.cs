using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
   public class DbSyncTriggerDiff
    {
        private Trigger trigA;
        private Trigger trigB;

        private string triggerName;

        private bool diffTrigName = false;
        private bool diffTRigOwner = false;
        private bool diffTableName = false;
        private bool diffOnAction = false;
        private bool diffIsAfter = false;
        private bool diffIsInstead = false;
        private bool diffDisabled = false;
        private bool diffsqltext = false;
        private bool different = false;

        private List<ObjectAtribute> triggerAtrListA;
        private List<ObjectAtribute> triggerAtrListB;

        private SqlTextHighlited sqlTextListA;
        private SqlTextHighlited sqlTextListB;


        public SqlTextHighlited SqlTextListA
        {
            get { return sqlTextListA; }
           
        }
        public SqlTextHighlited SqlTextListB
        {
            get { return sqlTextListB; }
           
        }
        internal List<ObjectAtribute> TriggerAtrListA
        {
            get { return triggerAtrListA; }
           
        }
        internal List<ObjectAtribute> TriggerAtrListB
        {
            get { return triggerAtrListB; }
           
        }
        public Trigger getTrigA()
        {
            return trigA;
        }
        public Trigger getTrigB()
        {
            return trigB;
        }
        
       public DbSyncTriggerDiff(Trigger trigAin, Trigger trigBin)
        {
            this.trigA = trigAin;
            this.trigB = trigBin;

            triggerAtrListA = new List<ObjectAtribute>();
            triggerAtrListB = new List<ObjectAtribute>();

            ComparatorOfSQL compSQL;

            
           
            if (trigA == null || trigB == null)
            {
                if (trigA != null)
                {
                    triggerName = trigA.Trigger_name;
                    triggerAtrListA.Add(new ObjectAtribute("Trigger name ", trigA.Trigger_name, true));
                    triggerAtrListA.Add(new ObjectAtribute("sql text  ", "Click button", true, true));
                    triggerAtrListA.Add(new ObjectAtribute("Disabled ", trigA.Disabled.ToString(), true));
                    triggerAtrListA.Add(new ObjectAtribute("Is after  ", trigA.IsAfter.ToString(), true));
                    triggerAtrListA.Add(new ObjectAtribute("Is instead  ", trigA.IsInsteadOf.ToString(), true));
                    triggerAtrListA.Add(new ObjectAtribute("On action  ", trigA.OnAction, true));
                    triggerAtrListA.Add(new ObjectAtribute("Trigger name  ", trigA.Trigger_name, true));
                    triggerAtrListA.Add(new ObjectAtribute("Trigger owner  ", trigA.Trigger_owner, true));
                    compSQL = new ComparatorOfSQL(trigA.SqlText, null);
                    sqlTextListA = compSQL.TextA;
                    sqlTextListB = null;
                   
                }
                else if (trigB != null)
                {
                    triggerName = trigB.Trigger_name;
                    triggerAtrListB.Add(new ObjectAtribute("Trigger name ", trigB.Trigger_name, true));
                    triggerAtrListB.Add(new ObjectAtribute("sql text  ", "Click button", true, true));
                    triggerAtrListB.Add(new ObjectAtribute("Disabled ", trigB.Disabled.ToString(), true));
                    triggerAtrListB.Add(new ObjectAtribute("Is after  ", trigB.IsAfter.ToString(), true));
                    triggerAtrListB.Add(new ObjectAtribute("Is instead  ", trigB.IsInsteadOf.ToString(), true));
                    triggerAtrListB.Add(new ObjectAtribute("On action  ", trigB.OnAction, true));
                    triggerAtrListB.Add(new ObjectAtribute("Trigger name  ", trigB.Trigger_name, true));
                    triggerAtrListB.Add(new ObjectAtribute("Trigger owner  ", trigB.Trigger_owner, true));
                    compSQL = new ComparatorOfSQL(null, trigB.SqlText);
                    sqlTextListA = null;
                    sqlTextListB = compSQL.TextB;
                }
                else triggerName = "UNDEFINED";
            }
            if (trigA != null && trigB != null)
            {
                compSQL = new ComparatorOfSQL(trigA.SqlText, trigB.SqlText);
                sqlTextListA = compSQL.TextA;
                sqlTextListB = compSQL.TextB;

                triggerName = trigA.Trigger_name;
                if (trigA.Disabled != trigB.Disabled) diffDisabled = true;
                if (trigA.IsAfter != trigB.IsAfter) diffIsAfter = true;
                if (trigA.IsInsteadOf != trigB.IsInsteadOf) diffIsInstead = true;
                if (trigA.OnAction != trigB.OnAction) diffOnAction = true;
                if (compSQL.IsDifferent) diffsqltext = true;
                if (trigA.Table_name != trigB.Table_name) diffTableName = true;
                if (trigA.Trigger_name != trigB.Trigger_name) diffTrigName = true;
                if (trigA.Trigger_owner != trigB.Trigger_owner) diffTRigOwner = true;
                if (diffDisabled || diffIsAfter || diffIsInstead || diffOnAction || diffsqltext || diffTableName || diffTrigName || diffTRigOwner) different = true;
                else different = false;

                ObjectAtribute oatriggerName = new ObjectAtribute("Trigger name ", this.triggerName, false);

                triggerAtrListA.Add(oatriggerName);
                triggerAtrListB.Add(oatriggerName);

                if (diffsqltext)
                {
                    ObjectAtribute tSqlTextA = new ObjectAtribute("sql text ", "Click button", true, true);
                    triggerAtrListA.Add(tSqlTextA);
                    
                    ObjectAtribute tSqlTextB = new ObjectAtribute("sql text ", "Click button", true, true);
                    triggerAtrListB.Add(tSqlTextB);
                    
                }
                else
                {
                    ObjectAtribute tSqlText = new ObjectAtribute("sql text ", "Click button", false, true);
                    triggerAtrListA.Add(tSqlText);
                    triggerAtrListB.Add(tSqlText);
                   
                }
                
                if (diffDisabled)
                {
                    ObjectAtribute tDisabledA = new ObjectAtribute("Disabled ", trigA.Disabled.ToString(), true);
                    triggerAtrListA.Add(tDisabledA);
                    ObjectAtribute tDisabledB = new ObjectAtribute("Disabled ", trigB.Disabled.ToString(), true);
                    triggerAtrListB.Add(tDisabledB);
                }
                else
                {
                    ObjectAtribute tDisabled = new ObjectAtribute("Disabled ", trigB.Disabled.ToString(), false);
                    triggerAtrListA.Add(tDisabled);
                    triggerAtrListB.Add(tDisabled);
                }

                if (diffIsAfter)
                {
                    ObjectAtribute tIsAfterA = new ObjectAtribute("Is after ", trigA.IsAfter.ToString(), true);
                    triggerAtrListA.Add(tIsAfterA);
                    ObjectAtribute tIsAfterB = new ObjectAtribute("Is after ", trigB.IsAfter.ToString(), true);
                    triggerAtrListB.Add(tIsAfterB);
                }
                else
                {
                    ObjectAtribute tIsAfter = new ObjectAtribute("Is after ", trigB.IsAfter.ToString(), false);
                    triggerAtrListA.Add(tIsAfter);
                    triggerAtrListB.Add(tIsAfter);
                }

                if (diffIsInstead)
                {
                    ObjectAtribute tIsInsteadA = new ObjectAtribute("Is instead ", trigA.IsInsteadOf.ToString(), true);
                    triggerAtrListA.Add(tIsInsteadA);
                    ObjectAtribute tIsInsteadB = new ObjectAtribute("Is instead ", trigB.IsInsteadOf.ToString(), true);
                    triggerAtrListB.Add(tIsInsteadB);
                }
                else
                {
                    ObjectAtribute tIsInstead = new ObjectAtribute("Is instead ", trigB.IsInsteadOf.ToString(), false);
                    triggerAtrListA.Add(tIsInstead);
                    triggerAtrListB.Add(tIsInstead);
                }

                if (diffOnAction)
                {
                    ObjectAtribute tOnActionA = new ObjectAtribute("On action ", trigA.OnAction, true);
                    triggerAtrListA.Add(tOnActionA);
                    ObjectAtribute tOnActionB = new ObjectAtribute("On action ", trigB.OnAction, true);
                    triggerAtrListB.Add(tOnActionB);
                }
                else
                {
                    ObjectAtribute tIsInstead = new ObjectAtribute("On action ", trigB.OnAction, false);
                    triggerAtrListA.Add(tIsInstead);
                    triggerAtrListB.Add(tIsInstead);
                }

               

                if (diffTrigName)
                {
                    ObjectAtribute ttrigNameA = new ObjectAtribute("Trigger name ", trigA.Trigger_name, true);
                    triggerAtrListA.Add(ttrigNameA);
                    ObjectAtribute ttrigNameB = new ObjectAtribute("Trigger name ", trigB.Trigger_name, true);
                    triggerAtrListB.Add(ttrigNameB);
                }
                else
                {
                    ObjectAtribute ttrigName = new ObjectAtribute("Trigger name ", trigB.Trigger_name, false);
                    triggerAtrListA.Add(ttrigName);
                    triggerAtrListB.Add(ttrigName);
                }

                if (diffTRigOwner)
                {
                    ObjectAtribute ttrigOwnerA = new ObjectAtribute("Trigger owner ", trigA.Trigger_owner, true);
                    triggerAtrListA.Add(ttrigOwnerA);
                    ObjectAtribute ttrigOwnerB = new ObjectAtribute("Trigger owner ", trigB.Trigger_owner, true);
                    triggerAtrListB.Add(ttrigOwnerB);
                }
                else
                {
                    ObjectAtribute ttrigOwner = new ObjectAtribute("Trigger owner ", trigB.Trigger_owner, false);
                    triggerAtrListA.Add(ttrigOwner);
                    triggerAtrListB.Add(ttrigOwner);
                }


            }
            else different = true;
        }

        public string getName()
        {
            return this.triggerName;
        }

        public bool isDiffirent()
        {
            return different;
        }
    }
}
