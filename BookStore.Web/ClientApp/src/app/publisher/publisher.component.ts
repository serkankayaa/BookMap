import { Component, OnInit } from '@angular/core';

import { Publisher } from '../models/publisher';
import { PublisherService } from '../services/publisher.service';
import { ToastrService } from 'ngx-toastr';
import { Supplier } from '../models/supplier';
import { SupplierService } from '../services/supplier.service';

@Component({
  selector: 'app-publisher',
  templateUrl: './publisher.component.html',
  styleUrls: ['./publisher.component.css']
})
export class PublisherComponent implements OnInit {
  publisher = new Publisher();
  allPublisher: Publisher[];
  allSupplier: Supplier[];
  isEdit: boolean;

  // tslint:disable-next-line: max-line-length
  constructor(private publisherService: PublisherService, private toastrService: ToastrService, private supplierService: SupplierService) { }

  ngOnInit() {
    this.getPublisher();
    this.getSupplierList();
  }
  getSupplierList(): void {
    this.supplierService.getSuppliers().subscribe(data => this.allSupplier = data);
  }

  refreshForm(): void {
    const dirtyFormID = 'publisherForm';
    const resetForm = <HTMLFormElement>document.getElementById(dirtyFormID);
    resetForm.reset();
  }

  getPublisher(): void {
    this.publisherService.getAllPublisher()
      .subscribe(data => this.allPublisher = data);
  }

  postPublisher(): object {
    const result = this.publisherService.postPublisher(this.publisher).subscribe((response) => {
      if (response.body != null && response.ok && response.body !== false) {
        this.toastrService.success('Publisher saved successfully');
        this.getPublisher();
        this.refreshForm();
        this.publisher = new Publisher();

        return;
      }

      if (response.body === false) {
        this.toastrService.error('This publisher saved already');
        this.focusErrorInput();
        return;
      }
    });

    return result;
  }

  focusErrorInput() {
    const dirtyFormID = 'publisherName';
    const focusForm = <HTMLFormElement>document.getElementById(dirtyFormID);
    focusForm.focus();
  }

  editPublisher(selectedPublisher: Publisher): void {
    this.publisher = selectedPublisher;
    this.isEdit = true;
  }

  updatePublisher(): void {
    const result = this.publisherService.updatePublisher(this.publisher).subscribe(
      (res) => {
        if (res.body != null && res.ok && res.body !== false) {
          this.toastrService.success('Publisher edited successfully.');
          this.getPublisher();
          this.refreshForm();
          this.publisher = new Publisher();
          this.isEdit = false;
        }
        if (res.body === false) {
          this.toastrService.error('Please make a change to edit.');
          this.focusErrorInput();
          return;
        }
      });
  }

  deletePublisher(id: any): void {
    this.publisherService.deletePublisher(id).subscribe((res) => {
      {
        this.toastrService.success('Publisher deleted successfully.');
        this.getPublisher();
        this.refreshForm();
        this.publisher = new Publisher();
        this.isEdit = false;
      }
    });
  }

}
