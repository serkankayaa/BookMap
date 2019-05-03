import { Component, OnInit } from '@angular/core';

import { Publisher } from '../models/publisher';
import { PublisherService } from '../services/publisher.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-publisher',
  templateUrl: './publisher.component.html',
  styleUrls: ['./publisher.component.css']
})
export class PublisherComponent implements OnInit {
  publisher = new Publisher();
  allPublisher: Publisher[];

  constructor(private publisherService: PublisherService, private toasterService: ToastrService) { }

  ngOnInit() {
    this.getPublisher();
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
      console.log(response);
      if (response.body != null && response.ok && response.body !== false) {
        this.toasterService.success('Publisher saved successfully');
        this.getPublisher();
        this.refreshForm();
        this.publisher = new Publisher();

        return;
      }

      if (response.body === false) {
        this.toasterService.error('This publisher saved already');
        return;
      }
    });

    return result;
  }
}
