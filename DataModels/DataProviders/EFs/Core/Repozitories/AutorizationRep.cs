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
    public class AuthorizationRep : IAuthorizationRep
    {
        private readonly DatabaseContext context;

        public AuthorizationRep(DatabaseContext context) => this.context = context;

        public Task DeleteAsync(Authorization item) => Task.Run(() =>
        {
            if (context.Authorizations.Contains(item))
            {
                context.Authorizations.Remove(item);
                context.SaveChanges();
            }
        });

        public async Task<Authorization?> GetItemByIdAsync(Guid id)
        {
            return await context.Authorizations.FirstOrDefaultAsync(a => a.UserId == id);
        }

        public async Task UpdateAsync(Authorization item)
        {
            var old = await context.Authorizations.FindAsync(item.UserId);
            if (old != null)
            {
                context.Authorizations.Remove(old);
            }
            context.Authorizations.Add(item);
            await context.SaveChangesAsync();
        }
    }
}
