export interface Offer {
    id : number,
    amount : number,
    daysExpected : number,
    jobId : number,
    message : string    
}

export interface OfferToReturnDto {
    id : number
    amount : number
    days : number
    message : number
    email : string
    jobId : number
}