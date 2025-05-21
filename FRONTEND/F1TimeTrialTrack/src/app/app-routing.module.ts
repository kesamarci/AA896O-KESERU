import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TtListComponent } from './tts/tt-list/tt-list.component';
import { TtAddComponent } from './tts/tt-add/tt-add.component';
import { TtDeleteComponent } from './tts/tt-delete/tt-delete.component';
import { TtListIdComponent } from './tts/tt-list-id/tt-list-id.component';
import { TtEditComponent } from './tts/tt-edit/tt-edit.component';
import { TtRatingComponent } from './tts/tt-rating/tt-rating.component';
import { TrackAddComponent } from './tracks/track-add/track-add.component';
import { TrackListComponent } from './tracks/track-list/track-list.component';
import { Trackdetails } from './models/trackdetails';
import { TrackListIdComponent } from './tracks/track-list-id/track-list-id.component';
import { TrackEditComponent } from './tracks/track-edit/track-edit.component';
import { TrackDeleteComponent } from './tracks/track-delete/track-delete.component';
import { TrackRatingComponent } from './tracks/track-rating/track-rating.component';
import { TtschartComponent } from './ttschart/ttschart.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [ 
  { path: 'tts', component: TtListComponent },
  { path: 'tt-add', component: TtAddComponent },
  { path: '', component: HomeComponent },
  { path: 'tt-details', component: TtListIdComponent }, 
  { path: 'tt-details/:id', component: TtListIdComponent }, 
  { path: 'tt-edit', component: TtEditComponent }, 
  { path: 'tt-edit/:id', component: TtEditComponent }, 
  {path:'tt-delete',component:TtDeleteComponent},
  { path: 'tt-rating', component: TtRatingComponent },
  { path: 'track-add', component: TrackAddComponent },
  { path: 'tracks', component: TrackListComponent, runGuardsAndResolvers: 'always'  },
  { path: 'track-details', component: TrackListIdComponent },
  { path: 'track-details/:id', component: TrackListIdComponent },
  { path: 'track-edit', component: TrackEditComponent },
  { path: 'track-edit/:id', component: TrackEditComponent },
  { path: 'track-delete', component: TrackDeleteComponent },
  { path: 'track-rating', component: TrackRatingComponent },
    { path: 'ttschart', component: TtschartComponent },

]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
