import { Component, Inject, OnInit, TemplateRef } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observable, observable } from 'rxjs';
import {  Item } from 'src/app/models/Item';
import { Kategori } from 'src/app/models/Kategori';
import { Sonuc } from 'src/app/models/Sonuc';
import { StockServiceService } from 'src/app/services/stockService.service';
import { ModalController } from '@ionic/angular';
import { StockDetailsPage } from '../stock-details/stock-details.page';
import { StockDetailsPageModule } from '../stock-details/stock-details.module';
import { format } from 'path';
import { exit } from 'process';

@Component({
  selector: 'app-stocks',
  templateUrl: './stocks.page.html',
  styleUrls: ['./stocks.page.scss'],
})
export class StocksPage implements OnInit {

  categories !: Kategori[];
  selectedCategory !: Kategori;
  katId !: string;

  items!: Item[];
  selectedItem !: Item;
  itemDuzenle !: TemplateRef<any>
  sonuc: Sonuc = new Sonuc();
  isModalOpen = false;
  miktar !: "";
  itemEkle: FormGroup = new FormGroup({
    itemAdi: new FormControl(),
    itemMiktar: new FormControl(),
    itemKatTur: new FormControl(),
    itemKayitTarih : new FormControl(),
    itemDuzenlenmeTarih : new FormControl(),
    itemResim : new FormControl(),
  });
 
  
  constructor(private stockService : StockServiceService,
    public modalController : ModalController
    ) { }

  ngOnInit() {
    this.ItemListe();
    this.KategoriListele();
    
  }
  Arttir(item : Item){
    item.itemMiktar += 1;
  }
  setOpen(isOpen: boolean) {
    this.isModalOpen = isOpen;
  }

  ItemListe(){
    this.stockService.ItemListele().subscribe((d : any) => {
      this.items = d;
      console.log(d);
  });}

  KategoriListele(){
    this.stockService.KategoriListele().subscribe((d : any) => {
      this.categories = d;
      console.log(d);
  });}

  SecKategoriListele(){
    this.stockService.KategoriById(this?.katId).subscribe(( d : any) => { this.selectedCategory = d; console.log(d); });
  }

  Console(){
    console.log("deneme");
  }

  ItemEkle() {
    var item: Item = this.itemEkle.value
    var tarih = new Date();
    if (!item.itemId) {
      var filtre = this.items.filter(s => s.itemResim == item.itemResim);
      var filtreAd = this.items.filter(s => s.itemAdi == item.itemAdi);
      if (filtre.length > 0) {
        this.sonuc.islem = false;
        this.sonuc.mesaj = "Aynı Ürün Resmi Eklenemez";
        console.log(this.sonuc);
        
      } if(filtreAd.length > 0){
        this.sonuc.islem = false;
        this.sonuc.mesaj = "Aynı Ürün İsmi Girilemez";
        console.log(this.sonuc);;

      }
       else {
        item.itemKayitTarih = tarih.getTime().toString();
        item.itemDuzenlenmeTarih = tarih.getTime().toString();
        this.stockService.ItemEkle(item).subscribe(d => {
          this.sonuc.islem = true;
          this.sonuc.mesaj = "Item Eklendi";
          console.log(this.sonuc);
          this.ItemListe();
          this.isModalOpen = false;
    });
      }
    }
  }  

Kaydet() {
      var items: Item = this.itemEkle.value
      var tarih = new Date();
      console.log(this.itemEkle.value);
      this.stockService.ItemEkle(this.itemEkle.value).subscribe(() => {
        var s: Sonuc = new Sonuc();
        this.selectedItem.itemKayitTarih = tarih.getTime().toString();
        this.selectedItem.itemDuzenlenmeTarih = tarih.getTime().toString();
        s.islem = true;
        s.mesaj = "Item Eklendi";
        console.log(s);  
        this.ItemListe();
      });
    }

  Duzenle(item : Item,isOpen : boolean){
      var tarih = new Date();
      this.isModalOpen = isOpen;
      this.stockService.ItemDuzenle(item).subscribe(() => {
        var s: Sonuc = new Sonuc();
        this.selectedItem.itemDuzenlenmeTarih = tarih.getTime().toString();
        s.islem = true;
        s.mesaj = "Item Duzenle";
        this.ItemListe();
        console.log(s);
      });
    }
    
  Sil(item : Item){
    let myString = item.toString();
    this.stockService.ItemSil(item.itemId).subscribe(() => {
      var s: Sonuc = new Sonuc();
      s.islem = true;
      s.mesaj = "Item Silindi";
      this.ItemListe();
      console.log(s);  // ! toast ekle
    });
}

}