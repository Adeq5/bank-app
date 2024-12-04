using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using bank.Data;
using bank.models;
using Microsoft.EntityFrameworkCore;

namespace bank
{
    public partial class Transfers : Page
    {

        private User _currentUser;

       
        public Transfers(User user)
        {
            InitializeComponent();
            _currentUser = user;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainBank(_currentUser)); 
        }

 
        private void ExecuteTransfer(object sender, RoutedEventArgs e)
        {
            string recipientLogin = RecipientAccountTextBox.Text;
            decimal amount;

            if (!decimal.TryParse(AmountTextBox.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("Please enter the correct amount.");
                return;
            }

            using (var context = new BankContext())
            {
              
                var senderUser = context.Users.FirstOrDefault(u => u.Login == _currentUser.Login);
                if (senderUser == null)
                {
                    MessageBox.Show("Error: Sender account not found.");
                    return;
                }

                if (senderUser.Balance < amount)
                {
                    MessageBox.Show("You don't have enough funds in your account.");
                    return;
                }

                var recipient = context.Users.FirstOrDefault(u => u.Login == recipientLogin);
                if (recipient == null)
                {
                    MessageBox.Show("No recipient with the given login was found.");
                    return;
                }


                senderUser.Balance -= amount;

                recipient.Balance += amount;


                var senderTransaction = new Transaction
                {
                    UserId = senderUser.Id,
                    Amount = -amount,
                    SenderName = $"{senderUser.FirstName} {senderUser.LastName}",
                    Description = DescriptionTextBox.Text,
                    Date = DateTime.Now
                };
                context.Transactions.Add(senderTransaction);


                var recipientTransaction = new Transaction
                {
                    UserId = recipient.Id,
                    Amount = amount,
                    SenderName = $"{senderUser.FirstName} {senderUser.LastName}",
                    Description = DescriptionTextBox.Text,
                    Date = DateTime.Now
                };
                context.Transactions.Add(recipientTransaction);


                context.SaveChanges();


                MessageBox.Show($"Transfer {amount:C} to {recipientLogin}.");

                
                _currentUser.Balance = senderUser.Balance;

                MainFrame.Navigate(new Transfers(_currentUser));
            }
        }




    }
}
