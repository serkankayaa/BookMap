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
    category$;

constructor(private http: HttpClient) {}
    getCategories(): Observable<Category[]> {
        this.category$ = this.http.get(apiBaseUrl + '/GetCategories');
        return this.category$;
    }
    postCategory(category: Category) {
        const result = this.http.post(apiBaseUrl + '/postCategory', category, { headers: headerContent, observe: 'response' });
        return result;
    }
}
