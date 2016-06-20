using System;
using System.Collections.Generic;

namespace ZeroZeroOne.Holidays.Interface
{
    public interface IHolidayCache
    {
        void Add(DateTime holiday, Int32 year);

        Boolean ContainsDate(DateTime date);

        List<DateTime> GetForYear(Int32 year);


    }
}