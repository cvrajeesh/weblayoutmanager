namespace PlugAI.Web.UI
{
    partial class DockableCollectionEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockableCollectionEditor));
            this.label1 = new System.Windows.Forms.Label();
            this.trvDockableItems = new System.Windows.Forms.TreeView();
            this.btnUp = new System.Windows.Forms.Button();
            this.imlMain = new System.Windows.Forms.ImageList(this.components);
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.prgDockableItemProperties = new System.Windows.Forms.PropertyGrid();
            this.lblGridLabel = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Members :";
            // 
            // trvDockableItems
            // 
            this.trvDockableItems.ImageIndex = 0;
            this.trvDockableItems.ImageList = this.imlMain;
            this.trvDockableItems.Location = new System.Drawing.Point(12, 38);
            this.trvDockableItems.Name = "trvDockableItems";
            this.trvDockableItems.SelectedImageIndex = 0;
            this.trvDockableItems.Size = new System.Drawing.Size(206, 296);
            this.trvDockableItems.TabIndex = 1;
            this.trvDockableItems.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvDockableItems_AfterSelect);
            // 
            // btnUp
            // 
            this.btnUp.Enabled = false;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUp.ImageIndex = 0;
            this.btnUp.ImageList = this.imlMain;
            this.btnUp.Location = new System.Drawing.Point(225, 38);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(26, 27);
            this.btnUp.TabIndex = 2;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // imlMain
            // 
            this.imlMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMain.ImageStream")));
            this.imlMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imlMain.Images.SetKeyName(0, "go-up.png");
            this.imlMain.Images.SetKeyName(1, "go-down.png");
            this.imlMain.Images.SetKeyName(2, "go-next.png");
            this.imlMain.Images.SetKeyName(3, "go-previous.png");
            this.imlMain.Images.SetKeyName(4, "stock_alignment.png");
            this.imlMain.Images.SetKeyName(5, "stock_alignment-left.png");
            this.imlMain.Images.SetKeyName(6, "stock_alignment-right.png");
            this.imlMain.Images.SetKeyName(7, "stock_alignment-top.png");
            this.imlMain.Images.SetKeyName(8, "stock_alignment-bottom.png");
            this.imlMain.Images.SetKeyName(9, "stock_alignment-centered.png");
            // 
            // btnLeft
            // 
            this.btnLeft.Enabled = false;
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLeft.ImageIndex = 3;
            this.btnLeft.ImageList = this.imlMain;
            this.btnLeft.Location = new System.Drawing.Point(225, 71);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(26, 27);
            this.btnLeft.TabIndex = 3;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnDown
            // 
            this.btnDown.Enabled = false;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDown.ImageIndex = 1;
            this.btnDown.ImageList = this.imlMain;
            this.btnDown.Location = new System.Drawing.Point(225, 137);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(26, 27);
            this.btnDown.TabIndex = 5;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnRight
            // 
            this.btnRight.Enabled = false;
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRight.ImageIndex = 2;
            this.btnRight.ImageList = this.imlMain;
            this.btnRight.Location = new System.Drawing.Point(225, 104);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(26, 27);
            this.btnRight.TabIndex = 4;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // prgDockableItemProperties
            // 
            this.prgDockableItemProperties.Location = new System.Drawing.Point(257, 38);
            this.prgDockableItemProperties.Name = "prgDockableItemProperties";
            this.prgDockableItemProperties.Size = new System.Drawing.Size(271, 325);
            this.prgDockableItemProperties.TabIndex = 6;
            this.prgDockableItemProperties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.prgDockableItemProperties_PropertyValueChanged);
            // 
            // lblGridLabel
            // 
            this.lblGridLabel.AutoSize = true;
            this.lblGridLabel.Location = new System.Drawing.Point(254, 22);
            this.lblGridLabel.Name = "lblGridLabel";
            this.lblGridLabel.Size = new System.Drawing.Size(60, 13);
            this.lblGridLabel.TabIndex = 7;
            this.lblGridLabel.Text = "Properties :";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(452, 371);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(371, 371);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 340);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(93, 340);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "&Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // DockableCollectionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 406);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblGridLabel);
            this.Controls.Add(this.prgDockableItemProperties);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.trvDockableItems);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DockableCollectionEditor";
            this.Text = "Dockable Collection Editor";
            this.Load += new System.EventHandler(this.DockableCollectionEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView trvDockableItems;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.ImageList imlMain;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.PropertyGrid prgDockableItemProperties;
        private System.Windows.Forms.Label lblGridLabel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
    }
}