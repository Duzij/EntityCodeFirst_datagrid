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
using MahApps.Metro.Controls;

namespace EntityFramework_CodeFirst_Datagrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public DbOrdersContext MyOrders = new DbOrdersContext();

        public MainWindow()
        {
            InitializeComponent();
            ShowGrid1();
            //this.GetRandomData();
        }

        public void GetRandomData()
        {
            Order order1 = new Order(0, "John", "Lemon", "London");
            Order order2 = new Order(1, "John", "Smith", "New York");
            Order order3 = new Order(2, "John", "Lemon", "London");
            Order order4 = new Order(3, "John", "Lemon", "London");
            Order order5 = new Order(4, "John", "Lemon", "London");
            Order order6 = new Order(5, "John", "Lemon", "London");
            Order order7 = new Order(6, "John", "Lemon", "London");
            Order order8 = new Order(7, "John", "Lemon", "London");
            Order order9 = new Order(8, "John", "Lemon", "London");
            Order order10 = new Order(9, "Petr", "Filip", "Prague");

            //MyOrders.OurOrders.Add(order1);
            //MyOrders.OurOrders.Add(order2);
            //MyOrders.OurOrders.Add(order3);
            //MyOrders.OurOrders.Add(order4);
            MyOrders.OurOrders.Add(order5);
            MyOrders.OurOrders.Add(order6);
            MyOrders.OurOrders.Add(order7);
            MyOrders.OurOrders.Add(order8);
            MyOrders.OurOrders.Add(order9);
            MyOrders.OurOrders.Add(order10);


            SpecialOrder Spec_order1 = new SpecialOrder(true, 0, "John", "Lemon", "London");
            SpecialOrder Spec_order2 = new SpecialOrder(true, 1, "John", "Smith", "New York");
            SpecialOrder Spec_order3 = new SpecialOrder(false, 2, "John", "Lemon", "London");
            SpecialOrder Spec_order4 = new SpecialOrder(true, 3, "John", "Lemon", "London");
            SpecialOrder Spec_order5 = new SpecialOrder(false, 4, "John", "Cena", "Universe");
            SpecialOrder Spec_order6 = new SpecialOrder(false, 5, "John", "Lemon", "London");
            SpecialOrder Spec_order7 = new SpecialOrder(true, 6, "John", "Lemon", "London");
            SpecialOrder Spec_order8 = new SpecialOrder(true, 7, "John", "Lemon", "London");
            SpecialOrder Spec_order9 = new SpecialOrder(true, 8, "John", "Lemon", "London");
            SpecialOrder Spec_order10 = new SpecialOrder(true, 9, "Petr", "Filip", "Prague");

            //MyOrders.OurSpecialOrders.Add(Spec_order1);
            //MyOrders.OurSpecialOrders.Add(Spec_order2);
            //MyOrders.OurSpecialOrders.Add(Spec_order3);
            //MyOrders.OurSpecialOrders.Add(Spec_order4);
            //MyOrders.OurSpecialOrders.Add(Spec_order5);
            MyOrders.OurSpecialOrders.Add(Spec_order6);
            MyOrders.OurSpecialOrders.Add(Spec_order7);
            MyOrders.OurSpecialOrders.Add(Spec_order8);
            MyOrders.OurSpecialOrders.Add(Spec_order9);
            MyOrders.OurSpecialOrders.Add(Spec_order10);

        }

        private void FirstTabButton_GotFocus(object sender, RoutedEventArgs e)
        {
            ShowGrid1();
        }
        private void ShowGrid1()
        {
            dataGrid2.Visibility = Visibility.Hidden;
            dataGrid.Visibility = Visibility.Visible;
            foreach (Order order in this.MyOrders.Set<Order>())
            {
            }
            
            this.dataGrid.ItemsSource = this.MyOrders.Set<Order>().Local;
        }
        private void SecondTabButton_GotFocus(object sender, RoutedEventArgs e)
        {
            ShowGrid2();
        }
        private void ShowGrid2()
        {
            dataGrid2.Visibility = Visibility.Visible;
            dataGrid.Visibility = Visibility.Hidden;
            foreach (SpecialOrder special_order in this.MyOrders.Set<SpecialOrder>())
            {
            }
            this.dataGrid2.ItemsSource = this.MyOrders.Set<SpecialOrder>().Local;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MyOrders.SaveChanges();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (dataGrid.IsEnabled)
                {
                    for (int i = 0; i < dataGrid.Items.Count - 1; i++)
                    {
                        Order a = (Order)dataGrid.Items[i];

                        if (a.OrderNumber.ToString() == txtbx_search.Text)
                        {
                            this.dataGrid.SelectedIndex = i;
                            MessageBox.Show("datagrid found the value", "", MessageBoxButton.OK);
                            break;
                        }
                    }
                }

                if (dataGrid2.IsEnabled)
                {
                    for (int i = 0; i < dataGrid.Items.Count - 1; i++)
                    {
                        SpecialOrder a = (SpecialOrder)dataGrid2.Items[i];

                        if (a.OrderNumber.ToString() == txtbx_search.Text)
                        {
                            this.dataGrid2.SelectedIndex = i;
                            SpecialOrder b = (SpecialOrder)dataGrid2.Items[i];
                            b.SpecialToken = false;
                            MessageBox.Show("datagrid found the value", "", MessageBoxButton.OK);
                            MyOrders.SaveChanges();
                            break;
                        }
                    }
                }
            }
        }

        private void txtbx_search_GotFocus(object sender, RoutedEventArgs e)
        {
            this.txtbx_search.Text = "";
        }

        private void txtbx_search_LostFocus(object sender, RoutedEventArgs e)
        {
            this.txtbx_search.Text = "Search...";
        }
    }
}
