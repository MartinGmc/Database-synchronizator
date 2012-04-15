using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Databazovy_Synchronizator
{
    public partial class FrmSqlCode : Form
    {
        private List<string> sqlTextListA;
        private List<string> sqlTextListB;

        private List<int> highlitedA;
        private List<int> highlitedB;

        public FrmSqlCode(SqlTextHighlited sqlTextAin, SqlTextHighlited sqlTextBin)
        {
            InitializeComponent();
            if (sqlTextAin != null) sqlTextListA = sqlTextAin.Text;
            if (sqlTextBin != null) sqlTextListB = sqlTextBin.Text;

            if (sqlTextAin != null) highlitedA = sqlTextAin.Highlited;
            if (sqlTextBin != null) highlitedB = sqlTextBin.Highlited;

            sqlTextA.Clear();
            if (sqlTextAin != null)
            {
                for (int i = 0; i < sqlTextListA.Count; i++)
                {
                    if (highlitedA.Contains(i)) sqlTextA.SelectionColor = Color.Red;
                    sqlTextA.AppendText(sqlTextListA[i]);
                }
            }      
            sqlTextB.Clear();
            if (sqlTextBin != null)
            {
                for (int i = 0; i < sqlTextListB.Count; i++)
                {
                    if (highlitedB.Contains(i)) sqlTextB.SelectionColor = Color.Red;
                    sqlTextB.AppendText(sqlTextListB[i]);
                }
            }
        }
    }
}
