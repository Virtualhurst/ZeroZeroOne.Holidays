using System;
using System.Collections.Generic;
using System.Linq;
using ZeroZeroOne.Holidays.Holiday;
using ZeroZeroOne.Holidays.Interface;

namespace ZeroZeroOne.Holidays.Providers
{
    public class SouthAfricaHolidayProvider : BaseHolidayProvider
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
        public SouthAfricaHolidayProvider(IHolidayCache cache): base(cache)
        {
            SetUpHolidays();
        }

        public void SetUpHolidays()
        {
            AddHoliday(new AnnualHoliday(1, 1, AnnualHoliday.WeekendDayMovementAction.MoveToMondayIfSunday)); // New Years Day
            AddHoliday(new AnnualHoliday(21, 3, AnnualHoliday.WeekendDayMovementAction.MoveToMondayIfSunday)); // Human Rights Day
            AddHoliday(new EasterSundayRelativeHoliday(-2)); // Good Friday
            AddHoliday(new EasterSundayRelativeHoliday(1)); // Family Day
            AddHoliday(new AnnualHoliday(27, 4, AnnualHoliday.WeekendDayMovementAction.MoveToMondayIfSunday)); // Freedom Day
            AddHoliday(new AnnualHoliday(1, 5, AnnualHoliday.WeekendDayMovementAction.MoveToMondayIfSunday)); // Workers Day
            AddHoliday(new AnnualHoliday(16, 6, AnnualHoliday.WeekendDayMovementAction.MoveToMondayIfSunday)); // Youth Day
            AddHoliday(new AnnualHoliday(9, 8, AnnualHoliday.WeekendDayMovementAction.MoveToMondayIfSunday)); // National Women's Day
            AddHoliday(new AnnualHoliday(24, 9, AnnualHoliday.WeekendDayMovementAction.MoveToMondayIfSunday)); // Heritage Day
            AddHoliday(new AnnualHoliday(16, 12, AnnualHoliday.WeekendDayMovementAction.MoveToMondayIfSunday)); // Day of Reconciliation
            AddHoliday(new AnnualHoliday(25, 12, AnnualHoliday.WeekendDayMovementAction.MoveToMondayIfSunday)); // Christmas Day
            AddHoliday(new AnnualHoliday(26, 12, AnnualHoliday.WeekendDayMovementAction.MoveToMondayIfSunday)); // Day Of Goodwill

            // Fixed date holidays
            AddHoliday(new FixedDateHoliday(3, 8, 2016)); // Local Government Elections 2016
        }
    }
}