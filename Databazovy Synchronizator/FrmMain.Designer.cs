namespace Databazovy_Synchronizator
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tvDb1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tvDb2 = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvExDb1 = new ListViewEmbeddedControls.ListViewEx();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvExDb2 = new ListViewEmbeddedControls.ListViewEx();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button3 = new System.Windows.Forms.Button();
            this.cmTvDB1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.vyberDoPorovnaniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.cmTvDB1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Pripoj DB 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "pripoj DB 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel1,
            this.statusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1194, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // statusLabel1
            // 
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(127, 17);
            this.statusLabel1.Text = "Databaza1 nepripojena";
            // 
            // statusLabel2
            // 
            this.statusLabel2.Name = "statusLabel2";
            this.statusLabel2.Size = new System.Drawing.Size(127, 17);
            this.statusLabel2.Text = "Databaza2 nepripojena";
            // 
            // tvDb1
            // 
            this.tvDb1.ImageIndex = 0;
            this.tvDb1.ImageList = this.imageList1;
            this.tvDb1.Location = new System.Drawing.Point(12, 41);
            this.tvDb1.Name = "tvDb1";
            this.tvDb1.SelectedImageIndex = 0;
            this.tvDb1.Size = new System.Drawing.Size(266, 330);
            this.tvDb1.TabIndex = 3;
            this.tvDb1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDb1_AfterSelect);
            this.tvDb1.DoubleClick += new System.EventHandler(this.tvDb1_DoubleClick);
            this.tvDb1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvDb1_MouseUp);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "database16.png");
            this.imageList1.Images.SetKeyName(1, "Tabulky.png");
            this.imageList1.Images.SetKeyName(2, "Stlpce.png");
            this.imageList1.Images.SetKeyName(3, "Kluce.png");
            this.imageList1.Images.SetKeyName(4, "typesIcon.png");
            this.imageList1.Images.SetKeyName(5, "trig.png");
            this.imageList1.Images.SetKeyName(6, "grantsIcon.png");
            this.imageList1.Images.SetKeyName(7, "ProceduresIcon.png");
            this.imageList1.Images.SetKeyName(8, "Funkcie.png");
            this.imageList1.Images.SetKeyName(9, "TypesIcon2.png");
            this.imageList1.Images.SetKeyName(10, "Users.png");
            this.imageList1.Images.SetKeyName(11, "TypeIcon.png");
            this.imageList1.Images.SetKeyName(12, "PKicon.png");
            this.imageList1.Images.SetKeyName(13, "FKicon.png");
            this.imageList1.Images.SetKeyName(14, "Tabulka.png");
            this.imageList1.Images.SetKeyName(15, "Stlpec.png");
            this.imageList1.Images.SetKeyName(16, "trig1.png");
            this.imageList1.Images.SetKeyName(17, "user1.png");
            this.imageList1.Images.SetKeyName(18, "procicon.png");
            this.imageList1.Images.SetKeyName(19, "Funkcia.png");
            this.imageList1.Images.SetKeyName(20, "type1icon.png");
            this.imageList1.Images.SetKeyName(21, "user1.png");
            // 
            // tvDb2
            // 
            this.tvDb2.ImageIndex = 0;
            this.tvDb2.ImageList = this.imageList1;
            this.tvDb2.Location = new System.Drawing.Point(302, 41);
            this.tvDb2.Name = "tvDb2";
            this.tvDb2.SelectedImageIndex = 0;
            this.tvDb2.Size = new System.Drawing.Size(284, 330);
            this.tvDb2.TabIndex = 4;
            this.tvDb2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDb2_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvExDb1);
            this.groupBox1.Location = new System.Drawing.Point(592, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 330);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DB1 vlastnosti";
            // 
            // lvExDb1
            // 
            this.lvExDb1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lvExDb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvExDb1.GridLines = true;
            this.lvExDb1.Location = new System.Drawing.Point(6, 19);
            this.lvExDb1.Name = "lvExDb1";
            this.lvExDb1.Size = new System.Drawing.Size(233, 305);
            this.lvExDb1.TabIndex = 9;
            this.lvExDb1.TileSize = new System.Drawing.Size(2, 20);
            this.lvExDb1.UseCompatibleStateImageBehavior = false;
            this.lvExDb1.View = System.Windows.Forms.View.Details;
            this.lvExDb1.SelectedIndexChanged += new System.EventHandler(this.lvExDb1_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Atribút";
            this.columnHeader3.Width = 88;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Hodnota";
            this.columnHeader4.Width = 140;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvExDb2);
            this.groupBox2.Location = new System.Drawing.Point(843, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 330);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DB2 vlastnosti";
            // 
            // lvExDb2
            // 
            this.lvExDb2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lvExDb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvExDb2.GridLines = true;
            this.lvExDb2.Location = new System.Drawing.Point(6, 19);
            this.lvExDb2.Name = "lvExDb2";
            this.lvExDb2.Size = new System.Drawing.Size(239, 305);
            this.lvExDb2.TabIndex = 11;
            this.lvExDb2.TileSize = new System.Drawing.Size(2, 20);
            this.lvExDb2.UseCompatibleStateImageBehavior = false;
            this.lvExDb2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Atribút";
            this.columnHeader5.Width = 88;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Hodnota";
            this.columnHeader6.Width = 140;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(203, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // cmTvDB1
            // 
            this.cmTvDB1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vyberDoPorovnaniaToolStripMenuItem});
            this.cmTvDB1.Name = "cmTvDB1";
            this.cmTvDB1.Size = new System.Drawing.Size(185, 26);
            // 
            // vyberDoPorovnaniaToolStripMenuItem
            // 
            this.vyberDoPorovnaniaToolStripMenuItem.Name = "vyberDoPorovnaniaToolStripMenuItem";
            this.vyberDoPorovnaniaToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.vyberDoPorovnaniaToolStripMenuItem.Text = "Vyber do porovnania";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(284, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(397, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "Synchronize";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 446);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tvDb2);
            this.Controls.Add(this.tvDb1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MainFrm";
            this.Text = "Databazovy synchronizator";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.cmTvDB1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TreeView tvDb1;
        private System.Windows.Forms.TreeView tvDb2;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip cmTvDB1;
        private System.Windows.Forms.ToolStripMenuItem vyberDoPorovnaniaToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private ListViewEmbeddedControls.ListViewEx lvExDb1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private ListViewEmbeddedControls.ListViewEx lvExDb2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button button5;
    }
}

