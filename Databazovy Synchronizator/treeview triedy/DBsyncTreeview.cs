using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Databazovy_Synchronizator
{
   public abstract class DBsyncTreeview : TreeNode
    {
       

       
        protected int typIkony;
        private bool Zvyraznene;
        private List<ObjectAtribute> objectAtributesList;
        private SqlTextHighlited sqlTextList;

        public SqlTextHighlited SqlTextList
        {
            get { return sqlTextList; }
            set { sqlTextList = value; }
        }


        internal List<ObjectAtribute> ObjectAtributesList
        {
            get { return objectAtributesList; }
            set { objectAtributesList = value; }
        }
        
        public bool Azvyraznene
        {
            get { return Zvyraznene; }
            set { Zvyraznene = value; }
        }

        public abstract override string ToString();

        
        

        public int getTypIkony()
        {
            return typIkony;
        }

        public const int DatabaseIcon = 0,
                         TablesIcon = 1,
                         ColumnsIcon = 2,
                         KeysIcon = 3,
                         ConstraintsIcon = 4,
                         TriggersIcon = 5,
                         GrantsIcon = 6,
                         StoredProceduresIcon = 7,
                         FunctionsIcon = 8,
                         TypesIcon = 9,
                         UsersIcon = 10,
                         ConstraintIcon = 11,
                         PrimaryKeyIcon = 12,
                         ForeinKeyIcon = 13,
                         TableIcon = 14,
                         ColumnIcon = 15,
                         TriggerIcon = 16,
                         GrantIcon = 17,
                         StoredProcedureIcon = 18,
                         FunctionIcon = 19,
                         TypeIcon = 20,
                         UserIcon = 21,
                         IndexesIcon = 22,
                         IndexIcon = 23;
    }
}
