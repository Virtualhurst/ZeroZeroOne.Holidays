using System;
using System.Collections.Generic;

namespace ZeroZeroOne.Holidays.Interface
{
    public interface ICountryHolidayProvider
    {
        List<DateTime> GetHolidaysForYear(Int32 year);

        Boolean DateIsHoliday(DateTime date);

        void AddHoliday(IHoliday holiday);
    }
}