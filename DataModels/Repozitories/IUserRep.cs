using DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataModels.Repozitories
{
    public interface IUserRep:IRepozitory<User>
    {
        
        IQueryable<User> Users { get; }

    }
}
