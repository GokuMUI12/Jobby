import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Job, JobCategory } from '../shared/models/job';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JobService {

  constructor(private http: HttpClient) { }
  baseUrl = environment.apiUrl;

  getJobCategories(): Observable<any> {
    return this.http.get<JobCategory[]>(this.baseUrl + 'job/get-job-categories')
  }

  getJobsForUser() : Observable<any[]>{
    return this.http.get<any[]>(this.baseUrl + 'job/get-jobs-for-user')
  }

  addJob(values: any) {
    return this.http.post<Job>(this.baseUrl + 'job/add-job', values)
  }

  getJobById(id: number){
    return this.http.get<any>(this.baseUrl + 'job/get-job-by-id?id=' + id)
  }
}
