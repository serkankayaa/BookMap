import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../models/user';
import { apiBaseUrl } from '../../config';

@Injectable()

export class JwtService {

    constructor(private httpClient: HttpClient) { }

    GetToken(user: User) {
        const headerContent = new HttpHeaders()
            .set('Content-Type', 'application/json')
            .set('Accept', 'application/json');
        return this.httpClient.post(apiBaseUrl + '/Token', user, { headers: headerContent, observe: 'body' });
    }

    Logout() {
        localStorage.removeItem('bookMapToken');
    }

    public get TokenControl(): boolean {
        return (!localStorage.getItem('bookMapToken'));
    }



}
