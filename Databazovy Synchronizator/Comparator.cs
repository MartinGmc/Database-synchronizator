using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace Databazovy_Synchronizator
{
   public class Comparator
	{
	   public DataBasee db1;
	   public DataBasee db2;

	   public ComparatorSettings settings;

	   public DbSyncDataBaseDiff DatabaseDifferences;

	   public event EventHandler aktualizujVypis;

	   //lists o objects whitch are in missing in db1
	   private List<Tablee> tablesMissingInDb1;
	   private List<SProcedure> proceduresMissingInDb1;
	   private List<SFunction> functionsMissingInDb1;
	   private List<Typ> typesMissingInDb1;
	   private List<User> usersMissingInDb1;

	   //lists o objects whitch are missing in db2        
	   private List<Tablee> tablesMissingInDb2;
	   private List<SProcedure> proceduresMissingInDb2;
	   private List<SFunction> functionsMissingInDb2;
	   private List<Typ> typesMissingInDb2;
	   private List<User> usersMissingInDb2;

	   // lists of objects whitch are different
	   private List<DbSyncTableDiff> differentTables;
	   private List<DbSyncStoredProcedureDiff> differentProcedures;
	   private List<DbSyncFunctionDiff> differentFunctions;
	   private List<DbSyncTypeDiff> differentTypes;
	   private List<DbSyncUserDiff> differentUsers;
	   
		public Comparator()
		{
			//vytvorim vsetky tie listy;
			tablesMissingInDb1 = new List<Tablee>();
			proceduresMissingInDb1 = new List<SProcedure>();
			functionsMissingInDb1 = new List<SFunction>();
			typesMissingInDb1 = new List<Typ>();
			usersMissingInDb1 = new List<User>();

			tablesMissingInDb2 = new List<Tablee>();
			proceduresMissingInDb2 = new List<SProcedure>();
			functionsMissingInDb2 = new List<SFunction>();
			typesMissingInDb2 = new List<Typ>();
			usersMissingInDb2 = new List<User>();


			differentFunctions = new List<DbSyncFunctionDiff>();
			differentProcedures = new List<DbSyncStoredProcedureDiff>();
			differentTables = new List<DbSyncTableDiff>();
			differentTypes = new List<DbSyncTypeDiff>();
			differentUsers = new List<DbSyncUserDiff>();
			//listy vytvorene

		 

			db1 = new DataBasee();
			db2 = new DataBasee();

			//priradim eventhandlery
			db1.DatabaseChanged += new EventHandler(Akt_Vypis);
			db2.DatabaseChanged += new EventHandler(Akt_Vypis);
			
		}

		private void Akt_Vypis(object sender, EventArgs e)
		{
			refreshConnections();
		}
	   
		public void fullfillLists()
		{
			tablesMissingInDb1 = new List<Tablee>();
			tablesMissingInDb2 = new List<Tablee>();
			differentTables = new List<DbSyncTableDiff>();
			functionsMissingInDb1 = new List<SFunction>();
			functionsMissingInDb2 = new List<SFunction>();
			differentFunctions = new List<DbSyncFunctionDiff>();
			proceduresMissingInDb1 = new List<SProcedure>();
			proceduresMissingInDb2 = new List<SProcedure>();
			differentProcedures = new List<DbSyncStoredProcedureDiff>();
			typesMissingInDb1 = new List<Typ>();
			typesMissingInDb2 = new List<Typ>();
			differentTypes = new List<DbSyncTypeDiff>();
			usersMissingInDb1 = new List<User>();
			usersMissingInDb2 = new List<User>();
			differentUsers = new List<DbSyncUserDiff>();
			if (DatabaseDifferences != null)
			{
				if (DatabaseDifferences.AreDiffFunctions())
				{
					foreach (DbSyncFunctionDiff funkc in DatabaseDifferences.getFunctionDiff())
					{
						if (funkc.isDifferent())
						{
							if ((funkc.getFunctionA() != null) && (funkc.getFunctionB() != null))
							{
								differentFunctions.Add(funkc);
							}
							else if (funkc.getFunctionA() == null)
							{
								functionsMissingInDb1.Add(funkc.getFunctionB());
							}
							else
							{
								functionsMissingInDb2.Add(funkc.getFunctionA());
							}
						}
					}
				}
				
				if (DatabaseDifferences.AreDiffStoredProcedures())
				{
					foreach (DbSyncStoredProcedureDiff proc in DatabaseDifferences.getStoredProcedureDiff())
					{
						if (proc.isDifferent())
						{
							if ((proc.getProcA() != null) && (proc.getProcB() != null))
							{
								differentProcedures.Add(proc);
							}
							else if (proc.getProcA() == null)
							{
								proceduresMissingInDb1.Add(proc.getProcB());
							}
							else
							{
								proceduresMissingInDb2.Add(proc.getProcA());
							}
						}
					}
				}

				if (DatabaseDifferences.AreDiffTables())
				{
					foreach (DbSyncTableDiff tab in DatabaseDifferences.getTablediff())
					{
						if (tab.isDifferent())
						{
							if ((tab.getTabA() != null) && (tab.getTabB() != null))
							{
								differentTables.Add(tab);
							}
							else if (tab.getTabA() == null)
							{
								tablesMissingInDb1.Add(tab.getTabB());
							}
							else
							{
								tablesMissingInDb2.Add(tab.getTabA());
							}
						}
					}
				}

				if (DatabaseDifferences.AreDiffTypes())
				{
					foreach (DbSyncTypeDiff tt in DatabaseDifferences.getTypesDiff())
					{
						if (tt.isDifferent())
						{
							if ((tt.getTypeA() != null) && (tt.getTypeB() != null))
							{
								differentTypes.Add(tt);
							}
							else if (tt.getTypeA() == null)
							{
								typesMissingInDb1.Add(tt.getTypeB());
							}
							else
							{
								typesMissingInDb2.Add(tt.getTypeA());
							}
						}
					}
				}

				if (DatabaseDifferences.AreDiffUSers())
				{
					foreach (DbSyncUserDiff usr in DatabaseDifferences.getUserDiff())
					{
						if (usr.isDifferent())
						{
							if ((usr.getUserA() != null) && (usr.getUserB() != null))
							{
								differentUsers.Add(usr);
							}
							else if (usr.getUserA() == null)
							{
								usersMissingInDb1.Add(usr.getUserB());
							}
							else
							{
								usersMissingInDb2.Add(usr.getUserA());
							}
						}
					}
				}
			}
		}
	   
		public bool jePrip1Aktivne()
		{
			return db1.jeAktivne();
		}

		public bool jePrip2Aktivne()
		{
			return db2.jeAktivne();
		}


		public DBsyncTreeview vyrobStromA()
		{

			DBsyncTvEmptyType hlavny = new DBsyncTvEmptyType(DatabaseDifferences.getNameA(), DBsyncTreeview.DatabaseIcon);
			DBsyncTvEmptyType tabb = new DBsyncTvEmptyType("Tables", DBsyncTreeview.TablesIcon);
			if (DatabaseDifferences.AreDiffTables()) tabb.Azvyraznene = true;
			hlavny.Nodes.Add(tabb);
			foreach (DbSyncTableDiff tab in DatabaseDifferences.getTablediff())
			{
				Tablee tabA = tab.getTabA();
				if (tabA != null)
				{
					DBsyncTvTableType novy = new DBsyncTvTableType(tabA);
					if (tab.isDifferent()) novy.Azvyraznene = true;

					DBsyncTvEmptyType Stlpc = new DBsyncTvEmptyType("Coulumns", DBsyncTreeview.ColumnsIcon);
					
					if (tab.DiffCoulumns()) Stlpc.Azvyraznene = true;
					novy.Nodes.Add(Stlpc);

					foreach (DbSyncColumnDiff s in tab.ColumnsDifList())
					{
						if (s.getColumnA() != null)
						{
							DbsyncTvColumnType novystlpec = new DbsyncTvColumnType(s.getColumnA());
							novystlpec.ObjectAtributesList = s.ColumnAtributesListA;
							if (s.isDifferent()) novystlpec.Azvyraznene = true;
							Stlpc.Nodes.Add(novystlpec);
						}
					}

					DBsyncTvEmptyType keys = new DBsyncTvEmptyType("Keys", DBsyncTreeview.KeysIcon);
					if (tab.DiffKeys()) keys.Azvyraznene = true;
					novy.Nodes.Add(keys);
					foreach (DbSyncKeyDiff k in tab.KeysDifList())
					{
						if (k.getKeyA() != null)
						{
						DbsyncTvKeyType key = new DbsyncTvKeyType(k.getKeyA());
						if (k.Different) key.Azvyraznene = true;
						key.ObjectAtributesList = k.KeyAtributesListA;
						keys.Nodes.Add(key);
						}
					}
					/*foreach (Stlpec s in tabA.Stlpce)
					{
						if (s.Is_primaryKey())
						{
							DbsyncTvKeyType pk = new DbsyncTvKeyType(s);
							keys.Nodes.Add(pk);
						}
						if (s.Is_foreinKey())
						{
							DbsyncTvKeyType fk = new DbsyncTvKeyType(s);
							keys.Nodes.Add(fk);
						}
					}*/

					DBsyncTvEmptyType constr = new DBsyncTvEmptyType("Constraints", DBsyncTreeview.ConstraintsIcon);
					novy.Nodes.Add(constr);
					if (tab.DiffConstraints()) constr.Azvyraznene = true;
					foreach (DbSyncConstraintDiff c in tab.ConstraiontDifList())
					{
						if (c.getConstA() != null)
						{
							if (c.getConstA().Constraint_typ != "DEFAULT")
							{
								DbsyncTvConstraintType con = new DbsyncTvConstraintType(c.getConstA());
								con.ObjectAtributesList = c.ConstraintAtributesListA;
								if (c.isDifferent()) con.Azvyraznene = true;
								constr.Nodes.Add(con);
							}
						}
					}

					DBsyncTvEmptyType trig = new DBsyncTvEmptyType("Triggers", DBsyncTreeview.TriggersIcon);
					novy.Nodes.Add(trig);
					if (tab.DiffTriggers()) trig.Azvyraznene = true;
					foreach (DbSyncTriggerDiff t in tab.TriggerDiffList())
					{
						if (t.getTrigA() != null)
						{
							DbsyncTvTriggerType trg = new DbsyncTvTriggerType(t.getTrigA());
							trg.ObjectAtributesList = t.TriggerAtrListA;
							trg.SqlTextList = t.SqlTextListA;
							if (t.isDiffirent()) trg.Azvyraznene = true;
							trig.Nodes.Add(trg);
						}
					}

					DBsyncTvEmptyType granty = new DBsyncTvEmptyType("Grants", DBsyncTreeview.GrantsIcon);
					novy.Nodes.Add(granty);
					if (tab.DiffPrivileges()) granty.Azvyraznene = true;
					foreach (DbSyncPrivilegeDiff p in tab.PrivilegeDifList())
					{
						if (p.getPrivA() != null)
						{
							DbsyncTvPrivilegeType grnt = new DbsyncTvPrivilegeType(p.getPrivA());
							grnt.ObjectAtributesList = p.PrivAtrListA;
							if (p.isDifferent()) grnt.Azvyraznene = true;
							granty.Nodes.Add(grnt);
						}
					}

					DBsyncTvEmptyType indexyy = new DBsyncTvEmptyType("Indexes", DBsyncTreeview.IndexesIcon);
					novy.Nodes.Add(indexyy);
					if (tab.DiffIndexes()) indexyy.Azvyraznene = true;
					foreach (DbSyncIndexDiff i in tab.IndexesDifList())
					{
						if (i.getIndexA() != null)
						{
							DbsyncTvIndexType iin = new DbsyncTvIndexType(i.getIndexA());
							iin.ObjectAtributesList = i.IndexAtributesListA;
							if (i.isDifferent()) iin.Azvyraznene = true;
							indexyy.Nodes.Add(iin);
						}
					}


					tabb.Nodes.Add(novy);
				}
			}
			DBsyncTvEmptyType procedures = new DBsyncTvEmptyType("Stored procedures", DBsyncTreeview.StoredProceduresIcon);
			if (DatabaseDifferences.AreDiffStoredProcedures()) procedures.Azvyraznene = true;
			hlavny.Nodes.Add(procedures);
			foreach (DbSyncStoredProcedureDiff sp in DatabaseDifferences.getStoredProcedureDiff())
			{
				if (sp.getProcA() != null)
				{
					DbsyncTvStoredProcType novy = new DbsyncTvStoredProcType(sp.getProcA());
					if (sp.isDifferent()) novy.Azvyraznene = true;
					procedures.Nodes.Add(novy);

					DBsyncTvEmptyType granty = new DBsyncTvEmptyType("Grants", DBsyncTreeview.GrantsIcon);
					novy.Nodes.Add(granty);
					novy.ObjectAtributesList = sp.StoredProcDiffListA;
					novy.SqlTextList = sp.SqlTextListA;
					if (sp.DiffPrivileges) granty.Azvyraznene = true;
					foreach (DbSyncPrivilegeDiff p in sp.PrivilegeDifList())
					{
						if (p.getPrivA() != null)
						{
							DbsyncTvPrivilegeType grnt = new DbsyncTvPrivilegeType(p.getPrivA());
							grnt.ObjectAtributesList = p.PrivAtrListA;
							if (p.isDifferent()) grnt.Azvyraznene = true;
							granty.Nodes.Add(grnt);
						}
					}
				}

				

			}
			DBsyncTvEmptyType funkc = new DBsyncTvEmptyType("Functions", DBsyncTreeview.FunctionsIcon);
			if (DatabaseDifferences.AreDiffFunctions()) funkc.Azvyraznene = true;
			hlavny.Nodes.Add(funkc);
			foreach (DbSyncFunctionDiff sf in DatabaseDifferences.getFunctionDiff())
			{
				if (sf.getFunctionA() != null)
				{
					DbsyncTvFunctionType novy = new DbsyncTvFunctionType(sf.getFunctionA());
					novy.ObjectAtributesList = sf.FunctionAtributesA;
					novy.SqlTextList = sf.SqlTextListA;
					if (sf.isDifferent()) novy.Azvyraznene = true;
					funkc.Nodes.Add(novy);

					DBsyncTvEmptyType granty = new DBsyncTvEmptyType("Grants", DBsyncTreeview.GrantsIcon);
					novy.Nodes.Add(granty);
					novy.ObjectAtributesList = sf.FunctionAtributesA;
					if (sf.DiffPrivileges) granty.Azvyraznene = true;
					foreach (DbSyncPrivilegeDiff p in sf.PrivilegeDiffList)
					{
						if (p.getPrivA() != null)
						{
							DbsyncTvPrivilegeType grnt = new DbsyncTvPrivilegeType(p.getPrivA());
							grnt.ObjectAtributesList = p.PrivAtrListA;
							if (p.isDifferent()) grnt.Azvyraznene = true;
							granty.Nodes.Add(grnt);
						}
					}
				}
			}

			DBsyncTvEmptyType types = new DBsyncTvEmptyType("Types", DBsyncTreeview.TypesIcon);
			if (DatabaseDifferences.AreDiffTypes()) types.Azvyraznene = true;
			hlavny.Nodes.Add(types);
			foreach (DbSyncTypeDiff tp in DatabaseDifferences.getTypesDiff())
			{
				if (tp.getTypeA() != null)
				{
					DbsyncTvTypeType novy = new DbsyncTvTypeType(tp.getTypeA());
					novy.ObjectAtributesList = tp.TypeAtributesA;
					if (tp.isDifferent()) novy.Azvyraznene = true;
					types.Nodes.Add(novy);
				}
			}
			DBsyncTvEmptyType users = new DBsyncTvEmptyType("Users", DBsyncTreeview.UsersIcon);
			if (DatabaseDifferences.AreDiffUSers()) users.Azvyraznene = true;
			hlavny.Nodes.Add(users);
			foreach (DbSyncUserDiff usr in DatabaseDifferences.getUserDiff())
			{
				if (usr.getUserA() != null)
				{
					DbsyncTvUserType novy = new DbsyncTvUserType(usr.getUserA());
					novy.ObjectAtributesList = usr.UserAtributesA;
					if (usr.isDifferent()) novy.Azvyraznene = true;
					users.Nodes.Add(novy);
				}
			}


			return hlavny;
		}

		public DBsyncTreeview vyrobStromB()
		{

			DBsyncTvEmptyType hlavny = new DBsyncTvEmptyType(DatabaseDifferences.getNameB(), DBsyncTreeview.DatabaseIcon);
			DBsyncTvEmptyType tabb = new DBsyncTvEmptyType("Tables", DBsyncTreeview.TablesIcon);
			if (DatabaseDifferences.AreDiffTables()) tabb.Azvyraznene = true;
			hlavny.Nodes.Add(tabb);
			foreach (DbSyncTableDiff tab in DatabaseDifferences.getTablediff())
			{
				Tablee tabB = tab.getTabB();
				if (tabB != null)
				{
					DBsyncTvTableType novy = new DBsyncTvTableType(tabB);
					if (tab.isDifferent()) novy.Azvyraznene = true;

					DBsyncTvEmptyType Stlpc = new DBsyncTvEmptyType("Coulumns", DBsyncTreeview.ColumnsIcon);
					if (tab.DiffCoulumns()) Stlpc.Azvyraznene = true;
					novy.Nodes.Add(Stlpc);

					foreach (DbSyncColumnDiff s in tab.ColumnsDifList())
					{
						if (s.getColumnB() != null)
						{
							DbsyncTvColumnType novystlpec = new DbsyncTvColumnType(s.getColumnB());
							novystlpec.ObjectAtributesList = s.ColumnAtributesListB;
							if (s.isDifferent()) novystlpec.Azvyraznene = true;
							Stlpc.Nodes.Add(novystlpec);
						}
					}

					DBsyncTvEmptyType keys = new DBsyncTvEmptyType("Keys", DBsyncTreeview.KeysIcon);
					if (tab.DiffKeys()) keys.Azvyraznene = true;
					novy.Nodes.Add(keys);
					foreach (DbSyncKeyDiff k in tab.KeysDifList())
					{
						if (k.getKeyB() != null)
						{
							DbsyncTvKeyType key = new DbsyncTvKeyType(k.getKeyB());
							if (k.Different) key.Azvyraznene = true;
							key.ObjectAtributesList = k.KeyAtributesListB;
							keys.Nodes.Add(key);
						}
					}
					/*foreach (Stlpec s in tabB.Stlpce)
					{
						if (s.Is_primaryKey())
						{
							DbsyncTvKeyType pk = new DbsyncTvKeyType(s);
							keys.Nodes.Add(pk);
						}
						if (s.Is_foreinKey())
						{
							DbsyncTvKeyType fk = new DbsyncTvKeyType(s);
							keys.Nodes.Add(fk);
						}
					}*/

					DBsyncTvEmptyType constr = new DBsyncTvEmptyType("Constraints", DBsyncTreeview.ConstraintsIcon);
					novy.Nodes.Add(constr);
					if (tab.DiffConstraints()) constr.Azvyraznene = true;
					foreach (DbSyncConstraintDiff c in tab.ConstraiontDifList())
					{
						if (c.getConstB() != null)
						{
							if (c.getConstB().Constraint_typ != "DEFAULT")
							{
								DbsyncTvConstraintType con = new DbsyncTvConstraintType(c.getConstB());
								con.ObjectAtributesList = c.ConstraintAtributesListB;
								if (c.isDifferent()) con.Azvyraznene = true;
								constr.Nodes.Add(con);
							}
						}
					}

					DBsyncTvEmptyType trig = new DBsyncTvEmptyType("Triggers", DBsyncTreeview.TriggersIcon);
					novy.Nodes.Add(trig);
					if (tab.DiffTriggers()) trig.Azvyraznene = true;
					foreach (DbSyncTriggerDiff t in tab.TriggerDiffList())
					{
						if (t.getTrigB() != null)
						{
							DbsyncTvTriggerType trg = new DbsyncTvTriggerType(t.getTrigB());
							trg.ObjectAtributesList = t.TriggerAtrListB;
							trg.SqlTextList = t.SqlTextListB;
							if (t.isDiffirent()) trg.Azvyraznene = true;
							trig.Nodes.Add(trg);
						}
					}

					DBsyncTvEmptyType granty = new DBsyncTvEmptyType("Grants", DBsyncTreeview.GrantsIcon);
					novy.Nodes.Add(granty);
					if (tab.DiffPrivileges()) granty.Azvyraznene = true;
					foreach (DbSyncPrivilegeDiff p in tab.PrivilegeDifList())
					{
						if (p.getPrivB() != null)
						{
							DbsyncTvPrivilegeType grnt = new DbsyncTvPrivilegeType(p.getPrivB());
							grnt.ObjectAtributesList = p.PrivAtrListB;
							if (p.isDifferent()) grnt.Azvyraznene = true;
							granty.Nodes.Add(grnt);
						}
					}

					DBsyncTvEmptyType indexyy = new DBsyncTvEmptyType("Indexes", DBsyncTreeview.IndexesIcon);
					novy.Nodes.Add(indexyy);
					if (tab.DiffIndexes()) indexyy.Azvyraznene = true;
					foreach (DbSyncIndexDiff i in tab.IndexesDifList())
					{
						if (i.getIndexB() != null)
						{
							DbsyncTvIndexType iin = new DbsyncTvIndexType(i.getIndexB());
							iin.ObjectAtributesList = i.IndexAtributesListB;
							if (i.isDifferent()) iin.Azvyraznene = true;
							indexyy.Nodes.Add(iin);
						}
					}


					tabb.Nodes.Add(novy);
				}
			}
			DBsyncTvEmptyType procedures = new DBsyncTvEmptyType("Stored procedures", DBsyncTreeview.StoredProceduresIcon);
			if (DatabaseDifferences.AreDiffStoredProcedures()) procedures.Azvyraznene = true;
			hlavny.Nodes.Add(procedures);
			foreach (DbSyncStoredProcedureDiff sp in DatabaseDifferences.getStoredProcedureDiff())
			{
				if (sp.getProcB() != null)
				{
					DbsyncTvStoredProcType novy = new DbsyncTvStoredProcType(sp.getProcB());
					if (sp.isDifferent()) novy.Azvyraznene = true;
					novy.SqlTextList = sp.SqlTextListB;
					novy.ObjectAtributesList = sp.StoredProcDiffListB;
					procedures.Nodes.Add(novy);

					DBsyncTvEmptyType granty = new DBsyncTvEmptyType("Grants", DBsyncTreeview.GrantsIcon);
					novy.Nodes.Add(granty);
					if (sp.DiffPrivileges) granty.Azvyraznene = true;
					foreach (DbSyncPrivilegeDiff p in sp.PrivilegeDifList())
					{
						if (p.getPrivB() != null)
						{
							DbsyncTvPrivilegeType grnt = new DbsyncTvPrivilegeType(p.getPrivB());
							grnt.ObjectAtributesList = p.PrivAtrListB;
							if (p.isDifferent()) grnt.Azvyraznene = true;
							granty.Nodes.Add(grnt);
						}
					}
				}
			}
			DBsyncTvEmptyType funkc = new DBsyncTvEmptyType("Functions", DBsyncTreeview.FunctionsIcon);
			if (DatabaseDifferences.AreDiffFunctions()) funkc.Azvyraznene = true;
			hlavny.Nodes.Add(funkc);
			foreach (DbSyncFunctionDiff sf in DatabaseDifferences.getFunctionDiff())
			{
				if (sf.getFunctionB() != null)
				{
					DbsyncTvFunctionType novy = new DbsyncTvFunctionType(sf.getFunctionB());
					novy.ObjectAtributesList = sf.FunctionAtributesB;
					novy.SqlTextList = sf.SqlTextListB;
					if (sf.isDifferent()) novy.Azvyraznene = true;
					funkc.Nodes.Add(novy);

					DBsyncTvEmptyType granty = new DBsyncTvEmptyType("Grants", DBsyncTreeview.GrantsIcon);
					novy.Nodes.Add(granty);
					novy.ObjectAtributesList = sf.FunctionAtributesB;
					if (sf.DiffPrivileges) granty.Azvyraznene = true;
					foreach (DbSyncPrivilegeDiff p in sf.PrivilegeDiffList)
					{
						if (p.getPrivB() != null)
						{
							DbsyncTvPrivilegeType grnt = new DbsyncTvPrivilegeType(p.getPrivB());
							grnt.ObjectAtributesList = p.PrivAtrListB;
							if (p.isDifferent()) grnt.Azvyraznene = true;
							granty.Nodes.Add(grnt);
						}
					}
				}
			}

			DBsyncTvEmptyType types = new DBsyncTvEmptyType("Types", DBsyncTreeview.TypesIcon);
			if (DatabaseDifferences.AreDiffTypes()) types.Azvyraznene = true;
			hlavny.Nodes.Add(types);
			foreach (DbSyncTypeDiff tp in DatabaseDifferences.getTypesDiff())
			{
				if (tp.getTypeB() != null)
				{
					DbsyncTvTypeType novy = new DbsyncTvTypeType(tp.getTypeB());
					novy.ObjectAtributesList = tp.TypeAtributesB;
					if (tp.isDifferent()) novy.Azvyraznene = true;
					types.Nodes.Add(novy);
				}
			}
			DBsyncTvEmptyType users = new DBsyncTvEmptyType("Users", DBsyncTreeview.UsersIcon);
			if (DatabaseDifferences.AreDiffUSers()) users.Azvyraznene = true;
			hlavny.Nodes.Add(users);
			foreach (DbSyncUserDiff usr in DatabaseDifferences.getUserDiff())
			{
				if (usr.getUserB() != null)
				{
					DbsyncTvUserType novy = new DbsyncTvUserType(usr.getUserB());
					novy.ObjectAtributesList = usr.UserAtributesB;
					if (usr.isDifferent()) novy.Azvyraznene = true;
					users.Nodes.Add(novy);
				}
			}


			return hlavny;
		}

		public void refreshConnections()
		{
			db1.ReadData();
			db2.ReadData();
			DatabaseDifferences = new DbSyncDataBaseDiff(db1, db2);
			fullfillLists();
			aktualizujVypis(this, new EventArgs());
		}
	   
		public bool createConnections(Connectionc con1, Connectionc con2)
		{
			bool db1OK = false;
			bool db2OK = false;
			db1.setConnection(con1);
			if (db1.ReadData())
			{
				db1OK = true;
			}
			db2.setConnection(con2);
			if (db2.ReadData())
			{
				db2OK = true;
			}
			if (db1OK && db2OK)
			{
				DatabaseDifferences = new DbSyncDataBaseDiff(db1, db2);
				fullfillLists();
				//aktualizujVypis(this, new EventArgs());
				return true;
			}
			else return false;
					}

		public List<string> addMissingColumnsToTables(List<DbSyncTableDiff> tables)
		{
			List<string> output = new List<string>();
			if (settings.ComparisonMethod == ComparatorSettings.LeftRight || settings.ComparisonMethod == ComparatorSettings.LeftRightDel)
			{
				foreach (DbSyncTableDiff tabIn in tables)
				{
					//missing columns
					foreach (Columnn coll in tabIn.ColumnsMissingDb2)
					{
						output.AddRange(db1.prip.addcolumn(tabIn.getTabA(), coll));
					}
				}
			}
			
		   if (settings.ComparisonMethod == ComparatorSettings.RightLeft || settings.ComparisonMethod == ComparatorSettings.RightLeftDel)
			{
				foreach (DbSyncTableDiff tabIn in tables)
				{
					//missing columns
					foreach (Columnn coll in tabIn.ColumnsMissingDb1)
					{
						output.AddRange(db1.prip.addcolumn(tabIn.getTabB(), coll));
					}
				}

			}

		   

			return output;
		}
 
		public List<string> syncTable(DbSyncTableDiff tabIn)
		{
			List<string> output = new List<string>();
			if (settings.ComparisonMethod == ComparatorSettings.LeftRight )
			{
				//missing objects
				foreach (DbSyncColumnDiff col in tabIn.ColumnsDifferent)
				{
					output.AddRange(db1.prip.alterColumn(tabIn.getTabB(), col.getColumnA()));
				}
				
				foreach (Trigger trg in tabIn.TriggersMissingDb2)
				{
					output.AddRange(db1.prip.addTrigger(tabIn.getTabB(), trg));
				}
				foreach (Privilege priv in tabIn.GrantsMissingDb2)
				{
					output.Add(db1.prip.createPrivilege(priv));
				}
				foreach (Index ind in tabIn.IndexesMissingDb2)
				{
					output.AddRange(db1.prip.addIndex(tabIn.getTabB(), ind));
				}
				foreach (Constraintt con in tabIn.ConstraintsMissingDb2)
				{
					output.AddRange(db1.prip.addConstraint(tabIn.getTabB(), con));
				}
				foreach (Key keyy in tabIn.KeysMissingDb2)
				{
					output.AddRange(db1.prip.addKey(tabIn.getTabB(), keyy));
				}
				//objects to rewrite
				foreach (DbSyncIndexDiff ind in tabIn.IndexesDifferent)
				{
					output.AddRange(db1.prip.alterIndex(tabIn.getTabB(), ind.getIndexA()));
				}
				foreach (DbSyncPrivilegeDiff priv in tabIn.GrantsDifferent)
				{
					output.AddRange(db1.prip.alterPrivilege(priv.getPrivB()));
				}
				foreach (DbSyncTriggerDiff trg in tabIn.TriggersDifferent)
				{
					output.AddRange(db1.prip.alterTrigger(tabIn.getTabB(), trg.getTrigA()));
				}
				foreach (DbSyncKeyDiff key in tabIn.KeysDifferent)
				{
					output.AddRange(db1.prip.alterKey(tabIn.getTabB(), key.getKeyA()));
				}
				foreach (DbSyncConstraintDiff con in tabIn.ConstraintsDifferent)
				{
					output.AddRange(db1.prip.alterConstraint(tabIn.getTabB(), con.getConstA()));
				}
				

			}

			if (settings.ComparisonMethod == ComparatorSettings.LeftRightDel)
			{
				//missing objects

				foreach (DbSyncColumnDiff col in tabIn.ColumnsDifferent)
				{
					output.AddRange(db1.prip.alterColumn(tabIn.getTabB(), col.getColumnA()));
				}
				foreach (Trigger trg in tabIn.TriggersMissingDb2)
				{
					output.AddRange(db1.prip.addTrigger(tabIn.getTabB(), trg));
				}
				foreach (Privilege priv in tabIn.GrantsMissingDb2)
				{
					output.Add(db1.prip.createPrivilege(priv));
				}
				foreach (Index ind in tabIn.IndexesMissingDb2)
				{
					output.AddRange(db1.prip.addIndex(tabIn.getTabB(), ind));
				}
				foreach (Constraintt con in tabIn.ConstraintsMissingDb2)
				{
					output.AddRange(db1.prip.addConstraint(tabIn.getTabB(), con));
				}
				foreach (Key keyy in tabIn.KeysMissingDb2)
				{
					output.AddRange(db1.prip.addKey(tabIn.getTabB(), keyy));
				}
				//objects to delete
				foreach (Index ind in tabIn.IndexesMissingDb1)
				{
					output.AddRange(db1.prip.removeIndex(tabIn.getTabB(), ind));
				}
				foreach (Trigger trg in tabIn.TriggersMissingDb1)
				{
					output.AddRange(db1.prip.removeTrigger(tabIn.getTabB(), trg));
				}
				foreach (Key keyy in tabIn.KeysMissingDb1)
				{
					output.AddRange(db1.prip.removeKey(tabIn.getTabB(), keyy));
				}
				foreach (Constraintt con in tabIn.ConstraintsMissingDb1)
				{
					output.AddRange(db1.prip.removeConstraint(tabIn.getTabB(), con));
				}
				foreach (Privilege priv in tabIn.GrantsMissingDb1)
				{
					output.AddRange(db1.prip.removePrivilege(priv));
				}
				foreach (Columnn col in tabIn.ColumnsMissingDb1)
				{
					output.AddRange(db1.prip.removeColumn(tabIn.getTabB(), col));
				}
				//objects to rewrite
				foreach (DbSyncIndexDiff ind in tabIn.IndexesDifferent)
				{
					output.AddRange(db1.prip.alterIndex(tabIn.getTabB(), ind.getIndexA()));
				}
				foreach (DbSyncPrivilegeDiff priv in tabIn.GrantsDifferent)
				{
					output.AddRange(db1.prip.alterPrivilege(priv.getPrivA()));
				}
				foreach (DbSyncTriggerDiff trg in tabIn.TriggersDifferent)
				{
					output.AddRange(db1.prip.alterTrigger(tabIn.getTabB(), trg.getTrigA()));
				}
				foreach (DbSyncKeyDiff key in tabIn.KeysDifferent)
				{
					output.AddRange(db1.prip.alterKey(tabIn.getTabB(), key.getKeyA()));
				}
				foreach (DbSyncConstraintDiff con in tabIn.ConstraintsDifferent)
				{
					output.AddRange(db1.prip.alterConstraint(tabIn.getTabB(), con.getConstA()));
				}
				
			}

			if (settings.ComparisonMethod == ComparatorSettings.RightLeft )
			{
				//missing objects
				foreach (DbSyncColumnDiff col in tabIn.ColumnsDifferent)
				{
					output.AddRange(db1.prip.alterColumn(tabIn.getTabA(), col.getColumnB()));
				}
				foreach (Trigger trg in tabIn.TriggersMissingDb1)
				{
					output.AddRange(db1.prip.addTrigger(tabIn.getTabA(), trg));
				}
				foreach (Privilege priv in tabIn.GrantsMissingDb1)
				{
					output.Add(db1.prip.createPrivilege(priv));
				}
				foreach (Index ind in tabIn.IndexesMissingDb1)
				{
					output.AddRange(db1.prip.addIndex(tabIn.getTabA(), ind));
				}
				foreach (Constraintt con in tabIn.ConstraintsMissingDb1)
				{
					output.AddRange(db1.prip.addConstraint(tabIn.getTabA(), con));
				}
				foreach (Key keyy in tabIn.KeysMissingDb1)
				{
					output.AddRange(db1.prip.addKey(tabIn.getTabA(), keyy));
				}
				//objects to rewrite
				foreach (DbSyncIndexDiff ind in tabIn.IndexesDifferent)
				{
					output.AddRange(db1.prip.alterIndex(tabIn.getTabA(), ind.getIndexB()));
				}
				foreach (DbSyncPrivilegeDiff priv in tabIn.GrantsDifferent)
				{
					output.AddRange(db1.prip.alterPrivilege(priv.getPrivA()));
				}
				foreach (DbSyncTriggerDiff trg in tabIn.TriggersDifferent)
				{
					output.AddRange(db1.prip.alterTrigger(tabIn.getTabA(), trg.getTrigB()));
				}
				foreach (DbSyncKeyDiff key in tabIn.KeysDifferent)
				{
					output.AddRange(db1.prip.alterKey(tabIn.getTabA(), key.getKeyB()));
				}
				foreach (DbSyncConstraintDiff con in tabIn.ConstraintsDifferent)
				{
					output.AddRange(db1.prip.alterConstraint(tabIn.getTabA(), con.getConstB()));
				}
				
			   
			}

			if (settings.ComparisonMethod == ComparatorSettings.RightLeftDel)
			{
				//missing objects
				foreach (DbSyncColumnDiff col in tabIn.ColumnsDifferent)
				{
					output.AddRange(db1.prip.alterColumn(tabIn.getTabA(), col.getColumnB()));
				}
				foreach (Trigger trg in tabIn.TriggersMissingDb1)
				{
					output.AddRange(db1.prip.addTrigger(tabIn.getTabA(), trg));
				}
				foreach (Privilege priv in tabIn.GrantsMissingDb1)
				{
					output.Add(db1.prip.createPrivilege(priv));
				}
				foreach (Index ind in tabIn.IndexesMissingDb1)
				{
					output.AddRange(db1.prip.addIndex(tabIn.getTabA(), ind));
				}
				foreach (Constraintt con in tabIn.ConstraintsMissingDb1)
				{
					output.AddRange(db1.prip.addConstraint(tabIn.getTabA(), con));
				}
				foreach (Key keyy in tabIn.KeysMissingDb1)
				{
					output.AddRange(db1.prip.addKey(tabIn.getTabA(), keyy));
				}
				//objects to delete
				foreach (Index ind in tabIn.IndexesMissingDb2)
				{
					output.AddRange(db1.prip.removeIndex(tabIn.getTabA(), ind));
				}
				foreach (Trigger trg in tabIn.TriggersMissingDb2)
				{
					output.AddRange(db1.prip.removeTrigger(tabIn.getTabA(), trg));
				}
				foreach (Key keyy in tabIn.KeysMissingDb2)
				{
					output.AddRange(db1.prip.removeKey(tabIn.getTabA(), keyy));
				}
				foreach (Constraintt con in tabIn.ConstraintsMissingDb2)
				{
					output.AddRange(db1.prip.removeConstraint(tabIn.getTabA(), con));
				}
				foreach (Privilege priv in tabIn.GrantsMissingDb2)
				{
					output.AddRange(db1.prip.removePrivilege(priv));
				}
				foreach (Columnn col in tabIn.ColumnsMissingDb2)
				{
					output.AddRange(db1.prip.removeColumn(tabIn.getTabA(), col));
				}
				//objects to rewrite
				foreach (DbSyncIndexDiff ind in tabIn.IndexesDifferent)
				{
					output.AddRange(db1.prip.alterIndex(tabIn.getTabA(), ind.getIndexB()));
				}
				foreach (DbSyncPrivilegeDiff priv in tabIn.GrantsDifferent)
				{
					output.AddRange(db1.prip.alterPrivilege(priv.getPrivB()));
				}
				foreach (DbSyncTriggerDiff trg in tabIn.TriggersDifferent)
				{
					output.AddRange(db1.prip.alterTrigger(tabIn.getTabA(), trg.getTrigB()));
				}
				foreach (DbSyncKeyDiff key in tabIn.KeysDifferent)
				{
					output.AddRange(db1.prip.alterKey(tabIn.getTabA(), key.getKeyB()));
				}
				foreach (DbSyncConstraintDiff con in tabIn.ConstraintsDifferent)
				{
					output.AddRange(db1.prip.alterConstraint(tabIn.getTabA(), con.getConstB()));
				}
				

			}

			return output;
		}
	   
		public List<string> generateScriptsForDb1()
		{
			List<string> output = new List<string>();

			//--------------------------------------------------RIGHT TO LEFT COMPARISON SCRIPTS FOR DB2---------------------------------------------------------------
			if (settings.ComparisonMethod == ComparatorSettings.RightLeft)
			{
				// objects to create
				if (settings.SyncProcedures)
				{
					foreach (SProcedure proc in proceduresMissingInDb1)
					{
						output.AddRange(db1.prip.createProcedure(proc));
					}
				}

				if (settings.SyncFunctions)
				{
					foreach (SFunction funct in functionsMissingInDb1)
					{
						output.AddRange(db1.prip.createFunction(funct));
					}
				}

				if (settings.SyncTypes)
				{
					foreach (Typ typp in typesMissingInDb1)
					{
						output.Add(db1.prip.createType(typp));
					}
				}

				if (settings.SyncUsers)
				{
					foreach (User usr in usersMissingInDb1)
					{
						output.AddRange(db1.prip.createUser(usr));
					}
				}
				if (settings.SyncTables)
				{
					foreach (Tablee tab in tablesMissingInDb1)
					{
						output.AddRange(db1.prip.createTable(tab));
					}
				}


				//objects to rewrite
				if (settings.SyncProcedures)
				{
					foreach (DbSyncStoredProcedureDiff proc in differentProcedures)
					{
						SProcedure procc = proc.getProcB();
						output.AddRange(db1.prip.alterProcedure(procc));
					}
				}

				if (settings.SyncFunctions)
				{
					foreach (DbSyncFunctionDiff funkc in differentFunctions)
					{
						SFunction funkcc = funkc.getFunctionB();
						output.AddRange(db1.prip.alterFunction(funkcc));
					}
				}
				if (settings.SyncTables)
				{
					output.AddRange(addMissingColumnsToTables(differentTables));
					foreach (DbSyncTableDiff tab in differentTables)
					{
					   
						output.AddRange(syncTable(tab));
					}
				}
				if (settings.SyncTypes)
				{
					foreach (DbSyncTypeDiff tt in differentTypes)
					{
						output.AddRange(db1.prip.alterType(tt.getTypeB()));
					}

				}



			}
			//--------------------------------------------------END OF RIGHT TO LEFT COMPARISON SCRIPTS FOR DB1---------------------------------------------------------------
			//--------------------------------------------------RIGHT TO LEFT COMPARISON WHITH DELETING SCRIPTS FOR DB1---------------------------------------------------------------
			if (settings.ComparisonMethod == ComparatorSettings.RightLeftDel)
			{
				// objects to create
				if (settings.SyncProcedures)
				{
					foreach (SProcedure proc in proceduresMissingInDb1)
					{
						output.AddRange(db1.prip.createProcedure(proc));
					}
				}

				if (settings.SyncFunctions)
				{
					foreach (SFunction funct in functionsMissingInDb1)
					{
						output.AddRange(db1.prip.createFunction(funct));
					}
				}

				if (settings.SyncTypes)
				{
					foreach (Typ typp in typesMissingInDb1)
					{
						output.Add(db1.prip.createType(typp));
					}
				}

				if (settings.SyncUsers)
				{
					foreach (User usr in usersMissingInDb1)
					{
						output.AddRange(db1.prip.createUser(usr));
					}
				}
				if (settings.SyncTables)
				{
					foreach (Tablee tab in tablesMissingInDb1)
					{
						output.AddRange(db1.prip.createTable(tab));
					}
				}
			   
				//objects to rewrite
				if (settings.SyncProcedures)
				{
					foreach (DbSyncStoredProcedureDiff proc in differentProcedures)
					{
						SProcedure procc = proc.getProcB();
						output.AddRange(db1.prip.alterProcedure(procc));
					}
				}

				if (settings.SyncFunctions)
				{
					foreach (DbSyncFunctionDiff funkc in differentFunctions)
					{
						SFunction funkcc = funkc.getFunctionB();
						output.AddRange(db1.prip.alterFunction(funkcc));
					}
				}

				if (settings.SyncTables)
				{
					output.AddRange(addMissingColumnsToTables(differentTables));
					foreach (DbSyncTableDiff tab in differentTables)
					{
						output.AddRange(syncTable(tab));
					}
				}
				if (settings.SyncTypes)
				{
					foreach (DbSyncTypeDiff tt in differentTypes)
					{
						output.AddRange(db1.prip.alterType(tt.getTypeB()));
					}

				}

				//odstranenie nadbytocnych objektov
				if (settings.SyncFunctions)
				{
					foreach (SFunction funkc in functionsMissingInDb2)
					{
						output.AddRange(db1.prip.removeFunction(funkc));
					}
				}

				if (settings.SyncProcedures)
				{
					foreach (SProcedure proc in proceduresMissingInDb2)
					{
						output.AddRange(db1.prip.removeProcedure(proc));
					}
				}

				if (settings.SyncTables)
				{
					//najprv zrusim cudzie kluce
					foreach (Tablee tab in tablesMissingInDb2)
					{
						output.AddRange(db1.prip.removeFKonTab(tab));
					}
					foreach (Tablee tab in tablesMissingInDb2)
					{
						output.AddRange(db1.prip.removeTable(tab));
					}

				}
				if (settings.SyncTypes)
				{
					foreach (Typ t in typesMissingInDb2)
					{
						output.AddRange(db1.prip.removeType(t));
					}
				}

			}
			//---------------------------------------------END OF RIGHT TO LEFT COMPARISON WHITH DELETING SCRIPTS FOR DB1---------------------------------------------------------------
			//---------------------------------------------TWO WAY SYNCHRONIZATION---------------------------------------------------------------------------
			if (settings.ComparisonMethod == ComparatorSettings.TwoWay)
			{
				// objects to create
				if (settings.SyncProcedures)
				{
					foreach (SProcedure proc in proceduresMissingInDb1)
					{
						output.AddRange(db1.prip.createProcedure(proc));
					}
				}

				if (settings.SyncFunctions)
				{
					foreach (SFunction funct in functionsMissingInDb1)
					{
						output.AddRange(db1.prip.createFunction(funct));
					}
				}

				if (settings.SyncTypes)
				{
					foreach (Typ typp in typesMissingInDb1)
					{
						output.Add(db1.prip.createType(typp));
					}
				}

				if (settings.SyncUsers)
				{
					foreach (User usr in usersMissingInDb1)
					{
						output.AddRange(db1.prip.createUser(usr));
					}
				}
				if (settings.SyncTables)
				{
					foreach (Tablee tab in tablesMissingInDb1)
					{
						output.AddRange(db1.prip.createTable(tab));
					}
				}
				if (!this.settings.IsDbAPriority)
				{
					//objects to rewrite
					if (settings.SyncProcedures)
					{
						foreach (DbSyncStoredProcedureDiff proc in differentProcedures)
						{
							SProcedure procc = proc.getProcB();
							output.AddRange(db1.prip.alterProcedure(procc));
						}
					}

					if (settings.SyncFunctions)
					{
						foreach (DbSyncFunctionDiff funkc in differentFunctions)
						{
							SFunction funkcc = funkc.getFunctionB();
							output.AddRange(db1.prip.alterFunction(funkcc));
						}
					}

					if (settings.SyncTables)
					{
						output.AddRange(addMissingColumnsToTables(differentTables));
						foreach (DbSyncTableDiff tab in differentTables)
						{
							output.AddRange(syncTable(tab));
						}
					}
					if (settings.SyncTypes)
					{
						foreach (DbSyncTypeDiff tt in differentTypes)
						{
							output.AddRange(db1.prip.alterType(tt.getTypeB()));
						}

					}
				}
			}
			//---------------------------------------------TWO WAY SYNCHRONIZATION---------------------------------------------------------------------------
			return output;
		}

		public List<string> generateScriptsForDb2()
		{
			List<string> output = new List<string>();

			//--------------------------------------------------LEFT TO RIGHT COMPARISON SCRIPTS FOR DB2---------------------------------------------------------------
			if (settings.ComparisonMethod == ComparatorSettings.LeftRight)
			{
				// objects to create
				if (settings.SyncProcedures)
				{
					foreach (SProcedure proc in proceduresMissingInDb2)
					{
						output.AddRange(db2.prip.createProcedure(proc));
					}
				}

				if (settings.SyncFunctions)
				{
					foreach (SFunction funct in functionsMissingInDb2)
					{
						output.AddRange(db2.prip.createFunction(funct));
					}
				}

				if (settings.SyncTypes)
				{
					foreach (Typ typp in typesMissingInDb2)
					{
						output.Add(db2.prip.createType(typp));
					}
				}

				if (settings.SyncUsers)
				{
					foreach (User usr in usersMissingInDb2)
					{
						output.AddRange(db2.prip.createUser(usr));
					}
				}
				if (settings.SyncTables)
				{
					foreach (Tablee tab in tablesMissingInDb2)
					{
						output.AddRange(db2.prip.createTable(tab));
					}
				}
				//prepisu sa objekty db2 tak aby boli rovnake s db1
				if (settings.SyncProcedures)
				{
					foreach (DbSyncStoredProcedureDiff proc in differentProcedures)
					{
						SProcedure procc = proc.getProcA();
						output.AddRange(db2.prip.alterProcedure(procc));
					}
				}

				if (settings.SyncFunctions)
				{
					foreach (DbSyncFunctionDiff funkc in differentFunctions)
					{
						SFunction funkcc = funkc.getFunctionA();
						output.AddRange(db2.prip.alterFunction(funkcc));
					}
				}
				if (settings.SyncTables)
				{
					output.AddRange(addMissingColumnsToTables(differentTables));
					foreach (DbSyncTableDiff tab in differentTables)
					{
						output.AddRange(syncTable(tab));
					}
				}
				if (settings.SyncTypes)
				{
					foreach (DbSyncTypeDiff tt in differentTypes)
					{
						output.AddRange(db1.prip.alterType(tt.getTypeA()));
					}

				}

			}
			//--------------------------------------------------------END OF LEFT TO RIGHT COMPARISON FOR DB2------------------------------------------------------------
			//--------------------------------------------------------LEFT TO RIGHT COMPARISON WHITH DELETING SCRIPTS FOR DB2---------------------------------------------------------------
			if (settings.ComparisonMethod == ComparatorSettings.LeftRightDel)
			{
				// objects to create
				if (settings.SyncProcedures)
				{
					foreach (SProcedure proc in proceduresMissingInDb2)
					{
						output.AddRange(db2.prip.createProcedure(proc));
					}
				}

				if (settings.SyncFunctions)
				{
					foreach (SFunction funct in functionsMissingInDb2)
					{
						output.AddRange(db2.prip.createFunction(funct));
					}
				}

				if (settings.SyncTypes)
				{
					foreach (Typ typp in typesMissingInDb2)
					{
						output.Add(db2.prip.createType(typp));
					}
				}

				if (settings.SyncUsers)
				{
					foreach (User usr in usersMissingInDb2)
					{
						output.AddRange(db2.prip.createUser(usr));
					}
				}
				if (settings.SyncTables)
				{
				   
					foreach (Tablee tab in tablesMissingInDb2)
					{
						output.AddRange(db2.prip.createTable(tab));
					}
				}
				//prepisu sa objekty db2 tak aby boli rovnake s db1

				if (settings.SyncProcedures)
				{
					foreach (DbSyncStoredProcedureDiff proc in differentProcedures)
					{
						SProcedure procc = proc.getProcA();
						output.AddRange(db1.prip.alterProcedure(procc));
					}
				}

				if (settings.SyncFunctions)
				{
					foreach (DbSyncFunctionDiff funkc in differentFunctions)
					{
						SFunction funkcc = funkc.getFunctionA();
						output.AddRange(db1.prip.alterFunction(funkcc));
					}
				}
				if (settings.SyncTables)
				{
					output.AddRange(addMissingColumnsToTables(differentTables));
					foreach (DbSyncTableDiff tab in differentTables)
					{
						output.AddRange(syncTable(tab));
					}
				}
				if (settings.SyncTypes)
				{
					foreach (DbSyncTypeDiff tt in differentTypes)
					{
						output.AddRange(db1.prip.alterType(tt.getTypeA()));
					}
					
				}

				//odstranenie nadbytocnych objektov
				if (settings.SyncFunctions)
				{
					foreach (SFunction funkc in functionsMissingInDb1)
					{
						output.AddRange(db2.prip.removeFunction(funkc));
					}
				}

				if (settings.SyncProcedures)
				{
					foreach (SProcedure proc in proceduresMissingInDb1)
					{
						output.AddRange(db2.prip.removeProcedure(proc));
					}
				}

				if (settings.SyncTables)
				{
					//najprv zrusim cudzie kluce
					foreach (Tablee tab in tablesMissingInDb1)
					{
						output.AddRange(db2.prip.removeFKonTab(tab));
					}
					foreach (Tablee tab in tablesMissingInDb1)
					{
						output.AddRange(db2.prip.removeTable(tab));
					}

				}
				if (settings.SyncTypes)
				{
					foreach (Typ t in typesMissingInDb1)
					{
						output.AddRange(db2.prip.removeType(t));
					}
				}
			}
				//---------------------------------------------------END OF LEFT TO RIGHT COMPARISON WHITH DELETING SCRIPTS FOR DB2---------------------------------------------------------------
				//---------------------------------------------------TWO WAY SYNC-----------------------------------------------------------------------------------------------------------------
				// objects to create
				if (settings.ComparisonMethod == ComparatorSettings.TwoWay)
				{
					if (settings.SyncProcedures)
					{
						foreach (SProcedure proc in proceduresMissingInDb2)
						{
							output.AddRange(db2.prip.createProcedure(proc));
						}
					}

					if (settings.SyncFunctions)
					{
						foreach (SFunction funct in functionsMissingInDb2)
						{
							output.AddRange(db2.prip.createFunction(funct));
						}
					}

					if (settings.SyncTypes)
					{
						foreach (Typ typp in typesMissingInDb2)
						{
							output.Add(db2.prip.createType(typp));
						}
					}

					if (settings.SyncUsers)
					{
						foreach (User usr in usersMissingInDb2)
						{
							output.AddRange(db2.prip.createUser(usr));
						}
					}
					if (settings.SyncTables)
					{

						foreach (Tablee tab in tablesMissingInDb2)
						{
							output.AddRange(db2.prip.createTable(tab));
						}
					}

					if (this.settings.IsDbAPriority)
					{
						if (settings.SyncProcedures)
						{
							foreach (DbSyncStoredProcedureDiff proc in differentProcedures)
							{
								SProcedure procc = proc.getProcA();
								output.AddRange(db1.prip.alterProcedure(procc));
							}
						}

						if (settings.SyncFunctions)
						{
							foreach (DbSyncFunctionDiff funkc in differentFunctions)
							{
								SFunction funkcc = funkc.getFunctionA();
								output.AddRange(db1.prip.alterFunction(funkcc));
							}
						}
						if (settings.SyncTables)
						{
							output.AddRange(addMissingColumnsToTables(differentTables));
							foreach (DbSyncTableDiff tab in differentTables)
							{
								output.AddRange(syncTable(tab));
							}
						}
						if (settings.SyncTypes)
						{
							foreach (DbSyncTypeDiff tt in differentTypes)
							{
								output.AddRange(db1.prip.alterType(tt.getTypeA()));
							}

						}
					}
				}
				//---------------------------------------------------END OF TWO WAY SYNC
			

			return output;
		}

		public List<string> generateDataScriptsForDB2(DbSyncTableDiff tab)
		{
			List<string> output = new List<string>();
			if (!tab.isDifferent())
			{
				int havePrimaryKey = 0;
				bool simplePK = false;
				Key kk = null;
				foreach (DbSyncKeyDiff k in tab.KeysDifList())
				{
					if (k.getKeyA().PrimaryKey)
					{
						havePrimaryKey++;
						if (k.getKeyA().NameOfColumns.Count == 1)
						{
							simplePK = true;
							kk = k.getKeyA();
						}
					}
				}

					if ((havePrimaryKey == 1) && simplePK)
					{
						if (this.settings.ComparisonMethod == ComparatorSettings.LeftRight)
						{
							DbDataReader red1 = db1.prip.getReaderOfTable(tab.getTableName(),"","");
							while (red1.Read())
							{
								bool differentExist = false;
								bool differentNotExist = false;
								List<ColVal> cvlist = new List<ColVal>();
								string key = red1[kk.NameOfColumns[0]].ToString();
								DbDataReader red2 = db2.prip.getReaderOfTable(tab.getTableName(), kk.NameOfColumns[0], key);
								if (red2.Read())
								{

									foreach (Columnn col in tab.getTabA().Stlpce)
									{
										cvlist.Add(new ColVal(col.COULUMN_NAME1,red1[col.COULUMN_NAME1].ToString()));
										if (red1[col.COULUMN_NAME1].ToString() != red2[col.COULUMN_NAME1].ToString())
										{
											differentExist = true;
											
										}
									}
								}
								   
								else differentNotExist = true;
								red2.Close();
								if (differentExist)
								{
									output.Add(db2.prip.updateRow(tab.getTableName(), cvlist, new ColVal(kk.NameOfColumns[0], key)));
								}
								if (differentNotExist)
								{
									foreach (Columnn col in tab.getTabA().Stlpce)
									{
										 cvlist.Add(new ColVal(col.COULUMN_NAME1,red1[col.COULUMN_NAME1].ToString()));    
									}
									output.Add(db2.prip.insertRow(tab.getTableName(), cvlist));
								}

							}
							red1.Close();
						}
						if (this.settings.ComparisonMethod == ComparatorSettings.LeftRightDel)
						{
							DbDataReader red1 = db1.prip.getReaderOfTable(tab.getTableName(), "", "");
							while (red1.Read())
							{
								bool differentExist = false;
								bool differentNotExist = false;
								List<ColVal> cvlist = new List<ColVal>();
								string key = red1[kk.NameOfColumns[0]].ToString();
								DbDataReader red2 = db2.prip.getReaderOfTable(tab.getTableName(), kk.NameOfColumns[0], key);
								if (red2.Read())
								{

									foreach (Columnn col in tab.getTabA().Stlpce)
									{
										cvlist.Add(new ColVal(col.COULUMN_NAME1, red1[col.COULUMN_NAME1].ToString()));
										if (red1[col.COULUMN_NAME1].ToString() != red2[col.COULUMN_NAME1].ToString())
										{
											differentExist = true;

										}
									}
								}
								else differentNotExist = true;
								red2.Close();
								if (differentExist)
								{
									output.Add(db2.prip.updateRow(tab.getTableName(), cvlist, new ColVal(kk.NameOfColumns[0], key)));
								}
								if (differentNotExist)
								{
									foreach (Columnn col in tab.getTabA().Stlpce)
									{
										cvlist.Add(new ColVal(col.COULUMN_NAME1, red1[col.COULUMN_NAME1].ToString()));
									}
									output.Add(db2.prip.insertRow(tab.getTableName(), cvlist));
								}
							}
							red1.Close();
							red1 = db2.prip.getReaderOfTable(tab.getTableName(), "", "");
							while (red1.Read())
							{
								bool differentExist = false;
								bool differentNotExist = false;
								List<ColVal> cvlist = new List<ColVal>();
								string key = red1[kk.NameOfColumns[0]].ToString();
								DbDataReader red2 = db1.prip.getReaderOfTable(tab.getTableName(), kk.NameOfColumns[0], key);
								if (red2.Read())
								{

									foreach (Columnn col in tab.getTabA().Stlpce)
									{
										cvlist.Add(new ColVal(col.COULUMN_NAME1, red1[col.COULUMN_NAME1].ToString()));
										if (red1[col.COULUMN_NAME1].ToString() != red2[col.COULUMN_NAME1].ToString())
										{
											differentExist = true;

										}
									}
								}
								else differentNotExist = true;
								red2.Close();
								//if (differentExist)
								//{
								//    output.Add(db2.prip.updateRow(tab.getTableName(), cvlist, new ColVal(key, red1[key].ToString())));
								//}
								if (differentNotExist)
								{
									output.Add(db2.prip.deleteRow(tab.getTableName(), new ColVal(kk.NameOfColumns[0], key)));
								}
							}
							red1.Close();
							//teraz vymazem tie, co tam nemaju byt

						}

						if (this.settings.ComparisonMethod == ComparatorSettings.TwoWay)
						{
							DbDataReader red1 = db2.prip.getReaderOfTable(tab.getTableName(), "", "");
							while (red1.Read())
							{
								bool differentExist = false;
								bool differentNotExist = false;
								List<ColVal> cvlist1 = new List<ColVal>();
								List<ColVal> cvlist2 = new List<ColVal>();
								string key = red1[kk.NameOfColumns[0]].ToString();
								DbDataReader red2 = db1.prip.getReaderOfTable(tab.getTableName(), kk.NameOfColumns[0], key);
								if (red2.Read())
								{

									foreach (Columnn col in tab.getTabA().Stlpce)
									{
										cvlist1.Add(new ColVal(col.COULUMN_NAME1, red1[col.COULUMN_NAME1].ToString()));
										cvlist2.Add(new ColVal(col.COULUMN_NAME1, red2[col.COULUMN_NAME1].ToString()));
										if (red1[col.COULUMN_NAME1].ToString() != red2[col.COULUMN_NAME1].ToString())
										{
											differentExist = true;

										}
									}
								}
								else differentNotExist = true;
								red2.Close();
								if (differentExist)
								{
									if (this.settings.IsDbAPriority)
									{
										output.Add(db2.prip.updateRow(tab.getTableName(), cvlist2, new ColVal(kk.NameOfColumns[0], key)));
									}
								   
								}
								if (differentNotExist)
								{
									foreach (Columnn col in tab.getTabA().Stlpce)
									{
									   // cvlist1.Add(new ColVal(col.COULUMN_NAME1, red1[col.COULUMN_NAME1].ToString()));
									}
								   // output.Add(db1.prip.insertRow(tab.getTableName(), cvlist1));
								}
							}
							red1.Close();
							red1 = db1.prip.getReaderOfTable(tab.getTableName(), "", "");
							while (red1.Read())
							{
								bool differentExist = false;
								bool differentNotExist = false;
								List<ColVal> cvlist = new List<ColVal>();
								string key = red1[kk.NameOfColumns[0]].ToString();
								DbDataReader red2 = db2.prip.getReaderOfTable(tab.getTableName(), kk.NameOfColumns[0], key);
								if (red2.Read())
								{

									foreach (Columnn col in tab.getTabA().Stlpce)
									{
										cvlist.Add(new ColVal(col.COULUMN_NAME1, red1[col.COULUMN_NAME1].ToString()));
										if (red1[col.COULUMN_NAME1].ToString() != red2[col.COULUMN_NAME1].ToString())
										{
											differentExist = true;

										}
									}
								}
								else differentNotExist = true;
								red2.Close();
								//if (differentExist)
								//{
								//    output.Add(db2.prip.updateRow(tab.getTableName(), cvlist, new ColVal(key, red1[key].ToString())));
								//}
								if (differentNotExist)
								{
									foreach (Columnn col in tab.getTabA().Stlpce)
									{
										cvlist.Add(new ColVal(col.COULUMN_NAME1, red1[col.COULUMN_NAME1].ToString()));
									}
									output.Add(db2.prip.insertRow(tab.getTableName(), cvlist));
								}
							}
							red1.Close();
						}

					}
					else throw new Exception("Cannot synchronize data on this table, because there is no primary key or composite primary key");
				
			}
			else
				throw new Exception("Cannot synchronize data on non synchronized tables, synchronize schema first please");
			return output;
			//return null;
		}
	   
		public List<string> generateDataScriptsForDB1(DbSyncTableDiff tab)
		{
			List<string> output = new List<string>();
			if (!tab.isDifferent())
			{
				int havePrimaryKey = 0;
				bool simplePK = false;
				Key kk = null;
				foreach (DbSyncKeyDiff k in tab.KeysDifList())
				{
					if (k.getKeyA().PrimaryKey)
					{
						havePrimaryKey++;
						if (k.getKeyA().NameOfColumns.Count == 1)
						{
							simplePK = true;
							kk = k.getKeyA();
						}
					}
				}

				if ((havePrimaryKey == 1) && simplePK)
				{
					if (this.settings.ComparisonMethod == ComparatorSettings.RightLeft)
					{
						DbDataReader red1 = db2.prip.getReaderOfTable(tab.getTableName(), "", "");
						while (red1.Read())
						{
							bool differentExist = false;
							bool differentNotExist = false;
							List<ColVal> cvlist = new List<ColVal>();
							string key = red1[kk.NameOfColumns[0]].ToString();
							DbDataReader red2 = db1.prip.getReaderOfTable(tab.getTableName(), kk.NameOfColumns[0], key);
							if (red2.Read())
							{

								foreach (Columnn col in tab.getTabA().Stlpce)
								{
									cvlist.Add(new ColVal(col.COULUMN_NAME1, red1[col.COULUMN_NAME1].ToString()));
									if (red1[col.COULUMN_NAME1].ToString() != red2[col.COULUMN_NAME1].ToString())
									{
										differentExist = true;

									}
								}
							}

							else differentNotExist = true;
							red2.Close();
							if (differentExist)
							{
								output.Add(db1.prip.updateRow(tab.getTableName(), cvlist, new ColVal(kk.NameOfColumns[0], key)));
							}
							if (differentNotExist)
							{
								foreach (Columnn col in tab.getTabA().Stlpce)
								{
									cvlist.Add(new ColVal(col.COULUMN_NAME1, red1[col.COULUMN_NAME1].ToString()));
								}
								output.Add(db1.prip.insertRow(tab.getTableName(), cvlist));
							}

						}
						red1.Close();
					}
					if (this.settings.ComparisonMethod == ComparatorSettings.RightLeftDel)
					{
						DbDataReader red1 = db2.prip.getReaderOfTable(tab.getTableName(), "", "");
						while (red1.Read())
						{
							bool differentExist = false;
							bool differentNotExist = false;
							List<ColVal> cvlist = new List<ColVal>();
							string key = red1[kk.NameOfColumns[0]].ToString();
							DbDataReader red2 = db1.prip.getReaderOfTable(tab.getTableName(), kk.NameOfColumns[0], key);
							if (red2.Read())
							{

								foreach (Columnn col in tab.getTabA().Stlpce)
								{
									cvlist.Add(new ColVal(col.COULUMN_NAME1, red1[col.COULUMN_NAME1].ToString()));
									if (red1[col.COULUMN_NAME1].ToString() != red2[col.COULUMN_NAME1].ToString())
									{
										differentExist = true;

									}
								}
							}
							else differentNotExist = true;
							red2.Close();
							if (differentExist)
							{
								output.Add(db1.prip.updateRow(tab.getTableName(), cvlist, new ColVal(kk.NameOfColumns[0], key)));
							}
							if (differentNotExist)
							{
								foreach (Columnn col in tab.getTabA().Stlpce)
								{
									cvlist.Add(new ColVal(col.COULUMN_NAME1, red1[col.COULUMN_NAME1].ToString()));
								}
								output.Add(db1.prip.insertRow(tab.getTableName(), cvlist));
							}
						}
						red1.Close();
						red1 = db1.prip.getReaderOfTable(tab.getTableName(), "", "");
						while (red1.Read())
						{
							bool differentExist = false;
							bool differentNotExist = false;
							List<ColVal> cvlist = new List<ColVal>();
							string key = red1[kk.NameOfColumns[0]].ToString();
							DbDataReader red2 = db2.prip.getReaderOfTable(tab.getTableName(), kk.NameOfColumns[0], key);
							if (red2.Read())
							{

								foreach (Columnn col in tab.getTabA().Stlpce)
								{
									cvlist.Add(new ColVal(col.COULUMN_NAME1, red1[col.COULUMN_NAME1].ToString()));
									if (red1[col.COULUMN_NAME1].ToString() != red2[col.COULUMN_NAME1].ToString())
									{
										differentExist = true;

									}
								}
							}
							else differentNotExist = true;
							red2.Close();
							//if (differentExist)
							//{
							//    output.Add(db2.prip.updateRow(tab.getTableName(), cvlist, new ColVal(key, red1[key].ToString())));
							//}
							if (differentNotExist)
							{
								output.Add(db1.prip.deleteRow(tab.getTableName(), new ColVal(kk.NameOfColumns[0], key)));
							}
						}
						red1.Close();
						//teraz vymazem tie, co tam nemaju byt

					}
					if (this.settings.ComparisonMethod == ComparatorSettings.TwoWay)
					{
						DbDataReader red1 = db2.prip.getReaderOfTable(tab.getTableName(), "", "");
						while (red1.Read())
						{
							bool differentExist = false;
							bool differentNotExist = false;
							List<ColVal> cvlist1 = new List<ColVal>();
							List<ColVal> cvlist2 = new List<ColVal>();
							string key = red1[kk.NameOfColumns[0]].ToString();
							DbDataReader red2 = db1.prip.getReaderOfTable(tab.getTableName(), kk.NameOfColumns[0], key);
							if (red2.Read())
							{

								foreach (Columnn col in tab.getTabA().Stlpce)
								{
									cvlist1.Add(new ColVal(col.COULUMN_NAME1, red1[col.COULUMN_NAME1].ToString()));
									cvlist2.Add(new ColVal(col.COULUMN_NAME1, red2[col.COULUMN_NAME1].ToString()));
									if (red1[col.COULUMN_NAME1].ToString() != red2[col.COULUMN_NAME1].ToString())
									{
										differentExist = true;

									}
								}
							}
							else differentNotExist = true;
							red2.Close();
							if (differentExist)
							{
								if (!this.settings.IsDbAPriority)
								{
									output.Add(db1.prip.updateRow(tab.getTableName(), cvlist1, new ColVal(kk.NameOfColumns[0], key)));
								}
							   
							}
							if (differentNotExist)
							{
								foreach (Columnn col in tab.getTabA().Stlpce)
								{
									cvlist1.Add(new ColVal(col.COULUMN_NAME1, red1[col.COULUMN_NAME1].ToString()));
								}
								output.Add(db1.prip.insertRow(tab.getTableName(), cvlist1));
							}
						}
						red1.Close();
						red1 = db1.prip.getReaderOfTable(tab.getTableName(), "", "");
						while (red1.Read())
						{
							bool differentExist = false;
							bool differentNotExist = false;
							List<ColVal> cvlist = new List<ColVal>();
							string key = red1[kk.NameOfColumns[0]].ToString();
							DbDataReader red2 = db2.prip.getReaderOfTable(tab.getTableName(), kk.NameOfColumns[0], key);
							if (red2.Read())
							{

								foreach (Columnn col in tab.getTabA().Stlpce)
								{
									cvlist.Add(new ColVal(col.COULUMN_NAME1, red1[col.COULUMN_NAME1].ToString()));
									if (red1[col.COULUMN_NAME1].ToString() != red2[col.COULUMN_NAME1].ToString())
									{
										differentExist = true;

									}
								}
							}
							else differentNotExist = true;
							red2.Close();
							//if (differentExist)
							//{
							//    output.Add(db2.prip.updateRow(tab.getTableName(), cvlist, new ColVal(key, red1[key].ToString())));
							//}
							if (differentNotExist)
							{
								foreach (Columnn col in tab.getTabA().Stlpce)
								{
								  //  cvlist.Add(new ColVal(col.COULUMN_NAME1, red1[col.COULUMN_NAME1].ToString()));
								}
							   // output.Add(db2.prip.insertRow(tab.getTableName(), cvlist));
							}
						}
						red1.Close();
					}

				}
				else throw new Exception("Cannot synchronize data on this table, because there is no primary key or composite primary key");

			}
			else
				throw new Exception("Cannot synchronize data on non synchronized tables, synchronize schema first please");
			return output;
			//return null;
		}

	   
		public bool vytvorPripojenie1(string connstring,string typ)
		{
			if (typ == "MySQL")
			{
				if (db1.vytvorMySQLpripojenie(connstring))
				{
					aktualizujVypis(this, new EventArgs());
					return true;
				}
			}
			if (typ == "MSSQL")
			{
				if (db1.vytvorMSSQLpripojenie(connstring))
				{
					aktualizujVypis(this, new EventArgs());
					return true;
				}
			}
			return false;
		}
		public bool vytvorPripojenie2(string connstring,string typ)
		{
			if (typ == "MySQL")
			{
				if (db1.vytvorMySQLpripojenie(connstring))
				{
					aktualizujVypis(this, new EventArgs());
					return true;
				}
			}
			
			if (typ == "MSSQL")
			{
				if (db2.vytvorMSSQLpripojenie(connstring))
				{
					aktualizujVypis(this, new EventArgs());
					return true;
				}
			}
			return false;
		}

	   
	}
}
