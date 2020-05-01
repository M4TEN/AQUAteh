using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopGiacomini.Areas.Admin.ViewModels.ProductViewModels
{
    public class DetailsProductViewModel : ProductViewModel
    {
        public byte[] Image { get; set; }
    }
}