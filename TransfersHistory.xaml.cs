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
using bank.Data;
using bank.models;

namespace bank
{
   
    public partial class TransfersHistory : Page
    {
        private User _currentUser;

        public TransfersHistory(User user)
        {
            InitializeComponent();
            _currentUser = user;
            LoadTransactionHistory();
        }
        private void LoadTransactionHistory()
        {
            using (var context = new BankContext())
            {
                var transactions = context.Transactions
                    .Where(t => t.UserId == _currentUser.Id)
                    .OrderByDescending(t => t.Date)
                    .ToList();

                foreach (var transaction in transactions)
                {
 
                    var transactionBorder = new Border
                    {
                        Style = (Style)FindResource("Transfer"),
                        Margin = new Thickness(0, 5, 0, 5)
                    };

                    var grid = new Grid();
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                    var amountBorder = new Border
                    {
                        Style = (Style)FindResource("Number"),
                        Background = transaction.Amount < 0 ? Brushes.Red : Brushes.LightGreen,
                        BorderBrush = transaction.Amount < 0 ? Brushes.DarkRed : Brushes.Green,
                        Margin = new Thickness(5)
                    };

                    var amountText = new TextBlock
                    {
                        Text = $"{transaction.Amount:C}",
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center
                    };
                    amountBorder.Child = amountText;
                    Grid.SetColumn(amountBorder, 0);
                    grid.Children.Add(amountBorder);


                    var senderText = new TextBlock
                    {
                        Style = (Style)FindResource("Person"),
                        Text = transaction.Amount < 0 ? $"To: {transaction.SenderName}" : $"From: {transaction.SenderName}",
                        Margin = new Thickness(10, 0, 0, 0)
                    };
                    Grid.SetColumn(senderText, 1);
                    grid.Children.Add(senderText);

                    var descriptionText = new TextBlock
                    {
                        Style = (Style)FindResource("Title"),
                        Text = transaction.Description.Length > 20
                               ? $"{transaction.Description.Substring(0, 20)}..."
                               : transaction.Description,
                        Margin = new Thickness(10, 0, 0, 0)
                    };
                    Grid.SetColumn(descriptionText, 2);
                    grid.Children.Add(descriptionText);

                    var dateText = new TextBlock
                    {
                        Style = (Style)FindResource("FinalAmount"),
                        Text = transaction.Date.ToString("mm-dd HH:mm"),
                        HorizontalAlignment = HorizontalAlignment.Right,
                        Margin = new Thickness(0, 0, 0, 0)
                    };
                    Grid.SetColumn(dateText, 3);
                    grid.Children.Add(dateText);

                   
                    transactionBorder.MouseLeftButtonDown += (s, e) =>
                    {
                        ShowFullDescription(transaction.Description);
                    };

                    transactionBorder.Child = grid;

                    MainStackPanel.Children.Add(transactionBorder);
                }
            }
        }

        private void ShowFullDescription(string description)
        {
            MessageBox.Show(description, "Transaction Details", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainBank(_currentUser));
        }
    }
}
