using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests
{
    public class BonusCalculatorTests
    {
        [Theory]
        [InlineData(3999.99, 100, 0)]
        [InlineData(4000, 100, 10)]
        public void BonusCalculatorGivesBonusesForGoldAccounts(
            decimal balance,
            decimal amountOfDeposit,
            decimal expectedBonusAmount)
        {
            var bonuseCalculator = new BonusCalculator();

            decimal bonus = bonuseCalculator.For(
                balance, amountOfDeposit);

            Assert.Equal(expectedBonusAmount, bonus);
        }
    }
}
