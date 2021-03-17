using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests
{
    public class GoldAccountTests
    {
        GoldAccount _account;
        decimal _initialAmount;

        public GoldAccountTests()
        {
            _account = new GoldAccount();
            _initialAmount = _account.GetBalance();
        }

        [Theory]
        [InlineData(100, 10)]
        public void GoldAccountsGetBonusOnDeposit(decimal amountToDeposit, decimal expectedBonus)
        {
            _account.Deposit(amountToDeposit);
            var expected = _initialAmount + amountToDeposit + expectedBonus;

            Assert.Equal(expected, _account.GetBalance());
        }
    }
}
