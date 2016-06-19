using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZeroZeroOne.Holidays.Interface;

namespace ZeroZeroOne.Holidays
{
    public static class HolidayManager
    {
        public static Boolean IsDateAHoliday(ICountryHolidayProvider countryHolidayProvider, DateTime date)
        {
            return countryHolidayProvider.DateIsHoliday(date);
        }

        public static List<DateTime> GetHolidaysForYear(ICountryHolidayProvider countryHolidayProvider, Int32 year)
        {
            return countryHolidayProvider.GetHolidaysForYear(year);
        }

    }
}
