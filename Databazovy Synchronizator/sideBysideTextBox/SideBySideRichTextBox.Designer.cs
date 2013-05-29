namespace Databazovy_Synchronizator
{
    partial class SideBySideRichTextBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rtbLeft = new System.Windows.Forms.RichTextBox();
            this.rtbRight = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.rtbLeft, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rtbRight, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(896, 399);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rtbLeft
            // 
            this.rtbLeft.BackColor = System.Drawing.Color.White;
            this.rtbLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLeft.Location = new System.Drawing.Point(3, 3);
            this.rtbLeft.Name = "rtbLeft";
            this.rtbLeft.ReadOnly = true;
            this.rtbLeft.Size = new System.Drawing.Size(442, 393);
            this.rtbLeft.TabIndex = 0;
            this.rtbLeft.Text = "";
            this.rtbLeft.WordWrap = false;
            // 
            // rtbRight
            // 
            this.rtbRight.BackColor = System.Drawing.Color.White;
            this.rtbRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbRight.Location = new System.Drawing.Point(451, 3);
            this.rtbRight.Name = "rtbRight";
            this.rtbRight.ReadOnly = true;
            this.rtbRight.Size = new System.Drawing.Size(442, 393);
            this.rtbRight.TabIndex = 1;
            this.rtbRight.Text = "";
            this.rtbRight.WordWrap = false;
            // 
            // SideBySideRichTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SideBySideRichTextBox";
            this.Size = new System.Drawing.Size(896, 399);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox rtbLeft;
        private System.Windows.Forms.RichTextBox rtbRight;
    }
}
