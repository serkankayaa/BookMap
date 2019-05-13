using System;
using System.Collections.Generic;
using BookStore.Dto;

namespace BookStore.Business.Services
{
    public interface ISupplierService
    {
        DtoSupplier GetSupplier(Guid id);
        List<DtoSupplier> GetSuppliers();
        object SupplierAdd(DtoSupplier model);
        object UpdateSupplier(DtoSupplier model);
        bool DeleteSupplier(Guid id);
    }
}