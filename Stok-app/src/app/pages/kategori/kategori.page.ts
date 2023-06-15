import { Component, OnInit } from '@angular/core';
import { Kategori } from '../../models/Kategori';
import { StockServiceService } from '../../services/stockService.service';
import { FormControl, FormGroup } from '@angular/forms';
import { Sonuc } from '../../models/Sonuc';

@Component({
  selector: 'app-kategori',
  templateUrl: './kategori.page.html',
  styleUrls: ['./kategori.page.scss'],
})
export class KategoriPage implements OnInit {
  secKategori !: Kategori;
  kategoriler !: Kategori[];
  isModalOpen = false;
  sonuc: Sonuc = new Sonuc();




  KatEkle: FormGroup = new FormGroup({
    katAdi: new FormControl(),
    katResim: new FormControl(),
  });
  constructor( private stockService : StockServiceService) { }

  ngOnInit() {
    this.KategoriListele();
  }
  KategoriListele(){
    this.stockService.KategoriListele().subscribe((d : any) =>{
      this.kategoriler = d;
      console.log(d);
  });
  }

  
  Console(){
console.log("kategori Deneme");

  }
  setOpen(isOpen: boolean) {
    this.isModalOpen = isOpen;
  }

 KategoriEkle() {
    var kategori: Kategori = this.KatEkle.value
    if (!kategori.katId) {
      var filtre = this.kategoriler.filter(s => s.katResim == kategori.katResim);
      if (filtre.length > 0) {
        this.sonuc.islem = false;
        this.sonuc.mesaj = "Aynı Ürün Resmi Eklenemez";
        console.log(this.sonuc);
        
      } 
       else {
       
        this.stockService.KategoriEkle(kategori).subscribe(d => {
          this.sonuc.islem = true;
          this.sonuc.mesaj = "Kategori Eklendi";
          console.log(this.sonuc);
          this.KategoriListele();
          this.isModalOpen = false;
    });
      }
    }
  }  
  Sil(kat : Kategori){
    this.stockService.KategoriSil(kat.katId).subscribe(() => {
      var s: Sonuc = new Sonuc();
      s.islem = true;
      s.mesaj = "Kategori Silindi";
      this.KategoriListele();
      console.log(s);  // ! toast ekle
    });
}



  }

