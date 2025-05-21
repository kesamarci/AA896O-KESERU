import { Component } from '@angular/core';
import { Trackrating } from '../../models/trackrating';
import { Router } from '@angular/router';
import { TrackRatingService } from '../../services/track-rating.service';

@Component({
  selector: 'app-track-rating',
  standalone: false,
  templateUrl: './track-rating.component.html',
  styleUrl: './track-rating.component.sass'
})
export class TrackRatingComponent {
 newRating: Trackrating=new Trackrating();
  constructor(private router:Router,private trackRatingService:TrackRatingService)
  {

  }
    submitRating(): void {
    if (this.newRating.trackId && this.newRating.rating > 0) {
      this.trackRatingService.addRating(this.newRating,() => {
        this.router.navigate(['/tracks'])
        this.newRating = { trackId: '', rating: 0, comment: '' }; // Űrítés
       
      });
    
  }
}
}
