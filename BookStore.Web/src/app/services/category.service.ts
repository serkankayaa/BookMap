import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Category } from '../models/category';
import { apiBaseUrl } from '../../config';
import { headerContent } from '../header';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class CategoryService {
  allCategories;

  constructor(private http: HttpClient) { }
  getAllCategories(): Observable<Category[]> {
    this.allCategories = this.http.get(apiBaseUrl + '/Category');

    return this.allCategories;
  }

  postCategory(category: Category) {
    const postedCategory = this.http.post(apiBaseUrl + '/Category', category, { headers: headerContent, observe: 'response' });

    return postedCategory;
  }
  updateCategory(category: Category) {
    const updatedCategory = this.http.put(apiBaseUrl + '/Category', category, { headers: headerContent, observe: 'response' });

    return updatedCategory;
  }

  deleteCategory(id: any) {
    const deletedCategory = this.http.delete(apiBaseUrl + '/Category/' + id, { headers: headerContent, observe: 'body' });
    
    return deletedCategory;
  }
}
