using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using CalculationModule;

namespace ViewModels
{
   public class MainViewModel:ViewModelBase
    {
        private Calculations calc = new Calculations();

        private string display = "0";
        public string Display
        {
            get => display;
            private set
            {
                display = value;
                OnPropertyChanged("Display");
                DotPress.RaiseCanExecuteChanged();
                Backspace.RaiseCanExecuteChanged();
            }
        }

        private string info = "";
        public string Info
        {
            get => info;
            private set
            {
                info = value;
                OnPropertyChanged("Info");
            }
        }
        public string Dot => CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        private string lastOperation = "";

        public Command <string> DigitPress { get; }
        public Command <string> Operation { get; }
        public Command PlusMinus { get; }
        public Command DotPress { get; }
        public Command Backspace { get; }
        


        public MainViewModel()
        {
            DigitPress = new Command<string>(digitPress);
            PlusMinus = new Command(plusMinus);
            DotPress = new Command(() => Display += Dot, () => !display.Contains(Dot));
            Backspace = new Command(backspace, () => display != "0");
            Operation = new Command<string>(operation);
            
        }

        private void operation(string obj)
        {
            if (obj == lastOperation) return;
            bool old = calc.IsAtomar;
            calc = new Calculations()
            {
                FirstOperand = display,
                Operation = obj
            };
            if (!string.IsNullOrEmpty(lastOperation))
            {
                if (old)
                {
                    if (calc.IsAtomar) Info = info.Replace(lastOperation, obj);
                    else Info = info.Remove(0, info.IndexOf('(')).TrimEnd(')');
                    lastOperation = obj;
                }
            }
        }

        private void backspace()
        {
            if (display == "-0") Display = "0";
            else if (display[0] == '-' && display.Length == 2 || display.Length == 1) Display = display.Remove(display.Length - 1) + "0";
            else Display = display.Remove(display.Length - 1);
        }

        private void plusMinus()
        {
            if (display[0] == '-') Display = display.Remove(0, 1);
            else Display = "-" + display;
        }


        private void digitPress(string digit)
        {
            if (display == "0" || display == "-0")
            {
                Display = display.Replace("0", digit);
            }
            else Display = display + digit;
        }
    }
}
