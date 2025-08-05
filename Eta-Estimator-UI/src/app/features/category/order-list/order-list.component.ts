import { Component, OnInit } from '@angular/core';
import { OrderService } from '../services/order.service';
import { SubmittedOrder } from '../models/submitted-order.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-order-list',
  standalone : true,
  imports: [CommonModule,FormsModule],
  templateUrl: './order-list.component.html',
})
export class OrderListComponent implements OnInit {
  orders: SubmittedOrder[] = [];

  constructor(private orderService: OrderService) {}

  ngOnInit(): void {
    this.loadOrders();
  }

  loadOrders() {
    this.orderService.getOrders().subscribe({
      next: (orders) => this.orders = orders
    });
  }

  deleteOrder(orderId: string) {
    if (confirm('Are you sure you want to delete this order?')) {
      this.orderService.deleteOrder(orderId).subscribe(() => this.loadOrders());
    }
  }
}
