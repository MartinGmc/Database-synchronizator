using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
   public class DbSyncConstraintDiff
    {
        private Constraintt constA;
        private Constraintt constB;

        private string constraintName;

        private bool diffConstraintName = false;
        private bool diffConstraintType = false;
        private bool diffIsDeferable = false;
        private bool diffInitialyDefered = false;
        private bool diffCondition = false;
        private bool diffColumns = false;
        private bool different = false;
        private List<ObjectAtribute> constraintAtributesListA;
        private List<ObjectAtribute> constraintAtributesListB;

        internal List<ObjectAtribute> ConstraintAtributesListA
        {
            get { return constraintAtributesListA; }
           
        }
        

        internal List<ObjectAtribute> ConstraintAtributesListB
        {
            get { return constraintAtributesListB; }
           
        }


        public Constraintt getConstA()
        {
            return constA;
        }

        public Constraintt getConstB()
        {
            return constB;
        }
        
        public DbSyncConstraintDiff(Constraintt constAin, Constraintt constBin)
        {
            this.constA = constAin;
            this.constB = constBin;

            constraintAtributesListA = new List<ObjectAtribute>();
            constraintAtributesListB = new List<ObjectAtribute>();

            if (constA == null || constB == null)
            {
                if (constA != null)
                {
                    this.constraintName = constA.Constraint_nam;
                    constraintAtributesListA.Add(new ObjectAtribute("Constraint name ", constA.Constraint_nam, true));
                    constraintAtributesListA.Add(new ObjectAtribute("Constraint type ", constA.Constraint_typ, true));
                    constraintAtributesListA.Add(new ObjectAtribute("Initialy defered ", constA.Initialy_deferre.ToString(), true));
                    constraintAtributesListA.Add(new ObjectAtribute("Is deferable ", constA.Is_deferabl.ToString(), true));
                    constraintAtributesListA.Add(new ObjectAtribute("Condition ", constA.Condition, true));
                    foreach (string s in constA.Column)
                    {
                    constraintAtributesListA.Add(new ObjectAtribute("Column ", s, true));    
                    }
                }
                else if (constB != null)
                {
                    this.constraintName = constB.Constraint_nam;
                    constraintAtributesListB.Add(new ObjectAtribute("Constraint name ", constB.Constraint_nam, true));
                    constraintAtributesListB.Add(new ObjectAtribute("Constraint type ", constB.Constraint_typ, true));
                    constraintAtributesListB.Add(new ObjectAtribute("Initialy defered ", constB.Initialy_deferre.ToString(), true));
                    constraintAtributesListB.Add(new ObjectAtribute("Is deferable ", constB.Is_deferabl.ToString(), true));
                    constraintAtributesListB.Add(new ObjectAtribute("Condition ", constB.Condition, true));
                    foreach (string s in constB.Column)
                    {
                        constraintAtributesListB.Add(new ObjectAtribute("Column ", s, true));
                    }
                }
                else this.constraintName = "UNDEFINED";
            }
            if (constA != null && constB != null)
            {
                this.constraintName = constA.Constraint_nam;
                if (constA.Constraint_nam != constB.Constraint_nam) diffConstraintName = true;
                if (constA.Constraint_typ != constB.Constraint_typ) diffConstraintType = true;
                if (constA.Initialy_deferre != constB.Initialy_deferre) diffInitialyDefered = true;
                if (constA.Is_deferabl != constB.Is_deferabl) diffIsDeferable = true;
                if (constA.Condition != constB.Condition) diffCondition = true;
                if (!CompareColumns(constA.Column,constB.Column)) diffColumns = true;

                if (diffConstraintName || diffConstraintType || diffInitialyDefered || diffIsDeferable||diffCondition||diffColumns) different = true;
                else different = false;

                ObjectAtribute cName = new ObjectAtribute("Constraint name ", constA.Constraint_nam, false);
                
                if (diffConstraintType)
                {
                    ObjectAtribute cTypeA = new ObjectAtribute("Constraint type ", constA.Constraint_typ, true);
                    constraintAtributesListA.Add(cTypeA);
                    ObjectAtribute cTypeB = new ObjectAtribute("Constraint type ", constB.Constraint_typ, true);
                    constraintAtributesListB.Add(cTypeB);
                }
                else
                {
                    ObjectAtribute cType = new ObjectAtribute("Constraint type ", constA.Constraint_typ, false);
                    constraintAtributesListA.Add(cType);
                    constraintAtributesListB.Add(cType);
                }

                if (diffInitialyDefered)
                {
                    ObjectAtribute cdeferedA = new ObjectAtribute("Initialy defered ", constA.Initialy_deferre.ToString(), true);
                    constraintAtributesListA.Add(cdeferedA);
                    ObjectAtribute cdeferedB = new ObjectAtribute("Initialy defered ", constB.Initialy_deferre.ToString(), true);
                    constraintAtributesListB.Add(cdeferedB);
                }
                else
                {
                    ObjectAtribute cdefered = new ObjectAtribute("Initialy defered ", constA.Initialy_deferre.ToString(), false);
                    constraintAtributesListA.Add(cdefered);
                    constraintAtributesListB.Add(cdefered);
                }

                if (diffIsDeferable)
                {
                    ObjectAtribute cDeferableA = new ObjectAtribute("Deferable ", constA.Is_deferabl.ToString(), true);
                    constraintAtributesListA.Add(cDeferableA);
                    ObjectAtribute cDeferableB = new ObjectAtribute("Deferable ", constB.Is_deferabl.ToString(), true);
                    constraintAtributesListB.Add(cDeferableB);
                }
                else
                {
                    ObjectAtribute cDeferable = new ObjectAtribute("Deferable ", constA.Is_deferabl.ToString(), false);
                    constraintAtributesListA.Add(cDeferable);
                    constraintAtributesListB.Add(cDeferable);
                }
                if (diffCondition)
                {
                    constraintAtributesListA.Add(new ObjectAtribute("Condition ", constA.Condition, true));
                    constraintAtributesListB.Add(new ObjectAtribute("Condition ", constB.Condition, true));
                    
                }
                else
                {
                    constraintAtributesListA.Add(new ObjectAtribute("Condition ", constA.Condition, false));
                    constraintAtributesListB.Add(new ObjectAtribute("Condition ", constB.Condition, false));
                }
                if (diffColumns)
                {
                    foreach (string s in constA.Column)
                    {
                        constraintAtributesListA.Add(new ObjectAtribute("Column ", s, true)); 
                    }
                    foreach (string s in constB.Column)
                    {
                        constraintAtributesListB.Add(new ObjectAtribute("Column ", s, true));
                    }
                    

                }
                else
                {
                    foreach (string s in constA.Column)
                    {
                        constraintAtributesListA.Add(new ObjectAtribute("Column ", s, false));
                        constraintAtributesListB.Add(new ObjectAtribute("Column ", s, false));
                    }
                }


            }
            else different = true;
        }

        public bool isDifferent()
        {
            return different;
        }

        public string getName()
        {
            return this.constraintName;
        }

        private bool CompareColumns(List<string> roleA, List<string> roleB)
        {
            bool ress = true;

            foreach (string sA in roleA)
            {
                bool nasiel = false;
                foreach (string sB in roleB)
                {
                    if (sA == sB) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            return ress;
        } 

    }
}
