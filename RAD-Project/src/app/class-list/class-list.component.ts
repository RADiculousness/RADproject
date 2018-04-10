import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import {Observable} from 'rxjs/Rx';

// Import RxJs required methods
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Component({
  selector: 'app-class-list',
  templateUrl: './class-list.component.html',
  styleUrls: ['./class-list.component.css']
})
export class ClassListComponent implements OnInit {

  classListItems: ClassListItem[] = [];
  modules: any[];

  t0: ClassListItem = { title: 'RAD', link: '/landing', attention: true };
  t1: ClassListItem = { title: 'Web Development', link: '/landing', attention: false };
  t2: ClassListItem = { title: 'Software Development', link: '/landing', attention: false };
  t3: ClassListItem = { title: 'Software Testing', link: '/landing', attention: true };
  t4: ClassListItem = { title: 'Graphic Design 102', link: '/landing', attention: true };
  t5: ClassListItem = { title: '2D Games Development', link: '/landing', attention: true };
  t6: ClassListItem = { title: '3D Modelling', link: '/landing', attention: false };
  t7: ClassListItem = { title: 'LINQ', link: '/landing', attention: true };


  constructor(private httpService: HttpService) { }

  ngOnInit() {
    this.classListItems.push(this.t0);
    this.classListItems.push(this.t1);
    this.classListItems.push(this.t2);
    this.classListItems.push(this.t3);
    this.classListItems.push(this.t4);
    this.classListItems.push(this.t5);
    this.classListItems.push(this.t6);
    this.classListItems.push(this.t7);
    this.loadModules();
  }

  loadModules() {
    // Get all comments
     this.httpService.getModules()
                       .subscribe(
                           modules => this.modules = modules,
                            err => {
                                console.log(err);
                            });
  }

  addModule(){
    let x: any = {ModuleName: 'Maths', Description: 'Numbers and the like'};
    console.log('adding');
    this.httpService.addModule(x);
  }

  logg(){
    this.loadModules();
    console.log('########################');
    console.log(this.modules);
  }

  

}

export interface ClassListItem {
  title: string;
  link: string;
  attention: boolean;
}