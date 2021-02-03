import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ToDoListComponent } from './to-dos/to-do-list/to-do-list.component';
import { ToDoComponent } from './to-dos/to-do/to-do.component';

const routes: Routes = [
  { path: "", component: ToDoListComponent },
  { path: "to-dos/:toDoId", component: ToDoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
