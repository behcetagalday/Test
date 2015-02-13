using EticaretMVC.Filters;
using EticaretMVC.Models.DTO;
using EticaretMVC.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EticaretMVC.Controllers
{
    public class CartsController : Controller
    {
        //
        // GET: /Carts/
        [LoginControls]
        public ActionResult ShoppingCart()
        {
          

          
            return View(  );
        }
        //Update Shopping Cart
        public ActionResult UpdateCart( string txtquantity, string hidden)
        {
            CartService cs = new CartService();
            if (ModelState.IsValid)
            {

                cs.UpdateCarts(Convert.ToInt32(hidden) ,Convert.ToInt32(txtquantity));
            }

            return RedirectToAction("ShoppingCart", "Carts");
        }
        //Delete ShoppingCart Product 
        public ActionResult DeleteProduct(ProductDTO product)
        {
            CartService cs = new CartService();
            if (ModelState.IsValid)
            {
                cs.DeleteCarts(product);
            }

            return RedirectToAction("ShoppingCart", "Carts");
        }
    //[HttpGet]
    //    public ActionResult Carts()
    //    {
    //        CartService cs = new CartService();
            

    //        return View(cs.GetCartsAll());
    //    }
    //    [HttpPost]
    //    public ActionResult Carts(ProductDTO product, string txtquantity, string hidden)
    //    {
    //        CartService cs = new CartService();
    //        if (ModelState.IsValid)
    //        {

    //            cs.UpdateCarts(Convert.ToInt32(hidden), Convert.ToInt32(txtquantity));
    //        }

    //        return View();
    //    }
    }    
}
