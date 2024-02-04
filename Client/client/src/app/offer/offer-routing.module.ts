import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OfferComponent } from './offer/offer.component';
import { BidsComponent } from './bids/bids.component';

const routes: Routes = [
  {path: 'job/:jobId', component : OfferComponent},
  {path: 'bids/:id', component: BidsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OfferRoutingModule { }
