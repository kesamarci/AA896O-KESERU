import { Injectable } from '@angular/core';
import { Ttrating } from '../models/ttrating';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TtRatingService {
  apiBaseUrl: string = 'https://localhost:7263/api/';
  constructor(private http:HttpClient) { }

  addRating(rating: Ttrating, callback: (response: any) => void): void {
  this.http.post(this.apiBaseUrl + 'TTsRating', rating).subscribe({
    next: (res) => callback(res),
    error: (err) => callback(err)
  });
}
}
