using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _balance = 5000; // Class Variable or 'Field'

        public BankAccount()
        {
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        public virtual void Deposit(decimal amountToDeposit)
        {
            _balance += amountToDeposit;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            _balance -= amountToWithdraw;
        }
    }
}