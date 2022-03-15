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

namespace Uch
{
    /// <summary>
    /// Логика взаимодействия для PageProduct.xaml
    /// </summary>
    public partial class PageProduct : Page
    {
        LoadList LoadS = new LoadList();
        List<Product> ls;
        public PageProduct(int i)
        {
            InitializeComponent();
            LoadS = new LoadList(1);
            ServiceList.ItemsSource = LoadS.product;
            ls = LoadS.product;
            DiscountCB.SelectedIndex = 0;

        }

        public PageProduct()
        {
            InitializeComponent();
            ServiceList.ItemsSource = LoadS.product;
            ls = LoadS.product;
            DiscountCB.SelectedIndex = 0;


        }

        private void EditService_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button IdBtn = (Button)sender;      //считываем нажатую кнопку
                int id = Convert.ToInt32(IdBtn.Uid); //получаем id сервиса
                Product ServicesRemove = BaseConnect.BaseModel.Product.FirstOrDefault(x => x.Id_service == id); //находим в таблице
                BaseConnect.BaseModel.Product.Remove(ServicesRemove);  // удаляем
                BaseConnect.BaseModel.SaveChanges(); //сохраняем
                LoadS = new LoadList(); //обновляем
                MessageBox.Show("Запись успешно удалена.");
                filter();
            }
            catch
            {
                MessageBox.Show("Присутствует запись на данную услугу.\nДанную запись нельзя удалить.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        int zap, Cost = 0, CostRevers = 0;
        void filter()
        {

            ls = LoadS.product;
            zap = ls.Count;
            try
            {
                if (Cost == 1) //сортировка по цене
                {

                    ls = ls.OrderBy(x => x.newcost).ToList();
                    if (CostRevers == 1)
                    {
                    }
                    else
                    {
                        ls.Reverse();

                    }
                }
            }
            catch { }

         
            try
            {
                ls = ls.Where(x => x.Name_of_the_service.Contains(SearchBarTxt.Text)).ToList(); //поисковая строка
            }
            catch
            { }
            ServiceList.ItemsSource = ls;		//обновление отображения на странице
            info();
        }

        /// <summary>
        /// Метод вывод кол-ва записей на странице
        /// </summary>
        void info()
        {
            kol_voZap.Text = "Записей на странице: " + ls.Count + " из " + zap;
        }

        private void NewZapis_Click(object sender, RoutedEventArgs e)
        {

        }

        private void autorizBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddService_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextZap_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CostSortBtn_Click(object sender, RoutedEventArgs e)
        {
            CostRevers *= -1;
            Cost = 1;
            if (CostRevers == 1)
            {
                CostSortBtn.Content = "Цене возраст.";
            }
            else
            {
                CostSortBtn.Content = "Цене убыв.";
            }
            filter();


        }

        private void SearchBarTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            filter();

        }

        private void DiscountCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filter();
        }
    }
    
}
