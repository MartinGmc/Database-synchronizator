using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
   public class DbSyncTypeDiff
    {
        private Typ typeA;
        private Typ typeB;

        private string typeName;

        private List<ObjectAtribute> typeAtributesA;
        private List<ObjectAtribute> typeAtributesB;

        internal List<ObjectAtribute> TypeAtributesB
        {
            get { return typeAtributesB; }
            
        }
        internal List<ObjectAtribute> TypeAtributesA
        {
            get { return typeAtributesA; }
           
        }
        
        private bool diffTypeNAme = false;
        private bool diffTypeDatatype = false;
        private bool diffPrecision = false;
        private bool diffScale = false;
        private bool diffCanBeNull = false;
        private bool different = false;

        public Typ getTypeA()
        {
            return typeA;
        }

        public Typ getTypeB()
        {
            return typeB;
        }
        
        public DbSyncTypeDiff(Typ typeAin, Typ typeBin)
        {
            this.typeA = typeAin;
            this.typeB = typeBin;

            typeAtributesA = new List<ObjectAtribute>();
            typeAtributesB = new List<ObjectAtribute>();

            if (typeA == null || typeB == null)
            {
                if (typeA != null)
                {
                    typeName = typeA.Nazov;
                    typeAtributesA.Add(new ObjectAtribute("Name of type", typeName, true));
                    typeAtributesA.Add(new ObjectAtribute("Type datatype ", typeA.Datatyp, true));
                    typeAtributesA.Add(new ObjectAtribute("Type precision ", typeA.Precision, true));
                    typeAtributesA.Add(new ObjectAtribute("Type scale ", typeA.Scale, true));
                    typeAtributesA.Add(new ObjectAtribute("Type Is Nullable ", typeA.CanBeNull.ToString(), true));
                }
                else if (typeB != null)
                {
                    typeName = typeB.Nazov;
                    typeAtributesB.Add(new ObjectAtribute("Name of type", typeName, true));
                    typeAtributesA.Add(new ObjectAtribute("Type datatype ", typeB.Datatyp, true));
                    typeAtributesA.Add(new ObjectAtribute("Type precision ", typeB.Precision, true));
                    typeAtributesA.Add(new ObjectAtribute("Type scale ", typeB.Scale, true));
                    typeAtributesA.Add(new ObjectAtribute("Type Is Nullable ", typeB.CanBeNull.ToString(), true));
                }
                else typeName = "UNDEFINED";
            }
            if (typeA != null && typeB != null)
            {
                if (typeA.Datatyp != typeB.Datatyp) diffTypeDatatype = true;
                if (typeA.Precision != typeB.Precision) diffPrecision = true;
                if (typeA.Scale != typeB.Scale) diffScale = true;
                if (typeA.CanBeNull != typeB.CanBeNull) diffCanBeNull = true;
                if (typeA.Nazov != typeB.Nazov) diffTypeNAme = true;

                if (diffPrecision || diffScale || diffTypeDatatype || diffTypeNAme || diffCanBeNull) different = true;
                else different = false;

                typeName = typeA.Nazov;
                typeAtributesA.Add (new ObjectAtribute("Name of type",typeName,false));
                typeAtributesB.Add (new ObjectAtribute("Name of type",typeName,false));
                
                if (diffPrecision)
                {
                    ObjectAtribute tcharA = new ObjectAtribute("Type precision ", typeA.Precision, true);
                    typeAtributesA.Add(tcharA);
                    ObjectAtribute tcharB = new ObjectAtribute("Type precision  ", typeB.Precision, true);
                    typeAtributesB.Add(tcharB);
                }
                else
                {
                    ObjectAtribute tchar = new ObjectAtribute("Type precision  ", typeA.Precision, false);
                    typeAtributesA.Add(tchar);
                    typeAtributesB.Add(tchar);
                }

                if (diffScale)
                {
                    ObjectAtribute tcharA = new ObjectAtribute("Type scale  ", typeA.Scale, true);
                    typeAtributesA.Add(tcharA);
                    ObjectAtribute tcharB = new ObjectAtribute("Type scale   ", typeB.Scale, true);
                    typeAtributesB.Add(tcharB);
                }
                else
                {
                    ObjectAtribute tchar = new ObjectAtribute("Type scale   ", typeA.Scale, false);
                    typeAtributesA.Add(tchar);
                    typeAtributesB.Add(tchar);
                }

                if (diffTypeDatatype)
                {
                    ObjectAtribute tcharA = new ObjectAtribute("Datatype ", typeA.Datatyp, true);
                    typeAtributesA.Add(tcharA);
                    ObjectAtribute tcharB = new ObjectAtribute("Datatype ", typeB.Datatyp, true);
                    typeAtributesB.Add(tcharB);
                }
                else
                {
                    ObjectAtribute tchar = new ObjectAtribute("Datatype  ", typeA.Datatyp, false);
                    typeAtributesA.Add(tchar);
                    typeAtributesB.Add(tchar);
                }

                if (diffCanBeNull)
                {
                    ObjectAtribute tcharA = new ObjectAtribute("Type Is Nullable ", typeA.CanBeNull.ToString(), true);
                    typeAtributesA.Add(tcharA);
                    ObjectAtribute tcharB = new ObjectAtribute("Type Is Nullable ", typeB.CanBeNull.ToString(), true);
                    typeAtributesB.Add(tcharB);
                }
                else
                {
                    ObjectAtribute tchar = new ObjectAtribute("Type Is Nullable  ", typeA.CanBeNull.ToString(), false);
                    typeAtributesA.Add(tchar);
                    typeAtributesB.Add(tchar);
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
            return typeName;
        }

    }
}
