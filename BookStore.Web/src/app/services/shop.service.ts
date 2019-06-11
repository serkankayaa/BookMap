import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Shop } from '../models/shop';

import { apiBaseUrl } from '../../config';
import { headerContent } from '../header';

@Injectable()
export class ShopService {
    allShops: any;

    constructor(private http: HttpClient) { }

    postShop(shop: Shop) {
        const postedShop = this.http.post(apiBaseUrl + '/PostShop', shop, { headers: headerContent, observe: 'response' });
        return postedShop;
    }

    getAllShops(): Observable<Shop[]> {
        this.allShops = this.http.get(apiBaseUrl + '/GetAllShops');
        return this.allShops;
    }

    updateShop(shop: Shop) {
        const updatedShop = this.http.put(apiBaseUrl + '/UpdateShop', shop, { headers: headerContent, observe: 'response' });
        return updatedShop;
    }

    deleteShop(id: any) {
        const deletedShop = this.http.delete(apiBaseUrl + '/DeleteShop/' + id, { headers: headerContent, observe: 'body' });
        return deletedShop;
    }
}
