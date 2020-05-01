using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopGiacomini.Areas.Admin.ViewModels.ProductViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }

        public string Facture { get; set; }

        //public virtual List <Category> Categories { get; set; } - один к многим
    }
}