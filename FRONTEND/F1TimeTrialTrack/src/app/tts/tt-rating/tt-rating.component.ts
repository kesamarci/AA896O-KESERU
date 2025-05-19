import { Component } from '@angular/core';
import { Ttrating } from '../../models/ttrating';
import { Router } from '@angular/router';
import { TtRatingService } from '../../services/tt-rating.service';

@Component({
  selector: 'app-tt-rating',
  standalone: false,
  templateUrl: './tt-rating.component.html',
  styleUrl: './tt-rating.component.sass'
})
export class TtRatingComponent {
  newRating: Ttrating=new Ttrating();
  constructor(private router:Router,private ttRatingService:TtRatingService)
  {

  }
    submitRating(): void {
    if (this.newRating.tTsId && this.newRating.rating > 0) {
      this.ttRatingService.addRating(this.newRating,() => {
        this.router.navigate(['/tt-list'])
        this.newRating = { tTsId: '', rating: 0, comment: '' }; // Űrítés
       
      });
    
  }
}
}