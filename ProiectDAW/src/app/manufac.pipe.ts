import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'manufac'
})
export class ManufacPipe implements PipeTransform {

  transform(value: string): any {
    
    var manu = `Manufacturer name is: ${value}`;
    
    return manu;
  }

}
