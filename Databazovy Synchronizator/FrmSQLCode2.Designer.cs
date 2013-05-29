namespace Databazovy_Synchronizator
{
    partial class FrmSQLCode2
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
            this.sideBySideRichTextBox1 = new Databazovy_Synchronizator.SideBySideRichTextBox();
            this.SuspendLayout();
            // 
            // sideBySideRichTextBox1
            // 
            this.sideBySideRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideBySideRichTextBox1.LeftText = "";
            this.sideBySideRichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.sideBySideRichTextBox1.Name = "sideBySideRichTextBox1";
            this.sideBySideRichTextBox1.RightText = "";
            this.sideBySideRichTextBox1.Size = new System.Drawing.Size(593, 340);
            this.sideBySideRichTextBox1.TabIndex = 0;
            // 
            // FrmSQLCode2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 340);
            this.Controls.Add(this.sideBySideRichTextBox1);
            this.Name = "FrmSQLCode2";
            this.Text = "SQL";
            this.ResumeLayout(false);

        }

        #endregion

        private SideBySideRichTextBox sideBySideRichTextBox1;
    }
}