import { Component, OnInit } from '@angular/core';
import { Supplier } from '../models/supplier';
import { SupplierService } from '../services/supplier.service';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-supplier',
  templateUrl: './supplier.component.html',
  styleUrls: ['./supplier.component.css']
})
export class SupplierComponent implements OnInit {
  supplier = new Supplier;
  allSuppliers: Supplier[];
  isEdit = false;

  constructor(private supplierService: SupplierService, private toastrService: ToastrService) { }

  ngOnInit() {
    this.getSuppliers();
  }
  refreshForm(): void {
    const dirtyFormID = 'supplierForm';
    const resetForm = <HTMLFormElement>document.getElementById(dirtyFormID);
    resetForm.reset();
  }
  getSuppliers(): void {
    this.supplierService.getSuppliers().subscribe(data => this.allSuppliers = data);
  }

  postSupplier(): object {
    const result = this.supplierService.postSupplier(this.supplier).subscribe((response) => {
      if (response.body != null && response.ok && response.body !== false) {
        this.toastrService.success('Supplier saved successfully.');
        this.getSuppliers();
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
    return result;
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
    const result = this.supplierService.updateSupplier(this.supplier).subscribe((res) => {
      if (res.body != null && res.ok && res.body !== false) {
        this.toastrService.success('Supplier edited successfully.');
        this.getSuppliers();
        this.refreshForm();
        this.supplier = new Supplier();
        this.isEdit = false;
      }
    });
  }
  deleteSupplier(id: any): void {
    this.supplierService.deleteSupplier(id).subscribe((res) => {
      {
        this.toastrService.success('Supplier deleted successfully.');
        this.getSuppliers();
        this.refreshForm();
        this.supplier = new Supplier();
        this.isEdit = false;
      }
    });
  }
}
