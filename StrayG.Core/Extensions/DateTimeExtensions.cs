using System;

namespace StrayG.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToFinancialYear(this DateTime dateTime)
        {
            return "Financial Year " + (dateTime.Month >= 4 ? dateTime.Year + 1 : dateTime.Year);
        }

        public static string ToFinancialYearShort(this DateTime dateTime)
        {
            return "FinY" + (dateTime.Month >= 4 ? dateTime.AddYears(1).ToString("yy") : dateTime.ToString("yy"));
        }

        public static int ToFiscalYear(this DateTime dateTime)
        {
            return dateTime.Month >= 10 ? dateTime.Year + 1 : dateTime.Year;
        }

        public static string ToFiscalYearString(this DateTime dateTime)
        {
            return "Fiscal Year " + dateTime.ToFiscalYear().ToString();
        }

        public static string ToFiscalYearShortString(this DateTime dateTime)
        {
            return "FY" + dateTime.ToFiscalYear().ToString();
        }
    }
}
