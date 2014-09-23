using System;
using System.ComponentModel;
using System.Globalization;
using TechTalk.SpecFlow;

namespace OneCog.Testing.SpecFlow
{
    public static class Extensions
    {
        public static T Read<T>(this TableRow row, string column)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            string value;

            if (row.TryGetValue(column, out value))
            {
                return (T)converter.ConvertFromString(null, CultureInfo.InvariantCulture, value);
            }
            else
            {
                throw new ArgumentException(string.Format("A column named '{0}' does not exist in the table", column), "column");
            }
        }

        public static T ReadOrDefault<T>(this TableRow row, string column)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            string value;

            if (row.TryGetValue(column, out value))
            {
                return (T)converter.ConvertFromString(null, CultureInfo.InvariantCulture, value);
            }
            else
            {
                return default(T);
            }
        }

        public static T ReadEnum<T>(this TableRow row, string column) where T : struct
        {
            string value;
            T result;

            if (row.TryGetValue(column, out value))
            {
                if (Enum.TryParse<T>(value, out result))
                {
                    return result;
                }
                else
                {
                    throw new InvalidOperationException(string.Format("'{0}' is not a valid value for the enumeration '{1}", value, typeof(T).Name));
                }
            }
            else
            {
                throw new ArgumentException(string.Format("A column named '{0}' does not exist in the table", column), "column");
            }            
        }
    }
}
