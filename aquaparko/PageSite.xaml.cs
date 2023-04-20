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
    /// Логика взаимодействия для PageSite.xaml
    /// </summary>
    public partial class PageSite : Window
    {
        public User user1 { get; set; }
        public PageSite(User user)
        {
            InitializeComponent();
            this.DataContext = this;
            user1 = user;
            user1.FirstName = user.FirstName;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void GoSlide(object sender, RoutedEventArgs e)
        {

        }

        private void GoMain(object sender, RoutedEventArgs e)
        {
            
        }

        private void GoSpa(object sender, RoutedEventArgs e)
        {

        }

        private void GoFood(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
