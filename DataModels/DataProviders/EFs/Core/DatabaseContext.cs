using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModels.Entities;
namespace DataModels.DataProviders.EFs.Core
{
    public  class DatabaseContext:DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Authorization> Authorizations { get; set; } = null!;
        public DbSet<History> Histories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Authorization>().HasKey(a => a.UserId);
            mb.Entity<User>().HasData(User.Gust);
        }
    }
}
