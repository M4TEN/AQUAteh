using AutoMapper;
using ShopGiacomini.Areas.Admin.ViewModels.ProductViewModels;
using ShopGiacomini.Model;
using ShopGiacomini.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ShopGiacomini.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: Admin/Product
        public ActionResult Index()
        {
            
            var products = _productService.GetProducts();

            var model = products.Select(Mapper.Map<Product, ProductViewModel>).ToList();//каждый раз селект для каждого поля маппит его. Промаппил от первого и до конца
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateProductViewModel model)
        {
            if (!ModelState.IsValid) {
                return View(model);//Если данные с формы неверны то ошибки будут выдаваться!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }
            var product = Mapper.Map<CreateProductViewModel, Product>(model);
            _productService.CreateProduct(product);
            return RedirectToAction("Index","Product");
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            var product = _productService.GetProduct(Id);
            var model = Mapper.Map<Product, DetailsProductViewModel>(product);
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var product = _productService.GetProduct(Id);

            _productService.DeleteProduct(product);
            return RedirectToAction("Index", "Product");
        }
    }
}