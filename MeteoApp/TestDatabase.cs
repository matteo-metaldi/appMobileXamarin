using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using MeteoApp;

namespace MeteoApp
{
    public class TestDatabase
    {
        private readonly SQLiteAsyncConnection database;

        public TestDatabase()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MeteoApp.db");
            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<Location>().Wait();
        }
        public Task<List<Location>> GetItemsAsync()
        {
            return database.Table<Location>().ToListAsync();
        }
        public Task<int> SaveItemAsync(Location item)
        {
            if (item.ID == 0) 
                return database.UpdateAsync(item);

            return database.InsertAsync(item);
        }
        public Task<int> DeleteItemAsync(Location item)
        {
            return database.DeleteAsync(item);
        }
    }
}
