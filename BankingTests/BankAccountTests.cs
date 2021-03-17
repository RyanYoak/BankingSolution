using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests
{
    public class BankAccountTests
    {
        BankAccount _account;
        decimal _balance;

        public BankAccountTests()
        {
            _account = new BankAccount(new DummyBonusCalculator());
            _balance = _account.GetBalance();
        }

        [Fact]
        public void NewAccountsHaveCorrectBalance()
        {
            // Then
            Assert.Equal(5000M, _balance);
        }

        [Fact]
        public void DepositsIncreaseTheBalance()
        {
            // Given
            var amountToDeposit = 42M;

            // When
            _account.Deposit(amountToDeposit);

            // Then
            Assert.Equal(
                _balance + amountToDeposit,
                _account.GetBalance()
            );
        }

        [Fact]
        public void WithdrawsDecraseTheBalance()
        {
            // Given
            var amountToWithdraw = 42M;

            // When
            _account.Withdraw(amountToWithdraw);

            // Then
            Assert.Equal(
                _balance - amountToWithdraw,
                _account.GetBalance()
            );
        }
    }
    public class DummyBonusCalculator : ICanCalculateBankAccountBonuses
    {
        public decimal For(decimal balance, decimal amountToDeposit)
        {
            return 0;
        }
    }
}
