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
    public class BankAccountInteractionTests
    {
        [Fact]
        public void DepositUsesTheBonusCalculator()
        {
            // Given
            var stubbedBonusCalculator = new Mock<ICanCalculateBankAccountBonuses>();
            var account = new BankAccount(stubbedBonusCalculator.Object);
            var openingBalance = account.GetBalance();
            var amountToDeposit = 10M;
            stubbedBonusCalculator.Setup(c => c.For(openingBalance, amountToDeposit)).Returns(42);

            //When
            account.Deposit(amountToDeposit);

            //Then
            Assert.Equal(
                openingBalance +
                amountToDeposit + 
                42,
                account.GetBalance());
        }
    }
    // Doing this to verigy that the BankAccounts class is actually implementing a version of
    // ICanCalculateBankAccountBonuses, and this version will only return what we want it to
    //public class StubbedBonusCalculator : ICanCalculateBankAccountBonuses
    //{
    //    public decimal expectedBalance;
    //    public decimal expectedAmountOfDeposit;
    //    public decimal amountToReturn;
    //    public decimal For(decimal balance, decimal amountToDeposit)
    //    {
    //        if(balance == expectedBalance && amountToDeposit == expectedAmountOfDeposit)
    //        {
    //            return amountToReturn;
    //        }
    //        else
    //        {
    //            return -10; // Or something else dumb
    //        }
    //    }
    //}
}
