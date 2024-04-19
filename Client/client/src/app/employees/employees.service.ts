import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserToReturn } from '../shared/models/UserToReturn';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  constructor(public http : HttpClient) { }
  baseUrl = environment.apiUrl
  getAllEmployees(){
     return this.http.get<UserToReturn[]>(this.baseUrl + 'Account/get-all-employers')
  }

}
