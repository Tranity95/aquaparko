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
    /// Логика взаимодействия для TicketsList.xaml
    /// </summary>
    public partial class TicketsList : Window, INotifyPropertyChanged
    {
        private int selectedSorting;
        private string searchText="";

        public string CountView { get; set; }
        public User User { get; }
        public List<Ticket> Tickets { get; set; }
        public Ticket SelectedTicket { get; set; }
        public List<string> Sorting { get; set; } = new List<string>() { "Без сортировки", "По фамилии (убыванию)", "По фамилии (возрастанию)", "По дате (убыванию)", "По дате (возрастанию)" };



        public TicketsList(User user)
        {
            this.User = user;
            InitializeComponent();
            DataContext = this;
            Search();
        }

        private void Search()
        {
            var result = DataBase.Instance.Tickets.Include(s => s.User).Where(s => s.User.LastName.Contains(searchText));
            if (selectedSorting == 1)
                result = result.OrderByDescending(s => s.User.LastName);
            if (selectedSorting == 2)
                result = result.OrderBy(s => s.User.LastName);
            if (selectedSorting == 3)
                result = result.OrderByDescending(s => s.Date);
            if (selectedSorting == 4)
                result = result.OrderBy(s => s.Date);
            Tickets = result.ToList();
            Signal(nameof(Tickets));

            CountView = $"Записей: {Tickets.Count} из {DataBase.Instance.Tickets.Count()}";
            Signal(nameof(CountView));
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

        public int SelectedSorting
        {
            get => selectedSorting;
            set
            {
                selectedSorting = value;
                Search();
            }
        }

        private void RemoveTicket(object sender, RoutedEventArgs e)
        {
            if (SelectedTicket != null)
            {
                if (MessageBox.Show("Удалить выбранный билет из базы данных?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    DataBase.Instance.Tickets.Remove(SelectedTicket);
                    DataBase.Instance.SaveChanges();
                    Search();
                }
            }
        }

        private void Closing(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
