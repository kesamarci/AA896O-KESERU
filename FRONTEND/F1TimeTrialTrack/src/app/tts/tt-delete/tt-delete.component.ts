import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TtService } from '../../services/tt.service';

@Component({
  selector: 'app-tt-delete',
  standalone: false,
  templateUrl: './tt-delete.component.html',
  styleUrl: './tt-delete.component.sass'
})
export class TtDeleteComponent {
    id: string = '';
    constructor(private router:Router,private ttService:TtService)
    {

    }
     onDelete(): void {
    if (this.id) {
      this.ttService.deleteTt(this.id);
      this.router.navigate(['/tts']);  // vissza a listához törlés után
    } else {
      alert('Adj meg egy érvényes ID-t!');
    }
  }
}
