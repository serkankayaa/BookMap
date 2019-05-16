import { Component, OnInit } from '@angular/core';
import { Book } from '../models/book';
import { BookService } from "../services/book.service";
import { ToastrService, Toast } from 'ngx-toastr';
declare var $: any;

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {
  book = new Book;
  allBooks: Book[];
  isEdit = false;
  bookId: any;
  hasData = true;

  constructor(private bookService: BookService, private toastrService: ToastrService) { }

  ngOnInit() {
    console.log('this is book.component.ts');
  }

}
