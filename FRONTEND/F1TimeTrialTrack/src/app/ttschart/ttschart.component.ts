import { Component } from '@angular/core';
import { TtService } from '../services/tt.service';
import { TtschartService } from '../services/ttschart.service';
import { ChartConfiguration } from 'chart.js';
import { Tt } from '../models/tt';

@Component({
  selector: 'app-ttschart',
  standalone: false,
  templateUrl: './ttschart.component.html',
  styleUrl: './ttschart.component.sass'
  
})
export class TtschartComponent {
 
  barChartConfig?: ChartConfiguration<'bar'>;
  lineChartConfig?: ChartConfiguration<'line'>;

  constructor(
    private ttService: TtService,
    private ttschartService: TtschartService
  ) {
    this.loadData();
  }

  loadData() {
    this.ttService.getAllTts((tts: Tt[]) => {
      this.barChartConfig = this.ttschartService.getBarChartConfig(tts);
      this.lineChartConfig = this.ttschartService.getLineChartConfig(tts);
    });
  }
}
