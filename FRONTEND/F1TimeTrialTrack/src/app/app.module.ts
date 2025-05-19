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

@NgModule({
  declarations: [
    AppComponent,
    TtAddComponent,
    TtListComponent,
    TtEditComponent,
    TtDeleteComponent,
    TtListIdComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
