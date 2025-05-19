import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Trackrating } from '../models/trackrating';

@Injectable({
  providedIn: 'root'
})
export class TrackRatingService {
  apiBaseUrl: string = 'https://localhost:7263/api/';
  constructor(private http:HttpClient) { 

  }
   addRating(rating: Trackrating): void {
    this.http.post(this.apiBaseUrl + 'TracksRating', rating).subscribe();
}
}