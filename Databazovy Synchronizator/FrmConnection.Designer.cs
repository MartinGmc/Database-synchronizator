namespace Databazovy_Synchronizator
{
    partial class FrmConnection
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
            this.button1 = new System.Windows.Forms.Button();
            this.cbDatabaza = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.db1Server = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.db1Name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.db1Username = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.db1Pass = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.db2Server = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.db2Pass = new System.Windows.Forms.TextBox();
            this.db2Name = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.db2Username = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbDatabaza
            // 
            this.cbDatabaza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabaza.FormattingEnabled = true;
            this.cbDatabaza.Items.AddRange(new object[] {
            "MSSQL"});
            this.cbDatabaza.Location = new System.Drawing.Point(200, 214);
            this.cbDatabaza.Name = "cbDatabaza";
            this.cbDatabaza.Size = new System.Drawing.Size(121, 21);
            this.cbDatabaza.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(220, 253);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Connect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // db1Server
            // 
            this.db1Server.Location = new System.Drawing.Point(118, 19);
            this.db1Server.Name = "db1Server";
            this.db1Server.Size = new System.Drawing.Size(134, 20);
            this.db1Server.TabIndex = 7;
            this.db1Server.Text = "192.168.171.134,1433";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "server :";
            // 
            // db1Name
            // 
            this.db1Name.Location = new System.Drawing.Point(118, 54);
            this.db1Name.Name = "db1Name";
            this.db1Name.Size = new System.Drawing.Size(100, 20);
            this.db1Name.TabIndex = 9;
            this.db1Name.Text = "Test database";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Name of Database :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(258, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Username :";
            // 
            // db1Username
            // 
            this.db1Username.Location = new System.Drawing.Point(325, 19);
            this.db1Username.Name = "db1Username";
            this.db1Username.Size = new System.Drawing.Size(100, 20);
            this.db1Username.TabIndex = 11;
            this.db1Username.Text = "Martintest";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Password :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // db1Pass
            // 
            this.db1Pass.Location = new System.Drawing.Point(325, 54);
            this.db1Pass.Name = "db1Pass";
            this.db1Pass.PasswordChar = '*';
            this.db1Pass.Size = new System.Drawing.Size(100, 20);
            this.db1Pass.TabIndex = 13;
            this.db1Pass.Text = "martintest";
            this.db1Pass.TextChanged += new System.EventHandler(this.db1Pass_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.db1Server);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.db1Pass);
            this.groupBox1.Controls.Add(this.db1Name);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.db1Username);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 83);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database 1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.db2Server);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.db2Pass);
            this.groupBox2.Controls.Add(this.db2Name);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.db2Username);
            this.groupBox2.Location = new System.Drawing.Point(12, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(477, 83);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database 1";
            // 
            // db2Server
            // 
            this.db2Server.Location = new System.Drawing.Point(118, 19);
            this.db2Server.Name = "db2Server";
            this.db2Server.Size = new System.Drawing.Size(100, 20);
            this.db2Server.TabIndex = 7;
            this.db2Server.Text = "192.168.171.134,1433";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(260, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Password :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(77, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "server :";
            // 
            // db2Pass
            // 
            this.db2Pass.Location = new System.Drawing.Point(325, 54);
            this.db2Pass.Name = "db2Pass";
            this.db2Pass.PasswordChar = '*';
            this.db2Pass.Size = new System.Drawing.Size(100, 20);
            this.db2Pass.TabIndex = 13;
            this.db2Pass.Text = "martintest";
            this.db2Pass.TextChanged += new System.EventHandler(this.db2Pass_TextChanged);
            // 
            // db2Name
            // 
            this.db2Name.Location = new System.Drawing.Point(118, 54);
            this.db2Name.Name = "db2Name";
            this.db2Name.Size = new System.Drawing.Size(100, 20);
            this.db2Name.TabIndex = 9;
            this.db2Name.Text = "Test database";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(258, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Username :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Name of Database :";
            // 
            // db2Username
            // 
            this.db2Username.Location = new System.Drawing.Point(325, 19);
            this.db2Username.Name = "db2Username";
            this.db2Username.Size = new System.Drawing.Size(100, 20);
            this.db2Username.TabIndex = 11;
            this.db2Username.Text = "Martintest";
            // 
            // FrmConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 299);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbDatabaza);
            this.Controls.Add(this.button1);
            this.Name = "FrmConnection";
            this.Text = "Set connection to database";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbDatabaza;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox db1Server;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox db1Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox db1Username;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox db1Pass;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox db2Server;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox db2Pass;
        private System.Windows.Forms.TextBox db2Name;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox db2Username;
    }
}