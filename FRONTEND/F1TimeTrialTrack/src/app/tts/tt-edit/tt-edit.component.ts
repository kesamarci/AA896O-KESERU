import { Component } from '@angular/core';
import { Tt } from '../../models/tt';
import { TtService } from '../../services/tt.service';
import { ActivatedRoute, Route, Router } from '@angular/router';

@Component({
  selector: 'app-tt-edit',
  standalone: false,
  templateUrl: './tt-edit.component.html',
  styleUrl: './tt-edit.component.sass'
})
export class TtEditComponent {
  platforms: string[] = ['PC', 'PlayStation', 'Xbox'];
  tires: string[] = ['Soft', 'Medium', 'Hard', 'Wet'];
  assists: string[] = ['None', 'Medium', 'Full'];
  setups: string[] = ['Default', 'Custom'];
  wheathers: string[] = ['Clear', 'Rainy', 'Overcast'];
  tt: Tt = new Tt();
  id: string = '';
  isLoadedFromUrl: boolean = false;

  constructor(
    private ttService: TtService, private router: Router,private route: ActivatedRoute) {
    const idFromUrl = this.route.snapshot.paramMap.get('id');
    if (idFromUrl) {
      this.isLoadedFromUrl = true;
      this.id = idFromUrl;
      this.loadTtById();
    }
  }

  loadTtById(): void {
    
    this.ttService.getTtById(this.id, (data) => {
      this.tt = data;
    });
  }

   onUpdate(): void {
    this.ttService.updateTt(this.tt, () => {
      
      this.router.navigate(['/tts']);
    });
  }
}


