using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stok_Ionic_Api.Models;
using Stok_Ionic_Api.View_Model;
namespace Stok_Ionic_Api.Controllers
{
    public class ServisController : ApiController
    {
        DBStokEntities9 db = new DBStokEntities9();
        SonucModel sonuc = new SonucModel();

        #region Items
        [HttpGet]
        [Route("api/itemliste")]
        public List<ItemModel> ItemListele()
        {
            List<ItemModel> liste = db.Item.Select(x => new ItemModel()
            {
                itemId = x.itemId,
                itemAdi = x.itemAdi,
                itemKatTur = x.itemKatTur,
                itemMiktar = x.itemMiktar,
                itemResim = x.itemResim,
                itemKayitTarih = x.itemKayitTarih,
                itemDuzenlenmeTarih = x.itemDuzenlenmeTarih,
                
            }).ToList();
            return liste;
        }


        [HttpGet]
        [Route("api/itembyid/{itemId}")]
        public ItemModel ItemById(string itemId)
        {
            ItemModel kayit = db.Item.Where(s => s.itemId == itemId).Select(x => new ItemModel()
            {
                itemId = x.itemId,
                itemAdi = x.itemAdi,
                itemKatTur = x.itemKatTur,
                itemMiktar = x.itemMiktar,
                itemResim = x.itemResim,
                itemKayitTarih = x.itemKayitTarih,
                itemDuzenlenmeTarih = x.itemDuzenlenmeTarih,
            }).FirstOrDefault();
            return kayit;
        }

        [HttpPost]
        [Route("api/itemekle")]
        public SonucModel ItemEkle(ItemModel model)
        {
            if (db.Item.Count(s => s.itemId == model.itemId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "İşlem Başarısız !";
                return sonuc;

            }
            if (db.Item.Count(s => s.itemAdi == model.itemAdi) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Item Mevcut !";
                return sonuc;
            }
            Item yeni = new Item();
            yeni.itemId = Guid.NewGuid().ToString();
            yeni.itemAdi = model.itemAdi;
            yeni.itemKatTur = model.itemKatTur;
            yeni.itemMiktar = model.itemMiktar;
            yeni.itemResim = model.itemResim;
            yeni.itemKayitTarih = model.itemKayitTarih;
            yeni.itemDuzenlenmeTarih = model.itemDuzenlenmeTarih;
            db.Item.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "İtem Eklendi !";
            return sonuc;

        }

        [HttpPut]
        [Route("api/itemduzenle")]
        public SonucModel İtemDuzenle(ItemModel model)
        {
            Item kayit = db.Item.Where(s => s.itemId == model.itemId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "İtem Bulunamadı !";
                return sonuc;
            }
            kayit.itemAdi = model.itemAdi;
            kayit.itemKatTur = model.itemKatTur;
            kayit.itemMiktar = model.itemMiktar;
            kayit.itemResim = model.itemResim;
            kayit.itemKayitTarih = model.itemKayitTarih;
            kayit.itemDuzenlenmeTarih = model.itemDuzenlenmeTarih;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "İtem Düzenlenildi !";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/itemsil/{itemId}")]
        public SonucModel İtemSil(string itemId)
        {
            Item kayit = db.Item.Where(s => s.itemId == itemId).FirstOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "İtem Bulunamadı !";
                return sonuc;
            }
            if (db.Kayit.Count(s => s.kayitItemId == itemId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "İtem Kategoriye Kayıtlı Olduğu İçin Silinemez ! ";
                return sonuc;
            }
            db.Item.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "İtem Silindi !";
            return sonuc;

        }

        #endregion

        #region Kategori
        [HttpGet]
        [Route("api/kategoriliste")]
        public List<KategoriModel> KategoriListe()
        {
            List<KategoriModel> liste = db.Kategori.Select(x => new KategoriModel()
            {
                katId = x.katId,
                katAdi = x.katAdi,
                katResim = x.katResim,
            }).ToList();
            return liste;
        }

        [HttpGet]
        [Route("api/kategoribyid/{katId}")]
        public KategoriModel KategoriById(string katId)
        {
            KategoriModel kayit = db.Kategori.Where(s => s.katId == katId).Select(x => new KategoriModel()
            {
                katId = x.katId,
                katAdi = x.katAdi,
                katResim = x.katResim,

            }).FirstOrDefault();

            return kayit;

        }

        [HttpPost]
        [Route("api/kategoriekle")]
        public SonucModel KategoriEkle(KategoriModel model)
        {
            if (db.Kategori.Count(s => s.katAdi == model.katAdi) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kategori Adı Mevcuttur ! ";
                return sonuc;

            }

            Kategori yeni = new Kategori();
            yeni.katId = Guid.NewGuid().ToString();
            yeni.katAdi = model.katAdi;
            yeni.katResim = model.katResim;
            db.Kategori.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = " Kategori Eklendi !";
            return sonuc;
        }


        [HttpPut]
        [Route("api/kategoriduzenle")]
        public SonucModel KategoriDuzenle(KategoriModel model)
        {
            Kategori kayit = db.Kategori.Where(s => s.katId == model.katId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kategori Bulunamadı !";
                return sonuc;

            }

            kayit.katAdi = model.katAdi;
            kayit.katResim = model.katResim;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kategori Başarıyla Değiştirildi! ";

            return sonuc;
        }

        [HttpDelete]
        [Route("api/kategorisil/{katId}")]
        public SonucModel KategoriSil(string katId)
        {
            Kategori kayit = db.Kategori.Where(s => s.katId == katId).FirstOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kategori Bulunamadı !";
                return sonuc;
            }

            if (db.Kayit.Count(s => s.kayitKatId == katId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Bu Kategoride Kayıtlı İtem Olduğu İçin Silinemez ! ";
                return sonuc;
            }


            db.Kategori.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kategori Silindi ! ";
            return sonuc;
        }
        #endregion

        #region Kayit
        [HttpGet]
        [Route("api/itemkategoriliste/{itemId}")]
        public List<KayitModel> ItemKategoriListe(string itemId)
        {
            List<KayitModel> liste = db.Kayit.Where(s => s.kayitItemId == itemId).Select(x => new KayitModel()
            {
                kayitId = x.kayitId,
                kayitItemId = x.kayitItemId,
                kayitKatId = x.kayitKatId,
            }).ToList();
            foreach (var kayit in liste)
            {
                kayit.ItemBilgi = ItemById(kayit.kayitItemId);
                kayit.KategoriBilgi = KategoriById(kayit.kayitKatId);
            }
            return liste;
        }


        [HttpGet]
        [Route("api/kategoriitemliste/{katId}")]
        public List<KayitModel> KategoriItemListe(string katId)
        {
            List<KayitModel> liste = db.Kayit.Where(s => s.kayitKatId == katId).Select(x => new KayitModel()
            {
                kayitId = x.kayitId,
                kayitItemId= x.kayitItemId,
                kayitKatId= x.kayitKatId,
            }).ToList();
            foreach (var kayit in liste)
            {
                kayit.ItemBilgi = ItemById(kayit.kayitItemId);
                kayit.KategoriBilgi = KategoriById(kayit.kayitKatId);
            }
            return liste;
        }

        [HttpPost]
        [Route("api/kayitekle")]
        public SonucModel KayitEkle(KayitModel model)
        {
            if (db.Kayit.Count(s => s.kayitItemId == model.kayitItemId && s.kayitKatId == model.kayitKatId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "İtem Önceden Kategoriye Kaydedilmiş !";

            }

            Kayit yeni = new Kayit();
            yeni.kayitId = Guid.NewGuid().ToString();
            yeni.kayitItemId = model.kayitItemId;
            yeni.kayitKatId = model.kayitKatId;
            db.Kayit.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "İtem kaydı Eklendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/kayitsil/{kayitId}")]
        public SonucModel KayitSil(string kayitId)
        {
            Kayit kayit = db.Kayit.Where(s => s.kayitId== kayitId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı !";
                return sonuc;

            }
            db.Kayit.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kayıt Silindi !";
            return sonuc;
        }
        #endregion
    }
}
