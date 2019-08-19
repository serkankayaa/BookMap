import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

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

  getBook(id: any): Observable<any> {
    const book = this.http.get(apiBaseUrl + '/Book/' + id, { headers: headerContent, observe: 'body' });

    return book;
  }

  postBook(book: Book) {
    return this.http.post<Book>(apiBaseUrl + '/Book', book, { headers: headerContent, observe: 'response', reportProgress: true });
  }

  updateBook(book: Book) {
    const updatedBook = this.http.put(apiBaseUrl + '/Book', book, { headers: headerContent, observe: 'response' });

    return updatedBook;
  }

  deleteBook(id: any) {
    const deletedBook = this.http.delete(apiBaseUrl + '/Book/' + id, { headers: headerContent, observe: 'body' });

    return deletedBook;
  }
}
