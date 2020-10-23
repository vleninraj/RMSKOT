using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace RMSKOT
{
    public partial class FrmLoginAdvanced : Form
    {
        DataTable dtUsers;
        public FrmLoginAdvanced()
        {
            InitializeComponent();
            if (Properties.Settings.Default.ServerName != "" && Properties.Settings.Default.DatabaseName != "")
            {
                DbHelper.sConnectionstring = "server=" + Properties.Settings.Default.ServerName + ";uid=root;pwd=root;database=" + Properties.Settings.Default.DatabaseName + ";Max Pool Size=1000";
            }
        }
        private void PopulateUsers()
        {
            if(DbHelper.sConnectionstring==null || DbHelper.sConnectionstring.Trim()=="")
            {
                return;
            }
            string sql = "SELECT UserId,EmpId,UserPassword FROM user_details";
            dtUsers = new DataTable();
            dtUsers = DbHelper.FillData(sql);
            pnlUsers.Controls.Clear();
            foreach (DataRow drow in dtUsers.Rows)
            {
                AddUserButton(drow);
            }
         
        }
        private void AddUserButton(DataRow row)
        {
            atGradientPanel btnItem = new atGradientPanel();
            btnItem.BackColor = Color.FromArgb(1, 137, 52);
            btnItem.ForeColor = Color.White;
            btnItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btnItem.Font = new Font("Open Sans", 12, FontStyle.Bold);
            btnItem.Cursor = System.Windows.Forms.Cursors.Hand;
            btnItem.Name = "btn_" + row["UserId"].ToString();
            btnItem.Size = new System.Drawing.Size(250, 80);
            btnItem.Text = row["UserId"].ToString();
            btnItem.Tag = row;
            btnItem.Click += (sndd, eee) =>
            {
                Login(row);
            };
            pnlUsers.Controls.Add(btnItem);
        }
        private void Login(DataRow drow)
        {
            frmPassword frm = new frmPassword(drow);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                
                this.DialogResult = DialogResult.OK;
            }
          
        }
        private void FrmLogin_Resize(object sender, EventArgs e)
        {
            pnlUsers.Left = (this.Width - pnlUsers.Width) / 2;
            pnlUsers.Top = (this.Height - pnlUsers.Height) / 2;
        }
        
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            FrmLogin_Resize(sender, e);
            PopulateUsers();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                ServerSettingView frm = new ServerSettingView();
                if(frm.ShowDialog()==DialogResult.OK)
                {
                    if (Properties.Settings.Default.ServerName != "" && Properties.Settings.Default.DatabaseName != "")
                    {
                        DbHelper.sConnectionstring = "server=" + Properties.Settings.Default.ServerName + ";uid=root;pwd=root;database=" + Properties.Settings.Default.DatabaseName + ";Max Pool Size=1000";
                        PopulateUsers();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
