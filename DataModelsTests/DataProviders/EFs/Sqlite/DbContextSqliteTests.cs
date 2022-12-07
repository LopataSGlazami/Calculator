using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataModels.DataProviders.EFs.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DataModels.Entities;

namespace DataModels.DataProviders.EFs.Sqlite.Tests
{
    [TestClass()]
    public class DbContextSqliteTests
    {
        [TestMethod()]
        public void SqliteConnectionTest()
        {
            var context = DataManager.Get(DataProvider.SqLite);
            Assert.IsTrue(File.Exists(@"C:\_Data\Sqlite.db"));
            Assert.IsTrue(context.UserRep.GetItemByIdAsync(User.GustGuid).Result != null);
        }
    }
}