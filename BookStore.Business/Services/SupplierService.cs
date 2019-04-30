using System;
using System.Collections.Generic;
using BookStore.Business.Generic;
using BookStore.Dto;
using BookStore.Entity.Context;
using BookStore.Entity.Models;

namespace BookStore.Business.Services
{
    public class SupplierService : EFRepository<Supplier>, ISupplierService
    {
        private BookDbContext _context;
        private ISupplierService _supplierService;

        #region Ctor
        public SupplierService(BookDbContext context, ISupplierService supplierService) : base(context)
        {
            this._context = context;
            this._supplierService = supplierService;
        }
        #endregion

        #region Method
        public bool DeleteSupplier(Guid id)
        {
            throw new NotImplementedException();
        }

        public DtoSupplier GetSupplier(Guid id)
        {
            throw new NotImplementedException();
        }

        public object GetSupplierPublishers(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<DtoSupplier> GetSuppliers()
        {
            throw new NotImplementedException();
        }

        public object SupplierAdd(DtoSupplier model)
        {
            throw new NotImplementedException();
        }

        public DtoSupplier UpdateSupplier(DtoSupplier model)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}