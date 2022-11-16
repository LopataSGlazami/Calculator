using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Entities
{
    public class Calculation
    {
        public Guid Id { get; set; }
        public string FirstOperand { get; set; } = null!;
        public string Operation { get; set; } = null!;
        public string? SecondOperand { get; set; }
        public string Result { get; set; } = null!;

        public static bool ContentEquales(Calculation left, Calculation right) 
        {
            if (left == null || right == null) return false;
            var left2 = left.SecondOperand ?? "";
            var right2 = right.SecondOperand ?? "";
            return left.FirstOperand == right.FirstOperand &&
                left.Operation == right.Operation &&
                left2 == right2;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(SecondOperand))
            {
                return $"{Operation}({FirstOperand}) = {Result}";
            }
            return $"{FirstOperand} {Operation} {SecondOperand} = {Result}";
        }
    }
}
