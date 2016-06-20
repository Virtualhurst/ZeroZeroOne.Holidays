using System;
using System.Collections.Generic;
using System.Linq;
using ZeroZeroOne.Holidays.Holiday;
using ZeroZeroOne.Holidays.Interface;

namespace ZeroZeroOne.Holidays.Providers
{
    public class UnitedStatesHolidayProvider : BaseHolidayProvider
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

        public UnitedStatesHolidayProvider(IHolidayCache cache) : base(cache)
        {
            SetUpHolidays();
        }

        public void SetUpHolidays()
        {
            AddHoliday(new AnnualHoliday(1, 1, AnnualHoliday.WeekendDayMovementAction.MoveToFridayIfSaturdayAndMondayIfSunday)); // New Years Day
            //AddHoliday(new AnnualHoliday(21, 3, true)); // Human Rights Day
            //AddHoliday(new EasterSundayRelativeHoliday(-2)); // Good Friday
            //AddHoliday(new EasterSundayRelativeHoliday(1)); // Family Day
            //AddHoliday(new AnnualHoliday(27, 4, true)); // Freedom Day
            //AddHoliday(new AnnualHoliday(1, 5, true)); // Workers Day
            //AddHoliday(new AnnualHoliday(16, 6, true)); // Youth Day
            //AddHoliday(new AnnualHoliday(9, 8, true)); // National Women's Day
            //AddHoliday(new AnnualHoliday(24, 9, true)); // Heritage Day
            //AddHoliday(new AnnualHoliday(16, 12, true)); // Day of Reconciliation
            //AddHoliday(new AnnualHoliday(25, 12, true)); // Christmas Day
            //AddHoliday(new AnnualHoliday(26, 12, true)); // Day Of Goodwill
        }
    }
}