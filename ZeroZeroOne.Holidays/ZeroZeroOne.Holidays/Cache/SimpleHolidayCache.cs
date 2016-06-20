using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroZeroOne.Holidays.Interface;

namespace ZeroZeroOne.Holidays.Cache
{
    public class SimpleHolidayCache : IHolidayCache
    {
        internal readonly Dictionary<DateTime, Int32> HolidaysCache;

        public SimpleHolidayCache()
        {
            HolidaysCache = new Dictionary<DateTime, int>();
        }

        public void Add(DateTime holiday, int year)
        {
            //TODO: Create custom exception/research correct exception
            if (ContainsDate(holiday))
                throw new Exception("This date is already in the cache");

            HolidaysCache.Add(holiday, year);
        }

        public bool ContainsDate(DateTime date)
        {
            return HolidaysCache.ContainsKey(date);
        }

        public List<DateTime> GetForYear(int year)
        {
            return HolidaysCache.Where(x => x.Value == year).Select(x => x.Key).ToList();
        }
    }
}
