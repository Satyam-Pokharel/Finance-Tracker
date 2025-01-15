using Dotnetcoursework.Model;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotnetcoursework.Services
{
    public class DebtDb
    {
        private ConcurrentBag<Debts> debts = new ConcurrentBag<Debts>(); // Thread-safe collection

        // Get all debts
        public Task<List<Debts>> GetAllDebts()
        {
            return Task.FromResult(new List<Debts>(debts));
        }

        // Add a new debt
        public Task<bool> AddTransaction(Debts debt)
        {
            if (debt == null) return Task.FromResult(false);
            debts.Add(debt);
            return Task.FromResult(true);
        }

        // Clear a debt (mark as cleared)
        public Task<bool> ClearDebt(Guid id)
        {
            var debt = debts.FirstOrDefault(d => d.Id == id);
            if (debt != null)
            {
                debt.IsCleared = true;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
