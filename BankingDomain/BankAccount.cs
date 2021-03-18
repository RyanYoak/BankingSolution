﻿using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _balance = 5000; // Class Variable or 'Field'
        private ICanCalculateBankAccountBonuses _bankAccountBonusCalculator;
        private INotifyTheFeds _fedNotifier;

        public BankAccount(ICanCalculateBankAccountBonuses bankAccountBonusCalculator, INotifyTheFeds fedNotifier)
        {
            _bankAccountBonusCalculator = bankAccountBonusCalculator;
            _fedNotifier = fedNotifier;
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
            if(amountToWithdraw > _balance)
            {
                throw new OverdraftException();
            }

            _fedNotifier.NotifyOfWithdraw(this, amountToWithdraw);
            _balance -= amountToWithdraw;
        }
    }
}