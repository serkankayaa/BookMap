import { PublisherService } from './../../services/publisher.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Publisher } from '../../models/publisher';

@Component({
  selector: 'app-admin-publisher',
  templateUrl: './admin-publisher.component.html',
  styleUrls: ['./admin-publisher.component.css']
})
export class AdminPublisherComponent implements OnInit {
  public formSubmitted = false;
  public publisher = new Publisher();
  public allPublishers: Publisher[];
  public publisherForm: FormGroup;

  constructor(private fb: FormBuilder, private publisherService: PublisherService) { }

  ngOnInit() {
    this.publisherForm = this.fb.group({
      publisher: ['', Validators.required],
      location: ['', Validators.required],
    });
    this.getAllPublishers();
  }

  get form() {
    return this.publisherForm.controls;
  }

  getAllPublishers() {
    this.publisherService.getAllPublishers().subscribe(data => {
      this.allPublishers = data;
    });
  }

  postPublisher() {
    this.formSubmitted = true;
    if (this.publisherForm.invalid) {
      return;
    }
    console.log(this.publisher);
  }
}
