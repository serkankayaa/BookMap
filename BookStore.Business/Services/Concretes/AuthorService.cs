using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStore.Business.Generic;
using BookStore.Dto;
using BookStore.Entity.Context;
using BookStore.Entity.Models;

namespace BookStore.Business.Services
{
    public class AuthorService : EFRepository<Author>, IAuthorService
    {
        private BookDbContext _context;
        private IMapper _mapper;

        public AuthorService(BookDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public DtoAuthor GetAuthor(Guid id)
        {
            var author = this.GetById(id);

            DtoAuthor model = new DtoAuthor();
            // model.AuthorId = author.Id;
            // model.AuthorName = author.Name;
            // model.BirthDate = author.BirthDate;
            // model.Biography = author.Biography;
            // model.ImageIdFk = author.DocumetIdFk;
            // model.ImageName = author.Document.FileName;
            // model.CreatedBy = author.CreatedBy;
            // model.CreatedDate = author.CreatedDate;
            // model.UpdatedBy = author.UpdatedBy;
            // model.UpdatedDate = author.UpdatedDate;

            model = _mapper.Map<Author, DtoAuthor>(author);

            return model;
        }

        public List<DtoAuthor> GetAuthors()
        {
            var authors = this.GetAll();

            var allAuthors = authors.Select(c => new DtoAuthor()
            {
                AuthorId = c.Id,
                AuthorName = c.Name,
                BirthDate = c.BirthDate,
                Biography = c.Biography,
                ImageIdFk = c.DocumetIdFk,
                ImageName = c.Document.FileName,
                CreatedBy = c.CreatedBy,
                CreatedDate = c.CreatedDate,
                UpdatedBy = c.UpdatedBy,
                UpdatedDate = c.UpdatedDate
            }).ToList();

            return allAuthors;
        }

        public object PostAuthor(DtoAuthor model)
        {
            var checkAuthorName = _context.Author.Where(c => c.Name == model.AuthorName).Any();

            if (checkAuthorName)
            {
                return false;
            }

            Author author = new Author();
            author.Name = model.AuthorName;
            author.Biography = model.Biography;
            author.BirthDate = model.BirthDate;
            author.DocumetIdFk = model.ImageIdFk;
            author.CreatedBy = model.CreatedBy;
            author.CreatedDate = DateTime.Now;

            this.Add(author);
            this.Save();

            model.AuthorId = author.Id;

            return model;
        }

        public object UpdateAuthor(DtoAuthor model)
        {
            Author author = this.GetById(model.AuthorId);

            author.Name = model.AuthorName;
            author.Biography = model.Biography;
            author.BirthDate = model.BirthDate;
            author.DocumetIdFk = model.ImageIdFk;
            author.UpdatedBy = model.UpdatedBy;
            author.UpdatedDate = DateTime.Now;

            this.Update(author);
            this.Save();

            return model;
        }

        public bool DeleteAuthor(Guid id)
        {
            if (id == null)
            {
                return false;
            }

            Author author = this.GetById(id);

            this.Delete(author);
            this.Save();

            return true;
        }

        public bool DeleteAllAuthors()
        {
            var authors = this.GetAll();

            if (authors.Count() == 0)
            {
                return false;
            }

            foreach (var author in authors)
            {
                this.Delete(author);
            }

            this.Save();

            return true;
        }
    }
}