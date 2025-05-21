import { Injectable } from '@angular/core';
import { TrackService } from './track.service';
import { TtService } from './tt.service';
import { Tt } from '../models/tt';
import { Track } from '../models/track';

@Injectable({
  providedIn: 'root'
})
export class StatsService {
 constructor(
    private trackService: TrackService,
    private ttService: TtService
  ) {}

  getTotalTracks(): number {
    return this.trackService.tracks.length;
  }

  getAverageTtTime(): number {
    const tts: Tt[] = this.ttService.tts;
    if (tts.length === 0) return 0;

    const totalTime = tts.reduce((sum, tt) => sum + (tt.averageTime || 0), 0);
    return totalTime / tts.length;
  }

  getBestTrack(): { name: string; rating: number } {
    const tracks: Track[] = this.trackService.tracks;
    if (tracks.length === 0) {
      return { name: '', rating: 0 };
    }

    let bestTrack = tracks[0];
    for (const track of tracks) {
      if ((track.avarageRating || 0) > (bestTrack.avarageRating || 0)) {
        bestTrack = track;
      }
    }

    return { name: bestTrack.name, rating: bestTrack.avarageRating || 0 };
  }
}
