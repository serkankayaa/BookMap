using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Business.Generic;
using BookStore.Dto;
using BookStore.Entity.Context;
using BookStore.Entity.Models;

namespace BookStore.Business.Services
{
    public class SupplierService : EFRepository<Supplier>, ISupplierService
    {
        private BookDbContext _context;

        #region Ctor
        public SupplierService(BookDbContext context) : base(context)
        {
            this._context = context;
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


        /// <summary>
        /// Get All Suppliers
        /// </summary>
        /// <returns></returns>
        public List<DtoSupplier> GetSuppliers()
        {
            var suppliers = this.GetAll();

            var totalSuppliers = suppliers.Select(c => new DtoSupplier()
            {
                SUPPLIER_ID = c.SUPPLIER_ID,
                SUPPLIER_NAME = c.SUPPLIER_NAME,
                SUPPLIER_REGION = c.SUPPLIER_REGION,
            }).ToList();

            return totalSuppliers;
        }

        /// <summary>
        /// Add Supplier
        /// </summary>
        /// <returns></returns>
        public object SupplierAdd(DtoSupplier model)
        {
            Supplier supplier = new Supplier();
            supplier.SUPPLIER_ID = model.SUPPLIER_ID;
            supplier.SUPPLIER_NAME = model.SUPPLIER_NAME;
            supplier.SUPPLIER_REGION = model.SUPPLIER_REGION;
            this.Add(supplier);
            this.Save();

            return model;
        }

        public DtoSupplier UpdateSupplier(DtoSupplier model)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}