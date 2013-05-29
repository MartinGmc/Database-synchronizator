using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Databazovy_Synchronizator
{
    public abstract class Connectionc
    {
      //public string typPripojenia;

      public event EventHandler needsUpdateView;

      //functions to read data
      public abstract bool createConnection(); 
      public abstract string GetNameOfDB();
      public abstract List<Tablee> ReadTables();
      public abstract List<SProcedure> ReadProcedures();
      public abstract List<SFunction> ReadFunctions();
      public abstract List<Typ> ReadTypes();
      public abstract List<User> ReadUsers();
      
      //functions to generate scripts
      //scripts to create objects
      public abstract List<string> createProcedure(SProcedure procIn);
      public abstract string createPrivilege(Privilege privIn);
      public abstract List<string> createFunction(SFunction funkcIn);
      public abstract string createType(Typ typIn);
      public abstract List<string> createUser(User usrIn);
      public abstract List<string> createTable(Tablee tabIn);
      
      //scripts to remove objects
      public abstract List<string> removeProcedure(SProcedure procIn);
      public abstract List<string> removeFunction(SFunction funkcIn);
      public abstract List<string> removeTable(Tablee tabIn);
      public abstract List<string> removeType(Typ typIn);
      public abstract List<string> removeUser(User usrIn);
      public abstract List<string> removeFKonTab(Tablee tab);
      public abstract List<string> removePrivilege(Privilege privIn);

      //scripts to modify objects
      public abstract List<string> alterFunction(SFunction funkcIn);
      public abstract List<string> alterProcedure(SProcedure procIn);
      public abstract List<string> alterType(Typ typeIn);
      public abstract List<string> alterUser(User usrIn);
      public abstract List<string> addcolumn(Tablee tabIn, Columnn colIn);
      public abstract List<string> alterColumn(Tablee tabIn, Columnn colIn);
      public abstract List<string> removeColumn(Tablee tabIn, Columnn colIn);
      public abstract List<string> addKey(Tablee tabIn, Key keyIn);
      public abstract List<string> alterKey(Tablee tabIn, Key keyIn);
      public abstract List<string> removeKey(Tablee tabIn, Key keyIn);
      public abstract List<string> addConstraint(Tablee tabIn, Constraintt constIn);
      public abstract List<string> alterConstraint(Tablee tabIn, Constraintt constIn);
      public abstract List<string> removeConstraint(Tablee tabIn, Constraintt constIn);
      public abstract List<string> addTrigger(Tablee tabIn, Trigger trigIn);
      public abstract List<string> alterTrigger(Tablee tabIn, Trigger trigIn);
      public abstract List<string> removeTrigger(Tablee tabIn, Trigger trigIn);
      public abstract List<string> addIndex(Tablee tabIn, Index indexIn);
      public abstract List<string> alterIndex(Tablee tabIn, Index indexIn);
      public abstract List<string> removeIndex(Tablee tabIn, Index indexIn);
      public abstract List<string> alterPrivilege(Privilege privIn);
      //  public abstract List<string> alterTable(Tablee tabIn);

      //function to execute scripts
      public abstract List<string> executeText(List<string> text);
      
      //functions to read data for comparing
      public abstract DbDataReader getReaderOfTable(string tablename, string conditionColumn, string conditionVal);
      public abstract string updateRow(string tablename, List<ColVal> values, ColVal key);
      public abstract string insertRow(string tablename, List<ColVal> values);
      public abstract string deleteRow(string tablename, ColVal key);

      public void needsUpdate()
      {
          needsUpdateView(this, new EventArgs());
      }

    }
}
