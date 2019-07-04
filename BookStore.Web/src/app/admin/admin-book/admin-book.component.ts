import { Component, OnInit } from '@angular/core';
declare var $: any;


@Component({
  selector: 'app-admin-book',
  templateUrl: './admin-book.component.html',
  styleUrls: ['./admin-book.component.css']
})
export class AdminBookComponent implements OnInit {

  constructor() { }

  ngOnInit() {

  }

  BookDetail(): any {
    $(function() {
      (<any>$('#exampleModal')).modal('show');
    });
  }
}
