import { Component } from '@angular/core';
import { TrackService } from '../../services/track.service';
import { Router } from '@angular/router';
import { Track } from '../../models/track';

@Component({
  selector: 'app-track-add',
  standalone: false,
  templateUrl: './track-add.component.html',
  styleUrl: './track-add.component.sass'
})
export class TrackAddComponent {
 track: Track = new Track();

  constructor(private trackService: TrackService, private router: Router) {}

  save(): void {
    this.trackService.addTrack(this.track);
    this.router.navigate(['/track-list']);
  }
}

