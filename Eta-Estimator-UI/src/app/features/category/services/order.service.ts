import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OrderRequest } from '../models/order-request.model';
import { SubmittedOrder } from '../models/submitted-order.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private apiUrl = 'https://localhost:5001/api/ordersapi';

  constructor(private http: HttpClient) {}

  submitOrder(order: OrderRequest): Observable<SubmittedOrder> {
    return this.http.post<SubmittedOrder>(this.apiUrl, order);
  }

  getOrders(): Observable<SubmittedOrder[]> {
    return this.http.get<SubmittedOrder[]>(this.apiUrl);
  }

  deleteOrder(orderId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${orderId}`);
  }
}
