import { Component, OnInit, Input } from '@angular/core';
import { Manufacturer } from '../../../interfaces/manufacturer';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { ManufacturerService } from '../../../manufacturer.service';

@Component({
  selector: 'app-manufacturer-detail',
  templateUrl: './manufacturer-detail.component.html',
  styleUrls: ['./manufacturer-detail.component.css']
})
export class ManufacturerDetailComponent implements OnInit {
  selectedMan? : Manufacturer;

  constructor(
    private route: ActivatedRoute,
    private manufacturerService: ManufacturerService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.getManufacturer();
  }

  getManufacturer(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.manufacturerService.getManufacturer(id)
      .subscribe(manufacturer => this.selectedMan = manufacturer);
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    if (this.selectedMan) {
      this.manufacturerService.updateManufacturer(this.selectedMan)
        .subscribe(() => this.goBack());
    }
  }

}
