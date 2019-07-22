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

  constructor(private dashboardService: DashboardService) { }

  ngOnInit() {
    this.dashboardService.getDataCounts().subscribe(result => {
      this.dashboardData = result[0];
    });
  }
}
