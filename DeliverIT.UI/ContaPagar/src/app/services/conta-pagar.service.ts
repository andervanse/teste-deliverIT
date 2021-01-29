import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ContaPagar } from '../models/conta-pagar/conta-pagar.model';

@Injectable({
  providedIn: 'root'
})
export class ContaPagarService {

  constructor(private http: HttpClient) { }

  listar(): Observable<ContaPagar[]> {
    return this.http.get<ContaPagar[]>(`${environment.apiBaseUrl}/ContasPagar`)
    .pipe(
        map((resp) => {
            return resp;
        })
    );        
  }

  salvar(contaPagar: ContaPagar): Observable<any> {
    return this.http.post(`${environment.apiBaseUrl}/ContasPagar`, contaPagar)
    .pipe(
        map((resp) => {
            return resp;
        })
    );        
  }
}
