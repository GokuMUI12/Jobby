import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { OfferService } from '../offer.service';
import { Offer } from 'src/app/shared/models/offer';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-offer',
  templateUrl: './offer.component.html',
  styleUrls: ['./offer.component.css']
})
export class OfferComponent implements OnInit {
  jobId?: string | null
  offerForm!: FormGroup
  constructor(public route: ActivatedRoute, public offerService: OfferService) { }

  ngOnInit(): void {
    this.jobId = this.route.snapshot.paramMap.get('jobId')
    this.offerForm = new FormGroup({
      amount: new FormControl(0, Validators.required),
      daysExpected: new FormControl(0, Validators.required),
      //  jobId: new FormControl(this.jobId, Validators.required)
      message: new FormControl('', Validators.required)
    })
  }

  public makeOffer(offerFormValues: Offer) {
    const formValues = { ...offerFormValues };

    if (this.jobId !== null && this.jobId !== undefined) {
      const jobIdNumber = parseInt(this.jobId, 10);
      const offer: Offer = {
        id: 0,
        amount: formValues.amount,
        jobId: jobIdNumber,
        daysExpected: formValues.daysExpected,
        message: formValues.message
      }
      this.offerService.addOffer(offer).subscribe({
        next: () => console.log('Offer Successfully Made'),
        error: (err: HttpErrorResponse) => {
          console.log('Error')
        }
      })
    }
  }
}
