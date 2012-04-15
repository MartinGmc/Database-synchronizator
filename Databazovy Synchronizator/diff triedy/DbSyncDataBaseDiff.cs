using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
  public class DbSyncDataBaseDiff
    {
        private DataBasee dataBaseA;
        private DataBasee dataBaseB;

        private string DatabaseNameA;
        private string DatabaseNameB;

        private List<DbSyncTableDiff>           difftables;
        private List<DbSyncStoredProcedureDiff> diffStoredProcedures;
        private List<DbSyncFunctionDiff>        diffFunctions;
        private List<DbSyncTypeDiff>            diffTypes;
        private List<DbSyncUserDiff>            diffUsers;

        private bool areDiffTables = false;
        private bool areDiffStoredProcedures = false;
        private bool areDiffFunctions = false;
        private bool areDiffTypes = false;
        private bool areDiffUsers = false;

        public bool AreDiffTables()
        {
            return areDiffTables;
        }
        public bool AreDiffStoredProcedures()
        {
            return areDiffStoredProcedures;
        }
        public bool AreDiffFunctions()
        {
            return areDiffFunctions;
        }
        public bool AreDiffTypes()
        {
            return areDiffTypes;
        }
        public bool AreDiffUSers()
        {
            return areDiffUsers;
        }
      
        public List<DbSyncTableDiff> getTablediff()
        {
            return difftables;
        }
        public List<DbSyncStoredProcedureDiff> getStoredProcedureDiff()
        {
            return diffStoredProcedures;
        }
        public List<DbSyncFunctionDiff> getFunctionDiff()
        {
            return diffFunctions;
        }
        public List<DbSyncTypeDiff> getTypesDiff()
        {
            return diffTypes;
        }
        public List<DbSyncUserDiff> getUserDiff()
        {
            return diffUsers;
        }

        public DbSyncDataBaseDiff(DataBasee db1, DataBasee db2)
        {
            this.dataBaseA = db1;
            this.dataBaseB = db2;

            if (dataBaseA != null) DatabaseNameA = dataBaseA.getNameOfDAtabase();
            if (dataBaseB != null) DatabaseNameB = dataBaseB.getNameOfDAtabase();
            

            //vytvorim listy
            diffFunctions = new List<DbSyncFunctionDiff>();
            diffStoredProcedures = new List<DbSyncStoredProcedureDiff>();
            difftables = new List<DbSyncTableDiff>();
            diffTypes = new List<DbSyncTypeDiff>();
            diffUsers = new List<DbSyncUserDiff>();

            //vytvorim objekty tabuliek
            foreach (Tablee tabA in dataBaseA.Tabulky)
            {
                //zistim ci je tabulka s rovnakym nazovm v databaseB
                bool found = false;
                foreach (Tablee tabB in dataBaseB.Tabulky)
                {
                   
                    if (tabA.NazovTabulky == tabB.NazovTabulky)
                    { 
                        difftables.Add(new DbSyncTableDiff(tabA,tabB));
                        found = true;
                    }
                }
                if (!found) difftables.Add(new DbSyncTableDiff(tabA, null));
            }
            //este zistim ci nahodou nejaka tabulka v DatabaseB nieje naviac
            foreach (Tablee tabB in dataBaseB.Tabulky)
            {
                bool found = false;
                foreach (DbSyncTableDiff diff in difftables)
                {
                    if (diff.getTableName() == tabB.NazovTabulky) found = true;
                }
                if (!found) difftables.Add(new DbSyncTableDiff(null, tabB));
            }
            // tabulky vytvorene

            //vytvorim objekty Stored procedur
            foreach (SProcedure spA in dataBaseA.Procedury)
            {
                //zistim ci je procedura s rovnakym nazovm v databaseB
                bool found = false;
                foreach (SProcedure spB in dataBaseB.Procedury)
                {

                    if (spA.NazovProcedury == spB.NazovProcedury)
                    {
                        diffStoredProcedures.Add(new DbSyncStoredProcedureDiff(spA, spB));
                        found = true;
                    }
                }
                if (!found) diffStoredProcedures.Add(new DbSyncStoredProcedureDiff(spA, null));
            }
            //este zistim ci nahodou nejaka procedura v DatabaseB nieje naviac
            foreach (SProcedure spB in dataBaseB.Procedury)
            {
                bool found = false;
                foreach (DbSyncStoredProcedureDiff diff in diffStoredProcedures)
                {
                    if (diff.getName() == spB.NazovProcedury) found = true;
                }
                if (!found) diffStoredProcedures.Add(new DbSyncStoredProcedureDiff(null, spB));
            }
            // Procedury vytvorene

            //vytvorim objekty funkcii
            foreach (SFunction sfA in dataBaseA.Funkcie)
            {
                
                bool found = false;
                foreach (SFunction sfB in dataBaseB.Funkcie)
                {

                    if (sfA.NazovFunkcie == sfB.NazovFunkcie)
                    {
                        diffFunctions.Add(new DbSyncFunctionDiff(sfA, sfB));
                        found = true;
                    }
                }
                if (!found) diffFunctions.Add(new DbSyncFunctionDiff(sfA, null));
            }

            foreach (SFunction sfB in dataBaseB.Funkcie)
            {
                bool found = false;
                foreach (DbSyncFunctionDiff diff in diffFunctions)
                {
                    if (diff.getName() == sfB.NazovFunkcie) found = true;
                }
                if (!found) diffFunctions.Add(new DbSyncFunctionDiff(null, sfB));
            }
            // funkcie vytvorene

            //vytvorim objekty typov
            foreach (Typ typA in dataBaseA.Typy)
            {

                bool found = false;
                foreach (Typ typB in dataBaseB.Typy)
                {

                    if (typA.Nazov == typB.Nazov)
                    {
                        diffTypes.Add(new DbSyncTypeDiff(typA, typB));
                        found = true;
                    }
                }
                if (!found) diffTypes.Add(new DbSyncTypeDiff(typA, null));
            }

            foreach (Typ typB in dataBaseB.Typy)
            {
                bool found = false;
                foreach (DbSyncTypeDiff diff in diffTypes)
                {
                    if (diff.getName() == typB.Nazov) found = true;
                }
                if (!found) diffTypes.Add(new DbSyncTypeDiff(null, typB));
            }
            // typy vytvorene

            //vytvorim objekty userov
            foreach (User usrA in dataBaseA.Usery)
            {

                bool found = false;
                foreach (User usrB in dataBaseB.Usery)
                {

                    if (usrA.UserName == usrB.UserName)
                    {
                        diffUsers.Add(new DbSyncUserDiff(usrA, usrB));
                        found = true;
                    }
                }
                if (!found) diffUsers.Add(new DbSyncUserDiff(usrA, null));
            }

            foreach (User usrB in dataBaseB.Usery)
            {
                bool found = false;
                foreach (DbSyncUserDiff diff in diffUsers)
                {
                    if (diff.getName() == usrB.UserName) found = true;
                }
                if (!found) diffUsers.Add(new DbSyncUserDiff(null, usrB));
            }
            // usery vytvoreny

            foreach (DbSyncTableDiff tab in difftables)
            {
                if (tab.isDifferent()) areDiffTables = true;
            }

            foreach (DbSyncFunctionDiff funct in diffFunctions)
            {
                if (funct.isDifferent()) areDiffFunctions = true;
            }

            foreach (DbSyncStoredProcedureDiff proc in diffStoredProcedures)
            {
                if (proc.isDifferent()) areDiffStoredProcedures = true;
            }

            foreach (DbSyncTypeDiff typee in diffTypes)
            {
                if (typee.isDifferent()) areDiffTypes = true;
            }

            foreach (DbSyncUserDiff usr in diffUsers)
            {
                if (usr.isDifferent()) areDiffUsers = true;
            }
           
        }

        public string getNameA()
        {
            return DatabaseNameA;
        }

        public string getNameB()
        {
            return DatabaseNameB;
        }
    }
}
