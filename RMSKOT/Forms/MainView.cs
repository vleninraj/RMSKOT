using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RMSKOT
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
            EnableControls(false);
            
        }
        private void EnableControls(bool blnEnable)
        {
            btnSalesOrder.Enabled = blnEnable;
            btnLogout.Enabled = blnEnable;
            btnSettings.Enabled = blnEnable;
        }
        private void ApplyDesign(ref atGradientPanel _obj)
        {
            _obj.Size = new Size(120, 70);
            _obj.Angle = 110F;
            _obj.Font = new System.Drawing.Font("Open Sans", 13);
            _obj.BackColor = System.Drawing.Color.SteelBlue;
            _obj.BottomColor = System.Drawing.Color.DodgerBlue;
            _obj.ForeColor = System.Drawing.Color.White;
            _obj.TextAdjestmentHeight = 0;
            _obj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            _obj.TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(77)))), ((int)(((byte)(125)))));
        }
        private void Login()
        {
            FrmLoginAdvanced frm = new FrmLoginAdvanced();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (Common.isLogin)
                {
                    EnableControls(true);
                }
                else
                {
                    EnableControls(false);
                }
            }

        }
        private void MainView_Load(object sender, EventArgs e)
        {
            Login();
        }

        private void btnLogout_Paint(object sender, PaintEventArgs e)
        {
           


        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            Common.isLogin = false;
            Common.UserID = "";
            Common.UserName = "";
            Login();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tmr1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToString();
        }
    }
}
