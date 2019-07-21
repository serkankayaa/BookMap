import { PublisherService } from './../../services/publisher.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Publisher } from '../../models/publisher';
import { ToastrService } from 'ngx-toastr';
declare var $: any;

@Component({
  selector: 'app-admin-publisher',
  templateUrl: './admin-publisher.component.html',
  styleUrls: ['./admin-publisher.component.css']
})
export class AdminPublisherComponent implements OnInit {
  public formSubmitted = false;
  public publisher = new Publisher();
  public publisherList: Publisher[];
  public publisherForm: FormGroup;
  public deletePublisher;
  public editPublisher;


  constructor(private fb: FormBuilder, private publisherService: PublisherService, private toastr: ToastrService) { }

  ngOnInit() {
    this.publisherForm = this.fb.group({
      publisher: ['', Validators.required],
      location: ['', Validators.required],
    });
    this.getAllPublishers();
  }

  get formPublisher() {
    return this.publisherForm.controls;
  }

  getAllPublishers() {
    this.publisherService.getAllPublishers().subscribe(data => {
      this.publisherList = data;
    });
  }

  submitPublisher() {
    this.formSubmitted = true;
    if (this.publisherForm.invalid) {
      return;
    }

    this.publisherService.postPublisher(this.publisher).subscribe(res => {
      if (res.status === 200 || res.statusText === 'OK') {
        this.toastr.success(`Shop '${this.publisher.PublisherName}' successfully added!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        this.getAllPublishers();
        $('#publisherModal').modal('hide');
      }
    });
    console.log(this.publisher);
  }

  // Passes selected publisher data and opens edit modal
  editModal(publisher) {
    this.editPublisher = publisher;
    $('#editShopModal').modal('show');
  }

  // Updates the selected publisher data
  updatePublisher(selectedPublisher) {
    this.formSubmitted = true;
    this.publisherService.updatePublisher(selectedPublisher).subscribe(res => {
      if (res.status === 200 || res.statusText === 'OK') {
        this.toastr.success(`Publisher '${selectedPublisher.ShopName}' successfully updated!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        this.getAllPublishers();
        $('#editShopModal').modal('hide');
      } else {
        this.toastr.error(`An error occured!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        $('#editShopModal').modal('hide');
      }
    });
  }

  // Passes selected publisher data and opens delete modal
  deleteModal(shop) {
    this.deletePublisher = shop;
    $('#deletePublisherModal').modal('show');
  }

  // Deletes the selected publisher data
  deleteExistingPublisher(selectedPublisher) {
    this.publisherService.deletePublisher(selectedPublisher.ShopId).subscribe(res => {
      if (res) {
        this.toastr.success(`Publisher '${selectedPublisher.PublisherName}' successfully deleted!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        this.getAllPublishers();
        $('#deletePublisherModal').modal('hide');
      } else {
        this.toastr.error(`An error occured!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        $('#deletePublisherModal').modal('hide');
      }
    });
  }
}
