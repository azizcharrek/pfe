import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  items = [];
  pageOfItems: Array<any>;
 /*  collection = [];
  constructor(){
    for(let i=1;i<=100;i++){
    let Obj = {'name': `Employee Name ${i}`,'code': `EMP00 ${i}`}
    this.collection.push(Obj);
    } */

  ngOnInit() {
    this.pageOfItems= [];
      // an example array of 150 items to be paged
      this.items = Array(150).fill(0).map((x, i) => ({ id: (i + 1), name: `Item ${i + 1}`}));
  }

  onChangePage(pageOfItems: Array<any>) {
      // update current page of items
      this.pageOfItems = pageOfItems;
  }
}
