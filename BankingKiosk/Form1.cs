using BankingDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingKiosk
{
    public partial class Form1 : Form
    {

        private BankAccount _account;

        public Form1()
        {
            InitializeComponent();
            _account = new BankAccount(
                new BonusCalculator(),
                new FakeFedNotifier()
                );
            UpdateBalance();
        }

        private void UpdateBalance()
        {
            Text = $"Bank Kiosk - Your Balance is {_account.GetBalance():c}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Deposit);
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Withdraw);
        }

        private void DoTransaction(Action<decimal> method) 
        {
            if (decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                try
                {
                    method(amount);
                    UpdateBalance();
                }
                catch (OverdraftException)
                {

                    MessageBox.Show("Be more rich loser!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (NoNegativeNumberTransactionsException)
                {
                    DisplayError("Enter a positive number, idiot");
                }
                finally
                {
                    txtAmount.SelectAll();
                    txtAmount.Focus();
                }
            }
            else
            {
                MessageBox.Show("Enter a number, please.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.Focus();
            }
        }

        private void DisplayError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public class FakeFedNotifier : INotifyTheFeds
    {
        public void NotifyOfWithdraw(BankAccount bankAccount, decimal amountToWithdraw)
        {
            MessageBox.Show("The Feds have been notified. Stay where you are");
        }
    }
}
