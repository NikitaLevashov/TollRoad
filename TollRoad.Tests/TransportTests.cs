using NUnit.Framework;
using System;
using TollRoad.Models;

namespace TollRoad.Tests
{
    public class Tests
    {

        [Test]
        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCases))]

        public decimal CalculateToll_WithCorrectParameters_ReturnDecimal(Transport transport, DateTime dateTime, bool inbound) =>
            transport.CalculateToll(dateTime, inbound);
    }
}