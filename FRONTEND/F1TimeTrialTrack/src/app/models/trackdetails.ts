import { Trackrating } from "./trackrating";

export class Trackdetails {
     id?: string;
  name: string = '';
  length: number = 0;
  ratings: Trackrating[] = [];
  ratingCount: number = 0;
  averageRating: number = 0;
}
