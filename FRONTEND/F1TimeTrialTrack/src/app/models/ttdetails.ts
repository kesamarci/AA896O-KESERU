import { Ttrating } from "./ttrating";

export class Ttdetails {
  id?: string;
  trackName: string = '';
  car: string = '';
  driver: string = '';
  time: string = '';
  date: Date = new Date();
  platform: string = '';
  tire: string = '';
  assist: string = '';
  setup: string = '';
  wheather: string = '';
  timeInMillis: number = 0;
  ratings: Ttrating[] = [];
  averageRating: number = 0;
  ratingCount: number = 0;
}

