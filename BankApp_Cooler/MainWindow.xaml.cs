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

            Ellipse e = new Ellipse();
            e.Width = 200;
            e.Height = 200;

            e.Fill = Brushes.Red;

            Canvas.SetLeft(e, 150);
            Canvas.SetTop(e, 150);

            QQQ.Children.Add(e);

            account = new Account(1000);

            account.Notify += ShowBal;

            account.RegisterHandlerTaken(InfoTaken);
            account.RegisterHandlerAdded(InfoTaken);
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
            Balance.Text = $"Текущий баланс - {account.Sum} R";
        }

        void InfoTaken(string s)
        {
            logField.Text += $"{s}\n";
        }
    }
}