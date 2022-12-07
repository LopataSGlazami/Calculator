using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModels.Repozitories;
using System.Threading.Tasks;
using DataModels.Entities;
using System.Linq;

namespace DataModels.DataProviders.EFs.Core.Repozitories
{
    public  class HistoryRep : IHistoryRep
    {
        private readonly DatabaseContext context;
        public HistoryRep(DatabaseContext context) => this.context = context;
        public IQueryable<History> Histories => context.Histories;
        //public IQueryable<History> Histories
        //{
        //    get
        //    {
        //        using var context = new DatabaseContext();
        //        return context.Histories.OrderBy(h => h.LastTime);
        //    }
        //}

        public Task DeleteAsync(History item) => Task.Run(() =>
         {
             if (context.Histories.Contains(item))
             {
                 context.Histories.Remove(item);
                 context.SaveChanges();
             }
         });

        public async Task<History?> GetItemByIdAsync(Guid id)
        {
            return await context.Histories.FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task UpdateAsync(History item)
        {
            var old = await context.Histories.FindAsync(item.Id);
            if (old != null)
            {
                context.Histories.Remove(old);
            }
            context.Histories.Add(item);
            await context.SaveChangesAsync();
        }
    }
}
