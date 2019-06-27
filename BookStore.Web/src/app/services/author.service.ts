import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { Author } from '../models/author';
import { headerContent } from '../header';
import { apiBaseUrl } from '../../config';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class AuthorService {
  allAuthors;

  constructor(private http: HttpClient) { }

  getAllAuthors(): Observable<Author[]> {
    this.allAuthors = this.http.get(apiBaseUrl + '/Author');
    return this.allAuthors;
  }

  //TODO: GetById

  postAuthor(author: Author) {
    const postedAuthor = this.http.post(apiBaseUrl + '/Author', author, { headers: headerContent, observe: 'response' });

    return postedAuthor;
  }

  updateAuthor(author: Author) {
    const updatedAuthor = this.http.put(apiBaseUrl + '/Author', author, { headers: headerContent, observe: 'response' });

    return updatedAuthor;
  }

  deleteAuthor(id: any) {
    const deletedAuthor = this.http.delete(apiBaseUrl + '/Author/' + id, { headers: headerContent, observe: 'body' });
    
    return deletedAuthor;
  }
}
