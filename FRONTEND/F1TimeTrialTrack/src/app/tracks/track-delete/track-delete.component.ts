import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TrackService } from '../../services/track.service';

@Component({
  selector: 'app-track-delete',
  standalone: false,
  templateUrl: './track-delete.component.html',
  styleUrl: './track-delete.component.sass'
})
export class TrackDeleteComponent {
id: string = '';
    constructor(private router:Router,private trackService:TrackService)
    {

    }
     onDelete(): void {
    this.trackService.deleteTrack(this.id, () => {
      this.router.navigate(['/tracks']); // csak akkor megy vissza, ha törlés kész
    });
  }
}
