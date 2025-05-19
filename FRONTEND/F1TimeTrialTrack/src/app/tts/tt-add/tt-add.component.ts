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
  newTt:Tt=new Tt();
  constructor(private ttService:TtService,private router: Router)
  {}
  onSubmit(): void {
    this.ttService.addTt(this.newTt);
    this.router.navigate(['/tts']);
}
}