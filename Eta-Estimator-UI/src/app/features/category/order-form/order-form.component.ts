import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { OrderService } from '../services/order.service';
import { OrderRequest } from '../models/order-request.model';
import { SubmittedOrder } from '../models/submitted-order.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-order-form',
  standalone : true,
  imports: [CommonModule,FormsModule],
  templateUrl: './order-form.component.html',
})
export class OrderFormComponent {
  region = '';
  productIdsText = '';
  submittedOrder?: SubmittedOrder;
  error?: string;

  constructor(private orderService: OrderService) {}

  submitOrder() {
    const productIds = this.productIdsText.split(',').map(p => p.trim());
    const request: OrderRequest = {
      region: this.region,
      productIds
    };

    this.orderService.submitOrder(request).subscribe({
      next: (order: any) => {        
        this.submittedOrder = order;       
        this.error = undefined;
      },
      error: (err: any) => {
        this.error = 'Failed to submit order';
        console.error(err);
      }
    });
  }
}
