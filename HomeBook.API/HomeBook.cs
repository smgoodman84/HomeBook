namespace HomeBook.API
{
    public static class HomeBook
    {
        public static void UploadFile(string filePath)
        {
            var uploader = new TransactionFileUploader();
            uploader.UploadFile(filePath);
        }
    }
}

