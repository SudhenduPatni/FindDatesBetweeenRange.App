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

        public static List<TodoDueDates> GetDailyDatesBetweenRange(this DateTime fromDate, DateTime toDate, bool weekdays, int priorDays = 0, int skipDays = 0)
        {
            var dates = new List<TodoDueDates>();

            if (weekdays)
            {
                for (DateTime dueDate = fromDate; dueDate <= toDate; dueDate = dueDate.AddDays(1))
                {
                    if (dueDate.DayOfWeek == DayOfWeek.Monday ||
                        dueDate.DayOfWeek == DayOfWeek.Tuesday ||
                        dueDate.DayOfWeek == DayOfWeek.Wednesday ||
                        dueDate.DayOfWeek == DayOfWeek.Thursday ||
                        dueDate.DayOfWeek == DayOfWeek.Friday)
                    {
                        dates.Add(SetTodoDueDates(dueDate, priorDays));
                    }
                }
            }
            else
            {
                int addDays = skipDays <= 1 ? 1 : skipDays;
                for (DateTime dueDate = fromDate; dueDate <= toDate; dueDate = dueDate.AddDays(addDays + 1))
                {
                    var todoDueDates = new TodoDueDates();
                    todoDueDates.DueDates = duedate;
                    todoDueDates.PriorToDates = duedate.AddDays(-priorDays);

                    dates.Add(SetTodoDueDates(dueDate, priorDays));
                }
            }

            return dates;
        }

        public static List<TodoDueDates> GetWeeklyDatesBetweenRange(DateTime fromDate, DateTime toDate, List<DayOfWeek> days, int priorDays = 0, int skipWeeks = 0)
        {
            var dates = new List<TodoDueDates>();
            int addDays = 1;

            for (DateTime dueDate = fromDate; dueDate <= toDate; dueDate = dueDate.AddDays(addDays))
            {
                addDays = 1;
                if (days.Contains(dueDate.DayOfWeek))
                {
                    dates.Add(SetTodoDueDates(dueDate, priorDays));
                }

                if (skipWeeks > 0 && dueDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    addDays = (skipWeeks * 7) + 1;
                }
            }

            return dates;
        }

        public static List<TodoDueDates> GetMonthlyDatesBetweenRange(DateTime fromDate, DateTime toDate, int day, int priorDays = 0, int skipMonths = 0)
        {
            var dates = new List<TodoDueDates>();
            int startMonth = fromDate.Month, endMonth = 12;

            for (int year = fromDate.Year; year <= toDate.Year; year++)
            {
                if (year == toDate.Year)
                    endMonth = toDate.Month;

                for (; startMonth <= endMonth; startMonth += skipMonths + 1)
                {
                    var dueDate = new DateTime(year, startMonth, day);
                    if (dueDate <= toDate)
                        dates.Add(SetTodoDueDates(dueDate, priorDays));
                }

                if (dates.Count > 0)
                    startMonth = dates[dates.Count - 1].AddMonths(skipMonths + 1).Month;
            }

            return dates;
        }

        public static List<TodoDueDates> GetYearlyDatesBetweenRange(DateTime fromDate, DateTime toDate, int day, int month, int priorDays = 0)
        {
            var dates = new List<TodoDueDates>();

            for (int year = fromDate.Year; year <= toDate.Year; year++)
            {
                var dueDate = new DateTime(year, month, day);

                if (dueDate <= toDate)
                    dates.Add(SetTodoDueDates(dueDate, priorDays));
            }

            return dates;
        }

        public TodoDueDates SetTodoDueDates(DateTime dueDate, int priorDays)
        {
            var todoDueDates = new TodoDueDates();
            
            todoDueDates.DueDates = dueDate;
            todoDueDates.PriorToDates = dueDate.AddDays(-priorDays);
            
            return todoDueDate;
        }
    }

    public class TodoDueDates
    {
        public DateTime DueDates { get; set; }
        public DateTime PriorToDates { get; set; }
    }
}
