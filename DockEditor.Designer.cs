namespace PlugAI.Web.UI
{
    partial class DockEditor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.chbNone = new System.Windows.Forms.CheckBox();
            this.chbTop = new System.Windows.Forms.CheckBox();
            this.chbBottom = new System.Windows.Forms.CheckBox();
            this.chbLeft = new System.Windows.Forms.CheckBox();
            this.chbRight = new System.Windows.Forms.CheckBox();
            this.chbFill = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.chbFill);
            this.panel1.Controls.Add(this.chbRight);
            this.panel1.Controls.Add(this.chbLeft);
            this.panel1.Controls.Add(this.chbBottom);
            this.panel1.Controls.Add(this.chbTop);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 127);
            this.panel1.TabIndex = 7;
            // 
            // chbNone
            // 
            this.chbNone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chbNone.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbNone.Location = new System.Drawing.Point(0, 127);
            this.chbNone.Name = "chbNone";
            this.chbNone.Size = new System.Drawing.Size(150, 23);
            this.chbNone.TabIndex = 0;
            this.chbNone.Text = "None";
            this.chbNone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbNone.UseVisualStyleBackColor = true;
            this.chbNone.Click += new System.EventHandler(this.chb_Click);
            // 
            // chbTop
            // 
            this.chbTop.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbTop.Location = new System.Drawing.Point(0, 0);
            this.chbTop.Name = "chbTop";
            this.chbTop.Size = new System.Drawing.Size(150, 23);
            this.chbTop.TabIndex = 0;
            this.chbTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbTop.UseVisualStyleBackColor = true;
            this.chbTop.Click += new System.EventHandler(this.chb_Click);
            // 
            // chbBottom
            // 
            this.chbBottom.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chbBottom.Location = new System.Drawing.Point(0, 104);
            this.chbBottom.Name = "chbBottom";
            this.chbBottom.Size = new System.Drawing.Size(150, 23);
            this.chbBottom.TabIndex = 4;
            this.chbBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbBottom.UseVisualStyleBackColor = true;
            this.chbBottom.Click += new System.EventHandler(this.chb_Click);
            // 
            // chbLeft
            // 
            this.chbLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.chbLeft.Location = new System.Drawing.Point(0, 23);
            this.chbLeft.Name = "chbLeft";
            this.chbLeft.Size = new System.Drawing.Size(23, 81);
            this.chbLeft.TabIndex = 1;
            this.chbLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbLeft.UseVisualStyleBackColor = true;
            this.chbLeft.Click += new System.EventHandler(this.chb_Click);
            // 
            // chbRight
            // 
            this.chbRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.chbRight.Location = new System.Drawing.Point(127, 23);
            this.chbRight.Name = "chbRight";
            this.chbRight.Size = new System.Drawing.Size(23, 81);
            this.chbRight.TabIndex = 3;
            this.chbRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbRight.UseVisualStyleBackColor = true;
            this.chbRight.Click += new System.EventHandler(this.chb_Click);
            // 
            // chbFill
            // 
            this.chbFill.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbFill.Location = new System.Drawing.Point(23, 23);
            this.chbFill.Name = "chbFill";
            this.chbFill.Size = new System.Drawing.Size(104, 81);
            this.chbFill.TabIndex = 2;
            this.chbFill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbFill.UseVisualStyleBackColor = true;
            this.chbFill.Click += new System.EventHandler(this.chb_Click);
            // 
            // DockEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.chbNone);
            this.Controls.Add(this.panel1);
            this.Name = "DockEditor";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chbFill;
        private System.Windows.Forms.CheckBox chbRight;
        private System.Windows.Forms.CheckBox chbLeft;
        private System.Windows.Forms.CheckBox chbBottom;
        private System.Windows.Forms.CheckBox chbTop;
        private System.Windows.Forms.CheckBox chbNone;
    }
}
