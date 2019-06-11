import { Component, OnInit } from '@angular/core';

import { ToastrService } from 'ngx-toastr';
import { SupplierService } from '../../services/supplier.service';

import { Supplier } from '../../models/supplier';
declare var $: any;

@Component({
  selector: 'app-supplier',
  templateUrl: './supplier.component.html',
  styleUrls: ['./supplier.component.css']
})

export class SupplierComponent implements OnInit {
  supplier = new Supplier;
  allSuppliers: Supplier[];
  isEdit = false;
  supplierId: any;
  hasData = true;

  constructor(private supplierService: SupplierService, private toastrService: ToastrService) { }

  ngOnInit() {
    this.getAllSuppliers();
  }

  refreshForm(): void {
    const dirtyFormID = 'supplierForm';
    const resetForm = <HTMLFormElement>document.getElementById(dirtyFormID);
    resetForm.reset();
  }

  getAllSuppliers(): void {
    this.supplierService.getAllSuppliers().subscribe(data => {
      if (data.length === 0) {
        this.hasData = false;
      } else {
        this.hasData = true;
        this.allSuppliers = data;
      }
    });
  }

  postSupplier(): object {
    const postedSupplier = this.supplierService.postSupplier(this.supplier).subscribe((response) => {
      if (response.body != null && response.ok && response.body !== false) {
        this.toastrService.success('Supplier saved successfully.');
        this.getAllSuppliers();
        this.refreshForm();
        this.supplier = new Supplier();

        return;
      }

      if (response.body === false) {
        this.toastrService.error('This supplier saved already!');
        this.focusErrorInput();
        return;
      }
    });

    return postedSupplier;
  }

  focusErrorInput() {
    const dirtyFormID = 'supplierName';
    const focusForm = <HTMLFormElement>document.getElementById(dirtyFormID);
    focusForm.focus();
  }

  editSupplier(selectedSupplier: Supplier): void {
    this.supplier = selectedSupplier;
    this.isEdit = true;
  }

  updateSupplier(): void {
    this.supplierService.updateSupplier(this.supplier).subscribe(
      (res) => {
        if (res.body != null && res.ok && res.body !== false) {
          this.toastrService.success('Supplier edited successfully.');
          this.getAllSuppliers();
          this.refreshForm();
          this.supplier = new Supplier();
          this.isEdit = false;
        }
        if (res.body === false) {
          this.toastrService.error('Please make a change to edit.');
          this.focusErrorInput();
          return;
        }
      });
  }

  deleteSupplier(): void {
    this.supplierService.deleteSupplier(this.supplierId).subscribe((res) => {
      {
        this.toastrService.success('Supplier deleted successfully.');
        this.getAllSuppliers();
        this.refreshForm();
        this.supplier = new Supplier();
        this.isEdit = false;
        $('#deleteSupplier').modal('hide');
      }
    });
  }

  onDelete(id: any): void {
    $('#deleteSupplier').modal('show');
    this.supplierId = id;
  }

  cancelUpdate() {
    this.supplier = new Supplier();
    this.isEdit = false;
    this.getAllSuppliers();
    this.refreshForm();
  }
}
