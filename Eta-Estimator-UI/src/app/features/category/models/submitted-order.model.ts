import { EtaItem } from './eta-item.model';

export interface SubmittedOrder {
  orderId: string;
  region: string;
  productEtas: EtaItem[];
}
