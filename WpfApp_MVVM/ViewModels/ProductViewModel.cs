using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp_MVVM.Commands;

namespace WpfApp_MVVM.ViewModels
{
    public class ProductViewModel
    {

        public Product Product { get; }

        public ProductViewModel(Product? product)
        {
            Product = (Product)product?.Clone() ?? new Product();

            OkCommand = new RelayCommand(x => Ok((Window)x), x => !Product.HasErrors);
        }

        public ICommand OkCommand { get; }

        private void Ok(Window window)
        {
            window.DialogResult = true;
        }
    }
}
