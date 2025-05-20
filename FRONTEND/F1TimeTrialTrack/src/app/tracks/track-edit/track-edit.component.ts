import { Component } from '@angular/core';
import { Track } from '../../models/track';
import { TrackService } from '../../services/track.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-track-edit',
  standalone: false,
  templateUrl: './track-edit.component.html',
  styleUrl: './track-edit.component.sass'
})
export class TrackEditComponent {
 track: Track = new Track();
  id: string = '';
  isLoadedFromUrl: boolean = false;

  constructor(
    private trackService: TrackService,private router: Router,private route: ActivatedRoute) {
    const idFromUrl = this.route.snapshot.paramMap.get('id');
    if (idFromUrl) {
      this.isLoadedFromUrl = true;
      this.id = idFromUrl;
      this.loadTrackById();
    }
  }

  loadTrackById(): void {
    this.trackService.getTrackById(this.id, (data) => {
      this.track = data;
    });
  }

  onUpdate(): void {
     this.trackService.updateTrack(this.track, () => {
    this.router.navigate(['/tracks']);
  });
}
}

