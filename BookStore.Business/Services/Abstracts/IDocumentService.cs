namespace BookStore.Business.Services
{
    public interface IDocumentService
    {
        object PostDocument(string contentType, string dbFile, string childPath);
    }
}