import { Component } from '@angular/core';

import { AuthorService } from './services/author.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private toastrService: ToastrService) {
    this.setToastrOptions();
  }

  setToastrOptions() {
    this.toastrService.toastrConfig.progressBar = true;
    this.toastrService.toastrConfig.newestOnTop = true;
    this.toastrService.toastrConfig.closeButton = true;
    this.toastrService.toastrConfig.preventDuplicates = true;
  }
}
