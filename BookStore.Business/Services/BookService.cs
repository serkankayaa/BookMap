using BookStore.Business.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using BookStore.Entity.Context;
using BookStore.Entity.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BookStore.Business
{
    public class BookService : EFRepository<Book>, IBookService
    {
        #region Field

        private BookDbContext _context;
        public IAuthorService _authorService;

        #endregion

        #region Ctor

        public BookService(BookDbContext context, IAuthorService authorService) : base(context)
        {
            _context = context;
            _authorService = authorService;
        }

        #endregion

        #region Method

        /// <summary>
        /// Get Book with specific
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DtoBook GetBook(Guid id)
        {
            var bookItem = this.GetById(id);

            DtoBook book = new DtoBook();
            book.BOOK_ID = bookItem.BOOK_ID;
            book.NAME = bookItem.NAME;
            book.SUMMARY = bookItem.SUMMARY;
            book.AUTHOR_ID_FK = bookItem.AUTHOR_ID_FK;
            book.PUBLISHER_ID_FK = bookItem.PUBLISHER_ID_FK;

            return book;
        }

        /// <summary>
        /// Get All Books
        /// </summary>
        /// <returns></returns>
        public List<DtoBook> GetBooks()
        {
            var books = base.GetAll();

            var totalBooks = books.Select(c => new DtoBook()
            {
                BOOK_ID = c.BOOK_ID,
                NAME = c.NAME,
                SUMMARY = c.SUMMARY,
                AUTHOR_ID_FK = c.AUTHOR_ID_FK,
                PUBLISHER_ID_FK = c.PUBLISHER_ID_FK
            }).ToList();

            return totalBooks;
        }

        /// <summary>
        /// Add book
        /// </summary>
        /// <param name="model"></param>
        public void BookAdd(DtoBook model)
        {
            Book book = new Book();
            book.NAME = model.NAME;
            book.SUMMARY = model.SUMMARY;
            book.AUTHOR_ID_FK = model.AUTHOR_ID_FK;
            book.PUBLISHER_ID_FK = model.PUBLISHER_ID_FK;

            this.Add(book);
            this.Save();
        }

        //public DtoBook UpdateBook(DtoBook model)
        //{
        //    var bookData = this.GetById(model.BOOK_ID);
        //    bookData.NAME = model.NAME;
        //    bookData.
        //}

        public bool DeleteBook(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Book List Related by Author
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List</returns>
        public object GetBookAuthor(Guid id)
        {
            var author = _authorService.GetAuthor(id);
            var bookResult = (from a in _context.Author
                              join b in _context.Book on a.AUTHOR_ID equals b.AUTHOR_ID_FK into bookAuthor
                              from r in bookAuthor.DefaultIfEmpty()
                              where r.AUTHOR_ID_FK == author.AUTHOR_ID
                              select new
                              {
                                  AUTHOR_ID_FK = a.AUTHOR_ID,
                                  BOOK_ID = r.BOOK_ID,
                                  BOOK_NAME = r.NAME,
                                  BOOK_SUMMARY = r.SUMMARY,
                                  BIOGRAPHY = a.BIOGRAPHY,
                                  AUTHOR_NAME = a.AUTHOR_NAME,
                                  BIRTH_DATE = a.BIRTH_DATE,
                              });

            var result = bookResult.Select(c => new DtoBookAuthor
            {
                AUTHOR_ID_FK = c.AUTHOR_ID_FK,
                BOOK_ID = c.BOOK_ID,
                BOOK_NAME = c.BOOK_NAME,
                BOOK_SUMMARY = c.BOOK_SUMMARY,
                BIOGRAPHY = c.BIOGRAPHY,
                AUTHOR_NAME = c.AUTHOR_NAME,
                BIRTH_DATE = c.BIRTH_DATE
            }).ToList();

            return result;
        }

        public DtoBook UpdateBook(DtoBook model)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
