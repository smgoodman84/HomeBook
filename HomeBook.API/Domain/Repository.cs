using System.Collections.Generic;

namespace HomeBook.API.Domain
{
    internal static class Repository
    {
        private static readonly List<Transaction> _transactions = new List<Transaction>();

        public static IEnumerable<Transaction> Transactions => _transactions;

        public static void Add(Transaction transaction) => _transactions.Add(transaction);
    }
}
