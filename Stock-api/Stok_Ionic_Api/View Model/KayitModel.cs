using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stok_Ionic_Api.View_Model
{
    public class KayitModel
    {
        public string kayitId { get; set; }
        public string kayitItemId { get; set; }
        public string kayitKatId { get; set; }

        public ItemModel ItemBilgi{ get; set; }
        public KategoriModel KategoriBilgi { get; set; }
    }
}