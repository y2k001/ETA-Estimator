import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { OrderFormComponent } from './features/category/order-form/order-form.component';
import { OrderListComponent } from './features/category/order-list/order-list.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent   
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    OrderFormComponent,
    OrderListComponent,
    HttpClientModule,    
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
