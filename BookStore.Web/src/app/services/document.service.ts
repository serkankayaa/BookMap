import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { apiBaseUrl } from '../../config';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class DocumentService {

  constructor(private http: HttpClient) { }

  postDocument(formData: FormData) {
    const postedDocument = this.http.post(apiBaseUrl + '/Document', formData, { reportProgress: true, observe: 'events' });

    return postedDocument;
  }
}
