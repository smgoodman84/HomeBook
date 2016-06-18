using System;

namespace HomeBook.DAL
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal? Value { get; set; }
        public decimal Balance { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
    }
}