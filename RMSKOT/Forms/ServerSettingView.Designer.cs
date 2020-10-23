namespace RMSKOT
{
    partial class ServerSettingView
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
            this.skyGroupBox1 = new RMSKOT.SkyGroupBox();
            this.txtdatabasename = new RMSKOT.SkyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtserverName = new RMSKOT.SkyTextBox();
            this.lblTotalQtyCap = new System.Windows.Forms.Label();
            this.btnCancel = new RMSKOT.SkyButton();
            this.btnOK = new RMSKOT.SkyButton();
            this.btnTestConnection = new RMSKOT.SkyButton();
            this.skyGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblcaption
            // 
            this.lblcaption.Size = new System.Drawing.Size(117, 22);
            this.lblcaption.Text = "Server Setting";
            // 
            // skyGroupBox1
            // 
            this.skyGroupBox1.Controls.Add(this.txtdatabasename);
            this.skyGroupBox1.Controls.Add(this.label2);
            this.skyGroupBox1.Controls.Add(this.txtserverName);
            this.skyGroupBox1.Controls.Add(this.lblTotalQtyCap);
            this.skyGroupBox1.Location = new System.Drawing.Point(7, 49);
            this.skyGroupBox1.Name = "skyGroupBox1";
            this.skyGroupBox1.Size = new System.Drawing.Size(350, 85);
            this.skyGroupBox1.TabIndex = 147;
            this.skyGroupBox1.TabStop = false;
            this.skyGroupBox1.Text = "Server Settings";
            // 
            // txtdatabasename
            // 
            this.txtdatabasename.Format = null;
            this.txtdatabasename.isAllowNegative = false;
            this.txtdatabasename.isNumeric = false;
            this.txtdatabasename.Location = new System.Drawing.Point(94, 53);
            this.txtdatabasename.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtdatabasename.Name = "txtdatabasename";
            this.txtdatabasename.Size = new System.Drawing.Size(243, 21);
            this.txtdatabasename.TabIndex = 148;
            this.txtdatabasename.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtdatabasename.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdatabasename_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(25, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 147;
            this.label2.Text = "Database";
            // 
            // txtserverName
            // 
            this.txtserverName.Format = null;
            this.txtserverName.isAllowNegative = false;
            this.txtserverName.isNumeric = false;
            this.txtserverName.Location = new System.Drawing.Point(94, 26);
            this.txtserverName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtserverName.Name = "txtserverName";
            this.txtserverName.Size = new System.Drawing.Size(243, 21);
            this.txtserverName.TabIndex = 146;
            this.txtserverName.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblTotalQtyCap
            // 
            this.lblTotalQtyCap.AutoSize = true;
            this.lblTotalQtyCap.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalQtyCap.ForeColor = System.Drawing.Color.Black;
            this.lblTotalQtyCap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotalQtyCap.Location = new System.Drawing.Point(4, 28);
            this.lblTotalQtyCap.Name = "lblTotalQtyCap";
            this.lblTotalQtyCap.Size = new System.Drawing.Size(85, 18);
            this.lblTotalQtyCap.TabIndex = 145;
            this.lblTotalQtyCap.Text = "Server Name";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(77)))), ((int)(((byte)(125)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Open Sans SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(262, 173);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 33);
            this.btnCancel.TabIndex = 149;
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
            this.btnOK.Font = new System.Drawing.Font("Open Sans SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(160, 173);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 33);
            this.btnOK.TabIndex = 148;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(77)))), ((int)(((byte)(125)))));
            this.btnTestConnection.FlatAppearance.BorderSize = 0;
            this.btnTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestConnection.Font = new System.Drawing.Font("Open Sans SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestConnection.ForeColor = System.Drawing.Color.White;
            this.btnTestConnection.Location = new System.Drawing.Point(230, 139);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(127, 28);
            this.btnTestConnection.TabIndex = 150;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = false;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // ServerSettingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 211);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.skyGroupBox1);
            this.Name = "ServerSettingView";
            this.Text = "ServerSettingView";
            this.Controls.SetChildIndex(this.skyGroupBox1, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnTestConnection, 0);
            this.skyGroupBox1.ResumeLayout(false);
            this.skyGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SkyGroupBox skyGroupBox1;
        private SkyTextBox txtdatabasename;
        private System.Windows.Forms.Label label2;
        private SkyTextBox txtserverName;
        private System.Windows.Forms.Label lblTotalQtyCap;
        private SkyButton btnCancel;
        private SkyButton btnOK;
        private SkyButton btnTestConnection;
    }
}