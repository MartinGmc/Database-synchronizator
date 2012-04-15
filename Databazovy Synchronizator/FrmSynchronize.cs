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
    public partial class FrmSynchronize : Form
    {
        Comparator comp;
        List <string> Db1Scripts;
        List <string> Db2Scripts;

        List<string> Db1DataScripts;
        List<string> Db2DataScripts;

        public FrmSynchronize(Comparator compIn)
        {
            InitializeComponent();
            this.comp = compIn;
            readTables();
        }

        private void readTables()
        {
            lbTables.Items.Clear();
            foreach (DbSyncTableDiff tab in comp.DatabaseDifferences.getTablediff())
            {
               
                lbTables.Items.Add(tab);
            }
        }
        
        private void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAll.Checked)
            {
                cbFunctions.Checked = true;
                cbProcedures.Checked = true;
                cbTables.Checked = true;
                cbTypes.Checked = true;
                cbUsers.Checked = true;
            }
            else
            {
                cbFunctions.Checked = false;
                cbProcedures.Checked = false;
                cbTables.Checked = false;
                cbTypes.Checked = false;
                cbUsers.Checked = false;
            }
        }
        private void cbTables_CheckedChanged(object sender, EventArgs e)
        {
             if (!cbTables.Checked)  if (cbAll.Checked) cbAll.Checked = false;
        }
        private void cbProcedures_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbProcedures.Checked) if (cbAll.Checked) cbAll.Checked = false;
        }
        private void cbFunctions_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbFunctions.Checked) if (cbAll.Checked) cbAll.Checked = false;
        }
        private void cbTypes_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbTypes.Checked) if (cbAll.Checked) cbAll.Checked = false;
        }
        private void cbUsers_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbUsers.Checked) if (cbAll.Checked) cbAll.Checked = false;
        }

        private ComparatorSettings readSettings()
        {
            //nacitam nastavenia
            ComparatorSettings set = new ComparatorSettings();

            if (rbDb1.Checked) set.IsDbAPriority = true;
            else set.IsDbAPriority = false;

            if (rbLeftToRight.Checked) set.ComparisonMethod = ComparatorSettings.LeftRight;
            if (rbLeftToRightDel.Checked) set.ComparisonMethod = ComparatorSettings.LeftRightDel;
            if (rbRightToLeft.Checked) set.ComparisonMethod = ComparatorSettings.RightLeft;
            if (rbRightToLeftDel.Checked) set.ComparisonMethod = ComparatorSettings.RightLeftDel;
            if (rbCompleteSync.Checked) set.ComparisonMethod = ComparatorSettings.TwoWay;

            if (cbAll.Checked)
            {
                set.SyncFunctions = true;
                set.SyncProcedures = true;
                set.SyncTables = true;
                set.SyncTypes = true;
                set.SyncUsers = true;
            }
            else
            {
                set.SyncFunctions = cbFunctions.Checked;
                set.SyncProcedures = cbProcedures.Checked;
                set.SyncTables = cbTables.Checked;
                set.SyncTypes = cbTypes.Checked;
                set.SyncUsers = cbUsers.Checked;
            }
            return set;
        }
        
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            tbStatusOut.Clear();
            tbStatusOut.AppendText("Reading settings...\r\n");
            this.comp.settings = readSettings();
            tbStatusOut.AppendText("Settings Inserted successfully. \r\n");
            tbStatusOut.AppendText("Generating scripts for Db1... \r\n");
            Db1Scripts = comp.generateScriptsForDb1();
            tbStatusOut.AppendText("Generating scripts for Db2... \r\n");
            Db2Scripts = comp.generateScriptsForDb2();
            tbStatusOut.AppendText("Scripts generated successfully \r\n");
        }

        private void btnDb1Scripts_Click(object sender, EventArgs e)
        {
            FrmSqlShow fs = new FrmSqlShow(Db1Scripts,comp.db1);
            fs.Show();
        }

        private void btnDb2Scripts_Click(object sender, EventArgs e)
        {
            FrmSqlShow fs = new FrmSqlShow(Db2Scripts,comp.db2);
            fs.Show();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            this.comp.settings = readSettings();
            try
            {
                this.Db1DataScripts = comp.generateDataScriptsForDB1((DbSyncTableDiff)lbTables.SelectedItem);
                this.Db2DataScripts = comp.generateDataScriptsForDB2((DbSyncTableDiff)lbTables.SelectedItem);
            }catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
        }

        private void btnScriptDb1_Click(object sender, EventArgs e)
        {
            FrmSqlShow fs = new FrmSqlShow(Db1DataScripts, comp.db1);
            fs.Show();
        }

        private void btnScrDb2_Click(object sender, EventArgs e)
        {
            FrmSqlShow fs = new FrmSqlShow(Db2DataScripts, comp.db2);
            fs.Show();
        }
    }
}
