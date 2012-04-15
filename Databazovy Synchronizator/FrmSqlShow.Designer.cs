namespace Databazovy_Synchronizator
{
    partial class FrmSqlShow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lineNumbers_For_RichTextBox2 = new LineNumbers.LineNumbers_For_RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lineNumbers_For_RichTextBox2);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 306);
            this.panel1.TabIndex = 0;
            // 
            // lineNumbers_For_RichTextBox2
            // 
            this.lineNumbers_For_RichTextBox2._SeeThroughMode_ = false;
            this.lineNumbers_For_RichTextBox2.AutoSizing = true;
            this.lineNumbers_For_RichTextBox2.BackgroundGradient_AlphaColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lineNumbers_For_RichTextBox2.BackgroundGradient_BetaColor = System.Drawing.Color.LightSteelBlue;
            this.lineNumbers_For_RichTextBox2.BackgroundGradient_Direction = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lineNumbers_For_RichTextBox2.BorderLines_Color = System.Drawing.Color.SlateGray;
            this.lineNumbers_For_RichTextBox2.BorderLines_Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lineNumbers_For_RichTextBox2.BorderLines_Thickness = 1F;
            this.lineNumbers_For_RichTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineNumbers_For_RichTextBox2.DockSide = LineNumbers.LineNumbers_For_RichTextBox.LineNumberDockSide.Left;
            this.lineNumbers_For_RichTextBox2.GridLines_Color = System.Drawing.Color.SlateGray;
            this.lineNumbers_For_RichTextBox2.GridLines_Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lineNumbers_For_RichTextBox2.GridLines_Thickness = 1F;
            this.lineNumbers_For_RichTextBox2.LineNrs_Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lineNumbers_For_RichTextBox2.LineNrs_AntiAlias = true;
            this.lineNumbers_For_RichTextBox2.LineNrs_AsHexadecimal = false;
            this.lineNumbers_For_RichTextBox2.LineNrs_ClippedByItemRectangle = true;
            this.lineNumbers_For_RichTextBox2.LineNrs_LeadingZeroes = true;
            this.lineNumbers_For_RichTextBox2.LineNrs_Offset = new System.Drawing.Size(0, 0);
            this.lineNumbers_For_RichTextBox2.Location = new System.Drawing.Point(0, 0);
            this.lineNumbers_For_RichTextBox2.Margin = new System.Windows.Forms.Padding(0);
            this.lineNumbers_For_RichTextBox2.MarginLines_Color = System.Drawing.Color.SlateGray;
            this.lineNumbers_For_RichTextBox2.MarginLines_Side = LineNumbers.LineNumbers_For_RichTextBox.LineNumberDockSide.Right;
            this.lineNumbers_For_RichTextBox2.MarginLines_Style = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lineNumbers_For_RichTextBox2.MarginLines_Thickness = 1F;
            this.lineNumbers_For_RichTextBox2.Name = "lineNumbers_For_RichTextBox2";
            this.lineNumbers_For_RichTextBox2.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lineNumbers_For_RichTextBox2.ParentRichTextBox = this.richTextBox1;
            this.lineNumbers_For_RichTextBox2.Show_BackgroundGradient = true;
            this.lineNumbers_For_RichTextBox2.Show_BorderLines = true;
            this.lineNumbers_For_RichTextBox2.Show_GridLines = true;
            this.lineNumbers_For_RichTextBox2.Show_LineNrs = true;
            this.lineNumbers_For_RichTextBox2.Show_MarginLines = true;
            this.lineNumbers_For_RichTextBox2.Size = new System.Drawing.Size(27, 306);
            this.lineNumbers_For_RichTextBox2.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.richTextBox1.Location = new System.Drawing.Point(27, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(594, 306);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.btnCopy);
            this.panel2.Controls.Add(this.btnSaveToFile);
            this.panel2.Controls.Add(this.btnExecute);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 306);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(621, 59);
            this.panel2.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(420, 18);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(261, 18);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(111, 23);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "Copy to clipboard";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Location = new System.Drawing.Point(160, 18);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveToFile.TabIndex = 1;
            this.btnSaveToFile.Text = "Save to file";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(45, 18);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 0;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(621, 365);
            this.panel3.TabIndex = 2;
            // 
            // FrmSqlShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 365);
            this.Controls.Add(this.panel3);
            this.Name = "FrmSqlShow";
            this.Text = "FrmSqlShow";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel2;
        private LineNumbers.LineNumbers_For_RichTextBox lineNumbers_For_RichTextBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}