import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path:'job', loadChildren: () => import('./employers/employers.module').then(m => m.EmployersModule)},
  {path: 'account', loadChildren: () => import('./account/account.module').then(m => m.AccountModule)},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
