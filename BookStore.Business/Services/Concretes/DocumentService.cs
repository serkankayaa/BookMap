using BookStore.Business.Generic;
using BookStore.Entity;
using BookStore.Entity.Context;

namespace BookStore.Business.Services
{
    public class DocumentService : EFRepository<Document>, IDocumentService
    {
        private BookDbContext _context;
        public DocumentService(BookDbContext context) : base(context)
        {
            _context = context;
        }

        public object PostDocument(string contentType, string dbFile, string childPath)
        {
            Document document = new Document();

            document.CONTENT_TYPE = contentType;
            document.FILE_NAME = dbFile;
            document.FULL_PATH = childPath;

            _context.Document.Add(document);
            _context.SaveChanges();

            return document.DOCUMENT_ID;
        }
    }
}