namespace Databazovy_Synchronizator
{
    partial class FrmSynchronize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSynchronize));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbCompleteSync = new System.Windows.Forms.RadioButton();
            this.rbRightToLeft = new System.Windows.Forms.RadioButton();
            this.rbRightToLeftDel = new System.Windows.Forms.RadioButton();
            this.rbLeftToRight = new System.Windows.Forms.RadioButton();
            this.rbLeftToRightDel = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDb2 = new System.Windows.Forms.RadioButton();
            this.rbDb1 = new System.Windows.Forms.RadioButton();
            this.tabSchema = new System.Windows.Forms.TabPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnExecuteScripts = new System.Windows.Forms.Button();
            this.btnDb2Scripts = new System.Windows.Forms.Button();
            this.btnDb1Scripts = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbStatusOut = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbUsers = new System.Windows.Forms.CheckBox();
            this.cbTypes = new System.Windows.Forms.CheckBox();
            this.cbFunctions = new System.Windows.Forms.CheckBox();
            this.cbProcedures = new System.Windows.Forms.CheckBox();
            this.cbTables = new System.Windows.Forms.CheckBox();
            this.cbAll = new System.Windows.Forms.CheckBox();
            this.tabData = new System.Windows.Forms.TabPage();
            this.ttPriority = new System.Windows.Forms.ToolTip(this.components);
            this.ttTypeOfSync = new System.Windows.Forms.ToolTip(this.components);
            this.lbTables = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGen = new System.Windows.Forms.Button();
            this.btnScriptDb1 = new System.Windows.Forms.Button();
            this.btnScrDb2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabSchema.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabData.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabSchema);
            this.tabControl1.Controls.Add(this.tabData);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(688, 319);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.groupBox2);
            this.tabSettings.Controls.Add(this.groupBox1);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(680, 293);
            this.tabSettings.TabIndex = 0;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbCompleteSync);
            this.groupBox2.Controls.Add(this.rbRightToLeft);
            this.groupBox2.Controls.Add(this.rbRightToLeftDel);
            this.groupBox2.Controls.Add(this.rbLeftToRight);
            this.groupBox2.Controls.Add(this.rbLeftToRightDel);
            this.groupBox2.Location = new System.Drawing.Point(223, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 256);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Type of synchronization";
            // 
            // rbCompleteSync
            // 
            this.rbCompleteSync.AutoSize = true;
            this.rbCompleteSync.Location = new System.Drawing.Point(21, 183);
            this.rbCompleteSync.Name = "rbCompleteSync";
            this.rbCompleteSync.Size = new System.Drawing.Size(144, 17);
            this.rbCompleteSync.TabIndex = 4;
            this.rbCompleteSync.Text = "Two way synchronization";
            this.ttTypeOfSync.SetToolTip(this.rbCompleteSync, resources.GetString("rbCompleteSync.ToolTip"));
            this.rbCompleteSync.UseVisualStyleBackColor = true;
            // 
            // rbRightToLeft
            // 
            this.rbRightToLeft.AutoSize = true;
            this.rbRightToLeft.Location = new System.Drawing.Point(21, 140);
            this.rbRightToLeft.Name = "rbRightToLeft";
            this.rbRightToLeft.Size = new System.Drawing.Size(79, 17);
            this.rbRightToLeft.TabIndex = 3;
            this.rbRightToLeft.Text = "Right to left";
            this.ttTypeOfSync.SetToolTip(this.rbRightToLeft, "This type of synchronization create all objects \r\nwhitch are in right database in" +
        " left database.\r\nDifferent objects whith same name \r\nwill be rewritten based on " +
        "database priority setting. ");
            this.rbRightToLeft.UseVisualStyleBackColor = true;
            // 
            // rbRightToLeftDel
            // 
            this.rbRightToLeftDel.AutoSize = true;
            this.rbRightToLeftDel.Location = new System.Drawing.Point(21, 102);
            this.rbRightToLeftDel.Name = "rbRightToLeftDel";
            this.rbRightToLeftDel.Size = new System.Drawing.Size(164, 17);
            this.rbRightToLeftDel.TabIndex = 2;
            this.rbRightToLeftDel.Text = "Right to left whith DELETING";
            this.ttTypeOfSync.SetToolTip(this.rbRightToLeftDel, resources.GetString("rbRightToLeftDel.ToolTip"));
            this.rbRightToLeftDel.UseVisualStyleBackColor = true;
            // 
            // rbLeftToRight
            // 
            this.rbLeftToRight.AutoSize = true;
            this.rbLeftToRight.Location = new System.Drawing.Point(21, 64);
            this.rbLeftToRight.Name = "rbLeftToRight";
            this.rbLeftToRight.Size = new System.Drawing.Size(78, 17);
            this.rbLeftToRight.TabIndex = 1;
            this.rbLeftToRight.Text = "Left to right";
            this.ttTypeOfSync.SetToolTip(this.rbLeftToRight, "This type of synchronization create all objects \r\nwhitch are in left database in " +
        "right database.\r\nDifferent objects whith same name \r\nwill be rewritten based on " +
        "database priority setting. ");
            this.rbLeftToRight.UseVisualStyleBackColor = true;
            // 
            // rbLeftToRightDel
            // 
            this.rbLeftToRightDel.AutoSize = true;
            this.rbLeftToRightDel.Checked = true;
            this.rbLeftToRightDel.Location = new System.Drawing.Point(21, 30);
            this.rbLeftToRightDel.Name = "rbLeftToRightDel";
            this.rbLeftToRightDel.Size = new System.Drawing.Size(163, 17);
            this.rbLeftToRightDel.TabIndex = 0;
            this.rbLeftToRightDel.TabStop = true;
            this.rbLeftToRightDel.Text = "Left to right whith DELETING";
            this.ttTypeOfSync.SetToolTip(this.rbLeftToRightDel, resources.GetString("rbLeftToRightDel.ToolTip"));
            this.rbLeftToRightDel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDb2);
            this.groupBox1.Controls.Add(this.rbDb1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "";
            this.groupBox1.Text = "Setting database priority";
            // 
            // rbDb2
            // 
            this.rbDb2.AutoSize = true;
            this.rbDb2.Location = new System.Drawing.Point(17, 42);
            this.rbDb2.Name = "rbDb2";
            this.rbDb2.Size = new System.Drawing.Size(80, 17);
            this.rbDb2.TabIndex = 1;
            this.rbDb2.Text = "Database 2";
            this.ttPriority.SetToolTip(this.rbDb2, "Choosen database will have higher priority. \r\nIt means that objects in database w" +
        "hith lower priority \r\nwill be rewritten whith objects from database whith higher" +
        " priority.");
            this.rbDb2.UseVisualStyleBackColor = true;
            // 
            // rbDb1
            // 
            this.rbDb1.AutoSize = true;
            this.rbDb1.Checked = true;
            this.rbDb1.Location = new System.Drawing.Point(17, 19);
            this.rbDb1.Name = "rbDb1";
            this.rbDb1.Size = new System.Drawing.Size(80, 17);
            this.rbDb1.TabIndex = 0;
            this.rbDb1.TabStop = true;
            this.rbDb1.Text = "Database 1";
            this.ttPriority.SetToolTip(this.rbDb1, "Choosen database will have higher priority. \r\nIt means that objects in database w" +
        "hith lower priority \r\nwill be rewritten whith objects from database whith higher" +
        " priority.");
            this.rbDb1.UseVisualStyleBackColor = true;
            // 
            // tabSchema
            // 
            this.tabSchema.Controls.Add(this.progressBar1);
            this.tabSchema.Controls.Add(this.btnExecuteScripts);
            this.tabSchema.Controls.Add(this.btnDb2Scripts);
            this.tabSchema.Controls.Add(this.btnDb1Scripts);
            this.tabSchema.Controls.Add(this.btnGenerate);
            this.tabSchema.Controls.Add(this.label1);
            this.tabSchema.Controls.Add(this.tbStatusOut);
            this.tabSchema.Controls.Add(this.groupBox3);
            this.tabSchema.Location = new System.Drawing.Point(4, 22);
            this.tabSchema.Name = "tabSchema";
            this.tabSchema.Padding = new System.Windows.Forms.Padding(3);
            this.tabSchema.Size = new System.Drawing.Size(680, 293);
            this.tabSchema.TabIndex = 1;
            this.tabSchema.Text = "SchemaSynchronization";
            this.tabSchema.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(301, 230);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(362, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // btnExecuteScripts
            // 
            this.btnExecuteScripts.Location = new System.Drawing.Point(588, 150);
            this.btnExecuteScripts.Name = "btnExecuteScripts";
            this.btnExecuteScripts.Size = new System.Drawing.Size(75, 39);
            this.btnExecuteScripts.TabIndex = 6;
            this.btnExecuteScripts.Text = "Execute scripts";
            this.btnExecuteScripts.UseVisualStyleBackColor = true;
            // 
            // btnDb2Scripts
            // 
            this.btnDb2Scripts.Location = new System.Drawing.Point(481, 150);
            this.btnDb2Scripts.Name = "btnDb2Scripts";
            this.btnDb2Scripts.Size = new System.Drawing.Size(75, 39);
            this.btnDb2Scripts.TabIndex = 5;
            this.btnDb2Scripts.Text = "Scripts for database 2";
            this.btnDb2Scripts.UseVisualStyleBackColor = true;
            this.btnDb2Scripts.Click += new System.EventHandler(this.btnDb2Scripts_Click);
            // 
            // btnDb1Scripts
            // 
            this.btnDb1Scripts.Location = new System.Drawing.Point(400, 150);
            this.btnDb1Scripts.Name = "btnDb1Scripts";
            this.btnDb1Scripts.Size = new System.Drawing.Size(75, 39);
            this.btnDb1Scripts.TabIndex = 4;
            this.btnDb1Scripts.Text = "Scripts for database 1";
            this.btnDb1Scripts.UseVisualStyleBackColor = true;
            this.btnDb1Scripts.Click += new System.EventHandler(this.btnDb1Scripts_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(301, 150);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 39);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate scripts";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Synchronization status";
            // 
            // tbStatusOut
            // 
            this.tbStatusOut.Location = new System.Drawing.Point(301, 21);
            this.tbStatusOut.Multiline = true;
            this.tbStatusOut.Name = "tbStatusOut";
            this.tbStatusOut.Size = new System.Drawing.Size(362, 122);
            this.tbStatusOut.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbUsers);
            this.groupBox3.Controls.Add(this.cbTypes);
            this.groupBox3.Controls.Add(this.cbFunctions);
            this.groupBox3.Controls.Add(this.cbProcedures);
            this.groupBox3.Controls.Add(this.cbTables);
            this.groupBox3.Controls.Add(this.cbAll);
            this.groupBox3.Location = new System.Drawing.Point(8, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 279);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Objects to synchronize";
            // 
            // cbUsers
            // 
            this.cbUsers.AutoSize = true;
            this.cbUsers.Checked = true;
            this.cbUsers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUsers.Location = new System.Drawing.Point(76, 166);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(114, 17);
            this.cbUsers.TabIndex = 5;
            this.cbUsers.Text = "Synchronize Users";
            this.cbUsers.UseVisualStyleBackColor = true;
            this.cbUsers.CheckedChanged += new System.EventHandler(this.cbUsers_CheckedChanged);
            // 
            // cbTypes
            // 
            this.cbTypes.AutoSize = true;
            this.cbTypes.Checked = true;
            this.cbTypes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTypes.Location = new System.Drawing.Point(76, 143);
            this.cbTypes.Name = "cbTypes";
            this.cbTypes.Size = new System.Drawing.Size(116, 17);
            this.cbTypes.TabIndex = 4;
            this.cbTypes.Text = "Synchronize Types";
            this.cbTypes.UseVisualStyleBackColor = true;
            this.cbTypes.CheckedChanged += new System.EventHandler(this.cbTypes_CheckedChanged);
            // 
            // cbFunctions
            // 
            this.cbFunctions.AutoSize = true;
            this.cbFunctions.Checked = true;
            this.cbFunctions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFunctions.Location = new System.Drawing.Point(76, 120);
            this.cbFunctions.Name = "cbFunctions";
            this.cbFunctions.Size = new System.Drawing.Size(133, 17);
            this.cbFunctions.TabIndex = 3;
            this.cbFunctions.Text = "Synchronize Functions";
            this.cbFunctions.UseVisualStyleBackColor = true;
            this.cbFunctions.CheckedChanged += new System.EventHandler(this.cbFunctions_CheckedChanged);
            // 
            // cbProcedures
            // 
            this.cbProcedures.AutoSize = true;
            this.cbProcedures.Checked = true;
            this.cbProcedures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbProcedures.Location = new System.Drawing.Point(76, 97);
            this.cbProcedures.Name = "cbProcedures";
            this.cbProcedures.Size = new System.Drawing.Size(141, 17);
            this.cbProcedures.TabIndex = 2;
            this.cbProcedures.Text = "Synchronize Procedures";
            this.cbProcedures.UseVisualStyleBackColor = true;
            this.cbProcedures.CheckedChanged += new System.EventHandler(this.cbProcedures_CheckedChanged);
            // 
            // cbTables
            // 
            this.cbTables.AutoSize = true;
            this.cbTables.Checked = true;
            this.cbTables.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTables.Location = new System.Drawing.Point(76, 74);
            this.cbTables.Name = "cbTables";
            this.cbTables.Size = new System.Drawing.Size(115, 17);
            this.cbTables.TabIndex = 1;
            this.cbTables.Text = "Synchronize tables";
            this.cbTables.UseVisualStyleBackColor = true;
            this.cbTables.CheckedChanged += new System.EventHandler(this.cbTables_CheckedChanged);
            // 
            // cbAll
            // 
            this.cbAll.AutoSize = true;
            this.cbAll.Checked = true;
            this.cbAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAll.Location = new System.Drawing.Point(24, 40);
            this.cbAll.Name = "cbAll";
            this.cbAll.Size = new System.Drawing.Size(97, 17);
            this.cbAll.TabIndex = 0;
            this.cbAll.Text = "Synchronize all";
            this.cbAll.UseVisualStyleBackColor = true;
            this.cbAll.CheckedChanged += new System.EventHandler(this.cbAll_CheckedChanged);
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.btnScrDb2);
            this.tabData.Controls.Add(this.btnScriptDb1);
            this.tabData.Controls.Add(this.btnGen);
            this.tabData.Controls.Add(this.label2);
            this.tabData.Controls.Add(this.lbTables);
            this.tabData.Location = new System.Drawing.Point(4, 22);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3);
            this.tabData.Size = new System.Drawing.Size(680, 293);
            this.tabData.TabIndex = 2;
            this.tabData.Text = "DataSynchronization";
            this.tabData.UseVisualStyleBackColor = true;
            // 
            // ttPriority
            // 
            this.ttPriority.AutoPopDelay = 20000;
            this.ttPriority.InitialDelay = 500;
            this.ttPriority.ReshowDelay = 100;
            this.ttPriority.ToolTipTitle = "Setting database priority";
            // 
            // ttTypeOfSync
            // 
            this.ttTypeOfSync.AutoPopDelay = 20000;
            this.ttTypeOfSync.InitialDelay = 500;
            this.ttTypeOfSync.ReshowDelay = 100;
            this.ttTypeOfSync.ToolTipTitle = "Setting type of synchronization";
            // 
            // lbTables
            // 
            this.lbTables.FormattingEnabled = true;
            this.lbTables.Location = new System.Drawing.Point(11, 35);
            this.lbTables.Name = "lbTables";
            this.lbTables.Size = new System.Drawing.Size(400, 238);
            this.lbTables.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Table to synchronize";
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(555, 75);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(75, 42);
            this.btnGen.TabIndex = 2;
            this.btnGen.Text = "Generate Scripts";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // btnScriptDb1
            // 
            this.btnScriptDb1.Location = new System.Drawing.Point(555, 123);
            this.btnScriptDb1.Name = "btnScriptDb1";
            this.btnScriptDb1.Size = new System.Drawing.Size(75, 45);
            this.btnScriptDb1.TabIndex = 3;
            this.btnScriptDb1.Text = "scripts for DB1";
            this.btnScriptDb1.UseVisualStyleBackColor = true;
            this.btnScriptDb1.Click += new System.EventHandler(this.btnScriptDb1_Click);
            // 
            // btnScrDb2
            // 
            this.btnScrDb2.Location = new System.Drawing.Point(555, 174);
            this.btnScrDb2.Name = "btnScrDb2";
            this.btnScrDb2.Size = new System.Drawing.Size(75, 46);
            this.btnScrDb2.TabIndex = 4;
            this.btnScrDb2.Text = "Scripts for DB2";
            this.btnScrDb2.UseVisualStyleBackColor = true;
            this.btnScrDb2.Click += new System.EventHandler(this.btnScrDb2_Click);
            // 
            // FrmSynchronize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 319);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmSynchronize";
            this.Text = "FrmSynchronize";
            this.tabControl1.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabSchema.ResumeLayout(false);
            this.tabSchema.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabData.ResumeLayout(false);
            this.tabData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDb2;
        private System.Windows.Forms.RadioButton rbDb1;
        private System.Windows.Forms.TabPage tabSchema;
        private System.Windows.Forms.TabPage tabData;
        private System.Windows.Forms.ToolTip ttPriority;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbCompleteSync;
        private System.Windows.Forms.RadioButton rbRightToLeft;
        private System.Windows.Forms.RadioButton rbRightToLeftDel;
        private System.Windows.Forms.RadioButton rbLeftToRight;
        private System.Windows.Forms.RadioButton rbLeftToRightDel;
        private System.Windows.Forms.ToolTip ttTypeOfSync;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbUsers;
        private System.Windows.Forms.CheckBox cbTypes;
        private System.Windows.Forms.CheckBox cbFunctions;
        private System.Windows.Forms.CheckBox cbProcedures;
        private System.Windows.Forms.CheckBox cbTables;
        private System.Windows.Forms.CheckBox cbAll;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnExecuteScripts;
        private System.Windows.Forms.Button btnDb2Scripts;
        private System.Windows.Forms.Button btnDb1Scripts;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbStatusOut;
        private System.Windows.Forms.Button btnScrDb2;
        private System.Windows.Forms.Button btnScriptDb1;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbTables;
    }
}