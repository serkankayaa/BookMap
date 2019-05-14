import { HttpHeaders } from '@angular/common/http';

export const headerContent = new HttpHeaders().set('Content-Type', 'application/json').set('Accept', 'application/json');
