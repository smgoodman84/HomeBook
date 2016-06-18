using System.Collections.Generic;

namespace HomeBook.DAL
{
    public interface IDatabase
    {
        IEnumerable<Transaction> Transactions { get; }

        void AddTransaction(Transaction transaction);
    }
}
