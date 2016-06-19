using System;

namespace ZeroZeroOne.Holidays.Interface
{
    public interface IHoliday
    {
        DateTime? GetHolidayDateForyear(Int32 year);
    }
}