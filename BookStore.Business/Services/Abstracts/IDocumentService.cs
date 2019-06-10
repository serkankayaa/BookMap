namespace BookStore.Business.Services
{
    public interface IDocumentService
    {
        object UploadDocument(string contentType, string dbFile, string childPath);
    }
}