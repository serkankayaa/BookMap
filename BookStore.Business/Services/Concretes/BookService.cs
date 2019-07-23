using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Business.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using BookStore.Entity.Context;
using BookStore.Entity.Models;

namespace BookStore.Business
{
    public class BookService : EFRepository<Book>, IBookService
    {
        private BookDbContext _context;
        public IAuthorService _authorService;

        public BookService(BookDbContext context, IAuthorService authorService) : base(context)
        {
            _context = context;
            _authorService = authorService;
        }

        public DtoBook GetBook(Guid id)
        {
            var bookItem = this.GetById(id);
            
            var book = (from b in _context.Book join a in _context.Author on b.AuthorIdFk equals a.Id into auTemp 
                        from bookAuthor in auTemp.DefaultIfEmpty() 
                        join p in _context.Publisher on b.PublisherIdFk equals p.Id into pbTemp 
                        from bookPublisher in pbTemp.DefaultIfEmpty() 
                        join c in _context.Category on b.CategoryIdFk equals c.Id into ctTemp 
                        from bookCategory in ctTemp.DefaultIfEmpty() 
                        join s in _context.Shop on b.ShopIdFk equals s.Id into spTemp 
                        from bookShop in spTemp.DefaultIfEmpty()
            select new DtoBook()
            {
                BookId = bookItem.Id,
                BookName = bookItem.Name,
                Summary = bookItem.Summary,
                AuthorIdFk = bookItem.AuthorIdFk,
                AuthorName = bookAuthor.Name,
                PublisherIdFk = bookItem.PublisherIdFk,
                PublisherName = bookPublisher.Name,
                CategoryIdFk = bookItem.CategoryIdFk,
                CategoryName = bookCategory.Name,
                ShopIdFk = bookItem.ShopIdFk,
                ShopName = bookShop.Name,
                ImageIdFk = bookItem.DocumetIdFk,
                ImageName = bookItem.Document.FileName,
                CreatedBy = bookItem.CreatedBy,
                CreatedDate = bookItem.CreatedDate,
                UpdatedBy = bookItem.UpdatedBy,
                UpdatedDate = bookItem.UpdatedDate
            }).FirstOrDefault();

            return book;
        }

        public List<DtoBook> GetBooks()
        {
            var books = base.GetAll();

            if(books == null || books.Count() == 0)
            {
                return new List<DtoBook>();
            }

            var allBooks = books.Select(c => new DtoBook()
            {
                BookId = c.Id,
                BookName = c.Name,
                Summary = c.Summary,
                AuthorIdFk = c.AuthorIdFk,
                AuthorName = c.Author.Name,
                PublisherIdFk = c.PublisherIdFk,
                PublisherName = c.Publisher.Name,
                CategoryIdFk = c.CategoryIdFk,
                CategoryName = c.Category.Name,
                ShopIdFk = c.ShopIdFk,
                ShopName = c.Shop.Name,
                ImageIdFk = c.DocumetIdFk,
                ImageName = c.Document.FileName,
                CreatedBy = c.CreatedBy,
                CreatedDate = c.CreatedDate,
                UpdatedBy = c.UpdatedBy,
                UpdatedDate = c.UpdatedDate
            }).ToList();

            return allBooks;
        }

        public object PostBook(DtoBook model)
        {
            if(model == null)
            {
                return new DtoBook();
            }

            Book book = new Book();
            book.Name = model.BookName;
            book.Summary = model.Summary;
            book.AuthorIdFk = model.AuthorIdFk;
            book.PublisherIdFk = model.PublisherIdFk;
            book.CategoryIdFk = model.CategoryIdFk;
            book.ShopIdFk = model.ShopIdFk;
            book.DocumetIdFk = model.ImageIdFk;
            book.CreatedBy = model.CreatedBy;
            book.CreatedDate = DateTime.Now;

            this.Add(book);
            this.Save();

            model.BookId = book.Id;

            return model;
        }

        public bool DeleteBook(Guid id)
        {
            if(id == null)
            {
                return false;
            }

            var book = this.GetById(id);

            if (book != null)
            {
                this.Delete(book);
                this.Save();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Get Book List Related by Author
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List</returns>
        public object GetBooksByAuthor(Guid id)
        {
            var author = _authorService.GetAuthor(id);
            var authorBooks = (from a in _context.Author join b in _context.Book on a.Id equals b.AuthorIdFk into bookAuthor 
                              from r in bookAuthor.DefaultIfEmpty() where r.AuthorIdFk == author.AuthorId 
            select new DtoBookAuthor
            {
                AuthorIdFk = a.Id,
                BookId = r.Id,
                BookName = r.Name,
                BookSummary = r.Summary,
                Biography = a.Biography,
                AuthorName = a.Name,
                BirthDate = a.BirthDate,
            }).ToList();

            return authorBooks;
        }

        public DtoBook UpdateBook(DtoBook model)
        {
            if(model == null)
            {
                return new DtoBook();
            }

            var book = this.GetById(model.BookId);

            book.Id = model.BookId;
            book.Name = model.BookName;
            book.Summary = model.Summary;
            book.AuthorIdFk = model.AuthorIdFk;
            book.PublisherIdFk = model.PublisherIdFk;
            book.CategoryIdFk = model.CategoryIdFk;
            book.ShopIdFk = model.ShopIdFk;
            book.DocumetIdFk = model.ImageIdFk;
            book.UpdatedBy = model.UpdatedBy;
            book.UpdatedDate = DateTime.Now;

            this.Update(book);
            this.Save();

            return model;
        }

        public object GetRecentlyBook()
        {
            return this._context.Book.Take(5).OrderByDescending(c=> c.CreatedDate);
        }        
    }
}