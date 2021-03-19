using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests
{
    public class AccountShouldNotAllowNegativeNumberTransactions
    {
        private INotifyTheFeds _fedDummy = new Mock<INotifyTheFeds>().Object;
        private ICanCalculateBankAccountBonuses _bonusDummy = new Mock<ICanCalculateBankAccountBonuses>().Object;

        [Fact]
        public void DepositDoesNotAllowNegativeNumbers()
        {
            var account = new BankAccount(_bonusDummy, _fedDummy);

            Assert.Throws<NoNegativeNumberTransactionsException>(
                () => account.Deposit(-100));
        }

        [Fact]
        public void WithdrawlDoesNotAllowNegativeNumbers()
        {
            var account = new BankAccount(_bonusDummy, _fedDummy);

            Assert.Throws<NoNegativeNumberTransactionsException>(
                () => account.Withdraw(-100));
        }
    }
}
