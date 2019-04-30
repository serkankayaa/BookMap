import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { Supplier } from '../models/supplier';
import { apiBaseUrl } from '../../config';
import { headerContent } from '../header';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class SupplierService {
    supplier$;

    constructor(private http: HttpClient) { }

    getAllSupplier(): Observable<Supplier[]> {
        this.supplier$ = this.http.get(apiBaseUrl + '/GetAllSupplier');
        return this.supplier$;
    }

    postSupplier(supplier: Supplier) {
        const result = this.http.post(apiBaseUrl + '/postSupplier', supplier, { headers: headerContent, observe: 'response' });
        return result;
    }

}
