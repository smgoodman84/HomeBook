using System.Linq;
using HomeBook.API.CsvParsing;
using HomeBook.API.Domain;

namespace HomeBook.API
{
    internal class TransactionFileUploader
    {
        public void UploadFile(string filePath)
        {
            var csvParser = new TransactionCsvParser();
            var transactions = csvParser.ParseFile(filePath).ToList();
            transactions.ForEach(Repository.Add);
        }
    }
}
