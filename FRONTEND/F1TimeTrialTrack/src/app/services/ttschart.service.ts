import { Injectable } from '@angular/core';
import { Tt } from '../models/tt';
import { ChartConfiguration } from 'chart.js';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TtschartService {
   constructor() { }

  getBarChartConfig(tts: Tt[]): ChartConfiguration<'bar'> {
    return {
      type: 'bar',
      data: {
        labels: tts.map(t => t.trackName),
        datasets: [{
          label: 'Average Rating',
          data: tts.map(t => t.avaerageRating),
          backgroundColor: 'rgba(54, 162, 235, 0.6)'
        }]
      },
      options: {
        responsive: true,
        scales: {
          y: { beginAtZero: true, max: 10 }
        }
      }
    };
  }

  getLineChartConfig(tts: Tt[]): ChartConfiguration<'line'> {
    return {
      type: 'line',
      data: {
        labels: tts.map(t => t.trackName),
        datasets: [{
          label: 'Average Time',
          data: tts.map(t => t.averageTime),
          borderColor: 'rgba(255, 99, 132, 0.8)',
          backgroundColor: 'rgba(255, 99, 132, 0.3)',
          fill: false,
          tension: 0.3
        }]
      },
      options: {
        responsive: true,
        scales: {
          y: { beginAtZero: true }
        }
      }
    };
  }
}
