using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
namespace RMSKOT
{
    public class DbHelper
    {
        public static string sConnectionstring { get; set; }
        public static int ExecuteNonQuery(string Sql)
        { 
           using (MySqlConnection conn = new MySqlConnection(sConnectionstring))
           {
               conn.Open();
                try
                {
                    MySqlCommand Cmd = new MySqlCommand(Sql, conn);
                    Cmd.CommandTimeout = 0;
                    return Cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
           }
        }
        public static int ExecuteNonQuery(string Sql, MySqlTransaction Tr)
        {
            try
            {
                MySqlCommand Cmd = new MySqlCommand(Sql, Tr.Connection, Tr);
                Cmd.CommandTimeout = 0;
                return Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static MySqlDataReader ExecuteReader(string Sql)
        {
            using (MySqlConnection conn = new MySqlConnection(sConnectionstring))
            {
                conn.Open();
                try
                {
                    MySqlCommand Cmd = new MySqlCommand(Sql, conn);
                    Cmd.CommandTimeout = 0;
                    return Cmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public static MySqlDataReader ExecuteReader(string Sql, MySqlTransaction Tr)
        {
            try
            {
                MySqlCommand Cmd = new MySqlCommand(Sql, Tr.Connection, Tr);
                Cmd.CommandTimeout = 0;
                return Cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string ExecuteScalar2(string Sql)
        {
            object obj = ExecuteScalar(Sql);
            if(obj!=null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }
        public static object ExecuteScalar(string Sql)
        {
            using (MySqlConnection conn = new MySqlConnection(sConnectionstring))
            {
                conn.Open();
                try
                {
                    MySqlCommand Cmd = new MySqlCommand(Sql, conn);
                    Cmd.CommandTimeout = 0;
                    return Cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public static object ExecuteScalar(string Sql, MySqlTransaction Tr)
        {
            try
            {
                MySqlCommand Cmd = new MySqlCommand(Sql, Tr.Connection, Tr);
                Cmd.CommandTimeout = 0;
                return Cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable FillData(string Sql)
        {
            using (MySqlConnection conn = new MySqlConnection(sConnectionstring))
            {
                conn.Open();
                try
                {
                    DataTable dtRet = new DataTable();
                    MySqlCommand Cmd = new MySqlCommand(Sql, conn);
                    Cmd.CommandTimeout = 0;
                    MySqlDataAdapter dad = new MySqlDataAdapter(Cmd);
                    dad.Fill(dtRet);
                    return dtRet;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public static DataTable FillData(string Sql, MySqlTransaction Tr)
        {
            try
            {
                DataTable dtRet = new DataTable();
                MySqlCommand Cmd = new MySqlCommand(Sql, Tr.Connection, Tr);
                Cmd.CommandTimeout = 0;
                MySqlDataAdapter dad = new MySqlDataAdapter(Cmd);
                dad.Fill(dtRet);
                return dtRet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int ExecuteNonQueryWithReturn(string Sql, MySqlTransaction Tr)
        {
            try
            {
                MySqlCommand Cmd = new MySqlCommand(Sql, Tr.Connection, Tr);
                return Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
