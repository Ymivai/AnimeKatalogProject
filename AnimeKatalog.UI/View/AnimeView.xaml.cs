using AnimeKatalog.UI.Infrastructure;
using Infralution.Localization.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace AnimeKatalog.UI.View
{
    /// <summary>
    /// Interaction logic for AnimeView.xaml
    /// </summary>
    public partial class AnimeView : Window
    {
        public AnimeView()
        {
            InitializeComponent();

        }

        private void addButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (Languge.Content == "EU")
            {
                CultureManager.UICulture = new CultureInfo("ru-RU");
                Languge.Content = "Ru";
            }
            else
            {
                CultureManager.UICulture = new CultureInfo("EU");
                Languge.Content = "EU";
            }
        }

        private void OpenWatch(object sender, RoutedEventArgs e)
        {
            if (SingleSelected.AnimeSelected != null)
            {
                InfoAnimeView win2 = new InfoAnimeView();
                win2.ShowDialog();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminViewModel win2 = new AdminViewModel();
            win2.ShowDialog();
        }
    }
}
