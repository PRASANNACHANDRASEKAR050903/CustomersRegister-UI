import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Customer } from '../models/customer';
import { Router } from '@angular/router';
import { CustomerService } from '../services/customer';

@Component({
  selector: 'app-customer-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './customer-list.html',
  styleUrls: ['./customer-list.css']
})
export class CustomerListComponent implements OnInit {

  customers: Customer[] = [];

  constructor(
    public router: Router,
    private service: CustomerService
  ) {}

  ngOnInit(): void {
    this.loadCustomers();
  }

  loadCustomers() {
    this.service.getCustomers().subscribe({
      next: (data) => {
        this.customers = data;
      },
      error: (err) => {
        console.error("Error:", err);
      }
    });
  }

  goToAddCustomer() {
    this.router.navigate(['/customer']);
  }

  editCustomer(id: number) {
    this.router.navigate(['/customer'], {
      queryParams: { id: id }
    });
  }

  deleteCustomer(id: number) {
    if (confirm("Are you sure?")) {
      this.service.deleteCustomer(id).subscribe({
        next: () => {
          alert("Deleted successfully");
          this.loadCustomers();
        },
        error: () => {
          alert("Delete failed");
        }
      });
    }
  }
}