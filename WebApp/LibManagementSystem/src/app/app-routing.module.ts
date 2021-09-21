import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddBookComponent } from './Components/add-book/add-book.component';
import { AddMemberComponent } from './Components/add-member/add-member.component';
import { BooksComponent } from './Components/books/books.component';
import { MainComponent } from './Components/main/main.component';
import { MembersComponent } from './Components/members/members.component';

const routes: Routes = [
  {path: '', redirectTo:'/dashboard', pathMatch: 'full'},
  {path: 'dashboard', component: MainComponent,
    children: [
      {path: '', component: BooksComponent},
      {path: 'books', component: BooksComponent},
      {path: 'books/add', component: AddBookComponent},
      {path: 'members', component: MembersComponent},
      {path: 'members/add', component: AddMemberComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
