using System;
using ZeroZeroOne.Holidays.Interface;

namespace ZeroZeroOne.Holidays.Holiday
{
    public class AnnualHoliday : IHoliday
    {
        public enum WeekendDayMovementAction
        {
            None = 0,
            MoveToFridayIfSaturday = 1,
            MoveToMondayIfSunday = 2,
            MoveToFridayIfSaturdayAndMondayIfSunday = 3,
        }

        public Int32 Month { get; set; }

        public Int32 Day { get; set; }

        public WeekendDayMovementAction WeekendMovementAction { get; set; }

        public AnnualHoliday(Int32 day, Int32 month, WeekendDayMovementAction moveToMondayIfFallsOnASunday)
        {
            if (day > 31)
                throw new ArgumentOutOfRangeException(nameof(day));

            if (month > 12)
                throw new ArgumentOutOfRangeException(nameof(month));

            Day = day;
            Month = month;
            WeekendMovementAction = moveToMondayIfFallsOnASunday;
        }

        public DateTime? GetHolidayDateForyear(int year)
        {
            var dateString = $"{year}-{Month}-{Day}";
            DateTime dateForYear;
            if (DateTime.TryParse(dateString, out dateForYear))
            {
                //TODO: These should be checking if the next day is also a holiday and moving them on until the first working day
                if ((WeekendMovementAction == WeekendDayMovementAction.MoveToFridayIfSaturday
                     || WeekendMovementAction == WeekendDayMovementAction.MoveToFridayIfSaturdayAndMondayIfSunday)
                    && dateForYear.DayOfWeek == DayOfWeek.Saturday)
                {
                    return dateForYear.AddDays(-1);
                }

                if ((WeekendMovementAction == WeekendDayMovementAction.MoveToMondayIfSunday
                     || WeekendMovementAction == WeekendDayMovementAction.MoveToFridayIfSaturdayAndMondayIfSunday)
                    && dateForYear.DayOfWeek == DayOfWeek.Sunday)
                {
                    return dateForYear.AddDays(1);
                }

                return dateForYear;
            }

            return null;
        }
    }
}