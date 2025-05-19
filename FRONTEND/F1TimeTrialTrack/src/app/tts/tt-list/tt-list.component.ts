import { Component } from '@angular/core';
import { Tt } from '../../models/tt';
import { TtService } from '../../services/tt.service';

@Component({
  selector: 'app-tt-list',
  standalone: false,
  templateUrl: './tt-list.component.html',
  styleUrl: './tt-list.component.sass'
})
export class TtListComponent {
tts:Tt[]=[];
constructor(private ttService:TtService)
{

}
loadTts(): void {
    this.ttService.getAllTts(); 
    this.tts = this.ttService.tts; 
}
}
