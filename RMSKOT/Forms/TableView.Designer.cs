namespace RMSKOT.Forms
{
    partial class TableView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableView));
            this.pnltop = new RMSKOT.SkyPanel();
            this.btnFloor = new System.Windows.Forms.Button();
            this.lblCap = new System.Windows.Forms.Label();
            this.pnltables = new RMSKOT.TouchableFlowLayoutPanel(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.pnltop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnltop
            // 
            this.pnltop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(33)))), ((int)(((byte)(53)))));
            this.pnltop.Controls.Add(this.btnClose);
            this.pnltop.Controls.Add(this.btnFloor);
            this.pnltop.Controls.Add(this.lblCap);
            this.pnltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltop.Location = new System.Drawing.Point(0, 0);
            this.pnltop.Name = "pnltop";
            this.pnltop.Size = new System.Drawing.Size(420, 54);
            this.pnltop.TabIndex = 0;
            // 
            // btnFloor
            // 
            this.btnFloor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFloor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnFloor.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnFloor.FlatAppearance.BorderSize = 0;
            this.btnFloor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFloor.Font = new System.Drawing.Font("Open Sans SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFloor.ForeColor = System.Drawing.Color.White;
            this.btnFloor.Image = ((System.Drawing.Image)(resources.GetObject("btnFloor.Image")));
            this.btnFloor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFloor.Location = new System.Drawing.Point(71, 9);
            this.btnFloor.Name = "btnFloor";
            this.btnFloor.Size = new System.Drawing.Size(269, 37);
            this.btnFloor.TabIndex = 118;
            this.btnFloor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFloor.UseVisualStyleBackColor = false;
            this.btnFloor.Click += new System.EventHandler(this.btnFloor_Click);
            // 
            // lblCap
            // 
            this.lblCap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCap.AutoSize = true;
            this.lblCap.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCap.ForeColor = System.Drawing.Color.White;
            this.lblCap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCap.Location = new System.Drawing.Point(18, 18);
            this.lblCap.Name = "lblCap";
            this.lblCap.Size = new System.Drawing.Size(47, 20);
            this.lblCap.TabIndex = 117;
            this.lblCap.Text = "Floor";
            // 
            // pnltables
            // 
            this.pnltables.AutoScroll = true;
            this.pnltables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(64)))));
            this.pnltables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnltables.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnltables.Location = new System.Drawing.Point(0, 54);
            this.pnltables.Name = "pnltables";
            this.pnltables.Padding = new System.Windows.Forms.Padding(20);
            this.pnltables.Size = new System.Drawing.Size(420, 499);
            this.pnltables.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Open Sans SemiBold", 15F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(362, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 47);
            this.btnClose.TabIndex = 119;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(420, 553);
            this.Controls.Add(this.pnltables);
            this.Controls.Add(this.pnltop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TableView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TableView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnltop.ResumeLayout(false);
            this.pnltop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SkyPanel pnltop;
        private TouchableFlowLayoutPanel pnltables;
        private System.Windows.Forms.Label lblCap;
        private System.Windows.Forms.Button btnFloor;
        private System.Windows.Forms.Button btnClose;
    }
}