import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path:'job', loadChildren: () => import('./employers/employers.module').then(m => m.EmployersModule)},
  {path: 'account', loadChildren: () => import('./account/account.module').then(m => m.AccountModule)},
  {path: 'offer', loadChildren: () => import('./offer/offer.module').then(m => m.OfferModule)},
  {path: '', loadChildren: () => import('./employees/employees.module').then(e => e.EmployeesModule)},
  {path: '', loadChildren: () => import('./freelancers/freelancers.module').then(e => e.FreelancersModule)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
