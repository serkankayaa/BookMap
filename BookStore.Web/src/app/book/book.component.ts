import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';

import { apiBaseUrl, apiImageUrl } from '../../config';
import { BookService } from '../services/book.service';

declare var $: any;

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {
  public progress: number;
  public message: string;
  filePath;
  
  @Output() public onUploadFinished = new EventEmitter();

  constructor(private http: HttpClient, private bookService: BookService) { }

  ngOnInit() {
    //Bu resim deneme amacıyla eklenmiştir.
    this.filePath = apiImageUrl + "8c79e466-b15c-4457-84ce-5faf4137e6ce-landing1.jpg";
  }

  uploadFile(files): object {

    if (files.length === 0) {
      return;
    }

    const fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    const result = this.bookService.documentAdd(formData).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress) {
        this.progress = Math.round(100 * event.loaded / event.total);
      } else if (event.type === HttpEventType.Response) {
        this.message = 'Upload success.';
        this.onUploadFinished.emit(event.body);
      }
    });

    return result;
  }

}
