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

namespace aquaparko
{
    /// <summary>
    /// Логика взаимодействия для Forgot.xaml
    /// </summary>
    public partial class Forgot : Window
    {
        private User user;
        public string Code { get; set; }
        public string Po4ta { get; set; }
        private string codo;
        public Forgot()
        {
            InitializeComponent();
            DataContext = this;
            
        }

        public string Generating()
        {
            Random rnd = new Random();
            string result = "";
            result += rnd.Next(10000);
            return result;
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            user = DataBase.Instance.Users.ToList().FirstOrDefault(s => s.Login == Po4ta);
            if(user == null)
            {
                MessageBox.Show("Такой почты не существует!");
                return;
            }
            codo = Generating();
            new Code(codo).ShowDialog();
        }

        private void ConfirmCode(object sender, RoutedEventArgs e)
        {

            if (Code == codo)
            {
                new YourPassword(user).ShowDialog();
                Close();
            }
            else
                MessageBox.Show("Неверный код!");
        }

        private void BackTo(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
