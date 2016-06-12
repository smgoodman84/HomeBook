using System.Collections.Generic;
using System.Linq;
using HomeBook.API.Domain;

namespace HomeBook.API.CsvParsing
{
    internal class TransactionCsvParser
    {
        public IEnumerable<Transaction> ParseFile(string filePath)
        {
            var csvParser = new CsvParser();
            var records = csvParser.ParseFile(filePath);
            var transactions = records.Select(ParseRecord).ToList();
            return transactions;
        }

        private Transaction ParseRecord(CsvRecord csvRecord)
        {
            return new Transaction(
                csvRecord.GetDateTime("Date"),
                csvRecord.GetString("Type"),
                csvRecord.GetString("Description"),
                csvRecord.GetOptionalDecimal("Value"),
                csvRecord.GetDecimal("Balance"),
                csvRecord.GetString("Account Name"),
                csvRecord.GetString("Account Number")
                );
        }
    }
}
