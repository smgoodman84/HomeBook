using System.Collections.Generic;
using HomeBook.API.Domain;

namespace HomeBook.API
{
    public static class HomeBook
    {
        public static void UploadFile(string filePath)
        {
            var uploader = new TransactionFileUploader();
            uploader.UploadFile(filePath);
        }

        public static IEnumerable<Transaction> Transactions => Repository.Transactions;
    }
}

