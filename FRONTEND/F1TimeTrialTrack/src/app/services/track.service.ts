import { Injectable } from '@angular/core';
import { Track } from '../models/track';
import { HttpClient } from '@angular/common/http';
import { Trackrating } from '../models/trackrating';

@Injectable({
  providedIn: 'root'
})
export class TrackService {

  apiBaseUrl:string = "https://localhost:7263/api/"
  tracks: Track[] = [];
  constructor(private http:HttpClient) {
    this.loadTracks();
   }
    loadTracks(): void {
    this.http.get<Track[]>(this.apiBaseUrl+'Tracks').subscribe(data => {
      this.tracks = data;
    });
  }
   addTrack(track: Track): void {
    this.http.post<Track>(this.apiBaseUrl + 'Tracks', track).subscribe(() => {
      this.loadTracks(); // újratöltés
    });
  }
  getAllTracks(): void {//ugyan az kb mint a load de jobban látom igy
  // Ez a metódus külön is hívható ha csak listát akarunk lekérni
  this.http.get<Track[]>(this.apiBaseUrl + 'Tracks').subscribe(data => {
    this.tracks = data;
  });
  }
  deleteTrack(id: string): void {
    this.http.delete(this.apiBaseUrl + 'Tracks/' + id).subscribe(() => {
      this.loadTracks(); // újratöltés
    });
  }

  updateTrack(id: string, track: Track): void {
    this.http.put(this.apiBaseUrl + 'Tracks/' + id, track).subscribe(() => {
      this.loadTracks(); // újratöltés
    });
  }

  addRating(rating: Trackrating): void {
    this.http.post(this.apiBaseUrl + 'TracksRating', rating).subscribe();
  }

  loadTrackById(id: string, callback: (track: Track) => void): void {
    this.http.get<Track>(this.apiBaseUrl + 'Tracks/' + id).subscribe(track => {
      callback(track);
    });
  }
}
