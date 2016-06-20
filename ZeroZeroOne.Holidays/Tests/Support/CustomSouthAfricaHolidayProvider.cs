using ZeroZeroOne.Holidays.Cache;
using ZeroZeroOne.Holidays.Holiday;
using ZeroZeroOne.Holidays.Providers;

namespace Tests.Support
{
    public class CustomSouthAfricaHolidayProvider : SouthAfricaHolidayProvider
    {
        public CustomSouthAfricaHolidayProvider() : base(new SimpleHolidayCache())
        {
            SetUpCustomHolidays();
        }

        public void SetUpCustomHolidays()
        {
            AddHoliday(new EasterSundayRelativeHoliday(0)); // Easter Sunday

            // Add the usual holidays
            base.SetUpHolidays();
        }
    }
}