import { Component, OnInit, Output, EventEmitter } from '@angular/core';

import { AuthorService } from '../../services/author.service';
import { PublisherService } from '../../services/publisher.service';
import { CategoryService } from '../../services/category.service';
import { DocumentService } from '../../services/document.service';

import { Author } from '../../models/author';
import { Book } from '../../models/book';
import { Category } from '../../models/category';
import { Publisher } from '../../models/publisher';
import { UIImagePath } from '../../../config';
declare var $: any;

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})

export class BookComponent implements OnInit {
  submitted = false;
  bookModel = new Book();
  public progress: number;
  public message: string;
  public book: Book[];
  public Authors: Author[];
  public Publishers: Publisher[];
  public Categories: Category[];
  public formData = new FormData();

  filePath;

  @Output() public onUploadFinished = new EventEmitter();

  constructor(
    private authorService: AuthorService,
    private publisherService: PublisherService,
    private categoryService: CategoryService) { }

  ngOnInit() {
    //Bu resim deneme amacıyla eklenmiştir.
    this.filePath = UIImagePath + "2ec7dc24-d7e2-4cea-b62b-daac5875d835-2.PNG";
    this.getAllAuthors();
    this.getAllCategories();
    this.getAllPublishers();
  }


  onSubmit() { this.submitted = true; }

  uploadFile(files): object {

    if (files.length === 0) {
      return;
    }

    const fileToUpload = <File>files[0];
    this.formData.set('file', fileToUpload, fileToUpload.name);

    // const result = this.documentService.documentAdd(formData).subscribe(event => {
    //   if (event.type === HttpEventType.UploadProgress) {
    //   } else if (event.type === HttpEventType.Response) {
    //     this.message = fileToUpload.name;
    //     this.onUploadFinished.emit(event.body);
    //   }
    // });
    console.log(this.formData.get("file"));

  }

  getAllAuthors() {
    this.authorService.getAllAuthors().subscribe(data => {
      this.Authors = data
      console.log(data);
    }
    );
  }

  getAllCategories() {
    this.categoryService.getAllCategories().subscribe(data => {
      this.Categories = data
      console.log(data);
    }
    );
  }

  getAllPublishers() {
    this.publisherService.getAllPublishers().subscribe(data => {
      this.Publishers = data
      console.log(data);
    });
  }
}
