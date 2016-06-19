using System;
using System.Collections.Generic;
using System.Linq;
using ZeroZeroOne.Holidays.Holiday;
using ZeroZeroOne.Holidays.Interface;

namespace ZeroZeroOne.Holidays.Providers
{
    public class SouthAfricaHolidayProvider : ICountryHolidayProvider
    {
        /*
            1 January – New Years Day
            21 March - Human Rights Day
            25 March 2016 – Good Friday
            28 March 2016 – Family Day
            27 April - Freedom Day
            1 May - Workers Day
            16 June - Youth Day
            9 August - National Women’s Day
            24 September – Heritage Day
            16 December - Day of Reconciliation
            25 December - Christmas Day
            26 December - Day Of Goodwill
         */
        internal readonly List<IHoliday> Holidays;

        internal readonly Dictionary<DateTime, Int32> HolidaysCache;

        public SouthAfricaHolidayProvider()
        {
            HolidaysCache = new Dictionary<DateTime, int>();
            Holidays = new List<IHoliday>();

            SetUpHolidays();
        }

        public virtual void SetUpHolidays()
        {
            AddHoliday(new AnnualHoliday(1, 1, true)); // New Years Day
            AddHoliday(new AnnualHoliday(21, 3, true)); // Human Rights Day
            AddHoliday(new EasterSundayRelativeHoliday(-2)); // Good Friday
            AddHoliday(new EasterSundayRelativeHoliday(1)); // Family Day
            AddHoliday(new AnnualHoliday(27, 4, true)); // Freedom Day
            AddHoliday(new AnnualHoliday(1, 5, true)); // Workers Day
            AddHoliday(new AnnualHoliday(16, 6, true)); // Youth Day
            AddHoliday(new AnnualHoliday(9, 8, true)); // National Women's Day
            AddHoliday(new AnnualHoliday(24, 9, true)); // Heritage Day
            AddHoliday(new AnnualHoliday(16, 12, true)); // Day of Reconciliation
            AddHoliday(new AnnualHoliday(25, 12, true)); // Christmas Day
            AddHoliday(new AnnualHoliday(26, 12, true)); // Day Of Goodwill

            // Fixed date holidays
            AddHoliday(new FixedDateHoliday(3, 8, 2016)); // Local Government Elections 2016
        }

        public void AddHoliday(IHoliday holiday)
        {
            Holidays.Add(holiday);
        }

        public List<DateTime> GetHolidaysForYear(int year)
        {
            // Determine public holidays for this year
            foreach (var holiday in Holidays)
            {
                var dateForyear = holiday.GetHolidayDateForyear(year);
                if (dateForyear.HasValue && !HolidaysCache.ContainsKey(dateForyear.Value))
                    HolidaysCache.Add(dateForyear.Value, year);
            }

            return HolidaysCache.Where(x => x.Value == year).Select(x => x.Key).ToList();
        }

        public Boolean DateIsHoliday(DateTime date)
        {
            return GetHolidaysForYear(date.Year).Any(x => x.Date == date.Date);
        }

    }
}