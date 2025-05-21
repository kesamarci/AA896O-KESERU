import { Component } from '@angular/core';
import { StatsService } from '../services/stats.service';
import { Router } from '@angular/router';
import { TtService } from '../services/tt.service';
import { TrackService } from '../services/track.service';

@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrl: './home.component.sass'
})
export class HomeComponent {
  totalTracks: number = 0;
  averageTtTime: number = 0;
  bestTrackRating: number = 0;
  bestTrackName:string='';
  constructor(private trackService: TrackService,
    private ttService: TtService,
    private statsService: StatsService,
     private router:Router) 
  {
    this.loadData();
  }
  loadData(): void {
    this.trackService.loadTracks(() => {
      this.ttService.loadTts(() => {
        this.loadStats();
      });
    });
  }
  loadStats(): void {
    this.totalTracks = this.statsService.getTotalTracks();
    this.averageTtTime = this.statsService.getAverageTtTime();
    const bestTrack = this.statsService.getBestTrack();
  this.bestTrackRating = bestTrack.rating;
  this.bestTrackName = bestTrack.name;
  }
}
