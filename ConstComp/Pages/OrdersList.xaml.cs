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
    /// Логика взаимодействия для OrderList.xaml
    /// </summary>
    public partial class OrdersList : Page
    {
        public OrdersList()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            OrderGrid.ItemsSource = AppData.db.Order_list.ToList();
        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            Order_list order = new Order_list();

            order.Адрес_объекта = txtaddres.Text;
            order.Дата_сдачи = txtdate.Text;
            order.Номер_клиента = txtnumber.Text;
            order.ФИО_клиента = txtname.Text;

            AppData.db.Order_list.Add(order);
            AppData.db.SaveChanges();
            MessageBox.Show("Проект был добавлен в базу");
        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var currentorder = OrderGrid.SelectedItem as Order_list;
                AppData.db.Order_list.Remove(currentorder);
                AppData.db.SaveChanges();

                OrderGrid.ItemsSource = AppData.db.Order_list.ToList();
                MessageBox.Show("Запись была удалена");
            }
        }
    }
}
