import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Item } from '../models/Item';
import { Kategori } from '../models/Kategori';

@Injectable({
  providedIn: 'root'
})
export class StockServiceService {

constructor(private http: HttpClient) { }

// Item
ItemListele(): Observable<object>{
  return this.http.get(environment.baseUrl + '/itemliste' );
}
ItemById(itemId : string){
  return this.http.get(environment.baseUrl + '/itembyid/' + itemId );
}
ItemEkle(item : Item){
  return this.http.post(environment.baseUrl + '/itemekle' , item );
}
ItemDuzenle(item : Item){
  return this.http.put(environment.baseUrl + '/itemduzenle' , item );
}
ItemSil(itemId : string){
  return this.http.delete(environment.baseUrl + '/itemsil/' + itemId );
}

 // Kategori

 KategoriListele(): Observable<object>{
  return this.http.get(environment.baseUrl + '/kategoriliste' );
}
KategoriById(katId : string){
  return this.http.get(environment.baseUrl + '/kategoribyid/' + katId );
}
KategoriEkle(kategori : Kategori ){
  return this.http.post(environment.baseUrl + '/kategoriekle' , kategori );
}
KategoriDuzenle(kategori : Kategori): Observable<object>{
  return this.http.put(environment.baseUrl + '/kategoriduzenle' , kategori );
}
KategoriSil(katId : string): Observable<object>{
  return this.http.delete(environment.baseUrl + '/kategorisil/' + katId );
} 



}
