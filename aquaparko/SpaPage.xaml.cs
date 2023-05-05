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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace aquaparko
{
    /// <summary>
    /// Логика взаимодействия для SpaPage.xaml
    /// </summary>
    public partial class SpaPage : Page, INotifyPropertyChanged
    {
        public string FIO { get; }
        private readonly User user;
        public string CountView { get; set; }

        public List<Sauna> Saunas { get; set; }
        public Sauna SelectedSauna { get; set; }
        public List<string> Sorting { get; set; } = new List<string>() { "Без сортировки", "Сортировка по убыванию цены", "Сортировка по возрастанию цены" };

        public Visibility IsAdminVisibility { get; set; } = Visibility.Visible;
        private int selectedSorting;
        private string searchText = "";

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public int SelectedSorting
        {
            get => selectedSorting;
            set
            {
                selectedSorting = value;
                Search();
            }
        }

        public string SearchText
        { 
            get => searchText; 
            set 
            { 
                searchText = value;
                Search();
            } 
        }

        public SpaPage(User user)
        {
            this.user = user;
            InitializeComponent();
            DataContext = this;
            Search();
            FIO = $"{user.FirstName} {user.LastName} {user.SurName}";

            IsAdminVisibility =
                user.RoleId == 1 ?
                Visibility.Visible :
                Visibility.Collapsed;
        }

        private void Search()
        {
            var result = DataBase.Instance.Saunas.Where(s => s.Title.Contains(searchText));
            if (selectedSorting == 1)
                result = result.OrderByDescending(s => s.Price);
            if (selectedSorting == 2)
                result = result.OrderBy(s => s.Price);
            Saunas = result.ToList();
            Signal(nameof(Saunas));

            CountView = $"Записей: {Saunas.Count} из {DataBase.Instance.Saunas.Count()}";
            Signal(nameof(CountView));
        }

        private void RemoveSpa(object sender, RoutedEventArgs e)
        {
            if (SelectedSauna != null)
            {
                if (MessageBox.Show("Удалить выбранную сауну из списка?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    DataBase.Instance.Saunas.Remove(SelectedSauna);
                    DataBase.Instance.SaveChanges();
                    Search();
                }
            }
        }

        private void EditSpa(object sender, RoutedEventArgs e)
        {
            if (SelectedSauna != null)
            {
                new RedakSpa(SelectedSauna).ShowDialog();
                Search();
            }
        }

        private void AddSpa(object sender, RoutedEventArgs e)
        {
            new RedakSpa(new Sauna()).ShowDialog();
            Search();
        }

        private void EditSpa(object sender, MouseButtonEventArgs e)
        {
            if (user.RoleId != 1)
            {
                return;
            }
            if (SelectedSauna != null)
            {
                new RedakSpa(SelectedSauna).ShowDialog();
                Search();
            }
        }
    }
}
