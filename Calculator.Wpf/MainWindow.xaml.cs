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
        private static MainPage mainPage;
        public static MainPage MainPage(MainWindow main) => mainPage == null ? new MainPage(main) : mainPage;

        private static Login login;
        public static Login Login(MainWindow main)
        {
            if (login == null)
            {
                login = new Login(main);
                Data.LoginOk = () => 
                {
                    main.MainFrame.Navigate(MainPage(main), DataViewModel.SelectedId);
                };
            }
            return login;
        }

        private static Regin regin;
        public static Regin Regin(MainWindow win)
        {
            if (regin == null)
            {
                regin = new Regin(win);
                Data.ReginOk = () =>
                    win.MainFrame.Navigate(Login(win));
            }
            return regin;
        }

        private static DataViewModel data;
        public static DataViewModel Data
        {
            get
            {
                data = data ?? new DataViewModel();
                return data;
            }
        }

        public MainWindow()
        {
            MainViewModel.ErrorHundler = new ErrorHundler();
            InitializeComponent();
            MainFrame.Navigate(Login(this));
        }
    }
}
