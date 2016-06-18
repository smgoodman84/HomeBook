using AutoMapper;
using HomeBook.DAL;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace HomeBook.API.Domain
{
    internal static class Repository
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private static readonly IDatabase Database = new SqlServerDatabase(ConnectionString);

        static Repository()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<DAL.Transaction, Transaction>();
                cfg.CreateMap<Transaction, DAL.Transaction>();
            });
        }

        public static IEnumerable<Transaction> Transactions => Database.Transactions.Select(Mapper.Map<Transaction>);

        public static void Add(Transaction transaction) => Database.AddTransaction(Mapper.Map<DAL.Transaction>(transaction));
    }
}