import { Component } from '@angular/core';
import { Tt } from '../../models/tt';
import { TtService } from '../../services/tt.service';
import { Ttdetails } from '../../models/ttdetails';

@Component({
  selector: 'app-tt-list-id',
  standalone: false,
  templateUrl: './tt-list-id.component.html',
  styleUrl: './tt-list-id.component.sass'
})
export class TtListIdComponent {
id:string='';
ttdetails?:Ttdetails;
constructor(private ttService: TtService)
{}
loadTtDetailsById(id: string): void {
  this.ttService.getTtDetailsById(id, (data:Ttdetails) => {
    this.ttdetails = data;
  });
}
}
