using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
   public class MainViewModel:ViewModelBase
    {
        private string display = "lopata";
        public string Display
        {
            get => display;
            private set
            {
                display = value;
                OnPropertyChanged("Display");
            }
        }
    }
}
