import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Offer, OfferToReturnDto } from '../shared/models/offer';

@Injectable({
  providedIn: 'root'
})
export class OfferService {

  constructor(public http: HttpClient) { }
  baseUrl = environment.apiUrl;
  addOffer(offerForm: Offer) {
    return this.http.post<any>(this.baseUrl + 'Offer/make-offer', offerForm)
  }

  getJobOffers(jobId : any) {
    return this.http.get<any>(this.baseUrl + `Offer/get-offers?jobId=${jobId}`);

  }
}
