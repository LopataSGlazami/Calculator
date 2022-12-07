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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private readonly MainWindow win;
        private readonly DataViewModel model;

        public Login(MainWindow win, string nick = "")
        {
            InitializeComponent();
            this.win = win;
            if (DataContext is DataViewModel model)
            {
                this.model = model;
                if (!string.IsNullOrEmpty(nick)) model.SelectedName = nick;
            }
            else throw new Exception();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Regin is null) MainWindow.Regin = new Regin(win);
            win.MainFrame.Navigate(MainWindow.Regin);
        }

        private void PassBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            model.Pass = PassBox.Password;
        }
    }
}
