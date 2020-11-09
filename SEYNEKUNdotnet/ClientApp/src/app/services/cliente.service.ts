import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../seynekun/models/cliente';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) { this.baseUrl = baseUrl; }

  get(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.baseUrl + 'api/Cliente')
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Cliente[]>('Consulta Cliente', null)));
  }

  post(cliente: Cliente): Observable<Cliente> {
    return this.http.post<Cliente>(this.baseUrl + 'api/Cliente', cliente)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Cliente>('Registrar Cliente', null)));
  }

  getIdentificacion(identificacion: string): Observable<Cliente> {
    const url = `${this.baseUrl + 'api/Cliente'}/${identificacion}`;
    return this.http.get<Cliente>(url).pipe(
      tap(_ => this.log(`datos enviados Cliente identificacion=${identificacion}`)),
      catchError(this.handleErrorService.handleError<Cliente>(`Consulta Cliente identificacion=${identificacion}`))
    );
  }

  update (cliente: Cliente): Observable<Cliente> {
    const url = `${this.baseUrl + 'api/Cliente'}/${cliente.identificacion}`;
    return this.http.put(url, cliente, httpOptions).pipe(
      tap(_ => this.log(`datos enviados Cliente identificacion=${cliente.identificacion}`)),
      catchError(this.handleErrorService.handleError<any>('Modificar Cliente'))
    );
  }

  delete (cliente: Cliente | string): Observable<Cliente> {
    const identificacion = typeof cliente === 'string' ? cliente : cliente.identificacion;
    const url = `${this.baseUrl + 'api/Cliente'}/${identificacion}`;

    return this.http.delete<Cliente>(url, httpOptions).pipe(
      tap(_ => this.log(`datos enviados identificacion=${identificacion}`)),
      catchError(this.handleErrorService.handleError<Cliente>('Eliminar Cliente'))
    );
  }

  private log(message: string) {
    console.log(message);
  }
}
