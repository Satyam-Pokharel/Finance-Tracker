using SQLite;
using Dotnetcoursework.Model;

namespace Dotnetcoursework.Services
{
    public class TransactionDB
    {
        private SQLiteAsyncConnection _database;

        public TransactionDB()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "Transaction.db");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TransactionModel>().Wait(); // Ensure table creation is complete before proceeding
        }

        public async Task<bool> AddTransaction(TransactionModel transaction)
        {
            try
            {
                var result = await _database.InsertAsync(transaction);
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

        public async Task<List<TransactionModel>> GetAllTransactions()
        {
            try
            {
                return await _database.Table<TransactionModel>().ToListAsync();
            }
            catch (SQLiteException sqlex)
            {
                Console.WriteLine($"SQLite error: {sqlex.Message}");
                return new List<TransactionModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error: {ex.Message}");
                return new List<TransactionModel>();
            }
        }
    }
}
