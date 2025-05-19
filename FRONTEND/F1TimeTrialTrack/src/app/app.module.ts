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

@NgModule({
  declarations: [
    AppComponent,
    TtAddComponent,
    TtListComponent,
    TtEditComponent,
    TtDeleteComponent
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
