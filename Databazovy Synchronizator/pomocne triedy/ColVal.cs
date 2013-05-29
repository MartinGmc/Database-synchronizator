using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
   public class ColVal
    {
        private string nameOfCol;
        private string colValue;


        public string NameOfCol
        {
            get { return nameOfCol; }
            set { nameOfCol = value; }
        }
       
        public string ColValue
        {
            get { return colValue; }
            set { colValue = value; }
        }

        public ColVal (string nameColIn ,string valIn)
        {
            this.colValue = valIn;
            this.nameOfCol = nameColIn;

        }
    }
}
