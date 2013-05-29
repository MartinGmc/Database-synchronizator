using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
   public class SqlTextHighlited
    {
        List<string> text;

        public List<string> Text
        {
            get { return text; }
           
        }
        List<int> highlited;

        public List<int> Highlited
        {
            get { return highlited; }
           
        }

        public string getText()
        {
            string ress = "";
            foreach (string s in text)
            {
                ress += s;
            }
            return ress;
        }

        public SqlTextHighlited (List<string> textIn,List<int>highlitedIn)
        {
            this.text = textIn;
            this.highlited = highlitedIn;
        }
    }
}
