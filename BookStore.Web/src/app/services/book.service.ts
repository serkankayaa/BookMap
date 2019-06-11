import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';



@Injectable()
export class BookService {

    constructor(private http: HttpClient) { }

}
