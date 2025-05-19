import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TtListComponent } from './tts/tt-list/tt-list.component';
import { TtAddComponent } from './tts/tt-add/tt-add.component';
import { TtDeleteComponent } from './tts/tt-delete/tt-delete.component';
import { TtListIdComponent } from './tts/tt-list-id/tt-list-id.component';

const routes: Routes = [ 
  { path: 'tts', component: TtListComponent },
  { path: 'tt-add', component: TtAddComponent },
  { path: '', redirectTo: '/tts', pathMatch: 'full' },
  { path: 'tt-details', component: TtListIdComponent }, 
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
