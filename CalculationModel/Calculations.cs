﻿using System;
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
        private bool isAtomar;
        public Calculations() { }
        public Calculations(string firstOperand, string secondOperand, string operation) 
        {
            CheckOperation(operation);
            CheckOperand(firstOperand);
            if (!isAtomar) CheckOperand(secondOperand);
          
            

            FirstOperand = firstOperand;
            if (!isAtomar) SecondOperand = secondOperand;
            Operation = operation;
        }

        public virtual void Calculate()
        {
            CheckOperation(Operation);
            CheckOperand(FirstOperand);
            if(!isAtomar) CheckOperand(SecondOperand);



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
                    case "sqrt":
                        Double firstOperand = Convert.ToDouble(FirstOperand);
                        if (firstOperand < 0)
                        {
                            Result = "Error: Bad argument(<0)";
                            throw new ArgumentException();
                        }
                        Result = Math.Sqrt(firstOperand).ToString();
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
                    isAtomar = false;
                    break;
                case "sqrt":
                    isAtomar = true;
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
