import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Shop } from '../models/shop';
import { apiBaseUrl } from '../../config';
import { headerContent } from '../header';

@Injectable()
export class ShopService {
    shopList;

    constructor(private http: HttpClient) { }

    postShop(shop: Shop) {
        const result = this.http.post(apiBaseUrl + '/PostShop', shop, { headers: headerContent, observe: 'response' });
        return result;
    }

    getAllShops(): Observable<Shop[]> {
        this.shopList = this.http.get(apiBaseUrl + '/GetAllShops');

        return this.shopList;
    }

    updateShop(shop: Shop) {
        const result = this.http.put(apiBaseUrl + '/UpdateShop', shop, { headers: headerContent, observe: 'response' });
        return result;
    }

    deleteShop(id: any) {
        const result = this.http.delete(apiBaseUrl + '/DeleteShop/' + id, { headers: headerContent, observe: 'body' });
        return result;
    }
}
