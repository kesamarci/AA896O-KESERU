import { Injectable } from '@angular/core';
import { Ttrating } from '../models/ttrating';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TtRatingService {
  apiBaseUrl: string = 'https://localhost:7263/api/';
  constructor(private http:HttpClient) { }
  addRating(rating: Ttrating): void {
    this.http.post(this.apiBaseUrl + 'TTsRating', rating).subscribe();
  }
}
