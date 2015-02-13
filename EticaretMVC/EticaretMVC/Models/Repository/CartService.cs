using EticaretMVC.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretMVC.Models.Repository
{
    public class CartService : ServiceBase
    {   
        //Alışveri Sepeti Olusturma ve sepeti göstermek
        public static List<ProductDTO> GetCarts()
        {
            ShopicaDBEntities Db = new ShopicaDBEntities();
            List<ProductDTO> plist;
            UserDTO user = HttpContext.Current.Session["_user"] as UserDTO;
            if (user != null)
            {
                if (HttpContext.Current.Session["_carts"] == null)
                {
                    var result = (from b in Db.Baskets
                                  where b.UserID == user.ID
                                  select new ProductDTO()
                                  {
                                      ID = b.ProductID,
                                      Name = b.Product.Name,
                                      Price = b.Product.Price,
                                      Discoount = b.Product.Discount,
                                      Quantity = (int)b.Quantity,
                                      Brand = new BrandDTO()
                                      {
                                          ID = (int)b.Product.Brand_ID,
                                          Name = b.Product.Brand.Name

                                      },
                                      Category = new CategoryDTO()
                                      {
                                          ID = (int)b.Product.Category_ID,
                                          Name = b.Product.Category.Name


                                      }
                                  }).ToList();
                    plist = result.Count == 0 ? new List<ProductDTO>() : result;
                    HttpContext.Current.Session["_carts"] = plist;
                }
                else
                {
                    plist = HttpContext.Current.Session["_carts"] as List<ProductDTO>;
                }
            }
            else
            {
                plist = new List<ProductDTO>();
            }
            return plist;
        }
        //Alısveriş Sepetine Ürün Ekleme
        public static void AddCarts(ProductDTO product)
        {
            using (ShopicaDBEntities db = new ShopicaDBEntities())
            {
                Basket b;
                UserDTO user = HttpContext.Current.Session["_user"] as UserDTO;
                if (user == null)
                    return;
                if (HttpContext.Current.Session["_carts"] == null)
                    HttpContext.Current.Session["_carts"] = new List<ProductDTO>();
                List<ProductDTO> carts = HttpContext.Current.Session["_carts"] as List<ProductDTO>;
                ProductDTO current = carts.Where(x => x.ID == product.ID).FirstOrDefault();
                if (carts.Contains(current))
                {
                    carts[carts.IndexOf(current)].Quantity += product.Quantity;
                    b = db.Baskets.Where(x => x.UserID == user.ID && x.ProductID == current.ID).FirstOrDefault();
                    b.Quantity = current.Quantity;
                }
                else
                {
                    //carts.Add(Product);
                    b = new Basket()
                    {
                        ProductID = product.ID,
                        Quantity = product.Quantity,
                        UserID = user.ID,
                        CreatedDate = DateTime.Now
                    };
                    db.Baskets.Add(b);
                }
                //HttpContext.Current.Session["_cart"] = carts;
                HttpContext.Current.Session["_carts"] = null;
                db.SaveChanges();
            }
        
        }
        //Alışveriş Sepetinde Ürün Güncelleme
        public void UpdateCarts(int productid,int Quantity)
        {
            
            UserDTO user = HttpContext.Current.Session["_user"] as UserDTO;
            List<ProductDTO> carts = HttpContext.Current.Session["_carts"] as List<ProductDTO>;
            ProductDTO current = carts.Where(x => x.ID == productid).FirstOrDefault();
            current.Quantity = Quantity;
            Basket b = DB.Baskets.Where(x => x.UserID == user.ID && x.ProductID == productid).FirstOrDefault();
            b.Quantity = Quantity;
            HttpContext.Current.Session["_carts"] = null;
            DB.SaveChanges();
        }
        //Alışveriş Sepetindedi Ürünleri silme
        public void DeleteCarts(ProductDTO product)
        {
            Basket b;
            UserDTO user = HttpContext.Current.Session["_user"] as UserDTO;
            if (user == null)
            {
                return;
            }
            if (HttpContext.Current.Session["_carts"] == null)
            {
                HttpContext.Current.Session["_carts"] = new List<ProductDTO>();
            }
            List<ProductDTO> carts = HttpContext.Current.Session["_carts"] as List<ProductDTO>;
            ProductDTO current = carts.Where(x => x.ID == product.ID).FirstOrDefault();
            if (carts.Contains(current))
            {
                carts.Remove(current);
                b = DB.Baskets.Where(x => x.UserID == user.ID && x.ProductID == current.ID).FirstOrDefault();
                DB.Baskets.Remove(b);
            }
            HttpContext.Current.Session["_cart"] = null;
            DB.SaveChanges();
        }

        public void DeleteAllCart(List<ProductDTO> Products)
        {
            using (ShopicaDBEntities DB = new ShopicaDBEntities())
            {
                Basket b;
                UserDTO user = HttpContext.Current.Session["_user"] as UserDTO;
                if (HttpContext.Current.Session["_cart"] == null)
                    HttpContext.Current.Session["_cart"] = new List<ProductDTO>();
                List<ProductDTO> carts = HttpContext.Current.Session["_cart"] as List<ProductDTO>;
                foreach (ProductDTO item in Products)
                {
                    ProductDTO current = carts.Where(x => x.ID == item.ID).FirstOrDefault();
                    if (carts.Contains(current))
                    {
                        carts.Remove(current);
                        b = DB.Baskets.Where(x => x.UserID == user.ID && x.ProductID == current.ID).FirstOrDefault();
                        DB.Baskets.Remove(b);
                    }
                }
                HttpContext.Current.Session["_cart"] = null;
                DB.SaveChanges();
            }
        }
        //public  List<ProductDTO> GetCartsAll()
        //{
        //    ShopicaDBEntities Db = new ShopicaDBEntities();
        //    List<ProductDTO> plist;
        //    UserDTO user = HttpContext.Current.Session["_user"] as UserDTO;
        //    if (user != null)
        //    {
        //        if (HttpContext.Current.Session["_carts"] == null)
        //        {
        //            var result = (from b in Db.Baskets
        //                          where b.UserID == user.ID
        //                          select new ProductDTO()
        //                          {
        //                              ID = b.ProductID,
        //                              Name = b.Product.Name,
        //                              Price = b.Product.Price,
        //                              Discoount = b.Product.Discount,
        //                              Quantity = (int)b.Quantity,
        //                              Brand = new BrandDTO()
        //                              {
        //                                  ID = (int)b.Product.Brand_ID,
        //                                  Name = b.Product.Brand.Name

        //                              },
        //                              Category = new CategoryDTO()
        //                              {
        //                                  ID = (int)b.Product.Category_ID,
        //                                  Name = b.Product.Category.Name


        //                              }
        //                          }).ToList();
        //            plist = result.Count == 0 ? new List<ProductDTO>() : result;
        //            HttpContext.Current.Session["_carts"] = plist;
        //        }
        //        else
        //        {
        //            plist = HttpContext.Current.Session["_carts"] as List<ProductDTO>;
        //        }
        //    }
        //    else
        //    {
        //        plist = new List<ProductDTO>();
        //    }
        //    return plist;
        //}
    }
}