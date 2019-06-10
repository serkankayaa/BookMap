using System;
using System.Collections.Generic;
using System.Linq;

using BookStore.Business.Generic;
using BookStore.Dto;
using BookStore.Entity.Context;
using BookStore.Entity.Models;

namespace BookStore.Business.Services {
    public class AuthorService : EFRepository<Author>, IAuthorService 
    {
        #region Field

        private BookDbContext _context;

        #endregion

        #region Ctor

        public AuthorService(BookDbContext context) : base(context) 
        {
            _context = context;
        }

        #endregion

        #region Method

        public DtoAuthor GetAuthor(Guid id) {
            var author = this.GetById(id);

            DtoAuthor model = new DtoAuthor();
            model.AUTHOR_ID = author.AUTHOR_ID;
            model.AUTHOR_NAME = author.AUTHOR_NAME;
            model.BIRTH_DATE = author.BIRTH_DATE;
            model.BIOGRAPHY = author.BIOGRAPHY;

            return model;
        }

        public List<DtoAuthor> GetAuthors() {
            var authors = this.GetAll();

            var totalAuthors = authors.Select(c => new DtoAuthor() {
                AUTHOR_ID = c.AUTHOR_ID,
                    AUTHOR_NAME = c.AUTHOR_NAME,
                    BIRTH_DATE = c.BIRTH_DATE,
                    BIOGRAPHY = c.BIOGRAPHY
            }).ToList();

            return totalAuthors;
        }

        public object AuthorAdd(DtoAuthor model) {
            var isAuthorNameExists = _context.Author.Where(c => c.AUTHOR_NAME == model.AUTHOR_NAME).Any();

            if (isAuthorNameExists) {
                return false;
            }

            Author author = new Author();
            author.AUTHOR_NAME = model.AUTHOR_NAME;
            author.BIOGRAPHY = model.BIOGRAPHY;
            author.BIRTH_DATE = model.BIRTH_DATE;

            this.Add(author);
            this.Save();

            model.AUTHOR_ID = author.AUTHOR_ID;

            return model;
        }

        #endregion

        public object UpdateAuthor(DtoAuthor model) {
            Author author = this.GetById(model.AUTHOR_ID);
            author.AUTHOR_NAME = model.AUTHOR_NAME;
            author.BIOGRAPHY = model.BIOGRAPHY;
            author.BIRTH_DATE = model.BIRTH_DATE;

            this.Update(author);
            this.Save();

            return model;
        }

        public bool DeleteAuthor(Guid id) {
            try {
                Author author = this.GetById(id);
                this.Delete(author);
                this.Save();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
        public bool DeleteAllAuthors() {

            var authors = this.GetAll();

            if (authors.Count() == 0) {
                return false;
            }
            else {
                try {

                    foreach (var author in authors) {
                        this.Delete(author);
                    }
                }
                catch (Exception) {
                    return false;
                }
            }
            this.Save();
            return true;
        }
    }
}