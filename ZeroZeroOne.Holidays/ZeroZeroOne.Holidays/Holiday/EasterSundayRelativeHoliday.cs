using System;
using ZeroZeroOne.Holidays.Interface;

namespace ZeroZeroOne.Holidays.Holiday
{
    public class EasterSundayRelativeHoliday : IHoliday
    {
        public int DayOffset { get; set; }

        public EasterSundayRelativeHoliday(Int32 dayOffset)
        {
            DayOffset = dayOffset;
        }

        public DateTime? GetHolidayDateForyear(int year)
        {
            return CalculateEasterSunday(year).AddDays(DayOffset);
        }

        private DateTime CalculateEasterSunday(Int32 year)
        {
            var goldenValue = year % 19;
            var centuryDiff = year / 100;
            var yearModifier = (centuryDiff - (Int32)(centuryDiff / 4) - (Int32)((8 * centuryDiff + 13) / 25) + 19 * goldenValue + 15) % 30;
            var dayModifier = yearModifier - (Int32)(yearModifier / 28) * (1 - (Int32)(yearModifier / 28) * (Int32)(29 / (yearModifier + 1)) * (Int32)((21 - goldenValue) / 11));

            var day = dayModifier - ((year + (Int32)(year / 4) + dayModifier + 2 - centuryDiff + (Int32)(centuryDiff / 4)) % 7) + 28;
            var month = 3;

            if (day > 31)
            {
                month++;
                day -= 31;
            }

            return new DateTime(year, month, day);
        }
    }
}