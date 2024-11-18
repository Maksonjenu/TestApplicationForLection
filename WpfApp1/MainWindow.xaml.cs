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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> ListOfInt = new List<int>();

        public MainWindow()
        {
            InitializeComponent();

            ListBoxBox.Items.Add("string 1"); //0
            ListBoxBox.Items.Add("string 2"); //1

            Button btn = new Button();

            btn.Content = "AAA";
            btn.Height = 25;
            btn.Width = 80;

            btn.Click += Button_Click;
            btn.Click += Button_Click_Another;

            ListBoxBox.Items.Add(btn); //3

            ListOfInt.Add(5);
            ListOfInt.Add("123");
            //   весь код 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string input = InputTextBox.Text;

            input += $" {(sender as Button).Content}";

            MessageBox.Show($"Вы ввели: {input}");
        }

        private void Button_Click_Another(object sender, RoutedEventArgs e)
        {

            MessageBox.Show($"Вы ввели: Combo");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            ListBoxBox.Items.Remove(ListBoxBox.SelectedItem);
        }

        private void RemoveText(object sender, RoutedEventArgs e)
        {
            
            InputTextBox.Clear(); // круче

        }

        private void ComboBoxBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            

            //a.Items.Remove(a.SelectedItem);
            //ComboBoxBox.Items.RemoveAt(ComboBoxBox.SelectedIndex);
        }
    }
}