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
    public  class UserRep : IUserRep
    {
        private readonly DatabaseContext context;

        public UserRep(DatabaseContext context) => this.context = context;

        public IQueryable<User> Users=> context.Users;

        public Task DeleteAsync(User item) => Task.Run(() =>
         {
             if (context.Users.Contains(item))
             {
                 context.Users.Remove(item);
                 context.SaveChanges();
             }
         });

        public async Task<User?> GetItemByIdAsync(Guid id)=>
            await context.Users.FirstOrDefaultAsync(u => u.Id == id);

        public async Task UpdateAsync(User item)
        {
            var old = await context.Users.FindAsync(item.Id);
            if (old != null)
            {
                if(item.Nick!=old.Nick)
                {
                    old.Nick = item.Nick;
                }

                if (item.RememberMe!= old.RememberMe)
                {
                    old.RememberMe = item.RememberMe;
                }
                context.Users.Update(old);
            }
            else context.Users.Add(item);
            await context.SaveChangesAsync();
        }
    }
}
