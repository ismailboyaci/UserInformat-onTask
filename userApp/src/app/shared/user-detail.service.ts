import { Injectable } from '@angular/core';
import { UserDetail } from './user-detail.model';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class UserDetailService {

  constructor(private http:HttpClient) { }

  formData:UserDetail = new UserDetail ();
  readonly baseUrl = 'http://localhost:5067/api/Test'
  list : UserDetail[];

  postUserDetail(){
    return this.http.post(this.baseUrl,this.formData);
  }

  deleteUserDetail(id:number){
    return this.http.delete(`${this.baseUrl}/${id}`)
  }

  refreshList(){
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res=>this.list=res as UserDetail[]);
  }
}
