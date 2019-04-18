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
  response : object;

  constructor(private publisherService : PublisherService, private toasterService : ToastrService) { }

  ngOnInit() {}

  postPublisher() : object {
    const result = this.publisherService.postPublisher(this.publisher).subscribe((response) => {
      console.log(response);
      if(response.body != null && response.ok && response.body != false){
        this.toasterService.success("Publisher saved successfully");
        this.publisher = new Publisher();
        
        return;
      }

      if(response.body == false){
        this.toasterService.error("This publisher saved already");
        return;
      }
    });

    return result;
  }
}
