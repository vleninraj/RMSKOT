using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
namespace RMSKOT
{
    public class Common
    {
        public static string UserName { get; set; }
        public static string UserID { get; set; }
        public static bool blnUnit { get; set; }
        public static bool blnUnitWiseRate { get; set; }
        public static bool blnFree { get; set; }
        public static string CompanyName { get; set; }
        public static string CompanyAddress { get; set; }
        public static string Email { get; set; }
        public static string EmailPassword { get; set; }
        public static string CurrencyCode { get; set; }
        public static string getCardTypeNameFromCode(string Code)
        {
            string sql = "SELECT Name FROM creditcards WHERE Code='" + Code + "'";
            object obj = DbHelper.ExecuteScalar(sql);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }
        public static string getDepoNameFromCode(string code)
        {
            string sql = "SELECT dname FROM depot WHERE dcode='" + code + "'";
            object obj = DbHelper.ExecuteScalar(sql);
            if(obj!=null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }
        public static string getLedgerName(string sledcode)
        {
            string sql = "SELECT ledname FROM accountledger where ledcode='" + sledcode + "'" ;
            return DbHelper.ExecuteScalar2(sql);
        }
        public static string getSalesTypeName(string scode)
        {
            string sql = "SELECT typename FROM tbltype where typeid='" + scode + "'";
            return DbHelper.ExecuteScalar2(sql);
        }
        public static decimal getStock(string pcode)
        {
            string sql = @"select SUM(IFNULL(purchase,0)+IFNULL(mr,0)+IFNULL(sr,0)+IFNULL(ireceipt,0)+IFNULL(ex,0)+IFNULL(bmr,0))-SUM(IFNULL(sales,0)+IFNULL(dn,0)+IFNULL(pr,0)+IFNULL(iissue,0)+IFNULL(sh,0)+IFNULL(dmg,0)+IFNULL(bmi,0)) AS stock ";
            sql += " from inventory where pcode='" + pcode + "'";
            object obj= DbHelper.ExecuteScalar(sql);
            if(obj!=null)
            {
                return obj.ToString().ToDecimal();
            }
            else
            {
                return 0;
            }
        }
        public static string getEmpNameFromCode(string code)
        {
            string sql = "Select EmpName FROM employee where empid='" + code + "'";
            object obj = DbHelper.ExecuteScalar(sql);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }
        public static void LoadSettings()
        {
            blnUnit = false;
            blnUnitWiseRate = false;
            blnFree = false;
            string sql = @" SELECT ParamName, ParamType, ParamValue FROM paramlist ";
            DataTable dtParamList = DbHelper.FillData(sql);
            if(dtParamList.Rows.Count>0)
            {
                DataRow drowUnit= dtParamList.AsEnumerable().Where(x => x["ParamName"].ToString() == "UseUnits").SingleOrDefault();
                if(drowUnit!=null)
                {
                    blnUnit = drowUnit["ParamValue"].ToString() == "1" ? true : false;
                }
                DataRow drowUnitWiseRate= dtParamList.AsEnumerable().Where(x => x["ParamName"].ToString() == "blnunitwise").SingleOrDefault();
                if (drowUnitWiseRate != null)
                {
                    blnUnitWiseRate = drowUnitWiseRate["ParamValue"].ToString() == "1" ? true : false;
                }
                DataRow drowFree= dtParamList.AsEnumerable().Where(x => x["ParamName"].ToString() == "blnFree"
                && x["ParamType"].ToString()=="0"
                ).SingleOrDefault();
                if (drowUnitWiseRate != null)
                {
                    blnFree = drowFree["ParamValue"].ToString() == "1" ? true : false;
                }
            }
            sql = "SELECT CompName,Address,CurrencyCode,Email,EmailPwd FROM company";
            DataTable dtCompany = new DataTable();
            dtCompany = DbHelper.FillData(sql);
            if(dtCompany.Rows.Count>0)
            {
                CompanyName = dtCompany.Rows[0]["CompName"].ToString();
                CompanyAddress = dtCompany.Rows[0]["Address"].ToString();
                CurrencyCode = dtCompany.Rows[0]["CurrencyCode"].ToString();
                Email = dtCompany.Rows[0]["Email"].ToString();
                EmailPassword = dtCompany.Rows[0]["EmailPwd"].ToString();
            }
        }
        public static string getFormattedValue(string Format, decimal _value)
        {
            string _FormattedValue;
            int NumberOfDecimals;
            decimal RoundedValue;
            if (Format != null && Format != "" && Format.Length > 1)
            {
                NumberOfDecimals = Format.Substring(1).ToInt32();
                if (NumberOfDecimals > 0)
                {
                    RoundedValue = Math.Round(_value, NumberOfDecimals);
                    _FormattedValue = RoundedValue.ToString(Format);
                }
                else
                {
                    _FormattedValue = _value.ToString(Format);
                }
            }
            else
            {
                _FormattedValue = _value.ToString();
            }
            return _FormattedValue;
        }
        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            using (Bitmap bmp = new Bitmap(imageIn))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    return ms.ToArray();
                }
            }
        }
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null) { return null; }
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public static void AddToAuditLog(MySqlTransaction Tr, DateTime dtDate, string sUserID, string sComputerName, string Action, string MFormName, string sDescription)
        {
            try
            {
                string sql = " Insert into auditlog (mdate,Userid,Computername,ActionType,MFormName,Description) ";
                sql = sql + " values('" + dtDate.ToString("yyyyMMddHHmmss") + "','" + sUserID + "','" + sComputerName + "','" + Action + "','" + MFormName + "','" + sDescription + "')";
                DbHelper.ExecuteNonQuery(sql, Tr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static decimal getAccountBalance(string sledcode)
        {
            string sql = "SELECT SUM(IFNULL(DbAmt,0)-IFNULL(CrAmt,0)) AS balance FROM generalledger WHERE ledcode='" + sledcode + "'";
            return DbHelper.ExecuteScalar2(sql).ToDecimal();
        }
        public static string GetAllGroupsUnder(int intHcode)
        {
            try
            {
                DataTable Dt = new DataTable();
                string grpCOde = "";
                string sql = "Select Headcode from AccountHead where underhead = " + intHcode;

                Dt = DbHelper.FillData(sql);
                foreach (DataRow r in Dt.Rows)
                {
                    grpCOde = grpCOde + r[0].ToString() + ",";
                    string strTemp = GetAllGroupsUnder(Convert.ToInt32(r["Headcode"].ToString()));
                    if (strTemp.Trim().Length > 0)
                        grpCOde += strTemp + ",";
                }


                if (grpCOde.Length > 0)
                    grpCOde = grpCOde.Substring(0, grpCOde.Length - 1);
                return grpCOde;

            }
            catch 
            {
                return "";
            }
        }

        public static string GetAllLedgersUnder(int intHcode)
        {
            try
            {
                DataTable ds = new DataTable();
                string sLcode = "";
                string sql = "Select LedCode From AccountLedger Where HeadCode=" + intHcode;
                ds = DbHelper.FillData(sql);
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    sLcode = sLcode + "'" + ds.Rows[i]["LedCode"].ToString() + "',";
                }
                ds.Clear();
                sql = "Select Headcode from AccountHead where underhead = " + intHcode;
                ds = DbHelper.FillData(sql);
                string sLedgers = "";
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    string strTemp = GetAllLedgersUnder(Convert.ToInt32(ds.Rows[i]["Headcode"].ToString()));
                    if (strTemp.Trim().Length > 0)
                        sLedgers = sLedgers + strTemp + ",";
                }

                if (sLedgers.Trim() == ",")
                    sLedgers = "";
                if (sLcode.Length > 0)
                    sLcode = sLcode.Substring(0, sLcode.Length - 1);
                return sLedgers + sLcode;

            }
            catch 
            {
                return "";
            }
        }

    }
}
