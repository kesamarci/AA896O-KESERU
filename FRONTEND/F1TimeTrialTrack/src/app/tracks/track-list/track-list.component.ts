import { Component } from '@angular/core';
import { Track } from '../../models/track';
import { TrackService } from '../../services/track.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-track-list',
  standalone: false,
  templateUrl: './track-list.component.html',
  styleUrl: './track-list.component.sass'
})
export class TrackListComponent {

  tracks:Track[]=[];
  constructor(private trackService:TrackService,private router: Router)
  {
    this.loadTracks();
  }
   loadTracks(): void {
    this.trackService.getAllTracks((data) => {
      this.tracks = data;
    });
    
  }
  deleteTrack(id: string): void {
    this.trackService.deleteTrack(id, () => {
      this.loadTracks();
    });
  }
}
