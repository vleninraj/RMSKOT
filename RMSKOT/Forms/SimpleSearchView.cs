using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RMSKOT.Forms
{
    public partial class SimpleSearchView : Form
    {
        string sDisplayMember, sValueMember;
        DataTable dtData;
        public string SelectedCode { get; set; }
        public string SelectedName { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgdetails.CurrentRow == null) { return; }
            if (dgdetails.CurrentRow.DataBoundItem == null) { return; }
            DataRowView dv = (DataRowView)dgdetails.CurrentRow.DataBoundItem;
            if(dv!=null)
            {
                SelectedCode= dv.Row["Code"].ToString();
                SelectedName = dv.Row["Name"].ToString();
                this.DialogResult = DialogResult.OK;
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectedCode = "";
            SelectedName = "";
            this.DialogResult = DialogResult.Cancel;
        }

        private void dgdetails_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnOK_Click(sender, e);
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            dtData.DefaultView.RowFilter = "Code like '%" + txtsearch.Text + "%' || Name like '%" + txtsearch.Text + "%'";
            //fnBindGrid();
        }

        public SimpleSearchView(DataTable _dtData,string sCaption, string _sDisplayMember,string _sValueMember)
        {
            InitializeComponent();
            dtData = _dtData;
            this.Text = sCaption;
            this.lblCap.Text = sCaption;
            sDisplayMember = _sDisplayMember;
            sValueMember = _sValueMember;
            PopulateGrid();
        }
        private void PopulateGrid()
        {
            colCode.DataPropertyName = sValueMember;
            colName.DataPropertyName = sDisplayMember;
            fnBindGrid();
        }
        private void fnBindGrid()
        {
            dgdetails.AutoGenerateColumns = false;
            dgdetails.DataSource = dtData.DefaultView;
        }
    }
}
