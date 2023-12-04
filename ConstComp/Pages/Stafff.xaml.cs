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
    /// Логика взаимодействия для Staff.xaml
    /// </summary>
    public partial class Stafff : Page
    {
        public Stafff()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            StaffGrid.ItemsSource = AppData.db.Staff.ToList();
        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            Staff staff = new Staff();

            staff.Фамилия = txtfam.Text;
            staff.Имя = txtname.Text;
            staff.Отчество = txtotch.Text;
            staff.Должность = txtpost.Text;

            AppData.db.Staff.Add(staff);
            AppData.db.SaveChanges();
            MessageBox.Show("Сотрудник был добавлен в базу");
        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var currentstaff = StaffGrid.SelectedItem as Staff;
                AppData.db.Staff.Remove(currentstaff);
                AppData.db.SaveChanges();

                StaffGrid.ItemsSource = AppData.db.Staff.ToList();
                MessageBox.Show("Запись была удалена");
            }
        }
    }
}
