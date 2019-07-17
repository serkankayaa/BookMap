import { Supplier } from './../../models/supplier';
import { Category } from './../../models/category';
import { Author } from './../../models/author';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Book } from '../../models/book';
import { Publisher } from '../../models/publisher';
declare var $: any;

@Component({
  selector: 'app-admin-book',
  templateUrl: './admin-book.component.html',
  styleUrls: ['./admin-book.component.css']
})
export class AdminBookComponent implements OnInit {
  public formSubmitted = false;
  public book: object = new Book();
  public allAuthors: Author[];
  public allCategories: Category[];
  public allPublishers: Publisher[];
  public allSuppliers: Supplier[];
  public bookForm: FormGroup;

  constructor(private fb: FormBuilder) { }

  get form() {
    return this.bookForm.controls;
  }

  ngOnInit() {
    this.bookForm = this.fb.group({
      book: ['', Validators.required],
      summary: ['', Validators.required],
      author: ['', Validators.required],
      publisher: ['', Validators.required],
      category: ['', Validators.required],
      shop: ['', Validators.required],
      image: ['', Validators.required]
    });
  }


  uploadCover(file) {
    console.log(file);
    const imageDetails = file.target.files[0];
    console.log(imageDetails);
  }

  submitBook() {
    this.formSubmitted = true;
    if (this.bookForm.invalid) {
      return;
    }
    console.log(this.bookForm);
    console.log(this.book);
  }
}
