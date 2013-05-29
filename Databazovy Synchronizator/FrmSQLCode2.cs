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
    public partial class FrmSQLCode2 : Form
    {
        string textA;
        string textB;

        public FrmSQLCode2(string text1, string text2)
        {
            InitializeComponent();
            textA = text1;
            textB = text2;

            sideBySideRichTextBox1.LeftText = textA;
            sideBySideRichTextBox1.RightText = textB;
            sideBySideRichTextBox1.CompareText();
        }
    }
}
