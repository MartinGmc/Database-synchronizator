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
            this.cmTvDB1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.vyberDoPorovnaniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.cmTvDB1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect databases";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.imageList1.Images.SetKeyName(22, "Index1.png");
            this.imageList1.Images.SetKeyName(23, "IndexIcon.png");
            // 
            // tvDb2
            // 
            this.tvDb2.ImageIndex = 0;
            this.tvDb2.ImageList = this.imageList1;
            this.tvDb2.Location = new System.Drawing.Point(578, 41);
            this.tvDb2.Name = "tvDb2";
            this.tvDb2.SelectedImageIndex = 0;
            this.tvDb2.Size = new System.Drawing.Size(284, 330);
            this.tvDb2.TabIndex = 4;
            this.tvDb2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDb2_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvExDb1);
            this.groupBox1.Location = new System.Drawing.Point(284, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 330);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DB1 Properties";
            // 
            // lvExDb1
            // 
            this.lvExDb1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lvExDb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvExDb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvExDb1.GridLines = true;
            this.lvExDb1.Location = new System.Drawing.Point(3, 16);
            this.lvExDb1.Name = "lvExDb1";
            this.lvExDb1.Size = new System.Drawing.Size(260, 311);
            this.lvExDb1.TabIndex = 9;
            this.lvExDb1.TileSize = new System.Drawing.Size(2, 20);
            this.lvExDb1.UseCompatibleStateImageBehavior = false;
            this.lvExDb1.View = System.Windows.Forms.View.Details;
            this.lvExDb1.SelectedIndexChanged += new System.EventHandler(this.lvExDb1_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Atribute";
            this.columnHeader3.Width = 123;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Value";
            this.columnHeader4.Width = 128;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvExDb2);
            this.groupBox2.Location = new System.Drawing.Point(868, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 330);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DB2 properties";
            // 
            // lvExDb2
            // 
            this.lvExDb2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lvExDb2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvExDb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvExDb2.GridLines = true;
            this.lvExDb2.Location = new System.Drawing.Point(3, 16);
            this.lvExDb2.Name = "lvExDb2";
            this.lvExDb2.Size = new System.Drawing.Size(278, 311);
            this.lvExDb2.TabIndex = 11;
            this.lvExDb2.TileSize = new System.Drawing.Size(2, 20);
            this.lvExDb2.UseCompatibleStateImageBehavior = false;
            this.lvExDb2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Atribute";
            this.columnHeader5.Width = 130;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Value";
            this.columnHeader6.Width = 141;
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
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(148, 12);
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
            this.ClientSize = new System.Drawing.Size(1187, 417);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tvDb2);
            this.Controls.Add(this.tvDb1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Name = "MainFrm";
            this.Text = "Database synchronizator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.cmTvDB1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView tvDb1;
        private System.Windows.Forms.TreeView tvDb2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip cmTvDB1;
        private System.Windows.Forms.ToolStripMenuItem vyberDoPorovnaniaToolStripMenuItem;
        private ListViewEmbeddedControls.ListViewEx lvExDb1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private ListViewEmbeddedControls.ListViewEx lvExDb2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button button5;
    }
}

