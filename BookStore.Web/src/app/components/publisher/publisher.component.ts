import { Component, OnInit } from '@angular/core';

import { PublisherService } from '../../services/publisher.service';
import { ToastrService } from 'ngx-toastr';
import { SupplierService } from '../../services/supplier.service';
import { Publisher } from '../../models/publisher';
import { Supplier } from '../../models/supplier';

declare var $: any;

@Component({
  selector: 'app-publisher',
  templateUrl: './publisher.component.html',
  styleUrls: ['./publisher.component.css']
})

export class PublisherComponent implements OnInit {
  publisher = new Publisher();
  allPublishers: Publisher[];
  allSuppliers: Supplier[];
  isEdit: boolean;
  publisherId: any;
  hasData = true;

  constructor(private publisherService: PublisherService,
              private toastrService: ToastrService,
              private supplierService: SupplierService) { }

  ngOnInit() {
    this.getAllPublishers();
    this.getAllSuppliers();
  }

  getAllSuppliers(): void {
    this.supplierService.getAllSuppliers().subscribe(data => this.allSuppliers = data);
  }

  refreshForm(): void {
    const dirtyFormID = 'publisherForm';
    const resetForm = <HTMLFormElement>document.getElementById(dirtyFormID);
    resetForm.reset();
  }

  getAllPublishers(): void {
    this.publisherService.getAllPublishers()
      .subscribe(data => {
        if (data.length === 0) {
          this.hasData = false;
        } else {
          this.hasData = true;
          this.allPublishers = data;
        }
      });
  }

  postPublisher(): object {
    console.log(this.publisher);
    const postedPublisher = this.publisherService.postPublisher(this.publisher).subscribe((response) => {
      if (response.body != null && response.ok && response.body !== false) {
        this.toastrService.success('Publisher saved successfully');
        this.getAllPublishers();
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

    return postedPublisher;
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
   this.publisherService.updatePublisher(this.publisher).subscribe(
      (res) => {
        if (res.body != null && res.ok && res.body !== false) {
          this.toastrService.success('Publisher edited successfully.');
          this.getAllPublishers();
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

  deletePublisher(): void {
    this.publisherService.deletePublisher(this.publisherId).subscribe((res) => {
      {
        this.toastrService.success('Publisher deleted successfully.');
        this.getAllPublishers();
        this.refreshForm();
        this.publisher = new Publisher();
        this.isEdit = false;
        $('#deletePublisher').modal('hide');
      }
    });
  }

  onDelete(id: any): void {
    $('#deletePublisher').modal('show');
    this.publisherId = id;
  }

  cancelUpdate() {
    this.publisher = new Publisher();
    this.isEdit = false;
    this.getAllPublishers();
    this.refreshForm();
  }
}
