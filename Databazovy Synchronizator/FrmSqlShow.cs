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
    public partial class FrmSqlShow : Form
    {
        DataBasee datab;
        List<string> sqlCommands;

        public FrmSqlShow(List<string> sqlText, DataBasee dat)
        {
            InitializeComponent();
            this.datab = dat;
            this.sqlCommands = sqlText;
            if (dat != null && sqlText != null)
            {
                foreach (string s in sqlText)
                {
                    this.richTextBox1.AppendText(s);
                    this.richTextBox1.AppendText(Environment.NewLine + " GO " + Environment.NewLine);
                }
            }
            
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            List<string> result = datab.prip.executeText(sqlCommands);
            if (result.Count > 0)
            {
                string text = "";
                foreach (string s in result)
                {
                    text += s;
                }
                MessageBox.Show(text);
            }
            else
            {
                MessageBox.Show(" Commands executed sucessfully ");
                
            }

 
            
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
            string nameOfFile = saveFileDialog.FileName ;
            System.IO.File.WriteAllText(nameOfFile,richTextBox1.Text);
            MessageBox.Show("File saved successfully");

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.Copy();
            richTextBox1.DeselectAll();
        }
    }
}
