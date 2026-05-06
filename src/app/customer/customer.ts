import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Customer } from '../models/customer';
import { CustomerService } from '../services/customer';

@Component({
  selector: 'app-customer',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './customer.html',
  styleUrl: './customer.css'
})
export class CustomerComponent {

  customer: Customer = new Customer();

  constructor(private service: CustomerService) {}

  saveCustomer(form: any) {

    if (form.invalid) {
      return;
    }

    if (this.customer.dateOfBirth) {
      const dob = new Date(this.customer.dateOfBirth);
      const today = new Date();

      let age = today.getFullYear() - dob.getFullYear();
      const monthDiff = today.getMonth() - dob.getMonth();

      if (
        monthDiff < 0 ||
        (monthDiff === 0 && today.getDate() < dob.getDate())
      ) {
        age--;
      }

      this.customer.age = age;

      // FIXED DATE FORMAT
      this.customer.dateOfBirth =
        dob.toISOString().split('T')[0];
    }

    this.service.addCustomer(this.customer).subscribe({
      next: () => {
        alert("Customer Added Successfully");
        this.customer = new Customer();
      },
      error: () => {
        alert("Save Failed");
      }
    });
  }
}