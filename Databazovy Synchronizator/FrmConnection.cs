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
    public partial class FrmConnection : Form
    {
        private Comparator com;
        private int cisloprip;
        private MainFrm main;
        public FrmConnection(Comparator comp,int cisloPripIn, MainFrm mainIn)
        {
            InitializeComponent();
            com = comp;
            cisloprip = cisloPripIn;
            this.main = mainIn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbDatabaza.SelectedItem != null)
            {
                if (cbDatabaza.SelectedItem.ToString() == "MSSQL")
                {
                    if (cisloprip == 0)
                    {
                        if (com.vytvorPripojenie1(textBox1.Text,cbDatabaza.SelectedItem.ToString())) { MessageBox.Show("Pripojenie uspesne"); this.Close(); }
                        else MessageBox.Show("Pripojenie neuspesne");

                    }
                    if (cisloprip == 1)
                    {
                        if (com.vytvorPripojenie2(textBox1.Text, cbDatabaza.SelectedItem.ToString())) { MessageBox.Show("Pripojenie uspesne"); this.Close(); }
                        else MessageBox.Show("Pripojenie neuspesne");
                    }
                }

                if (cbDatabaza.SelectedItem.ToString() == "MySQL")
                {
                    if (cisloprip == 0)
                    {
                        if (com.vytvorPripojenie1(textBox1.Text, cbDatabaza.SelectedItem.ToString())) { MessageBox.Show("Pripojenie uspesne"); this.Close(); }
                        else MessageBox.Show("Pripojenie neuspesne");

                    }
                    if (cisloprip == 1)
                    {
                        if (com.vytvorPripojenie2(textBox1.Text, cbDatabaza.SelectedItem.ToString())) { MessageBox.Show("Pripojenie uspesne"); this.Close(); }
                        else MessageBox.Show("Pripojenie neuspesne");
                    }
                }
            }
            else
            {
                MessageBox.Show("chyba, musite zvolit typ databazy");
            }
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbDatabaza.SelectedItem.ToString() == "MSSQL")
            {
                ConnectionMSSQL con1 = new ConnectionMSSQL(textBox1.Text);
                ConnectionMSSQL con2 = new ConnectionMSSQL(textBox2.Text);
                if (com.createConnections(con1, con2))
                {
                    MessageBox.Show("Connection succesfull");
                    DBsyncTreeview strom = com.vyrobStromA();
                    main.aktualizujIkonky(strom);
                    main.getTvDb1().Nodes.Add(strom);

                    DBsyncTreeview strom2 = com.vyrobStromB();
                    main.aktualizujIkonky(strom2);
                    main.getTvDb2().Nodes.Add(strom2);
                    this.Close();
                }
                else MessageBox.Show("Connection was not succesfull");
                
            }
            
            
        }
    }
}
