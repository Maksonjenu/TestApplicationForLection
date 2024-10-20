using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using BankApp;

namespace BankApp_Cooler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Account account;

        public MainWindow()
        {
            InitializeComponent();

            account = new Account(1000);

            account.Notify += ShowBal;

        }

        private void AddTwo_Click(object sender, RoutedEventArgs e)
        {
            account.Add(2);
        }
        private void SubTwo_Click(object sender, RoutedEventArgs e)
        {
            account.Take(2);
        }

        void ShowBal(string bal)
        {
            Balance.Text = account.Sum.ToString();
        }
    }
}