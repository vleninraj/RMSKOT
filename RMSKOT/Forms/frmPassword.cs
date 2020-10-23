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
    public partial class frmPassword : Form
    {
        DataRow drow;
        public frmPassword(DataRow _drow)
        {
            InitializeComponent();
            drow = _drow;
            lblCap.Text = "Enter Password For User :" + drow["UserId"].ToString();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (drow["UserPassword"].ToString().Trim() == txtPasswordbasic.Text.Trim())
            {
                Common.isLogin = true;
                Common.UserID = drow["EmpId"].ToString();
                Common.UserName = drow["UserId"].ToString();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                Common.isLogin = false;
                Common.UserID = "";
                Common.UserName = "";
                MessageBox.Show("Invalid Login Information","Login Failed",MessageBoxButtons.OKCancel);
                this.DialogResult = DialogResult.Cancel;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Common.isLogin = false;
            Common.UserID = "";
            Common.UserName = "";
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtPasswordbasic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnLogin_Click(sender, e);
            }
        }

       
    }
}
