using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using BookStore.Business;
using BookStore.Business.Services;
using BookStore.Entity;
using BookStore.Entity.Context;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private IBookService _bookservice;
        private readonly string[] ACCEPTED_FILE_TYPES = new [] { ".jpg", ".jpeg", ".png", ".JPG", ".JPEG", ".PNG" };

        public DocumentController(IBookService bookservice)
        {
            _bookservice = bookservice;
        }

        [Route("api/DocumentAdd")]
        [HttpPost]
        public object Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var contentType = file.ContentType;
                var folderName = Path.Combine("Resources", "images");
                var destinationPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\\BookStore.Web";
                var pathToSave = Path.Combine(destinationPath, folderName);

                if (file.Length > 0)
                {
                    if (file.Length > 2000000)
                    {
                        return Content("Max File size !");
                    }

                    if (!ACCEPTED_FILE_TYPES.Any(s => s == Path.GetExtension(file.FileName).ToLower()))
                    {
                        return BadRequest("Invalid file type.");
                    }

                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var childPath = Path.Combine(folderName, fileName);
                    var fileCode = Guid.NewGuid();
                    var dbFile = fileCode + "-" + fileName;
                    var fullPath = Path.Combine(pathToSave, dbFile);

                    using(var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return _bookservice.UploadBook(contentType, dbFile, childPath);

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