import { AuthorService } from './../../services/author.service';
import { DashboardCount } from './../../models/dashboardCount';
import { DashboardService } from './../../services/dashboard.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {
  public dashboardData: DashboardCount;
  public dashboardTableData;
  public shopTableList;
  public bookTableList;
  public categoryTableList;
  public publisherTableList;
  public rowCount;

  constructor(private dashboardService: DashboardService) { }

  ngOnInit() {
    this.getShopTableData();
    this.getBookTableData();
    this.getCategoryTableData();
    this.getPublisherTableData();
    this.getDataCount();
  }

  getDataCount() {
    this.dashboardService.getDataCounts().subscribe(result => {
      this.dashboardData = result[0];
    });
  }

  getShopTableData() {
    this.dashboardService.getShopTableData().subscribe(shopData => {
      // Explicitly tell TypeScript that we’re not interested in doing strict type checking.
      this.shopTableList = (<any>shopData).body;
    });
  }
  getBookTableData() {
    this.dashboardService.getBookTableData().subscribe(bookData => {
      // Explicitly tell TypeScript that we’re not interested in doing strict type checking.
      this.bookTableList = (<any>bookData).body;
    });
  }

  getCategoryTableData() {
    this.dashboardService.getCategoryTableData().subscribe(categoryData => {
      // Explicitly tell TypeScript that we’re not interested in doing strict type checking.
      this.categoryTableList = (<any>categoryData).body;
    });
  }
  getPublisherTableData() {
    this.dashboardService.getPublisherTableData().subscribe(publisherData => {
      // Explicitly tell TypeScript that we’re not interested in doing strict type checking.
      this.publisherTableList = (<any>publisherData).body;
    });
  }
}
