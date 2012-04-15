using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Databazovy_Synchronizator
{
    public class DataBasee
    {
        public event EventHandler DatabaseChanged;
        
        public Connectionc prip;
        private string nameOfDatabase;
        private bool pripAktivne;
        private List<Tablee> tabulky;
        private List<User> usery;
        private List<Typ> typy;
        private List<SFunction> funkcie;
        private List<SProcedure> procedury;

        public List<Tablee> Tabulky
        {
            get { return tabulky; }
            set { tabulky = value; }
        }
        public List<SProcedure> Procedury
        {
            get { return procedury; }
            set { procedury = value; }
        }
        public List<SFunction> Funkcie
        {
            get { return funkcie; }
            set { funkcie = value; }
        }
        public List<Typ> Typy
        {
            get { return typy; }
            set { typy = value; }
        }
        public List<User> Usery
        {
            get { return usery; }
            set { usery = value; }
        }

        public string getNameOfDAtabase()
        {
            return nameOfDatabase;
        }

        public DataBasee()
        {
            tabulky = new List<Tablee>();
            procedury = new List<SProcedure>();
            funkcie = new List<SFunction>();
            typy = new List<Typ>();
            usery = new List<User>();

        }
        
        public void setConnection(Connectionc con)
        {
            this.prip = con;
            con.needsUpdateView += new EventHandler(DBchanged);
        }
        
        public bool ReadData()
        {
            if (prip != null)
            {
                if (prip.createConnection())
                {
                    tabulky = prip.nacitajTabulky();
                    procedury = prip.nacitajProcedury();
                    funkcie = prip.nacitajFunkcie();
                    typy = prip.nacitajTypy();
                    usery = prip.nacitajUSerov();
                    nameOfDatabase = prip.dajNazovDB();
                    pripAktivne = true;
                    return true;
                }
                return false;
            }
            return false;
        }
        
        public bool vytvorMSSQLpripojenie(string connstring)
        {
            ConnectionMSSQL sqlPrip = new ConnectionMSSQL(connstring);
            prip = sqlPrip;
            if (sqlPrip.createConnection())
            {
                tabulky = sqlPrip.nacitajTabulky();
                procedury = sqlPrip.nacitajProcedury();
                funkcie = sqlPrip.nacitajFunkcie();
                typy = sqlPrip.nacitajTypy();
                usery = sqlPrip.nacitajUSerov();
                nameOfDatabase = sqlPrip.dajNazovDB();
                pripAktivne = true;
                return true;
            }
            return false;

        }

        public bool vytvorMySQLpripojenie(string connstring)
        {
            ConnectionMySQL sqlPrip = new ConnectionMySQL(connstring);
            prip = sqlPrip;
           /* if (tabulky != null)
            {
                tabulky = sqlPrip.createConnection();
                pripAktivne = true;
                return true;
            }
            else*/ return false;
        }


        public bool jeAktivne()
        {
            return pripAktivne;
        }
        public DBsyncTreeview vyrobStrom()
        {

            DBsyncTvEmptyType hlavny = new DBsyncTvEmptyType(prip.dajNazovDB(), DBsyncTreeview.DatabaseIcon);
            DBsyncTvEmptyType tabb = new DBsyncTvEmptyType("Tabuľky", DBsyncTreeview.TablesIcon);
            hlavny.Nodes.Add(tabb);
            foreach (Tablee tab in tabulky)
            {
                DBsyncTvTableType novy = new DBsyncTvTableType(tab);
                if (tab.OdlisneConstrainty || tab.OdlisneIndexy || tab.OdlisnePrivileges || tab.OdlisneStlpce || tab.OdlisneTrigre) novy.Azvyraznene = true;

                DBsyncTvEmptyType Stlpc = new DBsyncTvEmptyType("Stĺpce", DBsyncTreeview.ColumnsIcon);
                if (tab.OdlisneStlpce) Stlpc.Azvyraznene = true; 
                novy.Nodes.Add(Stlpc);

                foreach (Columnn s in tab.Stlpce)
                {
                    DbsyncTvColumnType novystlpec = new DbsyncTvColumnType(s);
                    Stlpc.Nodes.Add(novystlpec);
                }

                DBsyncTvEmptyType keys = new DBsyncTvEmptyType("Kľúče", DBsyncTreeview.KeysIcon);
                novy.Nodes.Add(keys);
                foreach (Columnn s in tab.Stlpce)
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
                }

                DBsyncTvEmptyType constr = new DBsyncTvEmptyType("Constrainty", DBsyncTreeview.ConstraintsIcon);
                novy.Nodes.Add(constr);
                if (tab.OdlisneConstrainty) constr.Azvyraznene = true; 
                foreach (Constraintt c in tab.Constrainty)
                {
                    DbsyncTvConstraintType con = new DbsyncTvConstraintType(c);
                    constr.Nodes.Add(con);
                }

                DBsyncTvEmptyType trig = new DBsyncTvEmptyType("Triggre", DBsyncTreeview.TriggersIcon);
                novy.Nodes.Add(trig);
                if (tab.OdlisneTrigre) trig.Azvyraznene = true; 
                foreach (Trigger t in tab.Trigre)
                {
                    DbsyncTvTriggerType trg = new DbsyncTvTriggerType(t);
                    trig.Nodes.Add(trg);
                }

                DBsyncTvEmptyType granty = new DBsyncTvEmptyType("Granty", DBsyncTreeview.GrantsIcon);
                novy.Nodes.Add(granty);
                if (tab.OdlisnePrivileges) granty.Azvyraznene = true; 
                foreach (Privilege p in tab.Privileges)
                {
                    DbsyncTvPrivilegeType grnt = new DbsyncTvPrivilegeType(p);
                    granty.Nodes.Add(grnt);
                }

                DBsyncTvEmptyType indexyy = new DBsyncTvEmptyType("Indexy", DBsyncTreeview.IndexesIcon);
                novy.Nodes.Add(indexyy);
                if (tab.OdlisneIndexy) indexyy.Azvyraznene = true; 
                foreach (Index i in tab.Indexy)
                {
                    DbsyncTvIndexType iin = new DbsyncTvIndexType(i);
                    indexyy.Nodes.Add(iin);
                }


                tabb.Nodes.Add(novy);
            }
            DBsyncTvEmptyType procedures = new DBsyncTvEmptyType("Stored procedures", DBsyncTreeview.StoredProceduresIcon);
            hlavny.Nodes.Add(procedures);
            foreach (SProcedure sp in procedury)
            {
                DbsyncTvStoredProcType novy = new DbsyncTvStoredProcType(sp);
                procedures.Nodes.Add(novy);
            }
            DBsyncTvEmptyType funkc = new DBsyncTvEmptyType("Funkcie", DBsyncTreeview.FunctionsIcon);
            hlavny.Nodes.Add(funkc);
            foreach (SFunction sf in funkcie)
            {
                DbsyncTvFunctionType novy = new DbsyncTvFunctionType(sf);
                funkc.Nodes.Add(novy);
            }

            DBsyncTvEmptyType types = new DBsyncTvEmptyType("Typy", DBsyncTreeview.TypesIcon);
            hlavny.Nodes.Add(types);
            foreach (Typ tp in typy)
            {
                DbsyncTvTypeType novy = new DbsyncTvTypeType(tp);
                types.Nodes.Add(novy);
            }
            DBsyncTvEmptyType users = new DBsyncTvEmptyType("Používatelia", DBsyncTreeview.UsersIcon);
            hlavny.Nodes.Add(users);
            foreach (User usr in usery)
            {
                DbsyncTvUserType novy = new DbsyncTvUserType(usr);
                users.Nodes.Add(novy);
            }

            
            return hlavny;
        }
    
        public bool porovnajTabulkyDB(List<Tablee> tabb)
        {
            bool ress = true;

            foreach (Tablee tabA in tabulky)
            {
                bool nasiel = false;
                foreach (Tablee tabB in tabb)
                {
                    if (tabA.DBSyncCompareTO(tabB)) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            return ress;

        }

        public bool porovnajStoredProceduryDB(List<SProcedure> stproc)
        {
            bool ress = true;

            foreach (SProcedure stA in procedury)
            {
                bool nasiel = false;
                foreach (SProcedure stB in stproc)
                {
                    if (stA.DBSyncCompareTO(stB)) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            return ress;

        }

        public bool porovnajStoredFunkcieDB(List<SFunction> stfunkc)
        {
            bool ress = true;

            foreach (SFunction fxA in funkcie)
            {
                bool nasiel = false;
                foreach (SFunction fxB in stfunkc)
                {
                    if (fxA.DBSyncCompareTO(fxB)) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            return ress;

        }

        public bool porovnajTypyDB(List<Typ> tiptip)
        {
            bool ress = true;

            foreach (Typ typA in typy)
            {
                bool nasiel = false;
                foreach (Typ typB in tiptip)
                {
                    if (typA.DBSyncCompareTO(typB)) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            return ress;

        }

        public bool porovnajUserov(List<User> userss)
        {
            bool ress = true;

            foreach (User usrA in usery)
            {
                bool nasiel = false;
                foreach (User usrB in userss)
                {
                    if (usrA.DBSyncCompareTO(usrB)) nasiel = true;
                }
                if (nasiel == false) ress = false;
            }
            return ress;

        }

        private void DBchanged(object sender, EventArgs e)
        {
            DatabaseChanged(this, new EventArgs());
        }

    }
}
