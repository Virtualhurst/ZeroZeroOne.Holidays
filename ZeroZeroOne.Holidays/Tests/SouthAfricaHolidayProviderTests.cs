using System;
using NUnit.Framework;
using Tests.Support;
using ZeroZeroOne.Holidays.Cache;
using ZeroZeroOne.Holidays.Interface;
using ZeroZeroOne.Holidays.Providers;

namespace Tests
{
    [TestFixture]
    public class SouthAfricaHolidayProviderTests
    {
        private IHolidayCache _cache;

        [SetUp]
        public void Setup()
        {
            _cache = new SimpleHolidayCache();
        }

        private ICountryHolidayProvider GetStandardProvider()
        {
            return new SouthAfricaHolidayProvider(_cache);
        }

        [Test]
        public void NewYearsDay_Is_Correct_For_2016()
        {
            var provider = GetStandardProvider();
            var holidays = provider.GetHolidaysForYear(2016);

            Assert.IsTrue(holidays.Contains(new DateTime(2016, 1, 1)));
        }

        [Test]
        public void HumanRightsDay_Is_Correct_For_2016()
        {
            var provider = GetStandardProvider();
            var holidays = provider.GetHolidaysForYear(2016);

            Assert.IsTrue(holidays.Contains(new DateTime(2016, 3, 21)));
        }

        [Test]
        public void GoodFriday_Is_Correct_For_2016()
        {
            var provider = GetStandardProvider();
            var holidays = provider.GetHolidaysForYear(2016);

            Assert.IsTrue(holidays.Contains(new DateTime(2016, 3, 25)));
        }

        [Test]
        public void EasterSunday_Is_Not_Available_For_Standard_Provider()
        {
            var provider = GetStandardProvider();
            var holidays = provider.GetHolidaysForYear(2016);

            Assert.IsFalse(holidays.Contains(new DateTime(2016, 3, 27)));
        }

        [Test]
        public void EasterSunday_Is_Correct_For_2016_Using_Custom_Provider()
        {
            var provider = new CustomSouthAfricaHolidayProvider();
            var holidays = provider.GetHolidaysForYear(2016);

            Assert.IsTrue(holidays.Contains(new DateTime(2016, 3, 27)));
        }

        [Test]
        public void FamilyDay_Is_Correct_For_2016()
        {
            var provider = GetStandardProvider();
            var holidays = provider.GetHolidaysForYear(2016);

            Assert.IsTrue(holidays.Contains(new DateTime(2016, 3, 28)));
        }

        [Test]
        public void FreedomDay_Is_Correct_For_2016()
        {
            var provider = GetStandardProvider();
            var holidays = provider.GetHolidaysForYear(2016);

            Assert.IsTrue(holidays.Contains(new DateTime(2016, 4, 27)));
        }

        [Test]
        public void WorkersDay_Is_Correct_For_2016()
        {
            var provider = GetStandardProvider();
            var holidays = provider.GetHolidaysForYear(2016);

            Assert.IsTrue(holidays.Contains(new DateTime(2016, 5, 2))); // Observed on the 2nd because the 1st is a Sunday
        }

        [Test]
        public void WorkersDay_Is_Correct_For_2017()
        {
            var provider = GetStandardProvider();
            var holidays = provider.GetHolidaysForYear(2017);

            Assert.IsTrue(holidays.Contains(new DateTime(2017, 5, 1))); 
        }

        [Test]
        public void LocalGovernmentElectionsDay_Is_Correct_For_2016()
        {
            var provider = GetStandardProvider();
            var dateIsHoliday = provider.DateIsHoliday(new DateTime(2016, 8, 3));

            Assert.IsTrue(dateIsHoliday); 
        }

        [Test]
        public void LocalGovernmentElectionsDay_Is_Correct_For_2017()
        {
            var provider = GetStandardProvider();
            var dateIsHoliday = provider.DateIsHoliday(new DateTime(2017, 8, 3));

            Assert.IsFalse(dateIsHoliday); // There are no local government elections in 2017
        }

        [Test]
        public void YouthDay_Is_Correct_For_2016()
        {
            var provider = GetStandardProvider();
            var holidays = provider.GetHolidaysForYear(2016);

            Assert.IsTrue(holidays.Contains(new DateTime(2016, 6, 16)));
        }

        [Test]
        public void WomansDay_Is_Correct_For_2016()
        {
            var provider = GetStandardProvider();
            var holidays = provider.GetHolidaysForYear(2016);

            Assert.IsTrue(holidays.Contains(new DateTime(2016, 8, 9)));
        }

        [Test]
        public void HeritageDay_Is_Correct_For_2016()
        {
            var provider = GetStandardProvider();
            var holidays = provider.GetHolidaysForYear(2016);

            Assert.IsTrue(holidays.Contains(new DateTime(2016, 9, 24)));
        }

        [Test]
        public void DayOfReconciliation_Is_Correct_For_2016()
        {
            var provider = GetStandardProvider();
            var holidays = provider.GetHolidaysForYear(2016);

            Assert.IsTrue(holidays.Contains(new DateTime(2016, 12, 16)));
        }

        [Test]
        public void ChristmasDay_Is_Correct_For_2016()
        {
            var provider = GetStandardProvider();
            var holidays = provider.GetHolidaysForYear(2016);

            Assert.IsTrue(holidays.Contains(new DateTime(2016, 12, 26)));
        }

        [Test]
        public void ChristmasDay_Is_Correct_For_2017()
        {
            var provider = GetStandardProvider();
            var holidays = provider.GetHolidaysForYear(2017);

            Assert.IsTrue(holidays.Contains(new DateTime(2017, 12, 25)));
        }

        [Test]
        public void DayOfGoodwill_Is_Correct_For_2016()
        {
            var provider = GetStandardProvider();
            var holidays = provider.GetHolidaysForYear(2016);

            Assert.IsTrue(holidays.Contains(new DateTime(2016, 12, 26)));
        }


    }
}
