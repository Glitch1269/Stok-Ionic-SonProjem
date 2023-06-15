import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { KategoriPageRoutingModule } from './kategori-routing.module';

import { KategoriPage } from './kategori.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    KategoriPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [KategoriPage]
})
export class KategoriPageModule {}
