import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { Author } from '../models/author';

import { headerContent } from '../header';
import { apiBaseUrl } from '../../config';

@Injectable()
export class AuthorService {
  allAuthors;

  constructor(private http: HttpClient) { }

  getAllAuthors(): Observable<Author[]> {
    this.allAuthors = this.http.get(apiBaseUrl + '/getAllAuthor');
    return this.allAuthors;
  }

  postAuthor(author: Author) {
    const postedAuthor = this.http.post(apiBaseUrl + '/PostAuthor', author, { headers: headerContent, observe: 'response' });
    return postedAuthor;
  }

  updateAuthor(author: Author) {
    const updatedAuthor = this.http.put(apiBaseUrl + '/UpdateAuthor', author, { headers: headerContent, observe: 'response' });
    return updatedAuthor;
  }

  deleteAuthor(id: any) {
    const deletedAuthor = this.http.delete(apiBaseUrl + '/DeleteAuthor/' + id, { headers: headerContent, observe: 'body' });
    return deletedAuthor;
  }
}
