using System;

namespace BankingDomain
{
    public class BonusCalculator : ICanCalculateBankAccountBonuses
    {
        public BonusCalculator()
        {
        }

        private decimal CalculateBonusForBankAccountDeposits(decimal balance, decimal amountOfDeposit)
        {
            return balance >= 4000? amountOfDeposit * .1M: 0;
        }

        public decimal For(decimal balance, decimal amountToDeposit)
        {
            return CalculateBonusForBankAccountDeposits(balance, amountToDeposit);
        }
    }
}