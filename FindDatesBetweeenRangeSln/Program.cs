using System;
using System.Collections.Generic;

namespace FindDatesBetweeenRangeSln
{
    public class Program
    {
        static void Main(string[] args)
        {
            var fromDate = new DateTime(2022, 7, 15);
            var toDate = new DateTime(2022, 8, 5);
            var priorDays = 0;
            var skip = 0;

            var dates = new List<DateTime>();

            ///============================================ D A I L Y ==============================================
            ///
            //Console.WriteLine("Daily due dates between daterange without with Prior Day = 0 and Skip Days = 0.");
            //dates = Helper.GetDailyDatesBetweenRange(fromDate, toDate, true, priorDays, skip);
            //foreach (var date in dates)
            //    Console.WriteLine($"Prior={priorDays} | skipDay={skip} | dueDate={date.ToString()}");

            //priorDays = 1;
            //Console.WriteLine("Daily due dates between daterange without with Prior Day = 1 and Skip Days = 0.");
            //dates = Helper.GetDailyDatesBetweenRange(fromDate, toDate, false, priorDays, skip);
            //foreach (var date in dates)
            //    Console.WriteLine($"Prior={priorDays} | skipDay={skip} | dueDate={date.ToString()}");

            //priorDays = 0;
            //skip = 2;
            //Console.WriteLine("Daily due dates between daterange without with Prior Day = 0 and Skip Days = 2.");
            //dates = Helper.GetDailyDatesBetweenRange(fromDate, toDate, false, priorDays, skip);
            //foreach (var date in dates)
            //    Console.WriteLine($"Prior={priorDays} | skipDay={skip} | dueDate={date.ToString()}");

            ///===================================== W E E K L Y =========================================
            ///
            Console.WriteLine("Weekly dates between daterange with Prior Day = 0 and Skip Week = 0.");
            dates = Helper.GetWeeklyDatesBetweenRange(fromDate, toDate, new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Friday }, priorDays, skip);
            foreach (var date in dates)
                Console.WriteLine(date.ToString());

            priorDays = 1;
            Console.WriteLine("Weekly dates between daterange with Prior Day = 1 and Skip Week = 0.");
            dates = Helper.GetWeeklyDatesBetweenRange(fromDate, toDate, new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Thursday }, priorDays, skip);
            foreach (var date in dates)
                Console.WriteLine(date.ToString());

            ///===================================== M O N T H L Y =========================================
            ///
            //Console.WriteLine("Monthly dates between daterange with Prior Day = 0 and Skip months = 0.");
            //dates = Helper.GetMonthlyDatesBetweenRange(fromDate, toDate, 18, priorDays, skip);
            //foreach (var date in dates)
            //    Console.WriteLine(date.ToString());

            //priorDays = 1;
            //Console.WriteLine("Monthly dates between daterange with Prior Day = 1 and Skip months = 0.");
            //dates = Helper.GetMonthlyDatesBetweenRange(fromDate, toDate, 18, priorDays, skip);
            //foreach (var date in dates)
            //    Console.WriteLine(date.ToString());

            //priorDays = 0;
            //skip = 3;
            //Console.WriteLine("Monthly dates between daterange with Prior Day = 0 and Skip months = 3.");
            //dates = Helper.GetMonthlyDatesBetweenRange(fromDate, toDate, 18, priorDays, skip);
            //foreach (var date in dates)
            //    Console.WriteLine(date.ToString());

            ///====================================== Y E A R L Y =======================================
            ///
            //Console.WriteLine("Yearly dates between daterange with Prior Day = 0 | Date = 15 | Month=3.");
            //dates = Helper.GetYearlyDatesBetweenRange(fromDate, toDate, 1, 5, priorDays);
            //foreach (var date in dates)
            //    Console.WriteLine(date.ToString());

            //priorDays = 1;
            //Console.WriteLine("Yearly dates between daterange with Prior Day = 1 | Date = 15 | Month=3.");
            //dates = Helper.GetYearlyDatesBetweenRange(fromDate, toDate, 1, 3, priorDays);
            //foreach (var date in dates)
            //    Console.WriteLine(date.ToString());
        }
    }
}
