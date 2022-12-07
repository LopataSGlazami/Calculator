using CalculationsModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Entities
{
    public class History : EntityBase
    {
        public string FirstOperand { get; set; } = "";
        public string Operation { get; set; } = "";
        public string Result { get; set; } = "";
        public string? SecondOperand { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; } = null!;

        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(SecondOperand)
                ? $"{Operation}({FirstOperand}) = {Result}"
                : $"{FirstOperand} {Operation} {SecondOperand} = {Result}";
        }
    }
}
