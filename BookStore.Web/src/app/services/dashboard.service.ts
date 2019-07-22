import { Injectable } from '@angular/core';
import { apiBaseUrl } from '../../config';
import { HttpClient } from '@angular/common/http';
import { headerContent } from '../header';
import { Observable } from 'rxjs';
import { DashboardCount } from '../models/dashboardCount';

@Injectable()
export class DashboardService {
  allDataCount;
  recentShopTableData;
  recentAuthorTableData;
  recentBookTableData;
  recentPublisherTableData;
  recentCategoryTableData;


  constructor(private http: HttpClient) { }

  getDataCounts(): Observable<object> {
    this.allDataCount = this.http.get(apiBaseUrl + '/Dashboard/DataCount', { headers: headerContent, observe: 'body' });

    return this.allDataCount;
  }

  getShopTableData(): Observable<object> {
    this.recentShopTableData = this.http.get(apiBaseUrl + '/RecentShops', { headers: headerContent, observe: 'response' });

    return this.recentShopTableData;
  }

  getAuthorTableData(): Observable<object> {
    this.recentAuthorTableData = this.http.get(apiBaseUrl + '/RecentAuthors', { headers: headerContent, observe: 'response' });

    return this.recentAuthorTableData;
  }

  getBookTableData(): Observable<object> {
    this.recentBookTableData = this.http.get(apiBaseUrl + '/RecentBooks', { headers: headerContent, observe: 'response' });

    return this.recentBookTableData;
  }

  getPublisherTableData(): Observable<object> {
    this.recentPublisherTableData = this.http.get(apiBaseUrl + '/RecentPublishers', { headers: headerContent, observe: 'response' });

    return this.recentPublisherTableData;
  }

  getCategoryTableData(): Observable<object> {
    this.recentCategoryTableData = this.http.get(apiBaseUrl + '/RecentCategories', { headers: headerContent, observe: 'response' });

    return this.recentCategoryTableData;
  }
}
