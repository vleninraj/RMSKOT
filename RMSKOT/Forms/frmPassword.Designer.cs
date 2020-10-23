namespace RMSKOT
{
    partial class frmPassword
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
            this.txtPasswordbasic = new RMSKOT.SkyTextBox();
            this.lblCap = new System.Windows.Forms.Label();
            this.pnlUsers = new RMSKOT.SkyPanel();
            this.btnCancel = new RMSKOT.SkyButton();
            this.btnOK = new RMSKOT.SkyButton();
            this.customPanel1 = new RMSKOT.SkyPanel();
            this.numKeyBoard1 = new RMSKOT.NumKeyBoardPOS();
            this.pnlUsers.SuspendLayout();
            this.customPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPasswordbasic
            // 
            this.txtPasswordbasic.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswordbasic.Format = null;
            this.txtPasswordbasic.isAllowNegative = false;
            this.txtPasswordbasic.isNumeric = false;
            this.txtPasswordbasic.Location = new System.Drawing.Point(316, 117);
            this.txtPasswordbasic.Name = "txtPasswordbasic";
            this.txtPasswordbasic.Size = new System.Drawing.Size(369, 33);
            this.txtPasswordbasic.TabIndex = 0;
            this.txtPasswordbasic.UseSystemPasswordChar = true;
            this.txtPasswordbasic.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPasswordbasic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPasswordbasic_KeyDown);
            // 
            // lblCap
            // 
            this.lblCap.AutoSize = true;
            this.lblCap.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCap.ForeColor = System.Drawing.Color.Black;
            this.lblCap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCap.Location = new System.Drawing.Point(312, 87);
            this.lblCap.Name = "lblCap";
            this.lblCap.Size = new System.Drawing.Size(158, 26);
            this.lblCap.TabIndex = 4;
            this.lblCap.Text = "Enter Password";
            // 
            // pnlUsers
            // 
            this.pnlUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(48)))), ((int)(((byte)(65)))));
            this.pnlUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUsers.Controls.Add(this.btnCancel);
            this.pnlUsers.Controls.Add(this.btnOK);
            this.pnlUsers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUsers.Location = new System.Drawing.Point(0, 260);
            this.pnlUsers.Name = "pnlUsers";
            this.pnlUsers.Size = new System.Drawing.Size(692, 61);
            this.pnlUsers.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(77)))), ((int)(((byte)(125)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(528, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(158, 48);
            this.btnCancel.TabIndex = 151;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(77)))), ((int)(((byte)(125)))));
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(364, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(158, 48);
            this.btnOK.TabIndex = 150;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // customPanel1
            // 
            this.customPanel1.BackColor = System.Drawing.Color.White;
            this.customPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel1.Controls.Add(this.lblCap);
            this.customPanel1.Controls.Add(this.txtPasswordbasic);
            this.customPanel1.Controls.Add(this.numKeyBoard1);
            this.customPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPanel1.Location = new System.Drawing.Point(0, 0);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(692, 260);
            this.customPanel1.TabIndex = 0;
            // 
            // numKeyBoard1
            // 
            this.numKeyBoard1.BackColor = System.Drawing.Color.Transparent;
            this.numKeyBoard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numKeyBoard1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numKeyBoard1.Location = new System.Drawing.Point(4, 3);
            this.numKeyBoard1.Margin = new System.Windows.Forms.Padding(4);
            this.numKeyBoard1.Name = "numKeyBoard1";
            this.numKeyBoard1.Size = new System.Drawing.Size(305, 251);
            this.numKeyBoard1.TabIndex = 5;
            // 
            // frmPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(129)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(692, 321);
            this.Controls.Add(this.customPanel1);
            this.Controls.Add(this.pnlUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter Password";
            this.pnlUsers.ResumeLayout(false);
            this.customPanel1.ResumeLayout(false);
            this.customPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SkyTextBox txtPasswordbasic;
        private System.Windows.Forms.Label lblCap;
        private SkyPanel pnlUsers;
        private SkyPanel customPanel1;
        private NumKeyBoardPOS numKeyBoard1;
        private SkyButton btnCancel;
        private SkyButton btnOK;
    }
}