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

    getSuppliers(): Observable<Supplier[]> {
        this.supplier$ = this.http.get(apiBaseUrl + '/GetSuppliers');
        return this.supplier$;
    }

    postSupplier(supplier: Supplier) {
        const result = this.http.post(apiBaseUrl + '/PostSupplier', supplier, { headers: headerContent, observe: 'response' });
        return result;
    }

    updateSupplier(supplier: Supplier) {
        const result = this.http.put(apiBaseUrl + '/UpdateSupplier', supplier, { headers: headerContent, observe: 'response' });
        return result;
    }

}
