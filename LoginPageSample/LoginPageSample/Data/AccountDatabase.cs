using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoginPageSample.Models;

namespace LoginPageSample.Data
{
    public class AccountDatabase
    {
        readonly SQLiteAsyncConnection database;

        public AccountDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Account>().Wait();
        }

        public Task<List<Account>> GetAccountsAsync()
        {
            //Get all accounts.
            return database.Table<Account>().ToListAsync();
        }

        public Task<Account> GetAccountAsync(string email)
        {
            // Get a specific account.
            return database.Table<Account>()
                            .Where(i => i.Email == email)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveAccountAsync(Account acc)
        {
            if (acc.ID != 0)
            {
                // Update an existing account.
                return database.UpdateAsync(acc);
            }
            else
            {
                // Save a new account.
                return database.InsertAsync(acc);
            }
        }

        public Task<int> DeleteAccountAsync(Account acc)
        {
            // Delete a account.
            return database.DeleteAsync(acc);
        }
    }
}