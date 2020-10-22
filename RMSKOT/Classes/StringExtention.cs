using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMSKOT
{
  public static  class StringExtention
    {
      public static bool toBool(this Boolean? obj)
      {
          try
          {
              return Convert.ToBoolean(obj);
          }
          catch (Exception)
          {
              return false;
          }
      }
      public static bool ToBool(this String obj)
      {
          try
          {
              return Convert.ToBoolean(obj);
          }
          catch (Exception)
          {
              return false;
          }
      }
        public static bool isNumeric(this Object Expression)
        {
            double retNum;
            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        public static Int32 ToInt32(this String obj)
      {
          try
          {
              return Convert.ToInt32(obj);
          }
          catch(Exception)
          {
              return 0;
          }
      }
      public static Int16 ToInt16(this String obj)
      {
          try
          {
              return Convert.ToInt16(obj);
          }
          catch (Exception)
          {
              return 0;
          }
      }
      public static Decimal ToDecimal(this String obj)
      {
          try
          {
              return Convert.ToDecimal(obj);
          }
          catch (Exception)
          {
              return 0;
          }
      }
      public static Double ToDouble(this String obj)
      {
          try
          {
              return Convert.ToDouble(obj);
          }
          catch (Exception)
          {
              return 0;
          }
      }
        public static DateTime ToDateTime(this String obj)
        {
            try
            {
                return Convert.ToDateTime(obj);
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }
    }
    
}
