using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroZeroOne.Holidays.Holiday;
using ZeroZeroOne.Holidays.Interface;

namespace ZeroZeroOne.Holidays.Providers
{
    public class BaseHolidayProvider : ICountryHolidayProvider
    {
        internal readonly IHolidayCache Cache;
        internal readonly List<IHoliday> Holidays;

        public BaseHolidayProvider(IHolidayCache cache)
        {
            Cache = cache;

            Holidays = new List<IHoliday>();
        }

        public virtual void AddHoliday(IHoliday holiday)
        {
            Holidays.Add(holiday);
        }

        public virtual List<DateTime> GetHolidaysForYear(int year)
        {
            // Determine public holidays for this year
            foreach (var holiday in Holidays)
            {
                var dateForyear = holiday.GetHolidayDateForyear(year);
                if (dateForyear.HasValue && !Cache.ContainsDate(dateForyear.Value))
                    Cache.Add(dateForyear.Value, year);
            }

            return Cache.GetForYear(year);
        }

        public virtual Boolean DateIsHoliday(DateTime date)
        {
            return GetHolidaysForYear(date.Year).Any(x => x.Date == date.Date);
        }
    }
}
