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

  constructor(private supplierService: SupplierService, private toastrService: ToastrService) { }

  ngOnInit() {
    this.getSuppliers();
  }
  getSuppliers(): void {
    this.supplierService.getSuppliers().subscribe(data => this.allSuppliers = data);
  }
}
