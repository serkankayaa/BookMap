import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { apiBaseUrl } from '../../config';
import { headerContent } from '../header';

import { Book } from '../models/book';

@Injectable()
export class BookService {
  allBooks;

  constructor(private http: HttpClient) { }

  getAllBooks(): Observable<Book[]> {
    this.allBooks = this.http.get(apiBaseUrl + '/Book', { headers: headerContent, observe: 'response', });
    return this.allBooks;

  }

  postBook(book: Book) {
    return this.http.post<Book>(apiBaseUrl + '/Book', book, { headers: headerContent, observe: 'response', reportProgress: true });
  }

  //TODO: PUT,DELETE
}
