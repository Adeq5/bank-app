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
using bank.models;

namespace bank
{
    
    public partial class MainBank : Page
    {
        private User _currentUser;
        public MainBank(User user)
        {
            InitializeComponent();
            _currentUser = user;
        }
        private void Logout(object sender, RoutedEventArgs e)
        {
            var MainWindow = (MainWindow)Window.GetWindow(this);
            MainWindow.MainFrame.Content = null;
        }

        private void NavigateToEditAcc(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EditAcc(_currentUser));
        }
        private void NavigateToWallet(object sender, RoutedEventArgs e)
        {
            Wallet walletPage = new Wallet(_currentUser);
            NavigationService.Navigate(walletPage);
        }
        private void NavigateToTransfers(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Transfers(_currentUser));
        }
        private void NavigateToTransfersHistory(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TransfersHistory(_currentUser));
        }
    }
}
