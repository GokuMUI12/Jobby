import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserToReturn } from '../shared/models/UserToReturn';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FreelancerService {
  baseUrl = environment.apiUrl
  constructor(public http: HttpClient) { }

  getFreelancers() {
    return this.http.get<UserToReturn[]>(this.baseUrl + 'Account/get-all-freelancers')
  }
}
