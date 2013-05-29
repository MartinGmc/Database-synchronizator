namespace Databazovy_Synchronizator
{
    partial class FrmSqlCode
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
            this.sqlTextA = new System.Windows.Forms.RichTextBox();
            this.sqlTextB = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lineNumbers_For_RichTextBox1 = new LineNumbers.LineNumbers_For_RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lineNumbers_For_RichTextBox2 = new LineNumbers.LineNumbers_For_RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sqlTextA
            // 
            this.sqlTextA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlTextA.Location = new System.Drawing.Point(20, 0);
            this.sqlTextA.Name = "sqlTextA";
            this.sqlTextA.ReadOnly = true;
            this.sqlTextA.Size = new System.Drawing.Size(222, 342);
            this.sqlTextA.TabIndex = 0;
            this.sqlTextA.Text = "";
            // 
            // sqlTextB
            // 
            this.sqlTextB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlTextB.Location = new System.Drawing.Point(20, 0);
            this.sqlTextB.Name = "sqlTextB";
            this.sqlTextB.ReadOnly = true;
            this.sqlTextB.Size = new System.Drawing.Size(253, 342);
            this.sqlTextB.TabIndex = 1;
            this.sqlTextB.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sqlTextA);
            this.splitContainer1.Panel1.Controls.Add(this.lineNumbers_For_RichTextBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(519, 342);
            this.splitContainer1.SplitterDistance = 242;
            this.splitContainer1.TabIndex = 2;
            // 
            // lineNumbers_For_RichTextBox1
            // 
            this.lineNumbers_For_RichTextBox1._SeeThroughMode_ = false;
            this.lineNumbers_For_RichTextBox1.AutoSizing = true;
            this.lineNumbers_For_RichTextBox1.BackgroundGradient_AlphaColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lineNumbers_For_RichTextBox1.BackgroundGradient_BetaColor = System.Drawing.Color.LightSteelBlue;
            this.lineNumbers_For_RichTextBox1.BackgroundGradient_Direction = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lineNumbers_For_RichTextBox1.BorderLines_Color = System.Drawing.Color.SlateGray;
            this.lineNumbers_For_RichTextBox1.BorderLines_Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lineNumbers_For_RichTextBox1.BorderLines_Thickness = 1F;
            this.lineNumbers_For_RichTextBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lineNumbers_For_RichTextBox1.DockSide = LineNumbers.LineNumbers_For_RichTextBox.LineNumberDockSide.Left;
            this.lineNumbers_For_RichTextBox1.GridLines_Color = System.Drawing.Color.SlateGray;
            this.lineNumbers_For_RichTextBox1.GridLines_Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lineNumbers_For_RichTextBox1.GridLines_Thickness = 1F;
            this.lineNumbers_For_RichTextBox1.LineNrs_Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lineNumbers_For_RichTextBox1.LineNrs_AntiAlias = true;
            this.lineNumbers_For_RichTextBox1.LineNrs_AsHexadecimal = false;
            this.lineNumbers_For_RichTextBox1.LineNrs_ClippedByItemRectangle = true;
            this.lineNumbers_For_RichTextBox1.LineNrs_LeadingZeroes = true;
            this.lineNumbers_For_RichTextBox1.LineNrs_Offset = new System.Drawing.Size(0, 0);
            this.lineNumbers_For_RichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.lineNumbers_For_RichTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.lineNumbers_For_RichTextBox1.MarginLines_Color = System.Drawing.Color.SlateGray;
            this.lineNumbers_For_RichTextBox1.MarginLines_Side = LineNumbers.LineNumbers_For_RichTextBox.LineNumberDockSide.Right;
            this.lineNumbers_For_RichTextBox1.MarginLines_Style = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lineNumbers_For_RichTextBox1.MarginLines_Thickness = 1F;
            this.lineNumbers_For_RichTextBox1.Name = "lineNumbers_For_RichTextBox1";
            this.lineNumbers_For_RichTextBox1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lineNumbers_For_RichTextBox1.ParentRichTextBox = this.sqlTextA;
            this.lineNumbers_For_RichTextBox1.Show_BackgroundGradient = true;
            this.lineNumbers_For_RichTextBox1.Show_BorderLines = true;
            this.lineNumbers_For_RichTextBox1.Show_GridLines = true;
            this.lineNumbers_For_RichTextBox1.Show_LineNrs = true;
            this.lineNumbers_For_RichTextBox1.Show_MarginLines = true;
            this.lineNumbers_For_RichTextBox1.Size = new System.Drawing.Size(20, 342);
            this.lineNumbers_For_RichTextBox1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sqlTextB);
            this.panel1.Controls.Add(this.lineNumbers_For_RichTextBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 342);
            this.panel1.TabIndex = 3;
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
            this.lineNumbers_For_RichTextBox2.Dock = System.Windows.Forms.DockStyle.Left;
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
            this.lineNumbers_For_RichTextBox2.ParentRichTextBox = this.sqlTextB;
            this.lineNumbers_For_RichTextBox2.Show_BackgroundGradient = true;
            this.lineNumbers_For_RichTextBox2.Show_BorderLines = true;
            this.lineNumbers_For_RichTextBox2.Show_GridLines = true;
            this.lineNumbers_For_RichTextBox2.Show_LineNrs = true;
            this.lineNumbers_For_RichTextBox2.Show_MarginLines = true;
            this.lineNumbers_For_RichTextBox2.Size = new System.Drawing.Size(20, 342);
            this.lineNumbers_For_RichTextBox2.TabIndex = 2;
            // 
            // FrmSqlCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 342);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmSqlCode";
            this.Text = "Comarison of SQL code";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox sqlTextA;
        private System.Windows.Forms.RichTextBox sqlTextB;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private LineNumbers.LineNumbers_For_RichTextBox lineNumbers_For_RichTextBox1;
        private LineNumbers.LineNumbers_For_RichTextBox lineNumbers_For_RichTextBox2;
        private System.Windows.Forms.Panel panel1;
    }
}