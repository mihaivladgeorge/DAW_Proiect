import { Component, OnInit, OnDestroy } from '@angular/core';
import { Manufacturer } from '../../../interfaces/manufacturer';
import { ManufacturerService } from '../../../manufacturer.service';
import { MessageService } from '../../../message.service';

@Component({
  selector: 'app-manufacturers',
  templateUrl: './manufacturers.component.html',
  styleUrls: ['./manufacturers.component.css']
})
export class ManufacturersComponent implements OnInit {
  manufacturers: Manufacturer[] = []

  constructor(private manufacturerService: ManufacturerService, private messageService: MessageService) { }

  ngOnInit(): void {
    this.getManufacturers();
  }

  ngOnDestroy(): void {
  }

  getManufacturers(): void {
    this.manufacturerService.getManufacturers().subscribe(manufacturers => this.manufacturers = manufacturers);
  }

  add(name: string, country: string): void {
    name = name.trim();
    country = country.trim();
    if (!name) { return; }
    if (!country) {return; }
    this.manufacturerService.addManufacturer({ name, country } as Manufacturer)
      .subscribe(manufacturer => {
        this.manufacturers.push(manufacturer);
      });
  }
  delete(manufacturer: Manufacturer): void {
    this.manufacturers = this.manufacturers.filter(m => m !== manufacturer);
    this.manufacturerService.deleteManufacturer(manufacturer.id).subscribe( manufacturers => {
      this.manufacturers = manufacturers;
    });
  }

}
