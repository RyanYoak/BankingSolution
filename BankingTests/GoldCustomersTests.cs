using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests
{
    public class GoldCustomersTests
    {
        BankAccount account;
        decimal openingBalance;

        public GoldCustomersTests()
        {
            account = new BankAccount();
            openingBalance = account.GetBalance();
            account.AccountType = AccountType.Gold;
        }

        [Theory]
        [InlineData(100, 10)]
        public void GetABonusOnDeposits(decimal amountToDeposit, decimal expectedBonus)
        {
            // When
            account.Deposit(amountToDeposit);

            // Then
            var expected = openingBalance + amountToDeposit + expectedBonus;
            Assert.Equal(expected, account.GetBalance());
        }
    }
}
