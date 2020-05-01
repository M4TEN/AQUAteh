using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopGiacomini.Areas.Admin.ViewModels.ProductViewModels
{
    public class CreateProductViewModel:ProductViewModel
    {
        public HttpPostedFileBase Image { get; set; }
    }
}