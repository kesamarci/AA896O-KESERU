import { Injectable } from '@angular/core';
import { Track } from '../models/track';
import { HttpClient } from '@angular/common/http';
import { Trackrating } from '../models/trackrating';
import { Trackdetails } from '../models/trackdetails';

@Injectable({
  providedIn: 'root'
})
export class TrackService {

  apiBaseUrl:string = "https://localhost:7263/api/"
  tracks: Track[] = [];
  trackDetails: Trackdetails[] = [];
  selectedTrack?: Track;
  selectedTrackDetails?: Trackdetails;
  constructor(private http:HttpClient) {
    this.loadTracks();
   }
     loadTracks(callback?: () => void): void {
    this.http.get<Track[]>(this.apiBaseUrl + 'Tracks').subscribe(data => {
      this.tracks = data;
      if (callback) callback();
    });
  }
    addTrack(track: Track, callback?: () => void): void {
  this.http.post<Track>(this.apiBaseUrl + 'Tracks', track).subscribe(() => {
    this.loadTracks(() => {
      if (callback) callback(); // csak akkor hívjuk, ha meg van adva
    });
  });
}
    getAllTracks(callback: (data: Track[]) => void): void {
    this.http.get<Track[]>(this.apiBaseUrl + 'Tracks').subscribe(data => {
      const tracks = data.map(item => {
        const t = new Track();
        Object.assign(t, item);
        return t;
      });
      callback(tracks);
    });
  }
  deleteTrack(id: string, callback?: () => void): void {
  this.http.delete(this.apiBaseUrl + 'Tracks/' + id).subscribe(() => {
    this.loadTracks(() => {
      if (callback) callback();
    });
  });
}
    updateTrack(track: Track, callback?: () => void): void {
  this.http.put(this.apiBaseUrl + 'Tracks/' + track.id, track).subscribe(() => {
    const index = this.tracks.findIndex(x => x.id === track.id);
    if (index !== -1) {
      this.tracks[index] = track;
    }
    this.loadTracks(() => {
      if (callback) callback();
    });
  });
}
   getTrackById(id: string, callback: (data: Track) => void): void {
    this.http.get<Track>(this.apiBaseUrl + 'Tracks/' + id).subscribe(data => {
      callback(data);
    });
  }
  getTrackDetailsById(id: string, callback: (data: Trackdetails) => void): void {
    this.http.get<Trackdetails>(this.apiBaseUrl + 'Tracks/' + id).subscribe(data => {
      callback(data);
    });
  }

}
