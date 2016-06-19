using System;
using ZeroZeroOne.Holidays.Interface;

namespace ZeroZeroOne.Holidays.Holiday
{
    public class AnnualHoliday : IHoliday
    {
        public Int32 Month { get; set; }

        public Int32 Day { get; set; }

        public Boolean MoveToMondayIfFallsOnASunday { get; set; }

        public AnnualHoliday(Int32 day, Int32 month, Boolean moveToMondayIfFallsOnASunday)
        {
            if (day > 31)
                throw new ArgumentOutOfRangeException(nameof(day));

            if (month > 12)
                throw new ArgumentOutOfRangeException(nameof(month));

            Day = day;
            Month = month;
            MoveToMondayIfFallsOnASunday = moveToMondayIfFallsOnASunday;
        }

        public DateTime? GetHolidayDateForyear(int year)
        {
            var dateString = $"{year}-{Month}-{Day}";
            DateTime dateForYear;
            if (DateTime.TryParse(dateString, out dateForYear))
            {
                if (dateForYear.DayOfWeek == DayOfWeek.Sunday && MoveToMondayIfFallsOnASunday)
                    return dateForYear.AddDays(1);

                return dateForYear;
            }

            return null;
        }
    }
}