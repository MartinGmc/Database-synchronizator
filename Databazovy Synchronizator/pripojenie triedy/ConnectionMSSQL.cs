using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Databazovy_Synchronizator
{
    class ConnectionMSSQL :Connectionc
    {
       
        
        SqlConnection pripojenie;
        string connString;
        string NazovDB = "";

        List<string> systemUsers;
        bool pripAktivne = false;
        
        public ConnectionMSSQL(string connStringin)
        {
            connString = connStringin;
            //this.typPripojenia = "MSSQL";

            systemUsers = new List<string>();
            systemUsers.Add("coder");
            systemUsers.Add("dbo");
            systemUsers.Add("guest");
            systemUsers.Add("INFORMATION_SCHEMA");
            systemUsers.Add("sys");

        }

        public override bool createConnection()
        {
            pripojenie = new SqlConnection(connString);
            try
            {
                pripojenie.Open();
                NazovDB = pripojenie.Database;
                pripojenie.Close();
                pripAktivne = true;
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine("pripojenie neuspesne z dovodu :" + e.Message);
                return false;
            }
        }

        public bool vytvorPripojenie(string connstring)
        {
            
            pripojenie = new SqlConnection(connstring);
            try
            {
                pripojenie.Open();
                NazovDB = pripojenie.Database;
                pripojenie.Close();
                pripAktivne = true;
                return true;
                
            }
            catch (Exception e)
            {
                Console.WriteLine("pripojenie neuspesne z dovodu :" + e.Message);
                return false;
            }
            
        }

        // nacitanie tabuliek
        public override List<Tablee> ReadTables()
        {
            List<Tablee> vystup = new List<Tablee>();
            pripojenie.Open();
            SqlCommand com = pripojenie.CreateCommand();
            com.CommandText = "select TABLE_NAME from INFORMATION_SCHEMA.TABLES where TABLE_TYPE = 'BASE TABLE'";
            SqlDataReader red = com.ExecuteReader();
            while (red.Read())
            {
                Tablee tab = new Tablee();
                tab.NazovTabulky = red["TABLE_NAME"].ToString();
                vystup.Add(tab);
            }
            red.Close();
            //nacitam stlpce pre jednotlive tabulky
           foreach (Tablee tab in vystup)
            {
                readColumnsForTab(tab);
                readPrivileges(tab);
                ReadTriggersForTab(tab);
                readConstraintsForTab(tab);
                readIndexesForTab(tab);
                //nacitajPKPreTab(tab);
                //nacitajFKPreTab(tab);
                readFKForTab(tab);
                readPKForTab(tab);
            }
            return vystup;

        }
        private void readConstraintsForTab(Tablee tab)
        {
            SqlCommand com = pripojenie.CreateCommand();
            com.CommandText = "select * from INFORMATION_SCHEMA.TABLE_CONSTRAINTS " +
                              "where TABLE_NAME = '" + tab.NazovTabulky + "'";
            SqlDataReader red = com.ExecuteReader();
            while (red.Read())
            {
                Constraintt constr = new Constraintt();
                constr.Constraint_nam = red["Constraint_name"].ToString();
                constr.Constraint_typ = red["Constraint_type"].ToString();
                if (red["IS_deferrable"].ToString() == "YES")
                {
                    constr.Is_deferabl = true;
                }
                else constr.Is_deferabl = false;
                if (red["INITIALLY_DEFERRED"].ToString() == "YES")
                {
                    constr.Initialy_deferre = true;
                }
                else constr.Initialy_deferre = false;

                //if (constr.Constraint_typ == "PRIMARY KEY")
                //{
                    SqlCommand com2 = pripojenie.CreateCommand();
                    com2.CommandText = "select * from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE where CONSTRAINT_NAME = '" + constr.Constraint_nam + "'";
                    SqlDataReader red2 = com2.ExecuteReader();
                    while (red2.Read())
                    {
                        constr.Column.Add(red2["COLUMN_NAME"].ToString());
                    }
                    red2.Close();
                //}

                if (constr.Constraint_typ == "CHECK")
                {
                    com2 = pripojenie.CreateCommand();
                    com2.CommandText = "SELECT * FROM INFORMATION_SCHEMA.CHECK_CONSTRAINTS where CONSTRAINT_NAME = '" + constr.Constraint_nam + "'";
                    red2 = com2.ExecuteReader();
                    while (red2.Read())
                    {
                        constr.Condition = (red2["CHECK_CLAUSE"].ToString());
                    }
                    red2.Close();
                }

                tab.Constrainty.Add(constr);

            }
            red.Close();

            //nacitam nazvy default constraint
            com = pripojenie.CreateCommand();
            com.CommandText = " select o.name name1, c.name name2 from sysobjects o " +
                                " inner join syscolumns c" +
                                " on o.id = c.cdefault" +
                                " inner join sysobjects t" +
                                " on c.id = t.id" +
                                " where o.xtype = 'd'" +
                                " and t.name = '"+tab.NazovTabulky+"'";
            red = com.ExecuteReader();
            while (red.Read())
            {
                Constraintt constrr = new Constraintt();
                constrr.Constraint_nam = red["name1"].ToString();
                constrr.Column.Add(red["name2"].ToString());
                constrr.Constraint_typ = "DEFAULT";
                tab.Constrainty.Add(constrr);
            }
            



        }
        private void readPrivileges(Tablee tab)
        {
            SqlCommand com = pripojenie.CreateCommand();
            com.CommandText = "select * from INFORMATION_SCHEMA.TABLE_PRIVILEGES " +
                              "where table_name = '" + tab.NazovTabulky + "'";
            SqlDataReader red = com.ExecuteReader();
            while (red.Read())
            {
                Privilege priv = new Privilege();
                priv.Grantee = red["grantee"].ToString();
               // priv.Grantor = red["grantor"].ToString();
                priv.Privilege_type = red["privilege_type"].ToString();
               // priv.Table_catalog = red["table_catalog"].ToString();
                priv.Table_name = red["table_name"].ToString();
              //  priv.Table_schema = red["table_schema"].ToString();
              //  if (red["is_grantable"].ToString() == "YES") priv.Is_grantable = true; else priv.Is_grantable = false;
                tab.Privileges.Add(priv);
            }
            red.Close();
        }
        private void ReadTriggersForTab(Tablee tab)
        {
            SqlCommand com = pripojenie.CreateCommand();
            com.CommandText = " SELECT " +
                                " [so].[name] AS [trigger_name], " +
                                " USER_NAME([so].[uid]) AS [trigger_owner], " +
                                " USER_NAME([so2].[uid]) AS [table_schema], " +
                                " OBJECT_NAME([so].[parent_obj]) AS [table_name], " +
                                " OBJECTPROPERTY( [so].[id], 'ExecIsUpdateTrigger') AS [isupdate], " +
                                " OBJECTPROPERTY( [so].[id], 'ExecIsDeleteTrigger') AS [isdelete], " +
                                " OBJECTPROPERTY( [so].[id], 'ExecIsInsertTrigger') AS [isinsert], " +
                                " OBJECTPROPERTY( [so].[id], 'ExecIsAfterTrigger') AS [isafter], " +
                                " OBJECTPROPERTY( [so].[id], 'ExecIsInsteadOfTrigger') AS [isinsteadof], " +
                                " OBJECTPROPERTY([so].[id], 'ExecIsTriggerDisabled') AS [disabled] " +
                                " FROM sysobjects AS [so] " +
                                " INNER JOIN sysobjects AS so2 ON so.parent_obj = so2.Id " +
                                " WHERE [so].[type] = 'TR' " +
                                " and OBJECT_NAME([so].[parent_obj]) = '" + tab.NazovTabulky + "' ";
            SqlDataReader red = com.ExecuteReader();
            
            while (red.Read())
            {
                Trigger trg = new Trigger();
                trg.Trigger_name = red["trigger_name"].ToString();
                trg.Trigger_owner = red["trigger_owner"].ToString();
               // trg.Trigger_schema = red["table_schema"].ToString();
                if (red["isupdate"].ToString() == "1") trg.OnAction = "UPDATE";
                if (red["isdelete"].ToString() == "1") trg.OnAction = "DELETE";
                if (red["isinsert"].ToString() == "1") trg.OnAction = "INSERT";
                if (red["isafter"].ToString() == "1") trg.IsAfter = true; else trg.IsAfter = false;
                if (red["isinsteadof"].ToString() == "1") trg.IsInsteadOf = true; else trg.IsInsteadOf = false;
                if (red["disabled"].ToString() == "1") trg.Disabled = true; else trg.Disabled = false;

                SqlCommand com2 = pripojenie.CreateCommand();
                com2.CommandText = "sp_helptext";
                com2.CommandType = CommandType.StoredProcedure;
                com2.Parameters.Add( new SqlParameter("@objname", trg.Trigger_name));
                SqlDataReader red2 = com2.ExecuteReader();
                List<string> text = new List<string>();
                while (red2.Read())
                {
                    text.Add(red2["Text"].ToString());
                    
                }
                red2.Close();
                trg.SqlText = text;
                
                tab.Trigre.Add(trg);
             }
            red.Close();

        }
        private void readIndexesForTab(Tablee tab)
        {
            SqlCommand com = pripojenie.CreateCommand();
            com.CommandText = "SELECT i.name , i.type_desc , i.is_unique,i.is_primary_key " +
                              "FROM sys.indexes AS i JOIN sys.tables as t ON i.object_id = t.object_id " +
                              "WHERE i.object_id = OBJECT_ID('" + NazovDB + ".dbo." + tab.NazovTabulky + "','U')" +
                              "AND i.type_desc <> 'HEAP' ";
            SqlDataReader red = com.ExecuteReader();
            while (red.Read())
            {
                Console.WriteLine("tab " +tab.NazovTabulky+ " name :" + red["name"].ToString() + " typedesc: " + red["type_desc"].ToString() + " isunique: " + red["is_unique"].ToString());
                string nazov = red["name"].ToString();
                string type = red["type_desc"].ToString();
                bool unique = bool.Parse(red["is_unique"].ToString());
                bool primaryKey = bool.Parse(red["is_primary_key"].ToString());
                Index newIndex = new Index(nazov, type, unique,primaryKey);
                SqlCommand com2 = pripojenie.CreateCommand();
                com2.CommandText = "sp_helpindex";
                com2.CommandType = CommandType.StoredProcedure;
                com2.Parameters.Add(new SqlParameter("@objname", tab.NazovTabulky));
                SqlDataReader red2 = com2.ExecuteReader(); // dorobit nacitavanie stlpca s nazvom indexKeys oddelene ciarkami
                while (red2.Read())
                {
                    if (red2["index_name"].ToString() == nazov)
                    {
                        string keys = red2["index_keys"].ToString();
                        string[] keyss = keys.Split(',');
                        foreach (string s in keyss)
                        {
                            string ss = s.Trim();
                            newIndex.Columns.Add(ss);
                        }
                    }
                    
                }
                red2.Close();
                tab.Indexy.Add(newIndex);
            }
            red.Close();
        }
        private void readColumnsForTab(Tablee tab)
        {
            SqlCommand com = pripojenie.CreateCommand();
            com.CommandText = "select * from information_schema.columns where table_name=@param";
            com.Parameters.Add("@param", SqlDbType.VarChar);
            com.Parameters["@param"].Value = tab.NazovTabulky;
            SqlDataReader red = com.ExecuteReader();
            while (red.Read())
            {
                Columnn st = new Columnn();
                //st.NazovStlpca = red["COLUMN_NAME"].ToString();

                
                st.COULUMN_DEFAULT1 = red["COLUMN_DEFAULT"].ToString();
                // uprava coulumn default
                st.COULUMN_DEFAULT1 = removeParentesis(st.COULUMN_DEFAULT1);
                st.COULUMN_NAME1 = red["COLUMN_NAME"].ToString();
                st.DATA_TYPE1 = red["DATA_TYPE"].ToString();
                st.DATETIME_PRECISION1 = red["DATETIME_PRECISION"].ToString();
                st.CHARACTER_MAXIMUM_LENGTH1 = red["CHARACTER_MAXIMUM_LENGTH"].ToString();
                //st.CHARACTER_OCTET_LENGTH1 = red["CHARACTER_OCTET_LENGTH"].ToString();
                //st.CHARACTER_SET_CATALOG1 = red["CHARACTER_SET_CATALOG"].ToString();
                //st.CHARACTER_SET_NAME1 = red["CHARACTER_SET_NAME"].ToString();
                //st.CHARACTER_SET_SCHEMA1 = red["CHARACTER_SET_SCHEMA"].ToString();
                st.IS_NULLABLE1 = red["IS_NULLABLE"].ToString();
                //st.NUMERIC_PRECISION_RADIX1 = red["NUMERIC_PRECISION_RADIX"].ToString();
                st.NUMERIC_PRECISION1 = red["NUMERIC_PRECISION"].ToString();
                st.NUMERIC_SCALE1 = red["NUMERIC_SCALE"].ToString();
              
          
                
                tab.Stlpce.Add(st);
            }
            red.Close();
        }
        //private void nacitajPKPreTab(Tablee tab)
        //{
        //    SqlCommand com = pripojenie.CreateCommand();
        //    com.CommandText = "SELECT cu.CONSTRAINT_NAME, cu.COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE cu WHERE EXISTS ( SELECT tc.* FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc WHERE tc.CONSTRAINT_CATALOG = '" + NazovDB + "' AND tc.TABLE_NAME = '" + tab.NazovTabulky + "' AND tc.CONSTRAINT_TYPE = 'PRIMARY KEY' AND tc.CONSTRAINT_NAME = cu.CONSTRAINT_NAME )";
        //    SqlDataReader red = com.ExecuteReader();
        //    while (red.Read())
        //    {
        //        string nazovPK = red["CONSTRAINT_NAME"].ToString();
        //        string nazovStlpca = red["COLUMN_NAME"].ToString();
        //        //najdem stlpec, ktory by mal byt primarnym klucom
        //        foreach (Columnn s in tab.Stlpce)
        //        {
        //            if (s.COULUMN_NAME1 == nazovStlpca)
        //            {
        //                s.Name_of_PK = nazovPK;
        //            }
        //        }
        //    }
        //    red.Close();
        //}
        private void readPKForTab(Tablee tab)
        {
            SqlCommand com = pripojenie.CreateCommand();
            com.CommandText = "SELECT cu.CONSTRAINT_NAME, cu.COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE cu WHERE EXISTS ( SELECT tc.* FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc WHERE tc.CONSTRAINT_CATALOG = '" + NazovDB + "' AND tc.TABLE_NAME = '" + tab.NazovTabulky + "' AND tc.CONSTRAINT_TYPE = 'PRIMARY KEY' AND tc.CONSTRAINT_NAME = cu.CONSTRAINT_NAME )";
            SqlDataReader red = com.ExecuteReader();
            while (red.Read())
            {
                string nazovPK = red["CONSTRAINT_NAME"].ToString();
                string nazovStlpca = red["COLUMN_NAME"].ToString();
                //najdem stlpec, ktory by mal byt primarnym klucom
                bool done = false;
                foreach (Key kluc in tab.Keys)
                {
                    if (kluc.NameOfKey == nazovPK)
                    {
                        kluc.NameOfColumns.Add(nazovStlpca);
                        done = true;
                    }
                }
                if (!done)
                {
                    List<string> stlpce = new List<string>();
                    stlpce.Add(nazovStlpca);
                    Key k = new Key(nazovPK, stlpce);
                    tab.Keys.Add(k);
                }
            }
            red.Close();
        }
        private void readFKForTab(Tablee tab)
        {
            SqlCommand prikaz = pripojenie.CreateCommand();
            prikaz.CommandType = CommandType.StoredProcedure;
            prikaz.CommandText = "dbo.sp_fkeys";
            prikaz.Parameters.Add("@fktable_name", SqlDbType.NVarChar, 128);
            prikaz.Parameters["@fktable_name"].Value = tab.NazovTabulky;
            SqlDataReader red = prikaz.ExecuteReader();
            while (red.Read())
            {
                string FKcolumnName = red["FKCOLUMN_NAME"].ToString();
                string PKTable = red["PKTABLE_NAME"].ToString();
                string PKTableCol = red["PKCOLUMN_NAME"].ToString();
                string FKName = red["FK_NAME"].ToString();
                bool done = false;
                foreach (Key kluc in tab.Keys)
                {
                    if (kluc.NameOfKey == FKName)
                    {
                        kluc.NameOfColumns.Add(FKcolumnName);
                        done = true;
                    }
                }
                if (!done)
                {
                    List<string> stlpce = new List<string>();
                    stlpce.Add(FKcolumnName);
                    Key k = new Key(FKName, stlpce, PKTable, PKTableCol);
                    tab.Keys.Add(k);
                }
                
               
            }
            red.Close();
        }
        //private void nacitajFKPreTab(Tablee tab)
        //{
        //    SqlCommand prikaz = pripojenie.CreateCommand();
        //    prikaz.CommandType = CommandType.StoredProcedure;
        //    prikaz.CommandText = "dbo.sp_fkeys";
        //    prikaz.Parameters.Add("@fktable_name", SqlDbType.NVarChar, 128);
        //    prikaz.Parameters["@fktable_name"].Value = tab.NazovTabulky;
        //    SqlDataReader red = prikaz.ExecuteReader();
        //    while (red.Read())
        //    {
        //        string FKcolumnName = red["FKCOLUMN_NAME"].ToString();
        //        string PKTable = red["PKTABLE_NAME"].ToString();
        //        string PKTableCol = red["PKCOLUMN_NAME"].ToString();
        //        string FKName = red["FK_NAME"].ToString();
        //        foreach (Columnn s in tab.Stlpce)
        //        {
        //            if (s.COULUMN_NAME1 == FKcolumnName)
        //            {
        //                s.Name_of_FK = FKName;
        //                s.FK_nameOFPKTab = PKTable;
        //                s.FK_NameOFPKCol = PKTableCol;
        //            }
        //        }
        //    }
        //    red.Close();
        //}

        //nacitanie procedur
        public override List<SProcedure> ReadProcedures()
        {
            List<SProcedure> procedury = new List<SProcedure>();
            
            SqlCommand com = pripojenie.CreateCommand();
            com.CommandText = "select * from sys.procedures";
            SqlDataReader red = com.ExecuteReader();
            List<string> nazvyproc = new List<string>();
            while (red.Read())
            {
                string nazovProc = red["name"].ToString();
                nazvyproc.Add(nazovProc);
            }
            red.Close();
            //mam nacitane nazvy procedur

            foreach (string nazov in nazvyproc)
            {
                //nacitanie parametrov pre procedury
               /* SqlCommand com2 = pripojenie.CreateCommand();
                com2.CommandText = " SELECT " +
                                   " SO.name AS [ObjectName], " +
                                   " P.parameter_id AS [ParameterID], " +
                                   " P.name AS [ParameterName], " +
                                   " TYPE_NAME(P.user_type_id) AS [ParameterDataType], " +
                                   " P.max_length AS [ParameterMaxBytes], " +
                                   " P.is_output AS [IsOutPutParameter] " +
                                   " FROM sys.objects AS SO " +
                                   " INNER JOIN sys.parameters AS P " +
                                   " ON SO.OBJECT_ID = P.OBJECT_ID " +
                                   " WHERE SO.OBJECT_ID IN ( SELECT OBJECT_ID " +
                                   " FROM sys.objects " +
                                   " WHERE TYPE IN ('P')) " +
                                   " and SO.name = 'Procedura1' " +
                                   " ORDER BY SO.name, P.parameter_id ";
                com2.CommandType = CommandType.Text;
                SqlDataReader red2 = com2.ExecuteReader();
                List<string> parametre = new List<string>(); 
                while (red2.Read())
                {

                }
                red2.Close();
                */ //asi to cele nebude potrebne.

                SqlCommand com2 = pripojenie.CreateCommand();
                com2.CommandText = "sp_helptext";
                com2.CommandType = CommandType.StoredProcedure;
                com2.Parameters.Add(new SqlParameter("@objname", nazov));
                SqlDataReader red2 = com2.ExecuteReader();
                List<string> text = new List<string>();
                while (red2.Read())
                {
                    text.Add(red2["Text"].ToString());
                   
                }
                red2.Close();
                SProcedure sp = new SProcedure();
                sp.NazovProcedury = nazov;
                sp.SqlText = text;

                //nacitam privileges pre sp
                com2.CommandText =  " SELECT "+
                                    " USER_NAME(dppriper.grantee_principal_id) AS [UserName], "+
                                    " dppri.type_desc AS principal_type_desc, "+
                                    " dppriper.class_desc, "+
                                    " OBJECT_NAME(dppriper.major_id) AS object_name, "+
                                    " dppriper.permission_name, "+
                                    " dppriper.state_desc AS permission_state_desc "+
                                    " FROM    sys.database_permissions dppriper "+
                                    " INNER JOIN sys.database_principals dppri "+
                                    " ON dppriper.grantee_principal_id = dppri.principal_id "+
                                    " where OBJECT_NAME(dppriper.major_id) = '"+nazov+"'";
                com2.CommandType = CommandType.Text;
                red2 = com2.ExecuteReader();
                while (red2.Read())
                {
                    Privilege priv = new Privilege();
                    priv.Grantee = red2["UserName"].ToString();
                    priv.Privilege_type = red2["permission_name"].ToString();
                    priv.Table_name = red2["object_name"].ToString();
                    sp.Privieges.Add(priv);
                }

                procedury.Add(sp);
            }

            return procedury;
        }

        //nacitanie funkcii
        public override List<SFunction> ReadFunctions()
        {
            List<SFunction> funkcie = new List<SFunction>();
            SqlCommand com = pripojenie.CreateCommand();
            com.CommandText = "SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'FUNCTION'";
            SqlDataReader red = com.ExecuteReader();
            while (red.Read())
            {
                SFunction sf = new SFunction();
                sf.NazovFunkcie = red["SPECIFIC_NAME"].ToString();
                sf.ReturnType = red["DATA_TYPE"].ToString();
                funkcie.Add(sf);
                
            }
            // nacitanie tela funkcii

            foreach (SFunction sf in funkcie )
            {
                SqlCommand com2 = pripojenie.CreateCommand();
                com2.CommandText = "sp_helptext";
                com2.CommandType = CommandType.StoredProcedure;
                com2.Parameters.Add(new SqlParameter("@objname", sf.NazovFunkcie));
                SqlDataReader red2 = com2.ExecuteReader();
                List<string> text = new List<string>();
                while (red2.Read())
                {
                    text.Add(red2["Text"].ToString());
                   
                }
                red2.Close();
                sf.SqlText = text;
                // nacitanie grantov
                com2.CommandText = " SELECT " +
                                  " USER_NAME(dppriper.grantee_principal_id) AS [UserName], " +
                                  " dppri.type_desc AS principal_type_desc, " +
                                  " dppriper.class_desc, " +
                                  " OBJECT_NAME(dppriper.major_id) AS object_name, " +
                                  " dppriper.permission_name, " +
                                  " dppriper.state_desc AS permission_state_desc " +
                                  " FROM    sys.database_permissions dppriper " +
                                  " INNER JOIN sys.database_principals dppri " +
                                  " ON dppriper.grantee_principal_id = dppri.principal_id " +
                                  " where OBJECT_NAME(dppriper.major_id) = '" + sf.NazovFunkcie + "'";
                com2.CommandType = CommandType.Text;
                red2 = com2.ExecuteReader();
                while (red2.Read())
                {
                    Privilege priv = new Privilege();
                    priv.Grantee = red2["UserName"].ToString();
                    priv.Privilege_type = red2["permission_name"].ToString();
                    priv.Table_name = red2["object_name"].ToString();
                    sf.Privileges.Add(priv);
                }
            }

            return funkcie;
        }

        //nacitanie typov
        public override List<Typ> ReadTypes()
        {
            List<Typ> typy = new List<Typ>();
            SqlCommand com = pripojenie.CreateCommand();
            com.CommandText = "select * from INFORMATION_SCHEMA.DOMAINS";
            SqlDataReader red = com.ExecuteReader();

            while (red.Read())
            {
                Typ t = new Typ();
                t.Nazov = red["DOMAIN_NAME"].ToString();
                
                SqlCommand com2 = pripojenie.CreateCommand();
                com2.CommandText = "sp_help";
                com2.CommandType = CommandType.StoredProcedure;
                com2.Parameters.Add(new SqlParameter("@objname", t.Nazov));
                SqlDataReader red2 = com2.ExecuteReader();
                red2.Read();
                
                    t.Datatyp = red2["Storage_TYPE"].ToString();
                    t.Precision = red2["prec"].ToString();
                    t.Scale = red2["scale"].ToString();
                    if (red2["nullable"].ToString() == "yes") t.CanBeNull = true;
                    else t.CanBeNull = false;
                       
                red2.Close();
               typy.Add(t);
            }
            return typy;
        }

        public override List<User> ReadUsers()
        {
            List<User> usery = new List<User>();
            SqlCommand com = pripojenie.CreateCommand();
            com.CommandText = "sp_helpuser";
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader red = com.ExecuteReader();
            while (red.Read())
            {
                Console.WriteLine (red["UserName"].ToString()+" ; "+ red["RoleName"].ToString() +" ; "+ red["LoginName"].ToString()+" ; "+red["UserID"].ToString() );
                int id = Int32.Parse(red["userid"].ToString());
                bool pridajusra = true;
                foreach (User u in usery)
                {
                    if (u.User_id == id)
                    {
                        u.Roly.Add(red["RoleNAme"].ToString());
                        pridajusra = false;
                    }
                                       
                }
                if (pridajusra)
                {
                    User usr = new User();
                    usr.UserName = red["UserName"].ToString();
                    usr.Roly.Add(red["RoleNAme"].ToString());
                    usr.Login = red["LoginName"].ToString();
                    usr.User_id = id;
                    usery.Add(usr);
                }
            }
            return usery;
        }

        public override string GetNameOfDB()
        {
            return NazovDB;
        }

        public string removeParentesis(string input)
        {
            string output = input;
            if (input.Contains("((") && input.Contains("))"))
            {
                output = input.Replace("((", "(");
                output = output.Replace("))", ")");
            }
            return output;
        }

        

        public override List <string> createProcedure(SProcedure procIn)
        {
            List <string> output = new List<string>();
            string proctext = "";
            foreach (string s in procIn.SqlText)
            {
                proctext += s;
            }
            output.Add(proctext);
           
            foreach (Privilege priv in procIn.Privieges)
            {
                output.Add(createPrivilege(priv));
              
            }
            
                
            return output;
        }

        public override string createPrivilege(Privilege privIn)
        {
            string output = "";
            if (privIn != null)
            {
                output = "GRANT " + privIn.Privilege_type + " ON " + privIn.Table_name + " TO " + privIn.Grantee + "\r\n";
                
            }
            
            return output;
        }

        public override List <string> createFunction(SFunction funkcIn)
        {
            List<string> output = new List<string>();
            string proctext = "";
            foreach (string s in funkcIn.SqlText)
            {
                proctext += s;
            }
            output.Add(proctext);
            
            foreach (Privilege priv in funkcIn.Privileges)
            {
                output.Add(createPrivilege(priv));
            }

            return output;
        }

        public override string createType(Typ typIn)
        {
            string output = "";
            if (typIn != null)
            {
                int typeofgen = 0;
                switch (typIn.Datatyp)
                {
                    case "bigint": typeofgen = 1; break;
                    case "binary": typeofgen = 2; break;
                    case "bit": typeofgen = 1; break;
                    case "char": typeofgen = 2; break;
                    case "datetime": typeofgen = 1; break;
                    case "datetime2": typeofgen = 3; break;
                    case "datetimeoffset": typeofgen = 3; break;
                    case "decimal": typeofgen = 4; break;
                    case "float": typeofgen = 1; break;
                    case "image": typeofgen = 1; break;
                    case "int": typeofgen = 1; break;
                    case "money": typeofgen = 1; break;
                    case "nchar": typeofgen = 2; break;
                    case "ntext": typeofgen = 1; break;
                    case "numeric": typeofgen = 4; break;
                    case "nvarchar": typeofgen = 2; break;
                    case "real": typeofgen = 1; break;
                    case "smalldatetime": typeofgen = 1; break;
                    case "smallint": typeofgen = 1; break;
                    case "smallmoney": typeofgen = 1; break;
                    case "sql_variant": typeofgen = 1; break;
                    case "text": typeofgen = 1; break;
                    case "time": typeofgen = 3; break;
                    case "tinyint": typeofgen = 1; break;
                    case "uniqueidentifier": typeofgen = 1; break;
                    case "varbinary": typeofgen = 2; break;
                    case "varchar": typeofgen = 2; break;
                    default:break;
                }
                if (typeofgen == 0)
                {
                    throw new Exception(typIn.Datatyp+ " is not recognized datatype.");
                }
                
                if (typeofgen == 1)
                {
                    output = "CREATE TYPE " +typIn.Nazov+ " FROM " +typIn.Datatyp ;
                    if (typIn.CanBeNull) output +=" NULL";
                    else output += " NOT NULL";
                }

                if (typeofgen == 2)
                {
                    output = "CREATE TYPE " + typIn.Nazov + " FROM " + typIn.Datatyp+ "("+typIn.Precision+")";
                    if (typIn.CanBeNull) output += " NULL";
                    else output += " NOT NULL";
                }

                if (typeofgen == 3)
                {
                    output = "CREATE TYPE " + typIn.Nazov + " FROM " + typIn.Datatyp + "(" + typIn.Scale + ")";
                    if (typIn.CanBeNull) output += " NULL";
                    else output += " NOT NULL";
                }

                if (typeofgen == 4)
                {
                    output = "CREATE TYPE " + typIn.Nazov + " FROM " + typIn.Datatyp + "(" + typIn.Precision +"," +typIn.Scale + ")";
                    if (typIn.CanBeNull) output += " NULL";
                    else output += " NOT NULL";
                }
            }
            //output += " GO " + Environment.NewLine;
            return output+Environment.NewLine;
        }

        public override List<string> executeText(List <string> text)
        {
            pripojenie.Close();
            pripojenie.Open();
            List<string> output = new List<string>();
            SqlCommand com = pripojenie.CreateCommand();
            SqlTransaction  t = pripojenie.BeginTransaction();
            com.Transaction = t;
            try
                {
                foreach (string s in text)
                {
                com.CommandText = s;
                com.ExecuteNonQuery();
                
                }
                }
            catch (Exception e)
            {
                string ss = "an error occured while executing command " /*+ s + Environment.NewLine*/ + " error description : " + e.Message;
                output.Add(ss);
            }
            finally
            {
                if (output.Count > 0)
                {
                    t.Rollback();
                    string sss = "No changes applied to database ";
                    output.Add(sss);
                }
                else
                {
                    t.Commit();
                    needsUpdate();
                }
            }
            return output;
           
        }



        public override List<string> createUser(User usrIn)
        {
            List<string> output = new List<string>();

            // 1. find out if login is existing
            bool loginExist = false;
            string defPass = "defaultpassword";
            SqlCommand com = pripojenie.CreateCommand();
            com.CommandText = "SELECT * FROM sys.server_principals where  name = '" + usrIn.Login+"'";
            SqlDataReader red = com.ExecuteReader();
            if (red.Read()) loginExist = true;

            if (loginExist)
            {
                output.Add(" CREATE USER " + usrIn.UserName + " for LOGIN " + usrIn.Login);
            }
            else
            {
                output.Add(" CREATE LOGIN " + usrIn.Login + " with password= '" + defPass+"'");
                output.Add(" CREATE USER " + usrIn.UserName + " for LOGIN " + usrIn.Login);
            }

            foreach (string role in usrIn.Roly)
            {
                output.Add("sp_addrolemember " + role + " , " + usrIn.UserName);
            }
            
            return output; 
        }

        public override List<string> createTable(Tablee tabIn)
        {
            List<string> output = new List<string>();
            string s = "Create table [" + tabIn.NazovTabulky + "]( ";
            foreach (Columnn col in tabIn.Stlpce)
            {
                string nulnotnull;
                if (col.IS_NULLABLE1 == "YES") nulnotnull = "NULL";
                else nulnotnull = "NOT NULL";
                //if (col.COULUMN_DEFAULT1.Length == 0) s += col.COULUMN_NAME1 + " " + generateType(col) + " " + nulnotnull + " ," + Environment.NewLine;
                s += col.COULUMN_NAME1 + " " + generateType(col) + " " + addDefault(col) +" " + nulnotnull + " ," + Environment.NewLine;
                
            }
            foreach (Constraintt con in tabIn.Constrainty)
            {
                if (con.Constraint_typ == "PRIMARY KEY")
                {
                    //vyhladam index s nazvom kluca
                    string cluster = "";
                    foreach (Index ind in tabIn.Indexy)
                    {
                        if (con.Constraint_nam == ind.Name)
                        {
                            cluster = ind.Type;
                        }
                    }

                    s += "Constraint " + con.Constraint_nam + " " + con.Constraint_typ + " "+cluster +" (";
                    bool putcolumn = false;
                    foreach (string ss in con.Column)
                    {
                        if (putcolumn) s += ",";
                        putcolumn = true;
                        s += ss;
                    }
                    s += ")";
                }
            }
            
 
            s += " )";
            output.Add(s);
            //zaklad tabulkky je vytvoreny

            //vytvorim kluce
            output.AddRange(addForeinKey(tabIn));
            output.AddRange(addcheckConst(tabIn));
            output.AddRange(addIndexes(tabIn));
            output.AddRange(addTriggers(tabIn));

            foreach (Privilege priv in tabIn.Privileges)
            {
                output.Add(createPrivilege(priv));
            }

            return output;
        }
        private List<string> addTriggers(Tablee tab)
        {
            List<string> output = new List<string>();
            foreach (Trigger trig in tab.Trigre)
            {
                string text = "";
                foreach (string s in trig.SqlText)
                {
                    text += s;
                }
                output.Add(text);
            }

            return output;
        }
        private List<string> addIndexes(Tablee tab)
        {
            List<string> output = new List<string>();
            //zistim ktore indexy treba vytvorit
            List<string> finishedIndexes = new List<string>();
            

            foreach (Index ind in tab.Indexy)
            {
                //zistim ci na indexnachadza v uz vytvorenych
                bool exist = false;
                if (ind.IsPrmaryKey) exist = true;
                
                string cols = "";
                bool comma = false;
                foreach (string s in ind.Columns)
                {
                    if (comma) cols +=",";
                    comma=true;
                    cols += s;
                }

                if (!exist)
                {
                    string unq = "";
                    if (ind.Unique) unq = "UNIQUE";
                    output.Add("CREATE " + unq + " " + ind.Type + " INDEX " + ind.Name + " ON [" + tab.NazovTabulky + "](" + cols + ")");
                }

                

            }
            return output;
            
        }
        private List<string> addcheckConst(Tablee tab)
        {
            List<string> output = new List<string>();
            foreach (Constraintt con in tab.Constrainty)
            {
                if (con.Constraint_typ == "CHECK")
                {
                    output.Add("ALTER TABLE [" + tab.NazovTabulky + "] ADD CONSTRAINT "+con.Constraint_nam+" CHECK (" + con.Condition + ")");
                }
            }
            return output;

        }
        private List<string> addForeinKey(Tablee tab)
        {
            List<string> output = new List<string>();
            List <Key> k = tab.Keys;
            foreach (Key kk in k)
            {
                if (!kk.PrimaryKey)
                {
                    output.Add("ALTER TABLE [" + tab.NazovTabulky + "] ADD CONSTRAINT "+kk.NameOfKey+" FOREIGN KEY (" + kk.NameOfColumns[0] + ") REFERENCES " + kk.NameofFTable + "(" + kk.NameOfFcolumn + ");");
                }
            }
            return output;

        }

        private string addDefault(Columnn col)
        {
            string output = "";
            if (col.COULUMN_DEFAULT1.Length > 0) output = " DEFAULT " + col.COULUMN_DEFAULT1;
            return output;
        }

        //private string addPrimaryKey(Columnn col)
        //{
        //    string output = "";
        //    if (col.Is_primaryKey()) output = " PRIMARY KEY " ;
        //    return output;
        //}
        
        private string generateType(Columnn col)
        {
            string output= "";
            int typeofgen = 0;
            switch (col.DATA_TYPE1)
            {
                case "bigint": typeofgen = 1; break;
                case "binary": typeofgen = 2; break;
                case "bit": typeofgen = 1; break;
                case "char": typeofgen = 2; break;
                case "date": typeofgen = 1; break;
                case "datetime2": typeofgen = 3; break;
                case "datetimeoffset": typeofgen = 3; break;
                case "decimal": typeofgen = 4; break;
                case "float": typeofgen = 1; break;
                case "geography": typeofgen = 1; break;
                case "geometry": typeofgen = 1; break;
                case "hierarchyid": typeofgen = 1; break;
                case "image": typeofgen = 1; break;
                case "int": typeofgen = 1; break;
                case "money": typeofgen = 1; break;
                case "nchar": typeofgen = 2; break;
                case "ntext": typeofgen = 1; break;
                case "numeric": typeofgen = 4; break;
                case "nvarchar": typeofgen = 2; break;
                case "real": typeofgen = 1; break;
                case "smalldatetime": typeofgen = 1; break;
                case "smallint": typeofgen = 1; break;
                case "smallmoney": typeofgen = 1; break;
                case "sql_variant": typeofgen = 1; break;
                case "text": typeofgen = 1; break;
                case "time": typeofgen = 3; break;
                case "tinyint": typeofgen = 1; break;
                case "uniqueidentifier": typeofgen = 1; break;
                case "varbinary": typeofgen = 2; break;
                case "varchar": typeofgen = 2; break;
                default: break;
            }
            if (typeofgen == 0)
            {
                output = col.DATA_TYPE1;
            }

            if (typeofgen == 1)
            {
                output = col.DATA_TYPE1;
            }

            if (typeofgen == 2)
            {
                output = col.DATA_TYPE1 + "(" + col.CHARACTER_MAXIMUM_LENGTH1 + ") ";
            }

            if (typeofgen == 3)
            {
                output = col.DATA_TYPE1 + "(" + col.DATETIME_PRECISION1 + ") ";
            }

            if (typeofgen == 4)
            {
                output = col.DATA_TYPE1 + "(" + col.NUMERIC_PRECISION1 +","+col.NUMERIC_SCALE1+ ") ";
            }

            return output;
        }

        public override List<string> removeProcedure(SProcedure procIn)
        {
            List<string> output = new List<string>();
            output.Add("DROP PROCEDURE [" + procIn.NazovProcedury+"]");
            return output;
        }

        public override List<string> removeFunction(SFunction funkcIn)
        {
            List<string> output = new List<string>();
            output.Add("DROP FUNCTION [" + funkcIn.NazovFunkcie+"]");
            return output;
        }

        public override List<string> removeTable(Tablee tabIn)
        {
            List<string> output = new List<string>();
            output.Add("DROP TABLE [" + tabIn.NazovTabulky+"]");
            return output;
        }

        public override List<string> removeType(Typ typIn)
        {
            List<string> output = new List<string>();
            output.Add("DROP TYPE [" + typIn.Nazov+"]");
            return output;
        }

        public override List<string> removeFKonTab(Tablee tab)
        {
            List<string> output = new List<string>();
            foreach (Key k in tab.Keys)
            {
                if (!k.PrimaryKey)
                {
                    output.Add("ALTER TABLE [" + tab.NazovTabulky + "] DROP FOREIGN KEY " + k.NameOfKey);
                }
            }
            return output;
        }

        public override List<string> removeUser(User usrIn)
        {
            List<string> output = new List<string>();
            if (!systemUsers.Contains(usrIn.UserName))
            {
                output.Add("DROP USER [" + usrIn.UserName+"]");
            } 
            return output;
        }

        public override List<string> alterFunction(SFunction funkcIn)
        {
            List<string> output = new List<string>();
            output.Add("DROP FUNCTION [" + funkcIn.NazovFunkcie+"]");
            output.AddRange(createFunction(funkcIn));
            return output;
            
        }

        public override List<string> alterProcedure(SProcedure procIn)
        {
            List<string> output = new List<string>();
            output.Add("DROP PROCEDURE [" + procIn.NazovProcedury+"]");
            output.AddRange(createProcedure(procIn));
            return output;
        }

        public override List<string> alterType(Typ typeIn)
        {
            List<string> output = new List<string>();
            output.Add("DROP TYPE [" + typeIn.Nazov+"]");
            output.Add(createType(typeIn));
            return output;
        }

        public override List<string> alterUser(User usrIn)
        {
            List<string> output = new List<string>();
            if (!systemUsers.Contains(usrIn.UserName))
            {
                output.Add("DROP USER [" + usrIn.UserName+"]");
                output.AddRange(createUser(usrIn));
            }
            return output;
        }

        //public override List<string> alterTable(Tablee tabIn)
        //{
        //    throw new NotImplementedException();
        //}



        public override List<string> addcolumn(Tablee tabIn, Columnn colIn)
        {
            List<string> output = new List<string>();
            string nulnotnull;
            if (colIn.IS_NULLABLE1 == "YES") nulnotnull = "NULL";
            else nulnotnull = "NOT NULL";
            output.Add("ALTER TABLE " + tabIn.NazovTabulky + " ADD " + colIn.COULUMN_NAME1 + " " + generateType(colIn) + " " + nulnotnull);
            //zistim ci existuje constrainta na povodnej tabulke
            if (colIn.COULUMN_DEFAULT1.Length > 0)
            {
                string name = "DF_" + tabIn.NazovTabulky + "_" + colIn.COULUMN_NAME1;
                foreach (Constraintt con in tabIn.Constrainty)
                {
                    if (con.Constraint_typ == "DEFAULT")
                    {
                        if (con.Column[0] == colIn.COULUMN_NAME1)
                        {
                            //zrusim existujucu constraint
                            output.Add("ALTER TABLE " + tabIn.NazovTabulky + "  DROP CONSTRAINT " + con.Constraint_nam);
                            name = con.Constraint_nam;
                        }
                    }
                }
                output.Add("ALTER TABLE " + tabIn.NazovTabulky + " ADD CONSTRAINT " + name + " DEFAULT " + colIn.COULUMN_DEFAULT1 + " FOR " + colIn.COULUMN_NAME1);
            }
            return output;
        }

        public override List<string> removeColumn(Tablee tabIn, Columnn colIn)
        {
            List<string> output = new List<string>();
            output.Add("ALTER TABLE " + tabIn.NazovTabulky + " DROP COLUMN " + colIn.COULUMN_NAME1 );
            return output;
        }

        public override List<string> alterColumn(Tablee tabIn, Columnn colIn)
        {
            List<string> output = new List<string>();
            
             string nulnotnull;
             if (colIn.IS_NULLABLE1 == "YES") nulnotnull = " ";
            else nulnotnull = "NOT NULL";
            output.Add("ALTER TABLE " + tabIn.NazovTabulky + " ALTER COLUMN " + colIn.COULUMN_NAME1 + " " + generateType(colIn) + " " + nulnotnull);
            //zistim ci existuje constrainta na povodnej tabulke
            if (colIn.COULUMN_DEFAULT1.Length > 0)
            {
                string name = "DF_" + tabIn.NazovTabulky + "_" + colIn.COULUMN_NAME1;
                foreach (Constraintt con in tabIn.Constrainty)
                {
                    if (con.Constraint_typ == "DEFAULT")
                    {
                        if (con.Column[0] == colIn.COULUMN_NAME1)
                        {
                            //zrusim existujucu constraint
                            output.Add("ALTER TABLE " + tabIn.NazovTabulky + "  DROP CONSTRAINT " + con.Constraint_nam);
                            name = con.Constraint_nam;
                        }
                    }
                }
                output.Add("ALTER TABLE " + tabIn.NazovTabulky + " ADD CONSTRAINT " + name + " DEFAULT " + colIn.COULUMN_DEFAULT1 + " FOR " + colIn.COULUMN_NAME1);
            }
            
            return output;
        }

        public override List<string> addKey(Tablee tabIn, Key keyIn)
        {
            List<string> output = new List<string>();
            string ss= "";
            bool addcol = false;
            foreach (string s in keyIn.NameOfColumns)
            {
               if (addcol) ss+=",";
                addcol =true;
                ss+=s;
            }
            
            if (keyIn.PrimaryKey)
            {
                output.Add( "ALTER TABLE "+tabIn.NazovTabulky+" ADD CONSTRAINT "+keyIn.NameOfKey+" PRIMARY KEY ("+ss+")");
            }
            else
            {
                output.Add("ALTER TABLE [" + tabIn.NazovTabulky + "] ADD CONSTRAINT " + keyIn.NameOfKey + " FOREIGN KEY (" + keyIn.NameOfColumns[0] + ") REFERENCES " + keyIn.NameofFTable + "(" + keyIn.NameOfFcolumn + ");");
            }
                return output;
        }

        public override List<string> alterKey(Tablee tabIn, Key keyIn)
        {
            List<string> output = new List<string>();
            output.AddRange(removeKey(tabIn, keyIn));
            output.AddRange(addKey(tabIn, keyIn));
            return output;
        }

        public override List<string> removeKey(Tablee tabIn, Key keyIn)
        {
            List<string> output = new List<string>();
                output.Add("ALTER TABLE " + tabIn.NazovTabulky + " drop CONSTRAINT " + keyIn.NameOfKey );
            return output;
        }

        public override List<string> addConstraint(Tablee tabIn, Constraintt constIn)
        {
            List<string> output = new List<string>();

            if (constIn.Constraint_typ == "CHECK")
                {
                    output.Add("ALTER TABLE [" + tabIn.NazovTabulky + "] ADD CONSTRAINT " + constIn.Constraint_nam + " CHECK (" + constIn.Condition + ")");
                }
          
            return output;
        }

        public override List<string> alterConstraint(Tablee tabIn, Constraintt constIn)
        {
            List<string> output = new List<string>();
            if (constIn.Constraint_typ != "PRIMARY KEY")
            {
                if (constIn.Constraint_typ != "FOREIGN KEY")
                {
                    output.AddRange(removeConstraint(tabIn, constIn));
                    output.AddRange(addConstraint(tabIn, constIn));
                }
            }
                return output;
        }

        public override List<string> removeConstraint(Tablee tabIn, Constraintt constIn)
        {
            List<string> output = new List<string>();
            if (constIn.Constraint_typ != "PRIMARY KEY")
                if (constIn.Constraint_typ != "FOREIGN KEY")
                {
                    {
                        output.Add("ALTER TABLE " + tabIn.NazovTabulky + " drop CONSTRAINT " + constIn.Constraint_nam);
                    }
                }
                return output;
        }

        public override List<string> addTrigger(Tablee tabIn, Trigger trigIn)
        {
            List<string> output = new List<string>();
           string text = "";
                foreach (string s in trigIn.SqlText)
                {
                    text += s;
                }
                output.Add(text);
           

            return output;
        }

        public override List<string> alterTrigger(Tablee tabIn, Trigger trigIn)
        {
            List<string> output = new List<string>();
            output.AddRange(removeTrigger(tabIn,trigIn));
            output.AddRange(addTrigger(tabIn, trigIn));
            return output;
        }

        public override List<string> removeTrigger(Tablee tabIn, Trigger trigIn)
        {
            List<string> output = new List<string>();
            output.Add(" DROP TRIGGER " + trigIn.Trigger_name );
            return output;
            
        }

        public override List<string> addIndex(Tablee tabIn, Index indexIn)
        {
            List<string> output = new List<string>();
            bool exist = false;
            if (indexIn.IsPrmaryKey) exist = true;

            string cols = "";
            bool comma = false;
            foreach (string s in indexIn.Columns)
            {
                if (comma) cols += ",";
                comma = true;
                cols += s;
            }

            if (!exist)
            {
                string unq = "";
                if (indexIn.Unique) unq = "UNIQUE";
                output.Add("CREATE " + unq + " " + indexIn.Type + " INDEX " + indexIn.Name + " ON [" + tabIn.NazovTabulky + "](" + cols + ")");
            }
            return output;
        }

        public override List<string> alterIndex(Tablee tabIn, Index indexIn)
        {
            List<string> output = new List<string>();
            if (!indexIn.IsPrmaryKey)
            {
                output.AddRange(removeIndex(tabIn,indexIn));
                output.AddRange(addIndex(tabIn, indexIn));
            }
            return output;
        }

        public override List<string> removeIndex(Tablee tabIn, Index indexIn)
        {
            List<string> output = new List<string>();
            if (!indexIn.IsPrmaryKey)
            {
                output.Add(" ALTER TABLE " + tabIn.NazovTabulky + " DROP INDEX " + indexIn.Name);
            }
            return output;
        }

        public override List<string> removePrivilege(Privilege privIn)
        {
             List<string> output = new List<string>();
            if (privIn != null)
            {
                output.Add( "REVOKE " + privIn.Privilege_type + " ON " + privIn.Table_name + " from " + privIn.Grantee );

            }

            return output;
        }

        public override List<string> alterPrivilege(Privilege privIn)
        {
            List<string> output = new List<string>();
            output.AddRange(removePrivilege(privIn));
            output.Add(createPrivilege(privIn));
            return output;
            
        }

        public override System.Data.Common.DbDataReader getReaderOfTable(string tablename, string conditionColumn, string conditionVal)
        {
            SqlCommand com = pripojenie.CreateCommand() ;
            if (conditionColumn.Length > 0)
            {
                com.CommandText = ("SELECT * FROM [" + tablename+ "] WHERE ["+conditionColumn+"] = '"+conditionVal+"'" );
            }
            else
            {
                com.CommandText = ("SELECT * FROM [" + tablename+"]");
            }
            SqlDataReader red = com.ExecuteReader();
            return red;
        }

        public override string updateRow(string tablename, List<ColVal> values, ColVal key)
        {
            
            string commandText = ("UPDATE [" + tablename + "] SET ");
            bool putcolumn = false;
            foreach (ColVal cv in values)
            {
                if (putcolumn) commandText += ",";
                putcolumn = true;
                commandText += " [" + cv.NameOfCol + "] = '" + cv.ColValue + "' ";
            }
            commandText += " WHERE ["+key.NameOfCol+"]= '"+key.ColValue+"'";
            return commandText;
        }

        public override string insertRow(string tablename, List<ColVal> values)
        {
            string commandText = ("INSERT INTO [" + tablename + "] ( ");
            bool putcolumn = false;
            foreach (ColVal cv in values)
            {
                if (putcolumn) commandText += ",";
                putcolumn = true;
                commandText += " [" + cv.NameOfCol + "] ";
            }
            commandText += ") VALUES (";
            putcolumn = false;
            foreach (ColVal cv in values)
            {
                if (putcolumn) commandText += ",";
                putcolumn = true;
                commandText += " '" + cv.ColValue + "' ";
            }
            commandText += ")";
            return commandText;
        }

        public override string deleteRow(string tablename, ColVal key)
        {
            string commandtext = "DELETE FROM " + tablename + " WHERE [" + key.NameOfCol + "]='" + key.ColValue + "'";
            return commandtext;
        }
    }
}
