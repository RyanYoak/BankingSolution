namespace BankingDomain
{
    public interface ICanCalculateBankAccountBonuses
    {
        decimal For(decimal balance, decimal amountToDeposit);
    }
}