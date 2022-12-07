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
using System.Globalization;
using ViewModels;
using Calculator.Wpf.Pages;

namespace Calculator.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Login Login;
        public static Regin Regin;

        public MainWindow()
        {
            MainViewModel.ErrorHundler = new ErrorHundler();
            InitializeComponent();
            OpenPage(WorkPage.Login);
        }

        private void OpenPage(WorkPage page)
        {
            switch (page)
            {
                case WorkPage.Main:
                    MainFrame.Navigate(new MainPage(this));
                    break;
                case WorkPage.Login:
                    if (Login is null) Login = new Login(this);
                    MainFrame.Navigate(Login);
                    break;
            }
        }
    }
}
