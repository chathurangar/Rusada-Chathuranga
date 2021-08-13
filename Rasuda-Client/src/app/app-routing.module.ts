import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import {SightDetailsComponent} from './sight-details/sight-details.component';

const routes: Routes = [
  {path: 'sightdetails', component:SightDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
