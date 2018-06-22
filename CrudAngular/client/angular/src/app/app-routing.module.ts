import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VehicleComponent } from './components/vehicle/vehicle.component';
import { HomeComponent } from './components/home/home.component';



const appRoutes: Routes = [
  { path: '', redirectTo: 'vehicles', pathMatch: 'full' },
  { path: 'vehicles/new', component: VehicleComponent },
  { path: 'home', component: HomeComponent },
  { path: '**', redirectTo: 'home' }
];


@NgModule({
  exports: [ RouterModule, VehicleComponent ],

  imports: [
    CommonModule
  ],
  declarations: []
})

export class AppRoutingModule { }
