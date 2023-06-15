import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
 
  {
    path: '',
    redirectTo: 'stocks',
    pathMatch: 'full'
  },
  {
    path: 'kategori',
    loadChildren: () => import('./pages/kategori/kategori.module').then( m => m.KategoriPageModule)
  },
  {
    path: 'stocks',
    loadChildren: () => import('./pages/stocks/stocks.module').then( m => m.StocksPageModule)
  },
  {
    path: 'itemlistele/:itemId',
    loadChildren: () => import('./pages/stock-details/stock-details.module').then( m => m.StockDetailsPageModule)
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
