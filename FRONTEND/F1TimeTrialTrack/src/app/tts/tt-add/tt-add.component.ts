import { Component } from '@angular/core';
import { Tt } from '../../models/tt';
import { TtService } from '../../services/tt.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tt-add',
  standalone: false,
  templateUrl: './tt-add.component.html',
  styleUrl: './tt-add.component.sass'
})
export class TtAddComponent {
   platforms: string[] = ['PC', 'PlayStation', 'Xbox'];
  tires: string[] = ['Soft', 'Medium', 'Hard', 'Wet'];
  assists: string[] = ['None', 'Medium', 'Full'];
  setups: string[] = ['Default', 'Custom'];
  wheathers: string[] = ['Clear', 'Rainy', 'Overcast'];
  newTt:Tt=new Tt();
  constructor(private ttService:TtService,private router: Router)
  {
     this.newTt.date = new Date().toISOString().substring(0, 10);
  }
  onSubmit(): void {
    this.ttService.addTt(this.newTt,()=>
    {
      this.router.navigate(['/tts']);
    });
    
}
}