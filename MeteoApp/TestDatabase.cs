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
            // collegamento al database
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MeteoApp.db");
            database = new SQLiteAsyncConnection(dbPath);

            // crea la tabella se non esiste
            database.CreateTableAsync<Location>().Wait();
        }

        /*
         * Ritorna una lista con tutti gli items.
         */
        public Task<List<Location>> GetItemsAsync()
        {
            return database.Table<Location>().ToListAsync();
        }


        /*
         * Salvataggio o update.
         */
        public Task<int> SaveItemAsync(Location item)
        {
            if (item.ID == 0) // esempio
                return database.UpdateAsync(item);

            return database.InsertAsync(item);
        }

        /*
         * Cancellazione di un elemento.
         */
        public Task<int> DeleteItemAsync(Location item)
        {
            return database.DeleteAsync(item);
        }
    }
}
