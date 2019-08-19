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
  allSuppliers: any;

  constructor(private http: HttpClient) { }

  getAllSuppliers(): Observable<Supplier[]> {
    this.allSuppliers = this.http.get(apiBaseUrl + '/Supplier');

    return this.allSuppliers;
  }

  postSupplier(supplier: Supplier) {
    const postedSupplier = this.http.post(apiBaseUrl + '/Supplier', supplier, { headers: headerContent, observe: 'response' });

    return postedSupplier;
  }

  updateSupplier(supplier: Supplier) {
    const updatedSupplier = this.http.put(apiBaseUrl + '/Supplier', supplier, { headers: headerContent, observe: 'response' });

    return updatedSupplier;
  }

  deleteSupplier(id: any) {
    const deleteSupplier = this.http.delete(apiBaseUrl + '/Supplier/' + id, { headers: headerContent, observe: 'body' });

    return deleteSupplier;
  }
}
