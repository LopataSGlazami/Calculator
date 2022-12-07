using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataModels.Entities;

namespace DataModels.Repozitories
{
    public interface IHistoryRep:IRepozitory<History>
    {
        IQueryable <History> Histories { get; }

      

    }
}
