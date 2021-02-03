import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { combineLatest, Observable } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { ToDoService } from '../to-do.service';

@Component({
  selector: 'app-to-do',
  templateUrl: './to-do.component.html',
  styleUrls: ['./to-do.component.scss']
})
export class ToDoComponent  {

  public toDoId$: Observable<string> = this._activatedRoute.params.pipe(
   map(x => x["toDoId"]) 
  );

  public vm$ = combineLatest([this.toDoId$])
  .pipe(
    map(([toDoId]) => toDoId),
    switchMap(toDoId => this._toDoService.getById({ toDoId })),
    map(toDo => {
      return {
        toDo
      };
    })
  )
  
  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _toDoService: ToDoService,
    private readonly _router: Router
  ) { }

  back() {
    this._router.navigateByUrl("");
  }
}
