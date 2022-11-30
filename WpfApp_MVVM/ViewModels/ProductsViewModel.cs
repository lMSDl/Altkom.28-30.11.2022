using Models;
using Models.Fakers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp_MVVM.Commands;

namespace WpfApp_MVVM.ViewModels
{
    public class ProductsViewModel
    {
        private Product? selectedProduct;

        public ObservableCollection<Product> Products { get; }
        public Product? SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                //ShowDetailsCommand.Product = value;

            }
        }

        public ProductsViewModel()
        {

            Products = new ObservableCollection<Product>(new ProductFaker().Generate(5));

            //ShowDetailsCommand = new ShowDetailsCommand();
            ShowDetailsCommand = new RelayCommand(
                param => MessageBox.Show($"Data przydatności: {SelectedProduct!.ExpirationDate}"),
                param => SelectedProduct != null);

            DeleteCommand = new RelayCommand(
                param => Products.Remove((Product)param),
                param => param as Product != null);
        }

        //public ShowDetailsCommand ShowDetailsCommand { get; }
        public ICommand ShowDetailsCommand { get; }
        public ICommand DeleteCommand { get; }
    }
}
