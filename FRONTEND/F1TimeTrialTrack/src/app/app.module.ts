import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TtAddComponent } from './tts/tt-add/tt-add.component';
import { TtListComponent } from './tts/tt-list/tt-list.component';
import { TtEditComponent } from './tts/tt-edit/tt-edit.component';
import { TtDeleteComponent } from './tts/tt-delete/tt-delete.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { TtListIdComponent } from './tts/tt-list-id/tt-list-id.component';
import { TtRatingComponent } from './tts/tt-rating/tt-rating.component';
import { TrackAddComponent } from './tracks/track-add/track-add.component';
import { TrackListComponent } from './tracks/track-list/track-list.component';
import { TrackDeleteComponent } from './tracks/track-delete/track-delete.component';
import { TrackListIdComponent } from './tracks/track-list-id/track-list-id.component';
import { TrackEditComponent } from './tracks/track-edit/track-edit.component';
import { TrackRatingComponent } from './tracks/track-rating/track-rating.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TtschartComponent } from './ttschart/ttschart.component';
import { NgChartsModule } from 'ng2-charts';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    TtAddComponent,
    TtListComponent,
    TtEditComponent,
    TtDeleteComponent,
    TtListIdComponent,
    TtRatingComponent,
    TrackAddComponent,
    TrackListComponent,
    TrackDeleteComponent,
    TrackListIdComponent,
    TrackEditComponent,
    TrackRatingComponent,
    TtschartComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NgbModule,
    NgChartsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
