using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _balance = 5000; // Class Variable or 'Field'
        private ICanCalculateBankAccountBonuses _bankAccountBonusCalculator;

        public BankAccount(ICanCalculateBankAccountBonuses bankAccountBonusCalculator)
        {
            _bankAccountBonusCalculator = bankAccountBonusCalculator;
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        public void Deposit(decimal amountToDeposit)
        {
            // write the code I wish I had
            decimal bonus = _bankAccountBonusCalculator.For(_balance, amountToDeposit);
            _balance += amountToDeposit + bonus;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            _balance -= amountToWithdraw;
        }
    }
}