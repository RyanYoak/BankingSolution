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
    public class BankAccountOverdraftTests
    {
        //[Fact]
        //// Writing a test to make happen what we don't want to happen that pass
        //// Then writing some tests of how we want it to work that don't
        //// After development we hope they switch
        //public void TheBadThingThatHappensThatWeWantToNotHappenAnymore()
        //{
        //    var account = new BankAccount(null, new Mock<INotifyTheFeds>().Object);
        //    var openingBalance = account.GetBalance();

        //    account.Withdraw(openingBalance + 1);

        //    Assert.Equal(-1, account.GetBalance());
        //}
        
        [Fact]
        public void OverdraftDoesNotDecreaseBalance()
        {
            var account = new BankAccount(null, new Mock<INotifyTheFeds>().Object);
            var openingBalance = account.GetBalance();

            try
            {
                account.Withdraw(openingBalance + 1);
            }
            catch (OverdraftException)
            {
                //Ignore this
            }
            finally
            {
                Assert.Equal(openingBalance, account.GetBalance());
            }
        }

        [Fact]
        public void OverdraftShouldThrowAnException()
        {
            var account = new BankAccount(null, new Mock<INotifyTheFeds>().Object);
            var openingBalance = account.GetBalance();

            Assert.Throws<OverdraftException>(() => account.Withdraw(openingBalance + 1));
        }
    }
}
