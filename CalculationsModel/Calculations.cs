using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationsModel
{
    public class Calculations
    {
        public string FirstOperand { get; set; } = "";
        public string SecondOperand { get; set; } = "";
        public string Operation { get; set; } = "";
        public string Result { get; private set; } = "";

        public bool IsAtomar { get; private set; } 

        public Calculations() {}
        public Calculations(string firstOperand, string secondOperand, string operation) 
        {
            CheckOperator(operation);
            CheckOperand(firstOperand);
            if (!IsAtomar) CheckOperand(secondOperand);

            FirstOperand = firstOperand;
            SecondOperand = secondOperand;
            Operation = operation;
        }

        public virtual void Calculate()
        {
            CheckOperator(Operation);
            CheckOperand(FirstOperand);
            if (!IsAtomar) CheckOperand(SecondOperand);

            try
            {
                checked
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
                            if (SecondOperand == "0")
                            {
                                Result = "Zero devision error";
                                throw new DivideByZeroException("Zero devision error");
                            }
                            Result = (Convert.ToDouble(FirstOperand) / Convert.ToDouble(SecondOperand)).ToString();
                            break;
                        case "√":
                            var firstOperand = Convert.ToDouble(FirstOperand);
                            if (firstOperand < 0)
                            {
                                Result = "Operand is negative";
                                throw new ArgumentException("Operand is negative");
                            }
                            Result = Math.Sqrt(firstOperand).ToString();
                            break;
                    }
                }
                
            }
            catch
            {
                Result = "Unknown error";
                throw;
            }
        }


        protected virtual void CheckOperator(string operation)
        {
            switch (operation)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    IsAtomar = false;
                    break;
                case "√":
                    IsAtomar = true;
                    break;
                default:
                    Result = "Operation error";
                    throw new ArgumentException("Operation error");
            }
        }



        private void CheckOperand(string operand)
        {
            try
            {
                Convert.ToDouble(operand);
            }
            catch
            {
                Result = "Operand error";
                throw;
            }
        }
    }

}
