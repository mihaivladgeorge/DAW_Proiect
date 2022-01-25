import { Injectable } from '@angular/core';
import { Manufacturer } from './interfaces/manufacturer';
import { ManufacturersComponent } from './modules/manufacturers/manufacturers/manufacturers.component';
import { Observable, of } from 'rxjs';
import { MessageService } from './message.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ManufacturerService {

  public manufacturerUrl = 'https://localhost:5001/api/Manufacturer';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
  constructor(
    public http: HttpClient,
    private messageService: MessageService) { }

  getManufacturers(): Observable<Manufacturer[]> {
    return this.http.get<Manufacturer[]>(this.manufacturerUrl)
    .pipe(
      tap(_ => this.log('fetched manufacturers')),
      catchError(this.handleError<Manufacturer[]>('getManufacturers', []))
    );
  }

  getManufacturer(id: number): Observable<Manufacturer> {
    return this.http.get<Manufacturer>(`${this.manufacturerUrl}/${id}`)
    .pipe(
      tap(_ => this.log('fetched manufacturer')),
      catchError(this.handleError<Manufacturer>('getManufacturer'))
    );
  }

  updateManufacturer(manufacturer: Manufacturer):Observable<any> {
    return this.http.put(this.manufacturerUrl, manufacturer, this.httpOptions).pipe(
      tap(_ => this.log(`updated manufacturer id=${manufacturer.id}`)),
      catchError(this.handleError<any>('updateManufacturer'))
    );
  }

  addManufacturer(manufacturer: Manufacturer):Observable<any> {
    return this.http.post<any>(this.manufacturerUrl, manufacturer, this.httpOptions).pipe(
      tap(_ => this.log(`added manufacturer id=${manufacturer.id}`)),
      catchError(this.handleError<any>('updateManufacturer'))
    );
  }

  deleteManufacturer(id: number):Observable<any> {
    return this.http.delete<any>(`${this.manufacturerUrl}/${id}`, this.httpOptions).pipe(
      tap(_ => this.log(`added manufacturer id=${id}`)),
      catchError(this.handleError<any>('updateManufacturer'))
    );
  }

  private log(message: string) {
    this.messageService.add(`ManufacturerFetchingService: ${message}`);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
 
      console.error(error);

      this.log(`${operation} failed: ${error.message}`);

      return of(result as T);
    };
  }
}
