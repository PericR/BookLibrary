import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookListComponent } from './book-list/book-list.component';
import { BookComponent } from './book/book.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: 'book', component: BookListComponent},
  { path: 'book/:id', component: BookComponent},
  { path: 'register', component: RegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
