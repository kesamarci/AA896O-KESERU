import { Injectable } from '@angular/core';
import { Tt } from '../models/tt';
import { HttpClient } from '@angular/common/http';
import { Ttdetails } from '../models/ttdetails';

@Injectable({
  providedIn: 'root'
})
export class TtService {
  apiBaseUrl: string = 'https://localhost:7263/api/';
  tts:Tt[]=[] ;
  ttsdetails:Ttdetails[]=[];
  selectedTtdetails?:Ttdetails;
  selectedTt?:Tt;
  constructor(private http: HttpClient) { 
    this.loadTts();
  }
  loadTts(): void {
    this.http.get<Tt[]>(this.apiBaseUrl + 'TTs').subscribe(data => {
      this.tts = data;
    });
  }
  addTt(tt: Tt): void {
    this.http.post(this.apiBaseUrl + 'TTs', tt).subscribe(() => {
      this.loadTts();
    });
  }

  getAllTts(): void {
  // Ez is lehet külön, ha máshol kell újratölteni
  this.http.get<Tt[]>(this.apiBaseUrl + 'TTs').subscribe(data => {
    this.tts = data;
  });
  }

  getTtDetailsById(id: string, callback: (data: Ttdetails) => void): void {
  this.http.get<Ttdetails>(this.apiBaseUrl + 'TTs/' + id).subscribe(data => {
    callback(data);
  });
}

  

  updateTt(id: string, tt: Tt): void {
    this.http.put(this.apiBaseUrl + 'TTs/' + id, tt).subscribe(() => {
      this.loadTts();
    });
  }

  deleteTt(id: string): void {
    this.http.delete(this.apiBaseUrl + 'TTs/' + id).subscribe(() => {
      this.loadTts();
    });
  }
}
