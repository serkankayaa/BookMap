using System;
using System.IO;
using System.Net.Http.Headers;
using BookStore.Entity;
using BookStore.Entity.Context;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private BookDbContext _context;
        public DocumentController(BookDbContext context)
        {
            this._context = context;
        }

        [Route("api/DocumentAdd")]
        [HttpPost]
        public object Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var childPath = Path.Combine(folderName, fileName);
                    var fileCode = Guid.NewGuid();
                    var dbFile = fileCode + fileName;
                    var fullPath = Path.Combine(pathToSave, dbFile);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    Document document = new Document();
                    document.CONTENT_TYPE = file.ContentType;
                    document.FILE_NAME = dbFile;
                    document.FULL_PATH = childPath;

                    _context.Document.Add(document);
                    _context.SaveChanges();

                    return document;
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}