using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using BookStore.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BookStore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private IDocumentService _documentService;
        public IConfiguration _configuration { get; }
        private readonly string[] ACCEPTED_FILE_TYPES = new [] { ".jpg", ".jpeg", ".png", ".JPG", ".JPEG", ".PNG" };

        public DocumentController(IDocumentService documentService, IConfiguration configuration)
        {
            _documentService = documentService;
            _configuration = configuration;
        }

        // POST: /Document/
        [HttpPost]
        public object PostDocument()
        {
            try
            {
                var file = Request.Form.Files[0];
                var contentType = file.ContentType;
                var folderName = Path.Combine("assets", "documents");
                string webUrlforImage; 

                if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    webUrlforImage = _configuration.GetValue<string>("WebUrlImageForWin");
                }
                else
                {
                    webUrlforImage = _configuration.GetValue<string>("WebUrlImageForOtherOS");
                }

                var destinationPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + webUrlforImage;
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

                    return _documentService.PostDocument(contentType, dbFile, childPath);

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