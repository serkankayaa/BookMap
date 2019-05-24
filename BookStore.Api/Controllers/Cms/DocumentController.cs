using System;
using System.IO;
using System.Linq;
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
        private readonly string[] ACCEPTED_FILE_TYPES = new[] {".jpg", ".jpeg", ".png", ".JPG", ".JPEG", ".PNG"};

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
                    if (file.Length > 2000000)
                    {
                        return Content("Max File size !");
                    }

                    if(!ACCEPTED_FILE_TYPES.Any(s => s == Path.GetExtension(file.FileName).ToLower()))
                    {
                        return BadRequest("Invalid file type.");
                    } 

                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var childPath = Path.Combine(folderName, fileName);
                    var fileCode = Guid.NewGuid();
                    var dbFile = fileCode + "-" + fileName;
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
                    return BadRequest("Empty File !");
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}