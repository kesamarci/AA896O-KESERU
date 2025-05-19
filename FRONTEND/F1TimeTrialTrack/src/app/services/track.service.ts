import { Injectable } from '@angular/core';
import { Track } from '../models/track';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TrackService {

  apiBaseUrl:string = "https://localhost:7263/"
  tracks: Track[] = [];
  constructor(private http:HttpClient) {
    this.loadTracks();
   }
    loadTracks(): void {
    this.http.get<Track[]>(this.apiBaseUrl+'Tracks').subscribe(data => {
      this.tracks = data;
    });
  }
  
}
