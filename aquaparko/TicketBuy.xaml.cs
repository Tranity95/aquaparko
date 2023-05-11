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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace aquaparko
{
    /// <summary>
    /// Логика взаимодействия для TicketBuy.xaml
    /// </summary>
    public partial class TicketBuy : Page
    {
        public DateTime Today { get; set; }
        
        public DateTime SelectedDate { get; set; }
        public Visibility IsAdminVisibility { get; set; } = Visibility.Visible;

        public User User { get; set; }

        public TicketBuy(User user)
        {
            InitializeComponent();
            Today = DateTime.Now;
            this.DataContext = this;
            User = user;
            SelectedDate = DateTime.Now;
            IsAdminVisibility =
                user.RoleId == 1 ?
                Visibility.Visible :
                Visibility.Collapsed;

        }
        private void Buying(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Билет успешно забронирован!");
                DataBase.GetInstance().Tickets.Add(new Ticket { UserId = this.User.Id, Date = SelectedDate });
                DataBase.GetInstance().SaveChanges();
        }

        private void GoTickets(object sender, RoutedEventArgs e)
        {
            new TicketsList(User).Show();
        }

        private void MyTickets(object sender, RoutedEventArgs e)
        {
            new MyTickets(User).Show();
        }
    }
}
