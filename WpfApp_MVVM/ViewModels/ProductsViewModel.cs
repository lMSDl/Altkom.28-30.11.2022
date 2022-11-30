using Models;
using Models.Fakers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp_MVVM.Commands;
using WpfApp_MVVM.Views;

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

            Products = new ObservableCollection<Product>();

            //ShowDetailsCommand = new ShowDetailsCommand();
            ShowDetailsCommand = new RelayCommand(
                param => MessageBox.Show($"Data przydatności: {SelectedProduct!.ExpirationDate}"),
                param => SelectedProduct != null);

            DeleteCommand = new RelayCommand(
                param => Products.Remove((Product)param),
                param => param as Product != null);

            AddOrEditCommand = new RelayCommand(x => AddOrEdit((Product?)x));
            LoadCommand = new RelayCommand(async x => await LoadAsync(),
                           x => !Products.Any());
        }

        private async Task LoadAsync()
        {
            await Task.Delay(5000);
            new ProductFaker().Generate(5).ForEach(xx => Products.Add(xx));
        }


        //public ShowDetailsCommand ShowDetailsCommand { get; }
        public ICommand ShowDetailsCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand AddOrEditCommand { get; }
        public ICommand LoadCommand { get; }

        private void AddOrEdit(Product product)
        {
            var vm = new ProductViewModel(product);
            var result = new ProductView(vm).ShowDialog();
            if (result != true)
                return;

            if(product != null)
            {
                Products.Remove(product);
            }
                
            Products.Add(vm.Product!);

        }
    }
}
