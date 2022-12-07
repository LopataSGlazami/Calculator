using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
namespace DataModels.Repozitories
{
    public interface IRepozitory<TEntity> where TEntity: class
    {
        Task<TEntity?> GetItemByIdAsync(Guid id);
        Task UpdateAsync (TEntity item);

        Task  DeleteAsync(TEntity item);

    }
}
