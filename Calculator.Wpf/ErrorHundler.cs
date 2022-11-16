using System;
using System.Collections.Generic;
using System.Text;
using ViewModels;
using System.Windows;
namespace Calculator.Wpf
{
    class ErrorHundler : IErrorHundler
    {
        public void ErrorHundle(Exception e)
        {
           if(e is DivideByZeroException)
           {
                MessageBox.Show(e.Message, "/0", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

               
           }

           if(e is OverflowException)
           {
                MessageBox.Show("Слишком большое число", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
           }

            MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
