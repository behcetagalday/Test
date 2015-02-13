using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EticaretMVC.Models.Repository;
using EticaretMVC.Filters;
using EticaretMVC.Models.DTO;

namespace EticaretMVC.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        [HttpGet]
        public ActionResult ProductDetail(int id)
        {
            ProductService ps = new ProductService();


            return View(ps.GetByID(id));
        }

        [LoginControls]
        [HttpPost]
        public ActionResult ProductDetail(ProductDTO product)
        {
            if (ModelState.IsValid)
                EticaretMVC.Models.Repository.CartService.AddCarts(product);
            return RedirectToAction("ProductDetail", "product", new { id = product.ID });
        }

        public ActionResult Products(int? CategoryId, int? BrandId)
        {

            CategoryService cs = new CategoryService();
            ProductService ps = new ProductService();
            Session["CategoryId"] = CategoryId;

            if (BrandId == null)
            {

                ViewData["Brands"] = cs.GetAllBrandInTopCategory((int)CategoryId);
                Session["Products"] = ps.GetProductInCategory((int)CategoryId);
            }
            else if (CategoryId == null)
            {

            }
            else
            {

                Session["Products"] = ps.GetProductInCatAndBrand((int)CategoryId, (int)BrandId);
            }
            return View();
        }
        public ActionResult ProductBrand(int CategoryId, int BrandId)
        {
            ProductService ps = new ProductService();
            if (ModelState.IsValid)
            {
                Session["ProductBrand"] = ps.GetProductInCatAndBrands(CategoryId, BrandId);

            }

            return View();
        }




        public ActionResult ProductSearch(string search)
        {
            ProductService ps = new ProductService();
            if (ModelState.IsValid)
            {
                ViewData["search"] = ps.SearchProduct(search);
            }

            return View();
        }

    }
}
