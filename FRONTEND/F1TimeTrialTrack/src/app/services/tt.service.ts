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

  getAllTts(callback: (data: Tt[]) => void): void {
  this.http.get<Tt[]>(this.apiBaseUrl + 'TTs').subscribe(data => {
    const tts = data.map(item => {
      const tt = new Tt();
      Object.assign(tt, item);
      return tt;
    });
    callback(tts);
  });
}
  getTtById(id: string, callback: (data: Tt) => void): void {
  this.http.get<Tt>(this.apiBaseUrl + 'TTs/' + id).subscribe((data) => {
    callback(data);
  });
}

  getTtDetailsById(id: string, callback: (data: Ttdetails) => void): void {
  this.http.get<Ttdetails>(this.apiBaseUrl + 'TTs/' + id).subscribe(data => {
    callback(data);
  });
}

  

 updateTt(tt: Tt, callback?: () => void): void {
  this.http.put(this.apiBaseUrl + 'TTs/' + tt.id, tt).subscribe(() => {
    const index = this.tts.findIndex(x => x.id === tt.id);
    if (index !== -1) {
      this.tts[index] = tt;
    }
    if (callback) callback(); // csak ha meg van adva
  });
}

  deleteTt(id: string): void {
    this.http.delete(this.apiBaseUrl + 'TTs/' + id).subscribe(() => {
      this.loadTts();
    });
  }
}
