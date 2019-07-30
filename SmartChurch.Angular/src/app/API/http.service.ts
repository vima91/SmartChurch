import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) {}

  getAll(url: string) {

    return this.http.get<any[]>(url);
  }

  getItemById(url: string) {

    return this.http.get(url);
  }

  create(url: string, item: any) {

    if (!item.Id) {

      return this.http.put(url, JSON.stringify(item));
    }
    return null;
  }

  update(url: string, item: any) {

    return this.http.post(url, JSON.stringify(item));
  }

  delete(url: string, item: any) {

    if (item.Id) {

      return this.http.delete(`${url}`);
    }
  }

  search(url: string, term: string) {

    const params = new HttpParams().set('q', term);
    return this.http.get(url, { params: params });
  }
}
