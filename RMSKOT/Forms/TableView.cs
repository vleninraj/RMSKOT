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
    public partial class TableView : Form
    {
        DataTable dtTables;
        public TableView()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
        private void populateFloors()
        {

        }
        private void PopulateTables(string sFloor)
        {
            string sql = "SELECT tblid,tbl_name,Floor,opnstatus,NoOfChair FROM table_master where floor='" + sFloor + "'  order by tblid asc ";
            dtTables = new DataTable();
            dtTables = DbHelper.FillData(sql);
            pnltables.Controls.Clear();
            foreach (DataRow drow in dtTables.Rows)
            {
                AddTable(drow);
            }
        }
        private void AddTable(DataRow row)
        {
            atGradientPanel btnItem = new atGradientPanel();
            btnItem.BackColor = Color.FromArgb(0, 122, 204);
            btnItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnItem.ForeColor = Color.White;
            btnItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btnItem.Font = new Font("Open Sans", 12, FontStyle.Bold);
            btnItem.Cursor = System.Windows.Forms.Cursors.Hand;
            btnItem.Name = "btn_" + row["tbl_name"].ToString();
            btnItem.Size = new System.Drawing.Size(250, 80);
            btnItem.Text = row["tbl_name"].ToString();
            btnItem.Tag = row;
            btnItem.Click += (sndd, eee) =>
            {
                string sSalesType = getSalesType();
                if (sSalesType.Trim() == "") { return; }
                
            };
            pnltables.Controls.Add(btnItem);
        }
        private string getSalesType()
        {
            if (Common.usrDefaultSalesType == "")
            {
                DataTable dt = new DataTable();
                DataColumn colCode = new DataColumn("Code", Type.GetType("System.String"));
                DataColumn colName = new DataColumn("Name", Type.GetType("System.String"));
                dt.Columns.Add(colCode); dt.Columns.Add(colName);
                DataRow drow = dt.NewRow();
                drow["Code"] = "1"; drow["Name"] = "Dine in"; dt.Rows.Add(drow);
                drow = dt.NewRow();
                drow["Code"] = "2"; drow["Name"] = "Take away"; dt.Rows.Add(drow);
                drow = dt.NewRow();
                drow["Code"] = "3"; drow["Name"] = "Delivery"; dt.Rows.Add(drow);
                SimpleSearchView frm = new SimpleSearchView(dt, "Sales Type", "Name", "Code");
                if(frm.ShowDialog()==DialogResult.OK)
                {
                    return frm.SelectedCode;
                }
                else
                {
                    return "";
                }

            }
            else
            {
                return Common.usrDefaultSalesType;
            }
        }
        private void btnFloor_Click(object sender, EventArgs e)
        {
            string sql = "Select `FloorCode`  as Code ,`FloorName`  as Name FROM `tblfloor` ";
            DataTable dt = new DataTable();
            dt = DbHelper.FillData(sql);
            SimpleSearchView frm = new SimpleSearchView(dt, "Floor","Name","Code");
            if(frm.ShowDialog()==DialogResult.OK)
            {
                btnFloor.Text = frm.SelectedName;
                btnFloor.Tag = frm.SelectedCode;
                PopulateTables(frm.SelectedCode);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
