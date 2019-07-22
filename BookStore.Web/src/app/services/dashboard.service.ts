import { Injectable } from '@angular/core';
import { apiBaseUrl } from '../../config';
import { HttpClient } from '@angular/common/http';
import { headerContent } from '../header';
import { Observable } from 'rxjs';

@Injectable()
export class DashboardService {
  allDataCount;

  constructor(private http: HttpClient) { }

  getDataCounts(): Observable<object> {
    this.allDataCount = this.http.get(apiBaseUrl + '/Dashboard/DataCount', { headers: headerContent, observe: 'body' });
    
    return this.allDataCount;
  }
}
