using System;
using ZeroZeroOne.Holidays.Interface;

namespace ZeroZeroOne.Holidays.Holiday
{
    public class FixedDateHoliday : IHoliday
    {
        public Int32 Year { get; set; }

        public Int32 Month { get; set; }

        public Int32 Day { get; set; }

        public FixedDateHoliday(Int32 day, Int32 month, Int32 year)
        {
            if (day > 31)
                throw new ArgumentOutOfRangeException(nameof(day));

            if (month > 12)
                throw new ArgumentOutOfRangeException(nameof(month));

            Day = day;
            Month = month;
            Year = year;
        }

        public DateTime? GetHolidayDateForyear(int year)
        {
            if (year != Year)
                return null;

            var dateString = $"{Year}-{Month}-{Day}";
            DateTime dateForYear;
            if (DateTime.TryParse(dateString, out dateForYear))
            {
                return dateForYear;
            }

            return null;
        }
    }
}