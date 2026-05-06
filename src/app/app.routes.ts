import { Routes } from '@angular/router';
import { CustomerComponent } from './customer/customer';
import { CustomerListComponent } from './customer-list/customer-list';

export const routes: Routes = [

  {
    path: '',
    redirectTo: 'list',
    pathMatch: 'full'
  },

  {
    path: 'customer',
    component: CustomerComponent
  },

  {
    path: 'list',
    component: CustomerListComponent
  }

];