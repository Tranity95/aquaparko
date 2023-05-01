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

        public List<Sauna> Spas { get; set; }
        public Sauna SelectedSpa { get; set; }
        public List<string> Sorting { get; set; } = new List<string>() { "Без сортировки", "Сортировка по убыванию", "Сортировка по возрастанию" };

        public Visibility IsAdminVisibility = Visibility.Visible;
        private int selectedSorting;
        private string searchText;

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public int SelectedSorting
        {
            get => selectedSorting;
            set
            {
                selectedSorting = value;

            }
        }

        public string SearchText
        { get => searchText; 
          set 
            { 
                searchText = value;
                
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
                result = result.OrderByDescending(s => s.Title);
            if (selectedSorting == 2)
                result = result.OrderBy(s => s.Title);
            Spas = result.ToList();
            Signal(nameof(Spas));

            CountView = $"Записей: {Spas.Count} из {DataBase.Instance.Saunas.Count()}";
            Signal(nameof(CountView));
        }

        private void RemoveSlide(object sender, RoutedEventArgs e)
        {

        }

        private void EditSlide(object sender, RoutedEventArgs e)
        {

        }

        private void AddSlide(object sender, RoutedEventArgs e)
        {

        }

    }
}
