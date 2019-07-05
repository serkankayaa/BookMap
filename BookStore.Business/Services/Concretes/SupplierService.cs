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

        public SupplierService(BookDbContext context) : base(context)
        {
            this._context = context;
        }

        //TODO: User sistemi yazıldığında CreatedBy ve UpdatedBy field ları doldurulacak.

        public bool DeleteSupplier(Guid id)
        {
            if(id == null)
            {
                return false;
            }

            Supplier supplier = this.GetById(id);

            this.Delete(supplier);
            this.Save();

            return true;
        }

        public DtoSupplier GetSupplier(Guid id)
        {
            var supplier = _context.Supplier.FirstOrDefault(x => x.Id == id);

            return new DtoSupplier()
            {
                SupplierId = supplier.Id,
                SupplierName = supplier.Name,
                SupplierRegion = supplier.SupplierRegion,
                CreatedBy = supplier.CreatedBy,
                CreatedDate = supplier.CreatedDate,
                UpdatedBy = supplier.UpdatedBy,
                UpdatedDate = supplier.UpdatedDate
            };
        }

        public List<DtoSupplier> GetSuppliers()
        {
            var suppliers = this.GetAll();

            if(suppliers == null || suppliers.Count() == 0)
            {
                return new List<DtoSupplier>();
            }

            var allSuppliers = suppliers.Select(c => new DtoSupplier()
            {
                SupplierId = c.Id,
                SupplierName = c.Name,
                SupplierRegion = c.SupplierRegion,
                CreatedBy = c.CreatedBy,
                CreatedDate = c.CreatedDate,
                UpdatedBy = c.UpdatedBy,
                UpdatedDate = c.UpdatedDate
            }).ToList();

            return allSuppliers;
        }

        public object PostSupplier(DtoSupplier model)
        {
            if(model == null)
            {
                return new DtoSupplier();
            }

            var checkSupplier = _context.Supplier.Where(c => c.Name == model.SupplierName).Any();

            if (checkSupplier)
            {
                return false;
            }

            Supplier supplier = new Supplier();
            supplier.Name = model.SupplierName;
            supplier.SupplierRegion = model.SupplierRegion;
            supplier.CreatedBy = "Test: Safa";
            supplier.CreatedDate = DateTime.Now;

            this.Add(supplier);
            this.Save();

            model.SupplierId = supplier.Id;

            return model;
        }

        public object UpdateSupplier(DtoSupplier model)
        {
            if(model == null)
            {
                return new DtoSupplier();
            }

            var checkSupplier = _context.Supplier.Where(c => c.Name == model.SupplierName).Any();

            if (checkSupplier)
            {
                return false;
            }

            Supplier supplier = this.GetById(model.SupplierId);
            supplier.Id = model.SupplierId;
            supplier.Name = model.SupplierName;
            supplier.SupplierRegion = model.SupplierRegion;
            supplier.UpdatedBy = "Test: Safa";
            supplier.UpdatedDate = DateTime.Now;

            this.Update(supplier);
            this.Save();

            return model;
        }
    }
}