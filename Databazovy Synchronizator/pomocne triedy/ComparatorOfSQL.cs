using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Databazovy_Synchronizator
{
   public class ComparatorOfSQL
    {
        private SqlTextHighlited textA;
        private SqlTextHighlited textB;

        internal SqlTextHighlited TextA
        {
            get { return textA; }
          
        }
        internal SqlTextHighlited TextB
        {
            get { return textB; }
            
        }
        
        private List<string> sqltextA;
        private List<string> sqltextB;
        
        private List<int> highlitedB;
        private List<int> highlitedA;

        private bool isDifferent = false;

        public bool IsDifferent
        {
            get { return isDifferent; }

        }
       

        public ComparatorOfSQL(List<string> sqlTextAin, List<string> sqlTextBin)
        {
            //prv vytvorim objekty
             
            sqltextA = new List<string>();
            sqltextB = new List<string>();
            highlitedA = new List<int>();
            highlitedB = new List<int>();
            
            //najprv zistim ktory sqltext je kratsi
            sqltextA = sqlTextAin;
            sqltextB = sqlTextBin;

            if (sqltextA != null && sqltextB != null)
            {
                int countMin = 0;
                if (sqltextA.Count > sqltextB.Count)
                {
                    countMin = sqltextB.Count;
                    //isDifferent = true;
                }
                else if (sqltextB.Count > sqltextA.Count)
                {
                    countMin = sqltextA.Count;
                    //isDifferent = true;
                }
                else countMin = sqltextA.Count;


                int ia = 0;
                int ib = 0;
                for (int i = 0; i < countMin; i++)
                {
                    string a = sqltextA[ia];
                    string b = sqltextB[ib];
                    a = a.Trim();
                    b = b.Trim();
                    while (a.Length == 0 && ((ia + 1) < sqltextA.Count))
                    {
                        ia++;
                        a = sqltextA[ia];
                        a = a.Trim();
                    }
                    while (b.Length == 0 && ((ib + 1) < sqltextB.Count))
                    {
                        ib++;
                        b = sqltextB[ib];
                        b = b.Trim();
                    }
                    if (a != b)
                    {
                        highlitedA.Add(ia);
                        highlitedB.Add(ib);
                        isDifferent = true;
                    }
                    if ((ia+1) < sqltextA.Count)  ia++;
                    if ((ib + 1) < sqltextB.Count) ib++;
                }

                if (isDifferent)
                {
                    if (countMin < sqltextA.Count)
                    {
                        for (int i = countMin; i < sqltextA.Count; i++)
                        {
                            highlitedA.Add(i);
                        }
                    }

                    if (countMin < sqltextB.Count)
                    {
                        for (int i = countMin; i < sqltextB.Count; i++)
                        {
                            highlitedB.Add(i);
                        }
                    }

                }

                textA = new SqlTextHighlited(sqltextA, highlitedA);
                textB = new SqlTextHighlited(sqltextB, highlitedB);
            }

            else if (sqltextA != null)
            {
                textA = new SqlTextHighlited(sqltextA, highlitedA);
                isDifferent = true;
                textB = null;
            }
            else if (sqltextB != null)
            {
                textB = new SqlTextHighlited(sqltextB, highlitedB);
                isDifferent = true;
                textA = null;
            }
        }

    }
}
