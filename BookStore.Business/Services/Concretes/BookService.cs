using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Business.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using BookStore.Entity;
using BookStore.Entity.Context;
using BookStore.Entity.Models;

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
            try
            {
                var bookItem = this.GetById(id);

                var getBook = (from b in _context.Book join a in _context.Author on b.AUTHOR_ID_FK equals a.AUTHOR_ID into auTemp from bookAuthor in auTemp.DefaultIfEmpty() join p in _context.Publisher on b.PUBLISHER_ID_FK equals p.PUBLISHER_ID into pbTemp from bookPublisher in pbTemp.DefaultIfEmpty() join c in _context.Category on b.CATEGORY_ID_FK equals c.CATEGORY_ID into ctTemp from bookCategory in ctTemp.DefaultIfEmpty() join s in _context.Shop on b.SHOP_ID_FK equals s.SHOP_ID into spTemp from bookShop in spTemp.DefaultIfEmpty() select new DtoBook()
                {
                    BOOK_ID = bookItem.BOOK_ID,
                    NAME = bookItem.NAME,
                    SUMMARY = bookItem.SUMMARY,
                    AUTHOR_ID_FK = bookItem.AUTHOR_ID_FK,
                    AUTHOR_NAME = bookAuthor.AUTHOR_NAME,
                    PUBLISHER_ID_FK = bookItem.PUBLISHER_ID_FK,
                    PUBLISHER_NAME = bookPublisher.NAME,
                    CATEGORY_ID_FK = bookItem.CATEGORY_ID_FK,
                    CATEGORY_NAME = bookCategory.NAME,
                    SHOP_ID_FK = bookItem.SHOP_ID_FK,
                    SHOP_NAME = bookShop.SHOP_NAME,
                    IMAGE_ID_FK = bookItem.DOCUMENT_ID_FK,
                    IMAGE_NAME = bookItem.Document.FILE_NAME
                }).FirstOrDefault();

                return getBook;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get All Books
        /// </summary>
        /// <returns></returns>
        public List<DtoBook> GetBooks()
        {
            try
            {
                var books = base.GetAll();

                var totalBooks = books.Select(c => new DtoBook()
                {
                    BOOK_ID = c.BOOK_ID,
                    NAME = c.NAME,
                    SUMMARY = c.SUMMARY,
                    AUTHOR_ID_FK = c.AUTHOR_ID_FK,
                    AUTHOR_NAME = c.Author.AUTHOR_NAME,
                    PUBLISHER_ID_FK = c.PUBLISHER_ID_FK,
                    PUBLISHER_NAME = c.Publisher.NAME,
                    CATEGORY_ID_FK = c.CATEGORY_ID_FK,
                    CATEGORY_NAME = c.Category.NAME,
                    SHOP_ID_FK = c.SHOP_ID_FK,
                    SHOP_NAME = c.Shop.SHOP_NAME,
                    IMAGE_ID_FK = c.DOCUMENT_ID_FK,
                    IMAGE_NAME = c.Document.FILE_NAME
                }).ToList();

                return totalBooks;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add book
        /// </summary>
        /// <param name="model"></param>
        public void PostBook(DtoBook model)
        {
            try
            {
                Book book = new Book();
                book.NAME = model.NAME;
                book.SUMMARY = model.SUMMARY;
                book.AUTHOR_ID_FK = model.AUTHOR_ID_FK;
                book.PUBLISHER_ID_FK = model.PUBLISHER_ID_FK;
                book.CATEGORY_ID_FK = model.CATEGORY_ID_FK;
                book.SHOP_ID_FK = model.SHOP_ID_FK;
                book.DOCUMENT_ID_FK = model.IMAGE_ID_FK;

                this.Add(book);
                this.Save();

                model.BOOK_ID = book.BOOK_ID;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete book
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List</returns>
        public bool DeleteBook(Guid id)
        {
            try
            {
                var book = this.GetById(id);

                if (book != null)
                {
                    this.Delete(book);
                    this.Save();

                    return true;
                }

                return false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Book List Related by Author
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List</returns>
        public object GetBooksByAuthor(Guid id)
        {
            var author = _authorService.GetAuthor(id);
            var bookResult = (from a in _context.Author join b in _context.Book on a.AUTHOR_ID equals b.AUTHOR_ID_FK into bookAuthor from r in bookAuthor.DefaultIfEmpty() where r.AUTHOR_ID_FK == author.AUTHOR_ID select new DtoBookAuthor
            {
                AUTHOR_ID_FK = a.AUTHOR_ID,
                BOOK_ID = r.BOOK_ID,
                BOOK_NAME = r.NAME,
                BOOK_SUMMARY = r.SUMMARY,
                BIOGRAPHY = a.BIOGRAPHY,
                AUTHOR_NAME = a.AUTHOR_NAME,
                BIRTH_DATE = a.BIRTH_DATE,
            }).ToList();

            return bookResult;
        }

        public DtoBook UpdateBook(DtoBook model)
        {
            try
            {
                var book = this.GetById(model.BOOK_ID);
                if (book != null)
                {
                    book.BOOK_ID = model.BOOK_ID;
                    book.NAME = model.NAME;
                    book.SUMMARY = model.SUMMARY;
                    book.AUTHOR_ID_FK = model.AUTHOR_ID_FK;
                    book.PUBLISHER_ID_FK = model.PUBLISHER_ID_FK;
                    book.CATEGORY_ID_FK = model.CATEGORY_ID_FK;
                    book.SHOP_ID_FK = model.SHOP_ID_FK;
                    book.DOCUMENT_ID_FK = model.IMAGE_ID_FK;
                }

                this.Update(book);
                this.Save();

                return model;
            }
            catch (System.Exception ex)
            {
                return new DtoBook();
                throw ex;
            }
        }
        
        #endregion
    }
}