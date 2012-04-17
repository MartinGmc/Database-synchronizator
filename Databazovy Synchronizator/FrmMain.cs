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
    public partial class MainFrm : Form
    {
        Comparator comp;
        bool canRunAfterselect = true;
        public MainFrm()
        {
            InitializeComponent();
            comp = new Comparator();
            comp.aktualizujVypis += new EventHandler(Akt_vypis2);
        }

        public TreeView getTvDb1()
        {
            return this.tvDb1;
        }

        public TreeView getTvDb2()
        {
            return this.tvDb2;
        }

        public void aktualizujIkonky(DBsyncTreeview tv)
        {
            if (tv.Nodes != null && tv.Nodes.Count > 0)
            {
                foreach (DBsyncTreeview dbtv in tv.Nodes)
                {
                    //dbtv.ImageIndex = 1;
                    dbtv.ImageIndex = dbtv.getTypIkony();
                    dbtv.SelectedImageIndex = dbtv.getTypIkony();
                    if (dbtv.Azvyraznene) dbtv.BackColor = Color.Red;
                    aktualizujIkonky(dbtv);
                }
            }
           
        }


        private void Akt_vypis2(object sender, EventArgs e)
        {
            tvDb1.Nodes.Clear();
            tvDb2.Nodes.Clear();
            //comp.refreshConnections();
            DBsyncTreeview strom = comp.vyrobStromA();
            aktualizujIkonky(strom);
            getTvDb1().Nodes.Add(strom);

            DBsyncTreeview strom2 = comp.vyrobStromB();
            aktualizujIkonky(strom2);
            getTvDb2().Nodes.Add(strom2);
        }
        
        //private void Akt_vypis(object sender, EventArgs e)
        //{
        //    tvDb1.Nodes.Clear();
        //    tvDb2.Nodes.Clear();
        //    if (comp.jePrip1Aktivne())
        //    {
        //        DBsyncTreeview strom = comp.db1.vyrobStrom();
        //        aktualizujIkonky(strom);
        //        tvDb1.Nodes.Add(strom);
        //    }

        //    if (comp.jePrip2Aktivne())
        //    {
        //        DBsyncTreeview strom = comp.db2.vyrobStrom();
        //        aktualizujIkonky(strom);
        //        tvDb2.Nodes.Add(strom);
                
                
        //    }
        //}
        
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmConnection prip = new FrmConnection(comp,0,this);
            prip.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmConnection prip = new FrmConnection(comp, 1,this);
            prip.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //comp.db1.nacitajTabulky();
            Console.WriteLine();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            List<string> test = new List<string>();
            test.Add("skuska\r\n");
            test.Add("skuska2\r\n");
            List<int> highl = new List<int>();
            highl.Add(0);
            SqlTextHighlited s = new SqlTextHighlited(test, highl);
            FrmSqlCode ff = new FrmSqlCode(s, s);
            ff.Show();
        }

        private void buttonSQLTextClick(object sender, EventArgs e)
        {
            FrmSqlCode ff;
            DBsyncTreeview n1 = (DBsyncTreeview) tvDb1.SelectedNode;
            DBsyncTreeview n2 = (DBsyncTreeview) tvDb2.SelectedNode;
            if (n1 != null && n2 != null)
            {
                ff = new FrmSqlCode(n1.SqlTextList, n2.SqlTextList);
            }
            else if (n1 != null)
            {
                ff = new FrmSqlCode(n1.SqlTextList, null);
            }
            else 
            {
                ff = new FrmSqlCode(null, n2.SqlTextList);
            }
            ff.Show();
        }

        private void tvDb1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (canRunAfterselect)
            {
                canRunAfterselect = false;
                DBsyncTreeview n = (DBsyncTreeview)e.Node;
                if (sender != null) otvorRovnakyNodeVstrome(e.Node, tvDb2, true);
                lvExDb1.Items.Clear();
                if (n.ObjectAtributesList != null)
                {
                    foreach (ObjectAtribute o in n.ObjectAtributesList)
                    {
                        ListViewItem lv = new ListViewItem(o.NameOfAtribute);
                        lv.SubItems.Add(o.AtributeValue);
                        if (o.IsHighlited) lv.BackColor = Color.Red;
                        lvExDb1.Items.Add(lv);
                        if (o.IsSql)
                        {
                            Button b = new Button();
                            b.Text = "...";
                            b.BackColor = SystemColors.Control;
                            b.Font = new System.Drawing.Font(this.Font.FontFamily, 6);
                            b.Height = 5;
                            b.Width = 20;
                            b.Click += new EventHandler(buttonSQLTextClick);
                            lvExDb1.AddEmbeddedControl(b, 1, 1, DockStyle.Right);
                        }


                    }
                }
                canRunAfterselect = true;
            }
        }

        private void tvDb2_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (canRunAfterselect)
            {
                canRunAfterselect = false;
                DBsyncTreeview n = (DBsyncTreeview)e.Node;
                if (sender != null) otvorRovnakyNodeVstrome(e.Node, tvDb1, false);
                lvExDb2.Items.Clear();
                if (n.ObjectAtributesList != null)
                {
                    foreach (ObjectAtribute o in n.ObjectAtributesList)
                    {
                        ListViewItem lv = new ListViewItem(o.NameOfAtribute);
                        lv.SubItems.Add(o.AtributeValue);
                        if (o.IsHighlited) lv.BackColor = Color.Red;
                        lvExDb2.Items.Add(lv);

                        if (o.IsSql)
                        {
                            Button b = new Button();
                            b.Text = "...";
                            b.BackColor = SystemColors.Control;
                            b.Font = new System.Drawing.Font(this.Font.FontFamily, 6);
                            b.Height = 5;
                            b.Width = 20;
                            b.Click += new EventHandler(buttonSQLTextClick);
                            lvExDb2.AddEmbeddedControl(b, 1, 1, DockStyle.Right);
                        }
                    }
                }
                canRunAfterselect = true;
            }
        }

        private void otvorRovnakyNodeVstrome(TreeNode n, TreeView tree,bool isTv1)
        {
            tree.SelectedNode = null;
            
            string cesta = n.FullPath;
            //rozparsujem cestu
            string[] cesta1 = cesta.Split('\\');
            if (cesta1.Length > 1)
            {
                TreeNode nnx = tree.Nodes[0];
                TreeNodeCollection nnxx = nnx.Nodes;
                for (int i = 1; i < cesta1.Length; i++)
                {
                   int k = nnxx.IndexOfKey(cesta1[i]);
                   if (k > -1)
                   {
                       nnxx[k].EnsureVisible();
                       TreeNode tn = nnxx[k];
                       nnxx = nnxx[k].Nodes;
                       if (i == cesta1.Length - 1)
                       {
                           if (isTv1)
                           {
                               tvDb2.SelectedNode = tn;
                               canRunAfterselect = true;
                               tvDb2_AfterSelect(null, new TreeViewEventArgs(tn));
                           }

                           else
                           {
                               tvDb1.SelectedNode = tn;
                               canRunAfterselect = true;
                               tvDb1_AfterSelect(null, new TreeViewEventArgs(tn));
                           }
                           //tree.SelectedNode = nnxx[k];
                       }
                   }
                }
            }
            
            Console.WriteLine();

        }
        
        private void tvDb1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void tvDb1_MouseUp(object sender, MouseEventArgs e)
        {

                    }

       

        private void button4_Click(object sender, EventArgs e)
        {
           


            comp.DatabaseDifferences = new DbSyncDataBaseDiff(comp.db1, comp.db2);
            comp.fullfillLists();
            Console.WriteLine();
            tvDb1.Nodes.Clear();
            tvDb2.Nodes.Clear();

            DBsyncTreeview strom = comp.vyrobStromA();
            aktualizujIkonky(strom);
            tvDb1.Nodes.Add(strom);

            DBsyncTreeview strom2 = comp.vyrobStromB();
            aktualizujIkonky(strom2);
            tvDb2.Nodes.Add(strom2);
        }

        private void lvExDb1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmSynchronize fs = new FrmSynchronize(comp);
            fs.Show();
        }
    }
}
