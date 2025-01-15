using SQLite;
using Dotnetcoursework.Model;
using System;
using System.IO;
using Microsoft.Maui.Storage;
using System.Threading.Tasks;

namespace Dotnetcoursework.Services
{
    public class Database
    {
        private SQLiteAsyncConnection _database;

        public Database()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "customer.db");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Customer>().Wait(); // Ensure table creation is complete before proceeding
        }

        public async Task<bool> AddUser(Customer customer)
        {
            try
            {
                var result = await _database.InsertAsync(customer);
                return true;
            }
            catch (SQLiteException sqlex)
            {
                Console.WriteLine($"SQLite error: {sqlex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error: {ex.Message}");
                return false;
            }
        }

        public async Task UpdateUser(Customer user)
        {
            await _database.UpdateAsync(user);
        }

        public async Task<Customer> GetUserByUsername(string username)
        {
            return await _database.Table<Customer>().Where(u => u.Username == username).FirstOrDefaultAsync();
        }

        public async Task<Customer> GetUserByEmail(string email)
        {
            return await _database.Table<Customer>().Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task DeleteUser(Customer user)
        {
            await _database.DeleteAsync(user);
        }

        public AsyncTableQuery<Customer> GetAllUsers()
        {
            return _database.Table<Customer>();
        }
    }
}