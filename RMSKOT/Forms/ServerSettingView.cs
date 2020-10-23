using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
namespace RMSKOT
{
    public partial class ServerSettingView : FormBase
    {
        public ServerSettingView()
        {
            InitializeComponent();
            txtserverName.Text = Properties.Settings.Default.ServerName;
            txtdatabasename.Text = Properties.Settings.Default.DatabaseName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerName = txtserverName.Text;
            Properties.Settings.Default.DatabaseName = txtdatabasename.Text;
            Properties.Settings.Default.Save();
            DbHelper.sConnectionstring= "server=" + Properties.Settings.Default.ServerName + ";uid=root;pwd=root;database=" + Properties.Settings.Default.DatabaseName + ";Max Pool Size=1000";
            MessageBox.Show("Settings Saved!");
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
           string sconnectionstring = "server=" + txtserverName.Text + ";uid=root;pwd=root;database=" + txtdatabasename.Text + ";Max Pool Size=1000";
            using(MySqlConnection conn=new MySqlConnection(sconnectionstring))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Connection succeeded!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void txtdatabasename_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnOK_Click(sender, e);
            }
        }
    }
}
