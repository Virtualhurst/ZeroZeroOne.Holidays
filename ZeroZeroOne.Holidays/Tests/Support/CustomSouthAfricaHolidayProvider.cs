using ZeroZeroOne.Holidays.Holiday;
using ZeroZeroOne.Holidays.Providers;

namespace Tests.Support
{
    public class CustomSouthAfricaHolidayProvider : SouthAfricaHolidayProvider
    {
        public CustomSouthAfricaHolidayProvider()
        {

        }

        public override void SetUpHolidays()
        {
            AddHoliday(new EasterSundayRelativeHoliday(0)); // Easter Sunday

            // Add the usual holidays
            base.SetUpHolidays();
        }

        //public List<DateTime> GetHolidaysForYear(int year)
        //{
        //    // Determine public holidays for this year
        //    foreach (var holiday in _holidays)
        //    {
        //        var dateForyear = holiday.GetHolidayDateForyear(year);
        //        if (dateForyear.HasValue && !_holidaysCache.ContainsKey(dateForyear.Value))
        //            _holidaysCache.Add(dateForyear.Value, year);
        //    }

        //    return _holidaysCache.Where(x => x.Value == year).Select(x => x.Key).ToList();
        //}

        //public Boolean DateIsHoliday(DateTime date)
        //{
        //    return GetHolidaysForYear(date.Year).Any(x => x.Date == date.Date);
        //}
    }
}