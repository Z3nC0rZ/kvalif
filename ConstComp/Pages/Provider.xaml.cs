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

namespace ConstComp.Pages
{
    /// <summary>
    /// Логика взаимодействия для Providers.xaml
    /// </summary>
    public partial class Provider : Page
    {
        public Provider()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ProvsGrid.ItemsSource = AppData.db.Providers.ToList();
        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var currentprov = ProvsGrid.SelectedItem as Providers;
                AppData.db.Providers.Remove(currentprov);
                AppData.db.SaveChanges();

                ProvsGrid.ItemsSource = AppData.db.Providers.ToList();
                MessageBox.Show("Запись была удалена");
            }
        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            Providers company = new Providers();

            company.Поставщик = txtprovider.Text;
            company.Адрес = txtaddres.Text;
            company.Телефон = txtphone.Text;

            AppData.db.Providers.Add(company);
            AppData.db.SaveChanges();
            MessageBox.Show("Поставщик был добавлен в базу");
        }
    }
}
