using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entity
{
    public class Document
    {
        [Key]
        public Guid DOCUMENT_ID { get; set; }
        public string CONTENT_TYPE { get; set; }
        public string FULL_PATH { get; set; }
        public string FILE_NAME { get; set; }
    }
}