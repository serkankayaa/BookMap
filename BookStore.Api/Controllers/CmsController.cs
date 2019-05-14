﻿using System;
using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreMap.Controllers
{
    [ApiController]
    public class CmsController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;
        private readonly IShopService _shopService;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;

        public CmsController(IBookService bookService,
                               IAuthorService authorService,
                               IPublisherService publisherService,
                               IShopService shopService,
                               ICategoryService categoryService,
                               ISupplierService supplierService
                               )
        {
            _bookService = bookService;
            _authorService = authorService;
            _publisherService = publisherService;
            _shopService = shopService;
            _categoryService = categoryService;
            _supplierService = supplierService;
        }

        #region Book Method

        [Route("api/Book/{id:Guid}")]
        [HttpGet]
        public DtoBook GetBook(Guid id)
        {
            return _bookService.GetBook(id);
        }

        [Route("api/GetAllBook")]
        [HttpGet]
        public List<DtoBook> GetBooks()
        {
            return _bookService.GetBooks();
        }

        [Route("api/PostBook")]
        [HttpPost]
        public void BookAdd(DtoBook model)
        {
            _bookService.BookAdd(model);
        }

        [Route("api/GetBookAuthor/{id:Guid}")]
        [HttpGet]
        public object GetBookAuthor(Guid id)
        {
            return _bookService.GetBookAuthor(id);
        }

        #endregion

        #region Author Method

        [Route("api/Author/{id:Guid}")]
        [HttpGet]
        public DtoAuthor GetAuthor(Guid id)
        {
            return _authorService.GetAuthor(id);
        }

        [Route("api/GetAllAuthor")]
        [HttpGet]
        public List<DtoAuthor> GetAuthors()
        {
            return _authorService.GetAuthors();
        }

        [Route("api/PostAuthor")]
        [HttpPost]
        public object PostAuthor(DtoAuthor model)
        {
            return _authorService.AuthorAdd(model);
        }

        [Route("api/UpdateAuthor")]
        [HttpPut]
        public object UpdateAuthor(DtoAuthor model)
        {
            return _authorService.UpdateAuthor(model);
        }

        [Route("api/DeleteAuthor/{id}")]
        [HttpDelete]
        public bool DeleteAuthor(Guid id)
        {
            return _authorService.DeleteAuthor(id);
        }

        #endregion

        #region Publisher

        [Route("api/Publisher/id:Guid")]
        [HttpGet]
        public DtoPublisher GetPublisher(Guid id)
        {
            return _publisherService.GetPublisher(id);
        }

        [Route("api/GetAllPublisher")]
        [HttpGet]
        public List<DtoPublisher> GetPublisher()
        {
            return _publisherService.GetPublishers();
        }

        [Route("api/PostPublisher")]
        [HttpPost]
        public object PostPublisher(DtoPublisher model)
        {
            return _publisherService.PublisherAdd(model);
        }

        [Route("api/UpdatePublisher")]
        [HttpPut]
        public object UpdatePublisher(DtoPublisher model)
        {
            return _publisherService.UpdatePublisher(model);
        }

        [Route("api/DeletePublisher/{id}")]
        [HttpDelete]
        public bool DeletePublisher(Guid id)
        {
            return _publisherService.DeletePublisher(id);
        }

        #endregion

        #region Shop
        [Route("api/PostShop")]
        [HttpPost]
        public object PostShop(DtoShop model)
        {
            return _shopService.AddShop(model);
        }

        [Route("api/GetShop")]
        [HttpGet]
        public object GetShop(Guid ID)
        {
            return _shopService.GetShop(ID);
        }

        [Route("api/GetAllShops")]
        [HttpGet]
        public List<DtoShop> GetAllShops()
        {

            return _shopService.GetShops();
        }

        [Route("api/UpdateShop")]
        [HttpPut]
        public object UpdateShop(DtoShop model)
        {
            return _shopService.UpdateShop(model);
        }

        [Route("api/DeleteShop/{id}")]
        [HttpDelete]
        public bool DeleteShop(Guid id)
        {
            return _shopService.DeleteShop(id);
        }

        #endregion

        #region Category

        [Route("api/GetCategories")]
        [HttpGet]
        public List<DtoCategory> GetCategories()
        {
            return _categoryService.GetCategories();
        }

        [Route("api/PostCategory")]
        [HttpPost]
        public object CategoryAdd(DtoCategory model)
        {
            return _categoryService.CategoryAdd(model);
        }

        [Route("api/UpdateCategory")]
        [HttpPut]
        public object UpdateCategory(DtoCategory model)
        {
            return _categoryService.UpdateCategory(model);
        }

        [Route("api/DeleteCategory/{id}")]
        [HttpDelete]
        public bool DeleteCategory(Guid id)
        {
            return _categoryService.DeleteCategory(id);
        }

        #endregion

        #region Supplier

        [Route("api/GetSuppliers")]
        [HttpGet]
        public List<DtoSupplier> GetSuppliers()
        {
            return _supplierService.GetSuppliers();
        }

        [Route("api/PostSupplier")]
        [HttpPost]
        public object PostSupplier(DtoSupplier model)
        {
            return _supplierService.SupplierAdd(model);
        }

        [Route("api/GetSupplier/id:Guid")]
        [HttpGet]
        public DtoSupplier GetSupplier(Guid id)
        {
            return _supplierService.GetSupplier(id);
        }

        [Route("api/UpdateSupplier")]
        [HttpPut]
        public object UpdateSupplier(DtoSupplier model)
        {
            return _supplierService.UpdateSupplier(model);
        }

        [Route("api/DeleteSupplier/{id}")]
        [HttpDelete]
        public bool DeleteSupplier(Guid id)
        {
            return _supplierService.DeleteSupplier(id);
        }

        #endregion

    }
}