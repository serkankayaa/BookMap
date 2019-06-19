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
            try
            {
                Supplier supplier = this.GetById(id);
                this.Delete(supplier);
                this.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DtoSupplier GetSupplier(Guid id)
        {
            var supplier = _context.Supplier.FirstOrDefault(x => x.SUPPLIER_ID == id);
            return new DtoSupplier()
            {
                SUPPLIER_ID = supplier.SUPPLIER_ID,
                    SUPPLIER_NAME = supplier.SUPPLIER_NAME,
                    SUPPLIER_REGION = supplier.SUPPLIER_REGION
            };
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
        public object PostSupplier(DtoSupplier model)
        {
            var isExistSupplier = _context.Supplier.Where(c => c.SUPPLIER_NAME == model.SUPPLIER_NAME).Any();

            if (isExistSupplier)
            {
                return false;
            }

            Supplier supplier = new Supplier();
            supplier.SUPPLIER_NAME = model.SUPPLIER_NAME;
            supplier.SUPPLIER_REGION = model.SUPPLIER_REGION;
            this.Add(supplier);
            this.Save();

            model.SUPPLIER_ID = supplier.SUPPLIER_ID;

            return model;
        }
        public object UpdateSupplier(DtoSupplier model)
        {
            var isSupplierExists = _context.Supplier.Where(c => c.SUPPLIER_NAME == model.SUPPLIER_NAME).Any();

            if (isSupplierExists)
            {
                return false;
            }

            Supplier supplier = this.GetById(model.SUPPLIER_ID);
            supplier.SUPPLIER_ID = model.SUPPLIER_ID;
            supplier.SUPPLIER_NAME = model.SUPPLIER_NAME;
            supplier.SUPPLIER_REGION = model.SUPPLIER_REGION;

            this.Update(supplier);
            this.Save();

            return model;
        }

        #endregion
    }
}