import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpEventType } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

import { AuthorService } from '../../services/author.service';
import { PublisherService } from '../../services/publisher.service';
import { CategoryService } from '../../services/category.service';
import { DocumentService } from '../../services/document.service';
import { BookService } from '../../services/book.service';
import { ShopService } from '../../services/shop.service';

import { Author } from '../../models/author';
import { Book } from '../../models/book';
import { Category } from '../../models/category';
import { Publisher } from '../../models/publisher';
import { Shop } from '../../models/shop';
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
  public allBooks: Book[];
  public book: Book[];
  public allAuthors: Author[];
  public allPublishers: Publisher[];
  public allCategories: Category[];
  public allShops: Shop[];
  public formData = new FormData();
  public fileToUpload;

  filePath;

  @Output() public onUploadFinished = new EventEmitter();

  constructor(
    public authorService: AuthorService,
    public shopService: ShopService,
    public publisherService: PublisherService,
    public documentService: DocumentService,
    public categoryService: CategoryService,
    private toastrService: ToastrService,
    public bookService: BookService) { }

  ngOnInit() {
    this.getAllAuthors();
    this.getAllCategories();
    this.getAllPublishers();
    this.getAllBooks();
    this.getAllShops();
  }

  onSubmit() { this.submitted = true; }

  uploadFile(files): object {

    if (files.length === 0) {
      return;
    }

    this.fileToUpload = <File>files[0];
    this.formData.append('file', this.fileToUpload, this.fileToUpload.name);
    this.postDocument();
  }

  getAllAuthors() {
    this.authorService.getAllAuthors().subscribe(authorData => {
      this.allAuthors = authorData;
    });
  }

  getAllCategories() {
    this.categoryService.getAllCategories().subscribe(categoryData => {
      this.allCategories = categoryData;
    });
  }

  getAllPublishers() {
    this.publisherService.getAllPublishers().subscribe(publisherData => {
      this.allPublishers = publisherData;
    });
  }

  getAllBooks() {
    this.bookService.getAllBooks().subscribe(bookData => {
      this.allBooks = bookData;
    });
  }

  getAllShops() {
    this.shopService.getAllShops().subscribe(shopData => {
      this.allShops = shopData;
    });
  }

  postDocument(): void {
    this.documentService.postDocument(this.formData).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress) {
      } else if (event.type === HttpEventType.Response) {
        this.message = this.fileToUpload.name;
        this.onUploadFinished.emit(event.body);
        this.bookModel.ImageIdFk = event.body.toString();
      }
    });
  }

  postBook(): void {
    this.bookService.postBook(this.bookModel).subscribe(response => {
      if (response.body != null && response.ok) {
        this.toastrService.success('Publisher edited successfully.');
        this.getAllBooks();
      }
    });
  }
}
