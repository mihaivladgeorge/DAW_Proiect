import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'idpipe'
})
export class IdpipePipe implements PipeTransform {

  transform(value: number): any {
    
    var idString = `Manufacturer id is ${value}`;

    return idString;

  }

}
