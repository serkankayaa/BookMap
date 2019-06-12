import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { apiBaseUrl } from '../../config';
import { headerContent } from '../header';

import { Book } from '../models/book';

@Injectable()
export class BookService {
    getAllBooksUrl = `${apiBaseUrl}/GetAllBooks`;
    postBookUrl = `${apiBaseUrl}/PostBook`;

    constructor(private http: HttpClient) { }

    getAllBooks(): Observable<Book[]> {
        return this.http.get<Book[]>(this.getAllBooksUrl);
    }

    postBook(book: Book) {
        return this.http.post<Book>(this.postBookUrl, book, { headers: headerContent, observe: 'response', reportProgress: true });
    }
}
