using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
   public class User :IDbsyncCompare<User>
    {
        private string userName;
        private string login;
        private int user_id;
        private List<string> roly;

        public User()
        {
            roly = new List<string>();
        }
 
       public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
      
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
       
        public int User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }
        
        public List<string> Roly
        {
            get { return roly; }
            set { roly = value; }
        }

        private bool porovnajRoly(List<string> rolaA, List<string> rolaB)
        {
            bool ress = true;

            foreach (string sA in rolaA)
            {
                bool nasiel = false;
                foreach (string sB in rolaB)
                {
                    if (sA == sB) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            return ress;
        }

        public bool DBSyncCompareTO(User usr)
        {
            bool ress = true;

            if (this.Login != usr.Login) ress = false;
            if (!porovnajRoly(roly,usr.roly)) ress = false;
            if (this.User_id != usr.User_id) ress = false;
            if (this.UserName != usr.UserName) ress = false;
            return ress;
        }



       public string getName()
       {
           return this.UserName;
       }
    }
}
