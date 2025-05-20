import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TtListComponent } from './tts/tt-list/tt-list.component';
import { TtAddComponent } from './tts/tt-add/tt-add.component';
import { TtDeleteComponent } from './tts/tt-delete/tt-delete.component';
import { TtListIdComponent } from './tts/tt-list-id/tt-list-id.component';
import { TtEditComponent } from './tts/tt-edit/tt-edit.component';
import { TtRatingComponent } from './tts/tt-rating/tt-rating.component';
import { TrackAddComponent } from './tracks/track-add/track-add.component';

const routes: Routes = [ 
  { path: 'tts', component: TtListComponent },
  { path: 'tt-add', component: TtAddComponent },
  { path: '', redirectTo: '/tts', pathMatch: 'full' },
  { path: 'tt-details', component: TtListIdComponent }, 
  { path: 'tt-details/:id', component: TtListIdComponent }, 
  { path: 'tt-edit', component: TtEditComponent }, 
  { path: 'tt-edit/:id', component: TtEditComponent }, 
  {path:'tt-delete',component:TtDeleteComponent},
  { path: 'tt-rating', component: TtRatingComponent },
  { path: 'track-create', component: TrackAddComponent },
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
