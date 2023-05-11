using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для MyTickets.xaml
    /// </summary>
    public partial class MyTickets : Window, INotifyPropertyChanged
    {
        private int selectedSorting;
        private string searchText = "";

        public List<Ticket> Tickets { get; set; }
        public Ticket SelectedTicket { get; set; }
        public List<string> Sorting { get; set; } = new List<string>() { "Без сортировки", "Сортировка по дате (убыванию)", "Сортировка по дате (возрастанию)" };

        public User User { get; }
        public MyTickets(User user)
        {
            this.User = user;
            InitializeComponent();
            DataContext = this;
            Tickets = DataBase.Instance.Tickets.Include(s => s.User).Where(s => s.UserId == User.Id).ToList();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public string SearchText 
        { 
            get => searchText; 
            set 
            { 
                searchText = value;
                Search();
            }
        }

        private void Search()
        {
            var result = DataBase.Instance.Tickets.Where(s => true);
            int.TryParse(SearchText, out int dateSearch);
            if (dateSearch > 0)
                result = result.Where(s => s.Date.Value.Year == dateSearch || s.Date.Value.Month == dateSearch || s.Date.Value.Day == dateSearch);
            if (selectedSorting == 1)
                result = result.OrderByDescending(s => s.Date);
            if (selectedSorting == 2)
                result = result.OrderBy(s => s.Date);
            Tickets = result.ToList();
            Signal(nameof(Tickets));

        }

        public int SelectedSorting
        {
            get => selectedSorting;
            set
            {
                selectedSorting = value;
                Search();
            }
        }

        private void RemoveTicketo(object sender, RoutedEventArgs e)
        {
            if (SelectedTicket != null)
            {
                if (MessageBox.Show("Удалить выбранную бронь из списка?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    DataBase.Instance.Tickets.Remove(SelectedTicket);
                    DataBase.Instance.SaveChanges();
                    Search();
                }
            }
        }
    }
}
