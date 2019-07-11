import { Component, OnInit } from '@angular/core';
import { NgForm, FormBuilder, Validators } from '@angular/forms';
import { Book } from '../../models/book';
declare var $: any;


@Component({
  selector: 'app-admin-book',
  templateUrl: './admin-book.component.html',
  styleUrls: ['./admin-book.component.css']
})
export class AdminBookComponent implements OnInit {
  public bookModel: object = new Book();

  constructor(private fb: FormBuilder) { }

  bookForm = this.fb.group({
    bookName: ['', Validators.required],
    summary: ['', Validators.required],
    authorName: ['', Validators.required],
    publisherName: ['', Validators.required],
    categoryName: ['', Validators.required],
    shopName: ['', Validators.required],
    imageName:['', Validators.required]
  });

  ngOnInit() {}

  submitBook() {
    console.log(this.bookForm.value);
    console.log(this.bookModel);
  }
}
