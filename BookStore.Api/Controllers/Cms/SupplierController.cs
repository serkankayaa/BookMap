using System;
using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers.Cms
{
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

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