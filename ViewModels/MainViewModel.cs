using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using CalculationsModel;
using DataModels;
using DataModels.Entities;
using System.Collections.ObjectModel;

namespace ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        internal static readonly DataManager Data = DataManager.Get(DataProvider.SqLite);

        private Calculations model = new Calculations();
        public static IErrorHundler? ErrorHundler { internal get; set; }

        string display = "0";
        public string Display
        {
            get => display;

            set
            {
                if (value.Length>18)
                {
                    value = value.Remove(18);
                }
                display = value;
                OnPropertyChanged("Display");
                BackSpace.RaiseCanExecuteChanged();
                DotPress.RaiseCanExecuteChanged();
            }

        }
         


        void SetInfo()
        {
            if(string.IsNullOrEmpty(lastOperation))
            {
                Info = Display;
                return;
            }
            if(model.IsAtomar)
            {
                Info = lastOperation + "(" + display + ")";
                return;
            }
            Info += $" {lastOperation} {display}";
            Display = "0";
        }

        string info = "";
        public string Info
        {
            get => info;
            set
            {
                info = value;
                OnPropertyChanged("Info");
                EqualPress.RaiseCanExecuteChanged();

                
            }
        }
        string lastOperation = "";
        string LastOperation
        {
            get => lastOperation;
            set
            {
                
            }
        }

        public string Dot => CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        public  Command<string> DigitPress { get; }
        public  Command<string> OperationPress { get; }
        public  Command BackSpace { get; }
        public  Command PlusMinus { get; }
        public  Command DotPress { get; }
        public  Command EqualPress { get; }
        public  Command CPress { get; }


        public MainViewModel()
        {
            DigitPress = new Command<string>(digitPress);
            OperationPress = new Command<string>(operationPress);
            BackSpace = new Command(backSpace, () => Display != "0");
            PlusMinus = new Command(() =>
            Display = Display[0] == '-' ? Display.Remove(0, 1) : '-' + Display) ;
            DotPress = new Command(()=> Display += Dot, ()=> !Display.Contains(Dot));
            EqualPress = new Command(equalPress, () => lastOperation.Length > 0, ErrorHundler!);
            CPress = new Command(cPress);
        }

        private void cPress()
        {
            model = new Calculations();
            lastOperation = "";
            Info = "";
            Display = "0";
        }

        private void equalPress()
        {
            if(!model.IsAtomar)
            {
                model.SecondOperand = display;
                Info = model.FirstOperand + " " +model.Operation+ " "+ display;
            }
            
            model.Calculate();
            Info = $"{Info} = {model.Result}";
            Display = model.Result;
            lastOperation = "";

        }

        private void operationPress(string obj)
        {
            if(lastOperation==obj)
            {
                return;
            }
            if(Info.Contains("="))
            {
                Info = display;
                
            }
            var old = lastOperation;
            bool oldIsAtomar = model.IsAtomar;
            lastOperation = obj;
            
            model = new Calculations(display, "0", obj);

            if (model.IsAtomar)
            {
                if(oldIsAtomar)
                {
                    Info = Info.Replace(old, model.Operation);
                    Display = "0";
                    return;
                }
                if(string.IsNullOrEmpty (old))
                {
                    Info = $"{model.Operation}({display})";
                    Display = "0";
                    return;
                }
                Info = model.Operation+ "("+Info.Replace(old, "").TrimEnd() + ")";
                Display = "0";
                return;

            }
            if (string.IsNullOrEmpty(old))
            {
                Info = display + " " + model.Operation;
                Display = "0";
                return;
            }
            if(oldIsAtomar)
            {
                Info = Info.Replace(old, "").Trim('(', ')')+" "+ model.Operation;
                Display = "0";
                return;
            }
            
            Info = Info.Replace(old, "").Trim() + " " + model.Operation;
            Display = "0";

        }

        private void backSpace()
        {
            if (Display == "-0" ||
                (Display[0] == '-' && Display.Length == 2) ||
                Display.Length == 1)
            {
                Display = "0";
                return;
            }
            Display = Display.Remove(Display.Length - 1);    
        }

        private void digitPress(string obj)
        {
            if(Display=="0" || Display=="-0")
            {
                Display = Display.Trim('0') + obj;
            }
            else
            {
                Display = Display + obj;
            }
        }
    }
}
