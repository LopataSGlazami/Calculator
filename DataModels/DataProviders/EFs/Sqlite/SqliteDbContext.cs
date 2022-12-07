using System;
using System.Collections.Generic;
using System.Text;
using DataModels.DataProviders.EFs.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace DataModels.DataProviders.EFs.Sqlite
{
    public class SqliteDbContext : DatabaseContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite(@"Data Source = C:\_Data\Sqlite.db");
        }
    }
}
