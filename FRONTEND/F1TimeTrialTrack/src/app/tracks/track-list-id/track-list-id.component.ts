import { Component } from '@angular/core';
import { TrackService } from '../../services/track.service';
import { ActivatedRoute } from '@angular/router';
import { Trackdetails } from '../../models/trackdetails';

@Component({
  selector: 'app-track-list-id',
  standalone: false,
  templateUrl: './track-list-id.component.html',
  styleUrl: './track-list-id.component.sass'
})
export class TrackListIdComponent {
 id: string = '';
  trackdetails?: Trackdetails;

  constructor(private trackService: TrackService, private route: ActivatedRoute) {
    const idFromParam = this.route.snapshot.paramMap.get('id');
    if (idFromParam) {
      this.loadTrackDetailsById(idFromParam);
    }
  }

  loadTrackDetailsById(id: string): void {
    this.trackService.getTrackDetailsById(id, (data: Trackdetails) => {
      this.trackdetails = data;
    });
  }
}
