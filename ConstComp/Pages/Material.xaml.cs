using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
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
    /// Логика взаимодействия для Materials.xaml
    /// </summary>
    public partial class Material : Page
    {
        public Material()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MatsGrid.ItemsSource = AppData.db.Materials.ToList();
        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var currentmats = MatsGrid.SelectedItem as Materials;
                AppData.db.Materials.Remove(currentmats);
                AppData.db.SaveChanges();

                MatsGrid.ItemsSource = AppData.db.Materials.ToList();
                MessageBox.Show("Запись была удалена");
            }
        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            Materials company = new Materials();

            company.Название = txtmaterial.Text;
            company.Стоимость = txtcost.Text;
            company.Поставщик = txtprovider.Text;

            AppData.db.Materials.Add(company);
            AppData.db.SaveChanges();
            MessageBox.Show("Материал был добавлен в базу");
        }
    }
}
