using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stok_Ionic_Api.View_Model
{
    public class ItemModel
    {
        public string itemId { get; set; }
        public string itemKatTur { get; set; }
        public string itemAdi { get; set; }
        public int itemMiktar { get; set; }
        public string itemKayitTarih { get; set; }
        public string itemDuzenlenmeTarih { get; set; }
        public string itemPng { get; set; }
        public string itemResim { get; set; }

    }
}