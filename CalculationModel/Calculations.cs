using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationModule
{
    public class Calculations
    {
        public string FirstOperand { get; set; } = string.Empty;
        public string SecondOperand { get; set; } = string.Empty;
        public string Operation { get; set; } = string.Empty;
        public string Result { get; protected set; } = string.Empty;

        public Calculations() { }
        public Calculations(string firstOperand, string secondOperand, string operation) 
        {
            CheckOperand(firstOperand);
            CheckOperand(secondOperand);
            CheckOperation(operation);

            FirstOperand = firstOperand;
            SecondOperand = secondOperand;
            Operation = operation;
        }

        public virtual void Calculate()
        {
            CheckOperand(FirstOperand);
            CheckOperand(SecondOperand);
            CheckOperation(Operation);
     
            try
            {
                switch (Operation)
                {
                    case "+":
                        Result = (Convert.ToDouble(FirstOperand) + Convert.ToDouble(SecondOperand)).ToString();
                        break;
                    case "-":
                        Result = (Convert.ToDouble(FirstOperand) - Convert.ToDouble(SecondOperand)).ToString();
                        break;
                    case "*":
                        Result = (Convert.ToDouble(FirstOperand) * Convert.ToDouble(SecondOperand)).ToString();
                        break;
                    case "/":
                        Double secondOperand = Convert.ToDouble(SecondOperand);
                        if (secondOperand == 0)
                        {
                            Result = "Error: Division by zero";
                            throw new DivideByZeroException();
                        }

                        Result = (Convert.ToDouble(FirstOperand) + secondOperand).ToString();
                        break;
                }
            }
            catch
            {
                Result = "Unknown Error";
                throw;
            }
        }
        protected virtual void CheckOperation(string operation)
        {
            switch(operation)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    break;
                default:
                    Result = "Operation Error";
                    throw new ArgumentException(Result);
            }
        }

        protected virtual void CheckOperand(string operand)
        {
            try
            {
                Convert.ToDouble(operand);
            }
            catch
            {
                Result = "Operand Error";
                throw;
            }
        }
    }
}
