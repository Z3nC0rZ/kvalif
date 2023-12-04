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
using ConstComp.DBase;
using ConstComp.Pages;

namespace ConstComp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnmaterials_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Material());
        }

        private void btnorderlist_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrdersList());
        }

        private void btnproviders_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Provider());
        } 

        private void btnstaff_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Stafff());
        }
    }
}
