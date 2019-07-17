using System;
using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers.Cms
{
    [Route("[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: /Supplier
        [HttpGet]
        public List<DtoSupplier> GetSuppliers()
        {
            return _supplierService.GetSuppliers();
        }

        // GET: /Supplier/5
        [Route("{id:Guid}")]
        [HttpGet]
        public DtoSupplier GetSupplier(Guid id)
        {
            return _supplierService.GetSupplier(id);
        }

        // POST: /Supplier/
        [HttpPost]
        public object PostSupplier(DtoSupplier model)
        {
            return _supplierService.PostSupplier(model);
        }

        // PUT: /Supplier/
        [HttpPut]
        public object UpdateSupplier(DtoSupplier model)
        {
            return _supplierService.UpdateSupplier(model);
        }

        // DELETE: /Supplier/5
        [Route("{id:Guid}")]
        [HttpDelete]
        public bool DeleteSupplier(Guid id)
        {
            return _supplierService.DeleteSupplier(id);
        }
    }
}