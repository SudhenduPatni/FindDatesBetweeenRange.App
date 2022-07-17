using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FindDatesBetweeenRangeSln
{
    public static class Helper
    {
        public enum RecurringType
        {
            Daily = 1,
            Weekly = 2,
            Monthly = 3,
            Yearly = 4
        }

        public static List<DateTime> GetDailyDatesBetweenRange(this DateTime fromDate, DateTime toDate, bool weekdays, int priorDays = 0, int skipDays = 0)
        {
            var dates = new List<DateTime>();

            if (weekdays)
            {
                for (DateTime date = fromDate; date <= toDate; date = date.AddDays(1))
                {
                    if (date.DayOfWeek == DayOfWeek.Monday ||
                        date.DayOfWeek == DayOfWeek.Tuesday ||
                        date.DayOfWeek == DayOfWeek.Wednesday ||
                        date.DayOfWeek == DayOfWeek.Thursday ||
                        date.DayOfWeek == DayOfWeek.Friday)
                    {
                        dates.Add(date.AddDays(-priorDays));
                    }
                }
            }
            else
            {
                int addDays = skipDays <= 1 ? 1 : skipDays;
                for (DateTime date = fromDate; date <= toDate; date = date.AddDays(addDays + 1))
                {
                    dates.Add(date.AddDays(-priorDays));
                }
            }

            return dates;
        }

        public static List<DateTime> GetWeeklyDatesBetweenRange(DateTime fromDate, DateTime toDate, List<DayOfWeek> days, int priorDays = 0, int skipWeeks = 0)
        {
            var dates = new List<DateTime>();
            int addDays = 1;

            for (DateTime date = fromDate; date <= toDate; date = date.AddDays(addDays))
            {
                addDays = 1;
                if (days.Contains(date.DayOfWeek))
                {
                    dates.Add(date.AddDays(-priorDays));
                }

                if (skipWeeks > 0 && date.DayOfWeek == DayOfWeek.Sunday)
                {
                    addDays = (skipWeeks * 7) + 1;
                }
            }

            return dates;
        }

        public static List<DateTime> GetWeeklyDatesBetweenRange2(DateTime fromDate, DateTime toDate, List<DayOfWeek> days, int priorDays = 0, int skipWeeks = 0)
        {
            var dates = new List<DateTime>();
            var startDate = fromDate;
            var dateInfo = DateTimeFormatInfo.CurrentInfo;
            int startWeek = dateInfo.Calendar.GetWeekOfYear(fromDate, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday), endWeek = 53;


            for (int year = fromDate.Year; year <= toDate.Year; year++)
            {
                if (year == toDate.Year)
                    endWeek = dateInfo.Calendar.GetWeekOfYear(toDate, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);

                for (; startWeek <= endWeek; startWeek += skipWeeks + 1)
                {
                    var date = new DateTime(startDate.Year, startDate.Month, startDate.Day);
                    if (date <= toDate)
                        dates.Add(date.AddDays(-priorDays));
                }

                if (dates.Count > 0)
                    startWeek = dateInfo.Calendar.GetWeekOfYear(dates[dates.Count - 1], CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday) + skipWeeks + 1;
            }

            return dates;
        }

        public static List<DateTime> GetMonthlyDatesBetweenRange(DateTime fromDate, DateTime toDate, int day, int priorDays = 0, int skipMonths = 0)
        {
            var dates = new List<DateTime>();
            int startMonth = fromDate.Month, endMonth = 12;

            for (int year = fromDate.Year; year <= toDate.Year; year++)
            {
                if (year == toDate.Year)
                    endMonth = toDate.Month;

                for (; startMonth <= endMonth; startMonth += skipMonths + 1)
                {
                    var date = new DateTime(year, startMonth, day);
                    if (date <= toDate)
                        dates.Add(date.AddDays(-priorDays));
                }

                if (dates.Count > 0)
                    startMonth = dates[dates.Count - 1].AddMonths(skipMonths + 1).Month;
            }

            return dates;
        }

        public static List<DateTime> GetYearlyDatesBetweenRange(DateTime fromDate, DateTime toDate, int day, int month, int priorDays = 0)
        {
            var dates = new List<DateTime>();

            for (int year = fromDate.Year; year <= toDate.Year; year++)
            {
                var date = new DateTime(year, month, day);

                if (date <= toDate)
                    dates.Add(date.AddDays(-priorDays));
            }

            return dates;
        }
    }
}
