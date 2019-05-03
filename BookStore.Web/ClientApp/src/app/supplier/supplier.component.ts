import { Component, OnInit } from '@angular/core';
import { Supplier } from '../models/supplier';
import { SupplierService } from '../services/supplier.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-supplier',
  templateUrl: './supplier.component.html',
  styleUrls: ['./supplier.component.css']
})
export class SupplierComponent implements OnInit {
  supplier = new Supplier;
  allSuppliers: Supplier[];

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
        this.toastrService.toastrConfig.progressBar = true;
        this.toastrService.success('Supplier saved successfully.');
        this.getSuppliers();
        this.refreshForm();
        this.supplier = new Supplier();

        return;
      }

      if (response.body === false) {
        this.toastrService.error('This supplier saved already!');
        return;
      }
    });
    return result;
  }
}
