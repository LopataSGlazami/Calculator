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
using System.Linq;
using ViewModels;
using DataModels.Entities;

namespace Calculator.Wpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private readonly MainWindow win;
        private readonly MainViewModel model;
        private readonly Guid id;

        public MainPage(MainWindow win, Guid? id = null)
        {
            InitializeComponent();
            this.win = win;
            if (DataContext is MainViewModel model)
            {
                this.model = model;
                if (id == null) this.id = User.GustGuid;
                else
                {
                    this.id = id.Value;
                }
            }
            else throw new Exception();
            Title = id.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new HistoryWindow().ShowDialog();
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            win.MainFrame.Navigate(MainWindow.Login(win));
        }
    }
}
