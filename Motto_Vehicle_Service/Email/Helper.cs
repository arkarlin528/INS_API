using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Globalization;

namespace ZeroBug.Helper
{
    public class Period
    {
        public virtual DateTime StartDate   { get; set; }
        public virtual DateTime EndDate     { get; set; }

        public override string ToString()
        {
            if (StartDate.Year == EndDate.Year && StartDate.Month == EndDate.Month && StartDate.Day == EndDate.Day)
                return StartDate.ToString("dd MMM yyyy");
            else if (StartDate.Year == EndDate.Year && StartDate.Month == EndDate.Month)
                return string.Format("{0} - {1} {2} {3}", StartDate.Day, EndDate.Day, StartDate.ToString("MMM"), StartDate.ToString("yyyy"));
            else if (StartDate.Year == EndDate.Year)
                return string.Format("{0} {1} - {2} {3} {4}", StartDate.Day, StartDate.ToString("MMM"), EndDate.Day, EndDate.ToString("MMM"), StartDate.ToString("yyyy"));
            else
                return string.Format("{0} - {1}", StartDate.ToString("dd MMM yyyy"), EndDate.ToString("dd MMM yyyy"));
        }
    }

    public static class Utils
    {

        public static int ToWeek(this DateTime date)
        {
            return GetIso8601WeekOfYear(date);
        }

        private static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static System.Collections.Specialized.NameValueCollection AppSetting
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings;
            }
        }

        public static bool ToBool(this object str)
        {
            bool result = false;

            if (bool.TryParse(str.ToString(), out result))
                return result;

            return false;
        }

        public static short ToShort(this object str)
        {
            return Convert.ToInt16(str.ToString());
        }


        public static Char ToChar(this object str)
        {
            return Convert.ToChar(str.ToString());
        }


        public static Decimal ToDecimal(this object str)
        {
            if (str == null)
                return 0;

            if (string.IsNullOrEmpty(str.ToString()))
                return 0;

            return Convert.ToDecimal(str.ToString());
        }

        public static int ToInt(this object str)
        {
            if (str == null)
                return 0;

            if (string.IsNullOrEmpty(str.ToString()))
                return 0;
            try
            {
                return Convert.ToInt32(str.ToString());
            }
            catch(FormatException e)
            {
                return 0;
            }
        }


        public static long ToLong(this object str)
        {
            if (str == null)
                return 0;

            if (string.IsNullOrEmpty(str.ToString()))
                return 0;
            try
            {
                return long.Parse(str.ToString());
            }
            catch (FormatException e)
            {
                return 0;
            }
        }

        public static Guid ToGuid(this object obj)
        {
            string str = obj.ToString();
            int index = str.IndexOf(',') - 1;

            return index > 0 ? new Guid(str.Substring(0, str.IndexOf(','))) : new Guid(str);
        }


        public static string GetValue(this object val)
        {
            if (val == null)
                return string.Empty;

            return val.ToString();
        }

        public static Double ToDouble(this object str)
        {
            if (str == null)
                return 0;

            if (string.IsNullOrEmpty(str.ToString()))
                return 0;
            try
            {
                return Double.Parse(str.ToString());
            }
            catch (FormatException e)
            {
                return 0;
            }
        }

        public static DateTime ToDateTime(this object str)
        {
            return DateTime.Parse(str.ToString());
        }

        public static T ToEnum<T>(this object value)
        {
            return (T)Enum.Parse(typeof(T), value.ToString(), true);
        }
        

        public static bool IsDatetime(this object value, string type)
        {
            if (value == null)
                return false;

            if (string.IsNullOrEmpty(value.ToString()))
                return false;

            DateTime temp = DateTime.Today;

            if (value.ToString().Length < type.Length)
                return false;

            string val = value.ToString().Substring(0, type.Length);

            return DateTime.TryParseExact(val, 
                type, 
                System.Globalization.CultureInfo.InvariantCulture, 
                System.Globalization.DateTimeStyles.None, 
                out temp);
        }

        public static bool IsEmptyOrZero(this object value)
        {
            if (value == null)
                return true;

            if (string.IsNullOrEmpty(value.ToString()))
                return true;

            double x = 0;

            if(double.TryParse(value.ToString(), out x))
            {
                return x == 0;
            }

            return true;
        }
        public static bool IsEmpty(this object value)
        {
            if (value == null)
                return true;

            if (value.ToString() == "?")
                return true;

            return string.IsNullOrEmpty(value.ToString().Trim());
        }

        public static bool IsDouble(this object value)
        {
            if (value == null)
                return false;

            double result = 0;

            return Double.TryParse(value.ToString(), out result);
        }

        public static bool IsInt(this object value)
        {
            if (value == null)
                return false;

            int result = 0;

            return Int32.TryParse(value.ToString(), out result);
        }

        public static string CreateWhitespace(string str)
        {
            return string.Concat(str.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
        }

        private static object GetValue(object entity, string propName)
        {
            object val     = null;
            object data    = entity;
            string[] props = propName.Split('.');

            foreach (var prop in props)
            {
                if (data == null)
                    return string.Empty;

                var propInf = data.GetType().GetProperty(prop);
                if (propInf != null)
                {
                    val = propInf.GetValue(data, null);
                    data = val;
                }
            }

            return val;
        }

        public static string ToString(this object entity, string format)
        {
            Regex filter = new Regex(@"{([a-zA-Z][\w\d.]*)}");

            foreach (Match match in filter.Matches(format))
            {
                string matched = match.Value;
                string propName = match.Value.Substring(1, match.Value.Length - 2);

                object val = GetValue(entity, propName);
                if (val != null)
                {
                    format = format.Replace(matched, val.ToString());
                }
            }

            return format;
        }
    }
}
