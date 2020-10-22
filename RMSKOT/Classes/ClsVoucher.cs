using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace RMSKOT
{
    public enum VoucherType
    {
        CashRecipt = 1,
        DesignCode = 2,
        WorkshopEnquery = 3,
        AccoundLedger = 4,
        Debitors = 5,
        Project = 6,
        CashPayments = 7,
        PurchaceOrder = 8,
        Purchase = 9,
        EmployeeCode = 10,
        PurchaseReturn = 11,
        JournalEntry = 12,
        DeliveryNote = 13,
        IssueNote = 14,
        ReceivedReport = 15,
        ReceivedReportHeadOffice = 16,
        Excess = 17,
        Shoratge = 18,
        PurchaceOrderGlass = 19,
        SalesReturn = 20,
        SalesReturnGlass = 21,
        SalesReturnRukam = 22,
        SalesInvoice = 23,
        DebitNote = 24,
        CreditNote = 25,
        SalesOrder=26,
             BankReceipt = 27
        //ProductionRecipt = 3
    }
    public class ClsVoucher
    {
        private DaVouchers _DaVoucher;
        public ClsVoucher()
        {
            _DaVoucher = new DaVouchers();
        }
        /// <summary>
        /// Get the Next Code    ||
        /// Ex: for 123 next is 124   ||
        ///  for abc12   next is abc13
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public string GetNexCode(string Code)
        {
            if (Char.IsLetter(Code, Code.Length - 1))
            {
                return (Code + "1");
            }
            else
            {
                int i;
                for (i = Code.Length - 1; i >= 0; i--)
                {
                    if (Char.IsLetter(Code, i))
                    {
                        break;
                    }
                }

                string tmp = Code.Substring(0, i + 1) + (int.Parse(Code.Substring(i + 1)) + 1);
                return tmp;
            }
        }
        ///// <summary>
        ///// Get the Last Voucher saved for the pericular Type
        ///// </summary>
        ///// <param name="Type"></param>
        ///// <returns></returns>
        //public string GetLastVoucherNo(VoucherType Type)
        //{
        //    return (_DaVoucher.GetLastVoucher(Type));
        //}
        /// <summary>
        ///If Next voucher is exsit then get next voucher
        ///else return the same voucher
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        public string GetNextVoucherNo(string Voucher, VoucherType Type)
        {
            return (_DaVoucher.GetNextVoucher(Voucher, Type));
        }
        public string GetNextVoucherNo(string Voucher, VoucherType Type,MySqlTransaction Tr)
        {
            return (_DaVoucher.GetNextVoucher(Voucher, Type, Tr));
        }
        /// <summary>
        ///If Next voucher is exsit then get next voucher
        ///else return the same voucher
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        public string GetNextVoucherNo(VoucherType Type)
        {
            return (_DaVoucher.GetNextVoucher(_DaVoucher.GetLastVoucher(Type), Type));
        }
        public string GetNextVoucherNo(VoucherType Type, MySqlTransaction Tr)
        {
            return (_DaVoucher.GetNextVoucher(_DaVoucher.GetLastVoucher(Type), Type));
        }
        /// <summary>
        /// Save the Last Vouchet to the Datatbase
        /// </summary>
        /// <param name="LastNo"></param>
        /// <param name="Type"></param>
        /// <param name="Tr"></param>
        /// <returns></returns>
        public bool SaveLastVoucherNo(string LastNo, VoucherType Type, MySqlTransaction Tr)
        {
            return (_DaVoucher.SaveLastVoucher(LastNo, Type, Tr));
        }
        //public string GetNextVoucherNo(VoucherType Type,MySqlConnection Conn,MySqlTransaction Tr )
        //{
        //    return (GetNexCode(Daother.GetLastVoucher(Type ,Conn  , Tr)));
        //}
        /// <summary>
        /// Get All prevoius Vouchers of a pericular Voucher Type
        ///  Including  the Next Voucher Number
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        public List<string> LoadVoucher(VoucherType Type)
        {
            return (_DaVoucher.LoadVoucher(Type));
        }
        /// <summary>
        /// Return DataTable with fields 'VNO'
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="SearchCondion"></param>
        /// <returns></returns>
        //public DataTable LoadVoucherCombo(VoucherType Type, string SearchCondion)
        //{
        //    return (_DaVoucher.LoadVoucherCombo(Type, SearchCondion));    
        //}

    }



    public class DaVouchers
    {

        private MySqlConnection _Con;
        // private DaAccountsHeaders _DaHeader;
        public DaVouchers()
        {
            _Con = new MySqlConnection(DbHelper.sConnectionstring);
            if (_Con.State == ConnectionState.Closed)
            {
                _Con.Open();
            }
        }
        //~DaVouchers()
        //{
        //    try
        //    {
        //        _Con.Close();
        //    }
        //    catch
        //    {
        //    }
        //}

        public string GetLastVoucher(VoucherType Type)
        {
            try
            {
                string strsql = "";
                switch (Type)
                {
                    case VoucherType.CashRecipt:
                        strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'CR')";
                        break;
                    case VoucherType.BankReceipt:
                        strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'BR')";
                        break;
                    case VoucherType.CashPayments:
                        strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'CP')";
                        break;

                    case VoucherType.DesignCode:
                        strsql = "SELECT ParamValue FROM  workshop_paramlist WHERE     (ParamName = 'DCode')";
                        break;
                    case VoucherType.WorkshopEnquery:
                        strsql = "SELECT ParamValue FROM  workshop_paramlist WHERE     (ParamName = 'EnqCode')";
                        break;
                    case VoucherType.AccoundLedger:
                    case VoucherType.Debitors:
                        strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'LedCode')";
                        break;
                    case VoucherType.Project:
                        strsql = "SELECT ParamValue FROM  workshop_paramlist WHERE  (ParamName = 'ProjectNO')";
                        break;
                    case VoucherType.PurchaceOrder:
                        strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'PO')";
                        break;
                    case VoucherType.Purchase:
                        strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'PI')";
                        break;
                    case VoucherType.SalesReturn:
                        strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'SR')";
                        break;
                    case VoucherType.SalesReturnGlass:
                        strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'GSR')";
                        break;
                    case VoucherType.SalesReturnRukam:
                        strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'RSR')";
                        break;
                    case VoucherType.EmployeeCode:
                        strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'EmpID')";
                        break;
                    case VoucherType.PurchaseReturn:
                        strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'PR')";
                        break;
                    case VoucherType.JournalEntry:
                        strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'JE')";
                        break;
                    case VoucherType.DeliveryNote:
                        strsql = "SELECT DVVno  FROM `deliverymaster` ORDER BY CAST(DVID AS SIGNED) DESC LIMIT 1";
                        break;
                    case VoucherType.IssueNote:
                        strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'IssNote')";
                        break;
                    case VoucherType.ReceivedReport:
                        strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'RcvRpt')";
                        break;
                    case VoucherType.ReceivedReportHeadOffice:
                        strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'RcvRpt')";
                        break;
                    case VoucherType.Excess:
                        strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'EX')";
                        break;
                    case VoucherType.Shoratge:
                        strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'SH')";
                        break;
                   
                    case VoucherType.SalesInvoice:
                        if (Properties.Settings.Default.SalesType != "")
                        {
                            string sTypeCrit = "SI T" + Properties.Settings.Default.SalesType;
                            strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = '" + sTypeCrit + "')";
                        }
                        else
                        {
                            strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'SI')";
                        }
                        break;
                    case VoucherType.SalesOrder:
                        strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'SO')";
                        break;
                }
                MySqlCommand Cmd = new MySqlCommand(strsql, _Con);
                string tmp = Cmd.ExecuteScalar() == null ? "1" : Cmd.ExecuteScalar().ToString();
                return tmp;
            }
            catch (MySqlException Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
                return "0";
            }
        }

        //public string GetLastVoucher(VoucherType Type,MySqlConnection Conn,MySqlTransaction Tr )
        //{

        //    try
        //    {
        //        string strsql = "";
        //        switch (Type)
        //        {
        //            case VoucherType.CashRecipt:
        //                strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'CR')";
        //                break;
        //            case VoucherType.DesignCode:
        //                strsql = "SELECT ParamValue FROM  workshop_paramlist WHERE     (ParamName = 'DCode')";
        //                break;

        //        }                
        //        MySqlCommand Cmd = new MySqlCommand(strsql, Conn,Tr);
        //        string tmp = Cmd.ExecuteScalar().ToString() == "" ? "0" : Cmd.ExecuteScalar().ToString();                
        //        return tmp;
        //    }
        //    catch (MySqlException Ex)
        //    {
        //        //Db.ForceClose();
        //        System.Windows.Forms.MessageBox.Show(Ex.Message);
        //        return "0";
        //    }
        //}
        public bool SaveLastVoucher(string LastNo, VoucherType Type, MySqlTransaction Tr)
        {

            try
            {
                string strsql = "";
                switch (Type)
                {
                    case VoucherType.CashRecipt:
                        strsql = "UPDATE ParamList SET ParamValue = @ParamValue WHERE (ParamList.ParamName = 'CR')";
                        break;
                    case VoucherType.BankReceipt:
                        strsql = "SELECT ParamValue FROM  ParamList WHERE     (ParamName = 'BR')";
                        break;
                    case VoucherType.CashPayments:
                        strsql = "UPDATE ParamList SET ParamValue = @ParamValue WHERE (ParamList.ParamName = 'CP')";
                        break;
                    case VoucherType.DesignCode:
                        strsql = "UPDATE  workshop_paramlist SET ParamValue = @ParamValue  WHERE (ParamName = 'DCode')";
                        break;
                    case VoucherType.WorkshopEnquery:
                        strsql = "UPDATE  workshop_paramlist SET ParamValue = @ParamValue  WHERE (ParamName = 'EnqCode')";
                        break;
                    case VoucherType.AccoundLedger:
                    case VoucherType.Debitors:
                        strsql = "UPDATE  ParamList SET ParamValue = @ParamValue  WHERE (ParamName = 'LedCode')";
                        break;
                    case VoucherType.Project:
                        strsql = "UPDATE  workshop_paramlist SET ParamValue = @ParamValue  WHERE (ParamName = 'ProjectNO')";
                        break;
                    case VoucherType.PurchaceOrder:
                        strsql = "UPDATE ParamList SET ParamValue = @ParamValue WHERE (ParamList.ParamName = 'PO')";
                        break;
                    case VoucherType.Purchase:
                        strsql = "UPDATE ParamList SET ParamValue = @ParamValue WHERE (ParamList.ParamName = 'PI')";
                        break;
                    case VoucherType.SalesReturn:
                        strsql = "UPDATE ParamList SET ParamValue = @ParamValue WHERE (ParamList.ParamName = 'SR')";
                        break;
                    case VoucherType.SalesReturnGlass:
                        strsql = "UPDATE ParamList SET ParamValue = @ParamValue WHERE (ParamList.ParamName = 'GSR')";
                        break;
                    case VoucherType.SalesReturnRukam:
                        strsql = "UPDATE ParamList SET ParamValue = @ParamValue WHERE (ParamList.ParamName = 'RSR')";
                        break;
                    case VoucherType.PurchaseReturn:
                        strsql = "UPDATE ParamList SET ParamValue = @ParamValue WHERE (ParamList.ParamName = 'PR')";
                        break;
                    case VoucherType.EmployeeCode:
                        strsql = "UPDATE ParamList SET ParamValue = @ParamValue WHERE     (ParamName = 'EmpID')";
                        break;
                    case VoucherType.JournalEntry:
                        strsql = "UPDATE ParamList SET ParamValue = @ParamValue WHERE (ParamList.ParamName = 'JE')";
                        break;
                    case VoucherType.IssueNote:
                        strsql = "UPDATE ParamList SET ParamValue = @ParamValue WHERE (ParamList.ParamName = 'IssNote')";
                        break;
                    case VoucherType.ReceivedReport:
                        strsql = "UPDATE ParamList SET ParamValue = @ParamValue WHERE (ParamList.ParamName = 'RcvRpt')";
                        break;
                    case VoucherType.ReceivedReportHeadOffice:
                        strsql = "UPDATE ParamList SET ParamValue = @ParamValue WHERE (ParamList.ParamName = 'RcvRpt')";
                        break;


                    case VoucherType.Excess:
                        strsql = "UPDATE ParamList SET ParamValue = @ParamValue WHERE (ParamList.ParamName = 'EX')";
                        break;
                    case VoucherType.Shoratge:
                        strsql = "UPDATE ParamList SET ParamValue = @ParamValue WHERE (ParamList.ParamName = 'SH')";
                        break;

                    case VoucherType.SalesInvoice :
                        strsql = "UPDATE ParamList SET ParamValue = @ParamValue WHERE (ParamList.ParamName = 'SI')";
                        break;
                }
                MySqlCommand Cmd = new MySqlCommand(strsql, Tr.Connection, Tr);
                Cmd.Parameters.AddWithValue("@ParamValue", LastNo);
                Cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException Ex)
            {
                //Db.ForceClose();
                System.Windows.Forms.MessageBox.Show(Ex.Message);
                return false;

            }
        }

        private string GetSQLNew(string VNO, VoucherType Type)
        {
            string strsql = "";
            switch (Type)
            {
                case VoucherType.CashRecipt:
                    strsql = "SELECT     COUNT(*) FROM   GeneralLedger WHERE  (VNo = '" + VNO + "') AND (VType = 'CR')";
                    break;
                case VoucherType.BankReceipt:
                    strsql = "SELECT     COUNT(*) FROM   GeneralLedger WHERE  (VNo = '" + VNO + "') AND (VType = 'BR')";
                    break;
                case VoucherType.CashPayments:
                    strsql = "SELECT     COUNT(*) FROM   GeneralLedger WHERE  (VNo = '" + VNO + "') AND (VType = 'CP')";
                    break;
                case VoucherType.DesignCode:
                    strsql = "SELECT COUNT(*)  FROM  workshop_equation_master WHERE (Dcode= '" + VNO + "')";
                    break;
                case VoucherType.WorkshopEnquery:
                    strsql = "SELECT COUNT(*) FROM  workshop_enq_master WHERE (EnqNo= '" + VNO + "')";
                    break;
                case VoucherType.AccoundLedger:
                case VoucherType.Debitors:
                    strsql = "SELECT COUNT(*) FROM  accountledger WHERE (LedCode= '" + VNO + "')";
                    break;
                case VoucherType.Project:
                    strsql = "SELECT COUNT(*) FROM  workshop_work_master   WHERE (WorkNo = '" + VNO + "')";
                    break;
                case VoucherType.PurchaceOrder:
                    strsql = "SELECT COUNT(*) FROM  ordermaster   WHERE (OrderNo = '" + VNO + "')";
                    break;
                case VoucherType.Purchase:
                    strsql = "SELECT COUNT(*) FROM  transactionreceipts   WHERE (VNo = '" + VNO + "' AND rcptType ='PI')";
                    break;
                case VoucherType.SalesReturn:
                    strsql = "SELECT COUNT(*) FROM  transactionreceipts   WHERE (VNo = '" + VNO + "' AND rcptType ='SR')";
                    break;
                case VoucherType.SalesReturnGlass:
                case VoucherType.SalesReturnRukam:
                    strsql = "SELECT COUNT(*) FROM  transactionreceipts   WHERE (VNo = '" + VNO + "' AND rcptType ='SR')";
                    break;

                case VoucherType.PurchaseReturn:
                    strsql = "SELECT COUNT(*) FROM  businessissue   WHERE (VNo = '" + VNO + "' AND issueType ='PR')";
                    break;
                case VoucherType.EmployeeCode:
                    strsql = "SELECT COUNT(*) FROM  employee   WHERE (EmpId = '" + VNO + "')";
                    break;
                case VoucherType.JournalEntry:
                    strsql = "SELECT     COUNT(*) FROM   GeneralLedger WHERE  (VNo = '" + VNO + "') AND (VType = 'JE')";
                    break;
                case VoucherType.DeliveryNote:
                    strsql = "SELECT   COUNT(*) FROM  `deliverymaster` WHERE  (DVVno = '" + VNO + "')";
                    break;
                case VoucherType.IssueNote:
                    strsql = "SELECT COUNT(*) FROM  deliverymaster_branch   WHERE (DeliveryKey = '" + VNO + "')";
                    break;
                case VoucherType.ReceivedReport:
                    strsql = "SELECT COUNT(*) FROM  Receivedmaster_branch   WHERE (ReceivedKey = '" + VNO + "')";
                    break;
                case VoucherType.ReceivedReportHeadOffice:
                    strsql = "SELECT COUNT(*) FROM  receivedmaster_headoffice   WHERE (ReceivedKey = '" + VNO + "')";
                    break;

                case VoucherType.Excess:
                    strsql = "SELECT COUNT(*) FROM  transactionreceipts   WHERE (VNo = '" + VNO + "' AND rcptType ='EX')";
                    break;
                case VoucherType.Shoratge:
                    strsql = "SELECT COUNT(*) FROM  businessissue   WHERE (VNo = '" + VNO + "' AND issueType ='SH')";
                    break;
                case VoucherType.SalesInvoice:
                    strsql = "SELECT COUNT(*) FROM  businessissue   WHERE (VNo = '" + VNO + "' AND issueType ='SI')";
                    break;
                case VoucherType.CreditNote:
                    strsql = "SELECT     COUNT(*) FROM   GeneralLedger WHERE  (VNo = '" + VNO + "') AND (VType = 'CN')";
                    break;
                case VoucherType.DebitNote:
                    strsql = "SELECT     COUNT(*) FROM   GeneralLedger WHERE  (VNo = '" + VNO + "') AND (VType = 'DR')";
                    break;
                case VoucherType.SalesOrder:
                    strsql = "SELECT COUNT(*) FROM  ordermaster   WHERE (OrderNo = '" + VNO + "' AND OrderType ='S')";
                    break;
            }

            return strsql;
        }
        //if Next voucher is exsit then get next voucher
        //else return the same voucher
        public string GetNextVoucher(string VNO, VoucherType Type)
        {
            try
            {
                if(VNO =="0")
                {
                    VNO = "1";
                }
                string strsql = GetSQLNew(VNO, Type);
                
                MySqlCommand Cmd = new MySqlCommand(strsql, _Con);
                if (int.Parse(Cmd.ExecuteScalar().ToString()) == 0)
                {
                    return VNO;
                }
                else
                {
                    return (GetNextVoucher(GetNexCode(VNO), Type));
                }
            }
            catch (MySqlException Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
                return "0";
            }
        }
        public string GetNextVoucher(string VNO, VoucherType Type,MySqlTransaction Tr)
        {
            try
            {
                if (VNO == "0")
                {
                    VNO = "1";
                }
                string strsql = GetSQLNew(VNO, Type);
                MySqlCommand Cmd = new MySqlCommand(strsql,Tr.Connection,Tr);
                if (int.Parse(Cmd.ExecuteScalar().ToString()) == 0)
                {
                    return VNO;
                }
                else
                {
                    return (GetNextVoucher(GetNexCode(VNO), Type,Tr ));
                }
            }
            catch (MySqlException Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
                return "0";
            }
        }

        public string GetNexCode(string Code)
        {
            if (Char.IsLetter(Code, Code.Length - 1))
            {
                return (Code + "1");
            }
            else
            {
                int i;
                for (i = Code.Length - 1; i >= 0; i--)
                {
                    if (Char.IsLetter(Code, i))
                    {
                        break;
                    }
                }

                string tmp = Code.Substring(0, i + 1) + (int.Parse(Code.Substring(i + 1)) + 1);
                return tmp;
            }
        }

        public List<string> LoadVoucher(VoucherType Type)
        {
            try
            {
                string strsql = "";
                switch (Type)
                {
                    case VoucherType.CashRecipt:
                        strsql = "SELECT  DISTINCT VNO  FROM   GeneralLedger WHERE  (VType = 'CR') ORDER BY CAST( VNO AS UNSIGNED) ";
                        break;
                    case VoucherType.CashPayments:
                        strsql = "SELECT  DISTINCT VNO  FROM   GeneralLedger WHERE  (VType = 'CP') ORDER BY CAST( VNO AS UNSIGNED) ";
                        break;
                    case VoucherType.DesignCode:
                        strsql = "SELECT Dcode FROM  workshop_equation_master ORDER BY Dcode";
                        break;
                    case VoucherType.WorkshopEnquery:
                        strsql = "SELECT EnqNo FROM  workshop_enq_master ORDER BY EnqDate , EnqNo";
                        break;
                    case VoucherType.AccoundLedger:
                        strsql = "SELECT UCASE(LedCode) FROM  accountledger ORDER BY CAST( LedCode AS UNSIGNED)";
                        break;
                    case VoucherType.Debitors:
                        //DaAccountsHeaders _DaHeader = new DaAccountsHeaders(_Con.ConnectionString);
                        //string Ledg = _DaHeader.GetAllHeadersUnder("9"); //All creditors
                        //strsql = "SELECT UCASE(LedCode) FROM  accountledger where HeadCode in (" + Ledg + ")  ORDER BY CAST( LedCode AS UNSIGNED)";
                        //break;
                    case VoucherType.Project:
                        strsql = "SELECT WorkNo FROM  workshop_work_master ORDER BY WorkDate , WorkNo";
                        break;
                    case VoucherType.PurchaceOrder:
                        // strsql = "SELECT OrderNo FROM  ordermaster  ORDER BY CAST(OrderNo as UNSIGNED) ";   //OrderKey "; //OrderDate ,OrderNo";
                        strsql = "SELECT DISTINCT ordermaster.OrderNo FROM orderdetails INNER JOIN  ordermaster ON orderdetails.OrderKey = ordermaster.OrderKey INNER JOIN " +
                                 " product ON orderdetails.PCode = product.PCode WHERE (product.IsGlass = 0) ORDER BY CAST(OrderNo as UNSIGNED) ";
                        break;
                    case VoucherType.PurchaceOrderGlass:
                        //  strsql = "SELECT OrderNo FROM  ordermaster  ORDER BY CAST(OrderNo as UNSIGNED) ";   //OrderKey "; //OrderDate ,OrderNo";
                        strsql = "SELECT DISTINCT ordermaster.OrderNo FROM orderdetails INNER JOIN  ordermaster ON orderdetails.OrderKey = ordermaster.OrderKey INNER JOIN " +
                                " product ON orderdetails.PCode = product.PCode WHERE (product.IsGlass = 1) ORDER BY CAST(OrderNo as UNSIGNED) ";
                        break;
                    case VoucherType.Purchase:
                        strsql = "SELECT VNo FROM  transactionreceipts  WHERE  rcptType ='PI' ORDER BY RcptDate, CAST(VNo AS UNSIGNED)";
                        break;
                    case VoucherType.SalesReturn:
                        strsql = "SELECT VNo FROM  transactionreceipts  WHERE  rcptType ='SR' AND BillType != 'GS' ORDER BY RcptDate, CAST(VNo AS UNSIGNED)";
                        break;
                    case VoucherType.SalesReturnGlass:
                    case VoucherType.SalesReturnRukam:
                        strsql = "SELECT VNo FROM  transactionreceipts  WHERE  rcptType ='SR' AND BillType = 'GS' ORDER BY RcptDate, CAST(VNo AS UNSIGNED)";
                        break;
                    case VoucherType.PurchaseReturn:
                        strsql = "SELECT  VNo FROM   businessissue   WHERE  issueType ='PR' ORDER BY IssueDate, CAST(VNo AS UNSIGNED)  ";
                        break;
                    case VoucherType.EmployeeCode:
                        strsql = "SELECT EmpId FROM  employee   ORDER BY CAST( EmpId AS UNSIGNED) ";
                        break;
                    case VoucherType.JournalEntry:
                        strsql = "SELECT  DISTINCT VNO  FROM   GeneralLedger WHERE  (VType = 'JE') ORDER BY CAST( VNO AS UNSIGNED) ";
                        break;
                    case VoucherType.DeliveryNote:
                        strsql = "SELECT DVVno  FROM `deliverymaster` ORDER BY CAST(DVVno AS SIGNED)";
                        break;
                    case VoucherType.IssueNote:
                        strsql = "SELECT DeliveryKey FROM  deliverymaster_branch  ORDER BY DeliveryDate , CAST( DeliveryKey AS UNSIGNED) ";
                        break;
                    case VoucherType.ReceivedReport:
                        strsql = "SELECT ReceivedKey FROM  Receivedmaster_branch  ORDER BY ReceivedKey , CAST( ReceivedKey AS UNSIGNED) ";
                        break;
                    case VoucherType.ReceivedReportHeadOffice:
                        strsql = "SELECT ReceivedKey FROM  receivedmaster_headoffice  ORDER BY ReceivedKey , CAST( ReceivedKey AS UNSIGNED) ";
                        break;

                    case VoucherType.Excess:
                        strsql = "SELECT VNo FROM  transactionreceipts  WHERE  rcptType ='EX' ORDER BY RcptDate, CAST(VNo AS UNSIGNED)";
                        break;
                    case VoucherType.Shoratge:
                        strsql = "SELECT  VNo FROM   businessissue   WHERE  issueType ='SH' ORDER BY IssueDate, CAST(VNo AS UNSIGNED)  ";
                        break;

                }
                MySqlCommand Cmd = new MySqlCommand(strsql, _Con);
                MySqlDataReader Dr = Cmd.ExecuteReader();
                List<string> ans = new List<string>();
                int i = 0;
                while (Dr.Read())
                {
                    ans.Add(Dr[0].ToString());
                    i++;
                }
                Dr.Close();
                return (ans);
            }
            catch (MySqlException Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
                return null;
            }
        }
    }

}
