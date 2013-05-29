using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Databazovy_Synchronizator
{
    class ConnectionMySQL : Connectionc
    {
        public MySqlConnection pripojenie;
        public bool pripAktivne = false;
        private string connString;
        //public ConnectionMySQL(string commStringIn)
        //{
        //    this.typPripojenia = "MySQL";
        //    this.connString = commStringIn;
        //}

        public override bool createConnection()
        {
            pripojenie = new MySqlConnection(connString);
            try
            {

                //vystup = nacitajTabulky();
                pripojenie.Open();
                pripAktivne = true;

            }
            catch (Exception e)
            {
                Console.WriteLine("pripojenie neuspesne z dovodu :" + e.Message);

            }
            return pripAktivne;
        }

        public List<Tablee> vytvorPripojenie(string connstring)
        {
            List<Tablee> vystup = null;
            pripojenie = new MySqlConnection(connstring);
            try
            {

                //vystup = nacitajTabulky();
                pripojenie.Open();
                pripAktivne = true;

            }
            catch (Exception e)
            {
                Console.WriteLine("pripojenie neuspesne z dovodu :" + e.Message);

            }
            return vystup;
        }

 /*       public List<Tabulka> nacitajTabulky()
        {
            List<Tabulka> vystup = new List<Tabulka>();
            pripojenie.Open();
            SqlCommand com = pripojenie.CreateCommand();
            com.CommandText = "select distinct name from sysobjects where xtype='U'";
            SqlDataReader red = com.ExecuteReader();
            while (red.Read())
            {
                Tabulka tab = new Tabulka();
                tab.NazovTabulky = red["name"].ToString();
                vystup.Add(tab);
            }
            red.Close();
            //nacitam stlpce pre jednotlive tabulky
            com.CommandText = "select column_name from information_schema.columns where table_name=@param";
            com.Parameters.Add("@param", SqlDbType.VarChar);
            foreach (Tabulka tab in vystup)
            {
                com.Parameters["@param"].Value = tab.NazovTabulky;
                red = com.ExecuteReader();
                while (red.Read())
                {
                    Stlpec st = new Stlpec();
                    st.NazovStlpca = red["COLUMN_NAME"].ToString();
                    tab.Stlpce.Add(st);
                }
                red.Close();
            }
            return vystup;

        }

        */

        public override string GetNameOfDB()
        {
            throw new NotImplementedException();
        }

        public override List<SProcedure> ReadProcedures()
        {
            throw new NotImplementedException();
        }

        public override List<SFunction> ReadFunctions()
        {
            throw new NotImplementedException();
        }

        public override List<Typ> ReadTypes()
        {
            throw new NotImplementedException();
        }

        public override List<User> ReadUsers()
        {
            throw new NotImplementedException();
        }

        public override List<Tablee> ReadTables()
        {
            throw new NotImplementedException();
        }



      

        public override string createPrivilege(Privilege privIn)
        {
            throw new NotImplementedException();
        }

        

        public override string createType(Typ typIn)
        {
            throw new NotImplementedException();
        }


        public override List<string> executeText(List<string> text)
        {
            throw new NotImplementedException();
        }

        public override List<string> createProcedure(SProcedure procIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> createFunction(SFunction funkcIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> createUser(User usrIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> createTable(Tablee tabIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> removeProcedure(SProcedure procIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> removeFunction(SFunction funkcIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> removeTable(Tablee tabIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> removeType(Typ typIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> removeFKonTab(Tablee tab)
        {
            throw new NotImplementedException();
        }

        public override List<string> alterFunction(SFunction funkcIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> alterProcedure(SProcedure procIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> alterType(Typ typeIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> alterUser(User usrIn)
        {
            throw new NotImplementedException();
        }

        //public override List<string> alterTable(Tablee tabIn)
        //{
        //    throw new NotImplementedException();
        //}

        public override List<string> removeUser(User usrIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> addcolumn(Tablee tabIn, Columnn colIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> removeColumn(Tablee tabIn, Columnn colIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> alterColumn(Tablee tabIn, Columnn colIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> addKey(Tablee tabIn, Key keyIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> alterKey(Tablee tabIn, Key keyIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> removeKey(Tablee tabIn, Key keyIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> addConstraint(Tablee tabIn, Constraintt constIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> alterConstraint(Tablee tabIn, Constraintt constIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> removeConstraint(Tablee tabIn, Constraintt constIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> addTrigger(Tablee tabIn, Trigger trigIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> alterTrigger(Tablee tabIn, Trigger trigIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> removeTrigger(Tablee tabIn, Trigger trigIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> addIndex(Tablee tabIn, Index indexIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> alterIndex(Tablee tabIn, Index indexIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> removeIndex(Tablee tabIn, Index indexIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> removePrivilege(Privilege privIn)
        {
            throw new NotImplementedException();
        }

        public override List<string> alterPrivilege(Privilege privIn)
        {
            throw new NotImplementedException();
        }

        public override System.Data.Common.DbDataReader getReaderOfTable(string tablename, string conditionColumn, string conditionVal)
        {
            throw new NotImplementedException();
        }

        public override string updateRow(string tablename, List<ColVal> values, ColVal key)
        {
            throw new NotImplementedException();
        }

        public override string insertRow(string tablename, List<ColVal> values)
        {
            throw new NotImplementedException();
        }

        public override string deleteRow(string tablename, ColVal key)
        {
            throw new NotImplementedException();
        }
    }

}
