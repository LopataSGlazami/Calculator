using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Entities
{
    public class History
    {
        public Guid Id { get; set; }
        public DateTime ActDate { get; set; } = DateTime.Now;
        public bool IsAdmin { get; set; }
        public Guid CalculationId { get; set; }
        public Calculation Calculation { get; set; } = null!;

        public override string ToString()
        {
            return Calculation.ToString();
        }
    }
}
