using System;
using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

#region SupplierController

namespace BookStore.Api.Controllers.Cms
{
    [Route("[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        #endregion

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        #region Supplier_GetAll
        // GET: /Supplier
        [HttpGet]
        public List<DtoSupplier> GetSuppliers()
        {
            return _supplierService.GetSuppliers();
        }

        #region Supplier_GetById
        // GET: /Supplier/5
        [Route("{id:Guid}")]
        [HttpGet]
        public DtoSupplier GetSupplier(Guid id)
        {
            return _supplierService.GetSupplier(id);
        }
        #endregion
        #endregion

        #region Supplier_Create
        // POST: /Supplier/
        [HttpPost]
        public object PostSupplier(DtoSupplier model)
        {
            return _supplierService.PostSupplier(model);
        }
        #endregion

        #region Supplier_Update
        // PUT: /Supplier/
        [HttpPut]
        public object UpdateSupplier(DtoSupplier model)
        {
            return _supplierService.UpdateSupplier(model);
        }
        #endregion

        #region Supplier_Delete
        // DELETE: /Supplier/5
        [Route("{id:Guid}")]
        [HttpDelete]
        public bool DeleteSupplier(Guid id)
        {
            return _supplierService.DeleteSupplier(id);
        }

        #endregion

    }
}