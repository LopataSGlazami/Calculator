using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataModels.Entities;
using System.Threading.Tasks;

namespace DataModels.Repos
{
    public interface IHistoryRep
    {
        IQueryable<History> GetHistories(bool isAdmin = false);
        Task<History> GetHistoryByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task AddAsync(History history);
    }
}
