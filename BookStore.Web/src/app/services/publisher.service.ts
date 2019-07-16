import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Publisher } from '../models/publisher';
import { apiBaseUrl } from '../../config';
import { headerContent } from '../header';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class PublisherService {
  allPublishers;

  constructor(private http: HttpClient) { }

  getAllPublishers(): Observable<Publisher[]> {
    this.allPublishers = this.http.get(apiBaseUrl + '/Publisher');

    return this.allPublishers;
  }

  postPublisher(publisher: Publisher) {
    const postedPublisher = this.http.post(apiBaseUrl + '/Publisher', publisher, { headers: headerContent, observe: 'response' });

    return postedPublisher;
  }

  updatePublisher(publisher: Publisher) {
    const updatedPublisher = this.http.put(apiBaseUrl + '/Publisher', publisher, { headers: headerContent, observe: 'response' });

    return updatedPublisher;
  }

  deletePublisher(id: any) {
    const deletedPublisher = this.http.delete(apiBaseUrl + '/Publisher/' + id, { headers: headerContent, observe: 'body' });

    return deletedPublisher;
  }
}
