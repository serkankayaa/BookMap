import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { Author } from '../models/author';
import { apiBaseUrl } from '../../config';
import { headerContent } from '../header';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class AuthorService {
  author$;

  constructor(private http: HttpClient) { }

  getAllAuthor(): Observable<Author[]> {
    this.author$ = this.http.get(apiBaseUrl + '/getAllAuthor');

    return this.author$;
  }

  postAuthor(author: Author) {
    const result = this.http.post(apiBaseUrl + '/PostAuthor', author, { headers: headerContent, observe: 'response' });

    return result;
  }

  updateAuthor(author: Author) {
    const result = this.http.put(apiBaseUrl + '/UpdateAuthor', author, { headers: headerContent, observe: 'response' });
    return result;
  }

  deleteAuthor(id: any) {
    const options = {
      headers: headerContent,
      body: {
        id: id
      },
    };
    const result = this.http.delete(apiBaseUrl + '/DeleteAuthor/' + id, options);
    return result;
  }

}
