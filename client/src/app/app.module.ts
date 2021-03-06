import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';
import { BookListComponent } from './book-list/book-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BookComponent } from './book/book.component';
import { NavComponent } from './nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    BookListComponent,
    BookComponent,
    NavComponent,
    TextInputComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
