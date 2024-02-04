import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OfferRoutingModule } from './offer-routing.module';
import { OfferComponent } from './offer/offer.component';
import { ReactiveFormsModule } from '@angular/forms';
import { BidsComponent } from './bids/bids.component';


@NgModule({
  declarations: [
    OfferComponent,
    BidsComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    OfferRoutingModule
  ]
})
export class OfferModule { }
