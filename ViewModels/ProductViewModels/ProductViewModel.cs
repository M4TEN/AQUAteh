using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopGiacomini.ViewModels.ProductViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        public string Facture { get; set; }

        //public virtual List <Category> Categories { get; set; } - один к многим
    }
}