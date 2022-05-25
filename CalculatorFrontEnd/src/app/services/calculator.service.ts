import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SubmitCalculationVM } from '../models/calculatorInput';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {

  constructor(
    private http: HttpClient,
    ) { }

  private baseUrl = 'https://localhost:44374/api/calculator';
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json',
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Allow-Headers': 'Content-Type',
    'Access-Control-Allow-Methods': 'GET,POST,OPTIONS,DELETE,PUT', })
  };

    Calculate(Input: SubmitCalculationVM): Observable<string> {
      return this.http.post<string>(this.baseUrl, Input, this.httpOptions).pipe(
      )
    }
}
