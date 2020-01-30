import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { AreaModel } from '../model/area.model';

@Injectable({
  providedIn: 'root'
})
export class AreaCrudService {

  baseurl = environment.baseURL;
  constructor(private http: HttpClient) { }


  Create(area: AreaModel) {
    let reqHeader = new HttpHeaders();
    return this.http.post(this.baseurl + 'api/area/create-area', area, { headers: reqHeader });
  }

  GetById(id: number) {
    let reqHeader = new HttpHeaders();
    return this.http.get(this.baseurl + 'api/area/get-area-byId?id=' + id, { headers: reqHeader });
  }

  GetAll() {
    let reqHeader = new HttpHeaders();
    return this.http.get(this.baseurl + 'api/area/get-all-areas', { headers: reqHeader });
  }

  Update(area: AreaModel) {
    let reqHeader = new HttpHeaders();
    return this.http.put(this.baseurl + 'api/area/update-area', area, { headers: reqHeader });
  }

  Delete(id: number) {
    let reqHeader = new HttpHeaders();
    return this.http.delete(this.baseurl + 'api/area/delete-area?id=' + id, { headers: reqHeader });
  }
}
