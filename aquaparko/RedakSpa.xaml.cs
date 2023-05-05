using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Логика взаимодействия для RedakSpa.xaml
    /// </summary>
    public partial class RedakSpa : Window, INotifyPropertyChanged
    {
        public bool Editable { get; set; }

        public RedakSpa(Sauna selectedSauna)
        {
            InitializeComponent();
            DataContext = this;
            if (selectedSauna.Id == 0 || selectedSauna.Id == null)
            {
                SelectedSauna = selectedSauna;
                Editable = true;
            }
            else
                SelectedSauna = selectedSauna.CloneSauna();
        }
        public Sauna SelectedSauna { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private void SelectPhoto(object sender, RoutedEventArgs e)
        {
            string dir = Environment.CurrentDirectory + @"\images\";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Images|*.png;*.jpg;*.jpeg";
            if (dlg.ShowDialog() == true)
            {
                var test = new BitmapImage(new Uri(dlg.FileName));
                if (test.PixelWidth > 400 || test.PixelWidth > 300)
                {
                    MessageBox.Show("Картинка слшком большая");
                    return;
                }
                string newFile = dir + new FileInfo(dlg.FileName).Name;
                File.Copy(dlg.FileName, newFile, true);
                SelectedSauna.Image = @"\images\" + new FileInfo(dlg.FileName).Name;
                Signal("SelectedSauna");
            }
        }
        private void SaveClose(object sender, RoutedEventArgs e)
        {
            if (SelectedSauna.Id == 0)
                DataBase.Instance.Saunas.Add(SelectedSauna);
            else
            {
                var origin = DataBase.Instance.Saunas.Find(SelectedSauna.Id);
                DataBase.Instance.Entry(origin).CurrentValues.SetValues(SelectedSauna);
            }
            DataBase.Instance.SaveChanges();
            Close();
        }
    }
    public static class SaunaExtension
    {
        public static Sauna CloneSauna(this Sauna sauna)
        {
            var values = DataBase.Instance.Saunas.Entry(sauna).CurrentValues.Clone();
            var clone = (Sauna)values.ToObject();
            return clone;
        }
    }
}
