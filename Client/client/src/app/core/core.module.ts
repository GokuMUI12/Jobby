import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { SectionHeaderComponent } from './section-header/section-header.component';



@NgModule({
  declarations: [
    NavbarComponent,
    SectionHeaderComponent
  ],
  imports: [
    CommonModule,
  ],
  exports:[
    NavbarComponent,
    SectionHeaderComponent
  ]
})
export class CoreModule { }
