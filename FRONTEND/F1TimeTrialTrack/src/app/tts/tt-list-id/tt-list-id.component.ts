import { Component } from '@angular/core';
import { Tt } from '../../models/tt';
import { TtService } from '../../services/tt.service';
import { Ttdetails } from '../../models/ttdetails';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-tt-list-id',
  standalone: false,
  templateUrl: './tt-list-id.component.html',
  styleUrl: './tt-list-id.component.sass'
})
export class TtListIdComponent {
   id: string = '';
  ttdetails?: Ttdetails;

  constructor(private ttService: TtService, private route: ActivatedRoute) {
    const idFromParam = this.route.snapshot.paramMap.get('id');
    if (idFromParam) {
      this.loadTtDetailsById(idFromParam);
    }
  }

  loadTtDetailsById(id: string): void {
    this.ttService.getTtDetailsById(id, (data: Ttdetails) => {
      this.ttdetails = data;
    });
  }
}
