using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModels;

namespace Calculator.Wpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для Regin.xaml
    /// </summary>
    public partial class Regin : Page
    {
        private readonly MainWindow win;
        private readonly DataViewModel model;

        public Regin(MainWindow win)
        {
            InitializeComponent();
            this.win = win;
            if (DataContext is DataViewModel model)
            {
                this.model = model;
                DataViewModel.ReginOk.Action = () => win.MainFrame.Navigate(MainWindow.Login!);
            }
            else throw new Exception();
        }

        private void PassBox_PasswordChanged(object sender, RoutedEventArgs e) => model.Pass = PassBox.Password;

        private void ConfPassBox_PasswordChanged(object sender, RoutedEventArgs e) => model.ConfPass = ConfPassBox.Password;
    }
}
