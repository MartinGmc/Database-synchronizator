using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    public class DbSyncPrivilegeDiff
    {
        private Privilege privA;
        private Privilege privB;

        private string privilegeName;

        private bool diffGrantee = false;
        private bool diffTableNAme = false;
        private bool diffprivilegeType = false;
        private bool diffISGrantable = false;
        private bool different = false;

        private List<ObjectAtribute> privAtrListA;
        private List<ObjectAtribute> privAtrListB;

        internal List<ObjectAtribute> PrivAtrListA
        {
            get { return privAtrListA; }
            
        }
       

        internal List<ObjectAtribute> PrivAtrListB
        {
            get { return privAtrListB; }
           
        }

        public Privilege getPrivA()
        {
            return privA;
        }

        public Privilege getPrivB()
        {
            return privB;
        }
        
        public DbSyncPrivilegeDiff(Privilege privAin, Privilege privBin)
        {
            this.privA = privAin;
            this.privB = privBin;

            privAtrListA = new List<ObjectAtribute>();
            privAtrListB = new List<ObjectAtribute>();

            if (privA == null || privB == null)
            {
                if (privA != null)
                {
                    this.privilegeName = privA.Grantee + " " + privA.Privilege_type;
                    privAtrListA.Add(new ObjectAtribute("Object name", privA.Table_name, true));
                    privAtrListA.Add(new ObjectAtribute("Grantee", privA.Grantee, true));
                    //privAtrListA.Add(new ObjectAtribute("Is Grantable", privA.Is_grantable.ToString(), true));
                    privAtrListA.Add(new ObjectAtribute("Privilege type", privA.Privilege_type, true));
                }
                else if (privB != null)
                {
                    this.privilegeName = privB.Grantee + " " + privB.Privilege_type;
                    privAtrListB.Add(new ObjectAtribute("Object name", privB.Table_name, true));
                    privAtrListB.Add(new ObjectAtribute("Grantee", privB.Grantee, true));
                    //privAtrListB.Add(new ObjectAtribute("Is Grantable", privB.Is_grantable.ToString(), true));
                    privAtrListB.Add(new ObjectAtribute("Privilege type", privB.Privilege_type, true));
                }
                else this.privilegeName = "UNDEFINED";

            }
            if (privA != null && privB != null)
            {
                this.privilegeName = privA.Grantee + " " + privA.Privilege_type;
                if (privA.Grantee != privB.Grantee) diffGrantee = true;
                //if (privA.Is_grantable != privB.Is_grantable) diffISGrantable = true;
                if (privA.Table_name != privB.Table_name) diffTableNAme = true;
                if (privA.Privilege_type != privB.Privilege_type) diffprivilegeType = true;
                if (diffGrantee || diffISGrantable || diffprivilegeType || diffTableNAme) different = true;
                else different = false;

                ObjectAtribute cObjectname = new ObjectAtribute("Object name ", privA.Table_name, false);
                privAtrListA.Add(cObjectname);
                privAtrListB.Add(cObjectname);

                if (diffGrantee)
                {
                    ObjectAtribute cGranteA = new ObjectAtribute("Grantee ", privA.Grantee, true);
                    privAtrListA.Add(cGranteA);
                    ObjectAtribute cGranteB = new ObjectAtribute("Grantee ", privB.Grantee, true);
                    privAtrListB.Add(cGranteB);
                }
                else
                {
                    ObjectAtribute cGrantee = new ObjectAtribute("Grantee ", privB.Grantee, false);
                    privAtrListA.Add(cGrantee);
                    privAtrListB.Add(cGrantee);
                }

                /*if (diffISGrantable)
                {
                    ObjectAtribute cIsGrantableA = new ObjectAtribute("Is Grantable ", privA.Is_grantable.ToString(), true);
                    privAtrListA.Add(cIsGrantableA);
                    ObjectAtribute cIsGrantableB = new ObjectAtribute("Is Grantable ", privB.Is_grantable.ToString(), true);
                    privAtrListB.Add(cIsGrantableB);
                }
                else
                {
                    ObjectAtribute cIsGrantable = new ObjectAtribute("Is Grantable ", privB.Is_grantable.ToString(), false);
                    privAtrListA.Add(cIsGrantable);
                    privAtrListB.Add(cIsGrantable);
                }
                */
                if (diffprivilegeType)
                {
                    ObjectAtribute cPrivilegeTypeA = new ObjectAtribute("Privilege type ", privA.Privilege_type, true);
                    privAtrListA.Add(cPrivilegeTypeA);
                    ObjectAtribute cPrivilegeTypeB = new ObjectAtribute("Privilege type ", privB.Privilege_type, true);
                    privAtrListB.Add(cPrivilegeTypeB);
                }
                else
                {
                    ObjectAtribute cPrivilegeType = new ObjectAtribute("Privilege type ", privB.Privilege_type, false);
                    privAtrListA.Add(cPrivilegeType);
                    privAtrListB.Add(cPrivilegeType);
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
            return this.privilegeName;
        }
    }
}
