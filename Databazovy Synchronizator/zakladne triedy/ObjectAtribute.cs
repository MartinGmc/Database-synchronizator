using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
    class ObjectAtribute
    {
        private string nameOfAtribute;
        private string atributeValue;
        private bool isHighlited;
        private bool isSql = false;

        public bool IsSql
        {
            get { return isSql; }
           
        }

        public string NameOfAtribute
        {
            get { return nameOfAtribute; }
        }
        

        public string AtributeValue
        {
            get { return atributeValue; }
           
        }
       

        public bool IsHighlited
        {
            get { return isHighlited; }
          
        }

        public ObjectAtribute(string inName, string inValue, bool inHighlited)
        {
            this.nameOfAtribute = inName;
            this.atributeValue = inValue;
            this.isHighlited = inHighlited;
        }

        public ObjectAtribute(string inName, string inValue, bool inHighlited,bool inIsSql)
        {
            this.nameOfAtribute = inName;
            this.atributeValue = inValue;
            this.isHighlited = inHighlited;
            this.isSql = inIsSql;
        }
        

    }
}
