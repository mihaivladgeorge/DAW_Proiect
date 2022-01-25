import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { Manufacturer } from '../interfaces/manufacturer';
import { ManufacturerService } from '../manufacturer.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  manufacturers: Manufacturer[] = []

  constructor(private manufacturerService: ManufacturerService, private authService : AuthService) { }

  ngOnInit(): void {
    this.getManufacturers();
  }

  getManufacturers(): void {
     this.manufacturerService.getManufacturers()
       .subscribe(manufacturers => this.manufacturers = manufacturers.slice(1, 5));
  }

  OnLogout() {
    this.authService.logout();
  }
}
