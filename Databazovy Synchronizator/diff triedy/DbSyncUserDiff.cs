using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
   public class DbSyncUserDiff
	{
		private User userA;
		private User userB;

		private string userName;

		private bool diffUserName = false;
		private bool diffLogin = false;
	   // private bool diffUserId = false; // toto bude odstranene
		private bool diffRoles = false;
		private bool different = false;

		private List<ObjectAtribute> userAtributesA;
		private List<ObjectAtribute> userAtributesB;

		internal List<ObjectAtribute> UserAtributesB
		{
			get { return userAtributesB; }
			set { userAtributesB = value; }
		}
		internal List<ObjectAtribute> UserAtributesA
		{
			get { return userAtributesA; }
			set { userAtributesA = value; }
		} 

		public DbSyncUserDiff(User userAin, User userBin)
		{
			this.userA = userAin;
			this.userB = userBin;

			userAtributesA = new List<ObjectAtribute>();
			userAtributesB = new List<ObjectAtribute>();

			if (userA == null || userB == null)
			{
				if (this.userA != null)
				{
					userName = userA.UserName;
					userAtributesA.Add(new ObjectAtribute("User name ", userA.UserName, true));
					userAtributesA.Add(new ObjectAtribute("User login ", userA.UserName, true));
					foreach (string s in userA.Roly)
					{
						ObjectAtribute rolaA = new ObjectAtribute("Role", s, true);
						userAtributesA.Add(rolaA);
					}
				}
				else if (this.userB != null)
				{
					userName = userB.UserName;
					userAtributesB.Add(new ObjectAtribute("User name ", userB.UserName, true));
					userAtributesB.Add(new ObjectAtribute("User login ", userB.UserName, true));
					foreach (string s in userB.Roly)
					{
						ObjectAtribute rolaA = new ObjectAtribute("Role", s, true);
						userAtributesB.Add(rolaA);
					}
				}
				else userName = "UNDEFINED";
			}
			if (userA != null && userB != null)
			{
				userName = userA.UserName;
				
				if (userA.Login != userB.Login) diffLogin = true;
				//if (userA.User_id != userB.User_id) diffUserId = true; //asi to netreba
				if (userA.UserName != userB.UserName) diffUserName = true;
				if (!CompareRoles(userA.Roly, userB.Roly)) diffRoles = true;

				if (diffLogin || diffRoles || diffUserName) different = true;
				else different = false;

				userAtributesA.Add(new ObjectAtribute("User name ", userName, false));
				userAtributesB.Add(new ObjectAtribute("User name ", userName, false));

				if (diffLogin)
				{
					ObjectAtribute loginA = new ObjectAtribute("User login", userA.Login, true);
					userAtributesA.Add(loginA);
					ObjectAtribute loginB = new ObjectAtribute("User login", userB.Login, true);
					userAtributesB.Add(loginB);
				}
				else
				{
					ObjectAtribute loginA = new ObjectAtribute("User login", userA.Login, false);
					userAtributesA.Add(loginA);
					userAtributesB.Add(loginA);
				}

				if (diffRoles)
				{
					foreach (string s in userA.Roly)
					{
					  ObjectAtribute rolaA = new ObjectAtribute("Role", s, true);
					  userAtributesA.Add(rolaA);
					}

					 foreach (string s in userB.Roly)
					{
					  ObjectAtribute rolaB = new ObjectAtribute("Role", s, true);
					  userAtributesB.Add(rolaB);
					}
				   
				}
				else
				{
					foreach (string s in userA.Roly)
					{
						ObjectAtribute rolaA = new ObjectAtribute("Role", s, false);
						userAtributesA.Add(rolaA);
						userAtributesB.Add(rolaA);
					}
				   
				}

			}
			else different = true;
		}

		public User getUserA()
		{
			return userA;
		}

		public User getUserB()
		{
			return userB;
		}
		
		public string getName()
		{
			return userName;
		}

		public bool isDifferent()
		{
			return different;
		}

		private bool CompareRoles(List<string> roleA, List<string> roleB)
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
