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
  public addPublisherForm: FormGroup;
  public editPublisherForm: FormGroup;
  public deletePublisher = {};
  public editPublisher = {};

  constructor(private fb: FormBuilder, private publisherService: PublisherService, private toastr: ToastrService) { }

  ngOnInit() {
    this.addPublisherForm = this.fb.group({
      publisher: ['', Validators.required],
      location: ['', Validators.required],
    });
    this.editPublisherForm = this.fb.group({
      publisher: ['', Validators.required],
      location: ['', Validators.required],
    });
    this.getAllPublishers();
  }

  getAllPublishers() {
    this.publisherService.getAllPublishers().subscribe(publisherData => {
      this.publisherList = publisherData;
    });
  }

  submitPublisher() {
    this.formSubmitted = true;
    if (this.addPublisherForm.invalid) {
      return;
    }

    this.publisherService.postPublisher(this.publisher).subscribe(res => {
      if (res.status === 200 || res.statusText === 'OK') {
        this.toastr.success(`Publisher '${this.publisher.PublisherName}' successfully added!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        this.getAllPublishers();
        $('#publisherModal').modal('hide');
      }
    });
  }

  // Passes selected publisher data and opens edit modal
  editModal(publisher) {
    this.editPublisher = publisher;
    $('#editPublisherModal').modal('show');
  }

  // Updates the selected publisher data
  updatePublisher(selectedPublisher) {
    this.formSubmitted = true;
    this.publisherService.updatePublisher(selectedPublisher).subscribe(res => {
      if (res.status === 200 || res.statusText === 'OK') {
        this.toastr.success(`Publisher '${selectedPublisher.PublisherName}' successfully updated!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        this.getAllPublishers();
        $('#editPublisherModal').modal('hide');
      } else {
        this.toastr.error(`An error occured!`, '', {
          closeButton: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          timeOut: 4000
        });
        $('#editPublisherModal').modal('hide');
      }
    });
  }

  // Passes selected publisher data and opens delete modal
  deleteModal(publisher) {
    this.deletePublisher = publisher;
    $('#deletePublisherModal').modal('show');
  }

  // Deletes the selected publisher data
  deleteExistingPublisher(selectedPublisher) {
    this.publisherService.deletePublisher(selectedPublisher.PublisherId).subscribe(res => {
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

  get form() {
    return this.addPublisherForm.controls;
  }

  get editForm() {
    return this.editPublisherForm.controls;
  }
}
