using System;

namespace HomeBook.API.Domain
{
    internal class Transaction
    {
        public Transaction(
            DateTime date,
            string type,
            string description,
            decimal? value,
            decimal balance,
            string accountName,
            string accountNumber)
        {
            Date = date;
            Type = type;
            Description = description;
            Value = value;
            Balance = balance;
            AccountName = accountName;
            AccountNumber = accountNumber;
        }

        public DateTime Date { get; }
        public string Type { get; }
        public string Description { get; }
        public decimal? Value { get; }
        public decimal Balance { get; }
        public string AccountName { get; }
        public string AccountNumber { get; }
    }
}
