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
  publisher$;

  constructor(private http : HttpClient) { }

  getAllPublisher(): Observable<Publisher[]> {
    this.publisher$ = this.http.get(apiBaseUrl + '/GetAllPublisher');

    return this.publisher$;
  }
  
  postPublisher(publisher : Publisher){
    const result = this.http.post(apiBaseUrl + "/PostPublisher" , publisher, { headers: headerContent, observe: 'response' });

    return result;
  }
}
