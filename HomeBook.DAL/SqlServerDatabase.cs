using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace HomeBook.DAL
{
    public class SqlServerDatabase : IDatabase
    {
        private readonly string _connectionString;

        public SqlServerDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection NewConnection()
        {
            return new SqlConnection(_connectionString);
        }
    
        public IEnumerable<Transaction> Transactions => GetTransactions();

        public IEnumerable<Transaction> GetTransactions()
        {
            using (var sqlConnection = NewConnection())
            {
                return sqlConnection.Query<Transaction>("SELECT * FROM [Transaction]");
            }
        }

        public void AddTransaction(Transaction transaction)
        {
            using (var sqlConnection = NewConnection())
            {
                var queryResult = sqlConnection.Query(
                    @"
                    DECLARE @InsertedRows AS TABLE (TransactionId int);

                    INSERT INTO [Transaction](TransactionDate, Type, Description, Value, Balance, AccountName, AccountNumber)
                    OUTPUT INSERTED.TransactionId INTO @InsertedRows
                    VALUES (@Date, @Type, @Description, @Value, @Balance, @AccountName, @AccountNumber)
                    
                    SELECT TransactionId FROM @InsertedRows
                    ", 
                transaction);

                var insertedRow = queryResult.Single();

                transaction.TransactionId = insertedRow.TransactionId;
            }
        }
    }
}
