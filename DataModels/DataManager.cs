using DataModels.DataProviders.EFs.Core.Repozitories;
using DataModels.DataProviders.EFs.Sqlite;
using DataModels.Repozitories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class DataManager
    {
        //public DbContext? Context { get; private set; }
        public IAuthorizationRep AutoriationRep { get; }
        public IUserRep UserRep { get; }
        public IHistoryRep HistoryRep { get; }

        private DataManager(IUserRep userRep, IAuthorizationRep autarizationRep, IHistoryRep historyRep)
        {
            AutoriationRep = autarizationRep;
            UserRep = userRep;
            HistoryRep = historyRep;
        }

        public static DataManager Get(DataProvider data)
        {
            switch (data)
            {
                default:
                    throw new DataMisalignedException("No data");
                case DataProvider.SqlServer:
                    throw new Exception("Debugging and (structured) exception handling - tracking down and fixing programming errors in an application under development.");
                case DataProvider.SqLite:
                    var context = new SqliteDbContext();
                    context.Database.EnsureCreated();
                    return new DataManager(new UserRep(context), new AuthorizationRep(context), new HistoryRep(context));
            }
        }
    }
}
