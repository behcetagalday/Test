using EticaretMVC.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretMVC.Models.Repository
{
    public class ProductService:ServiceBase,IService<ProductDTO>
    {
        public List<ProductDTO> GetALL()
        {
            throw new NotImplementedException();
        }
        //Seçilmiş Ürünler
        public List<ProductDTO> GetSpecialProduct()
        {
            var result = from p in DB.Products
                         where p.IsSpecial == true
                         select new ProductDTO
                         {
                             ID = p.ID,
                             Name = p.Name,
                             Price = p.Price,
                    Picture=p.Pictures.Where(x=>x.IsDefault==true).Select(x=>x.Path).FirstOrDefault(),
                             Category = new CategoryDTO()
                             {
                                 ID = (int)p.Category_ID,
                                 Name = p.Category.Name
                             },
                             Brand = new BrandDTO()
                             {
                                 ID =(int) p.Brand_ID,
                                 Name = p.Brand.Name
                             }


                         };
     return result.Take(10).ToList();
        }
        //Son Eklenen Ürünler
       public  List<ProductDTO> GetLatesProduct()
        {
        var result=from p in DB.Products
                   orderby p.CreatedDate descending
                   select new ProductDTO
                   {
                       ID = p.ID,
                       Name = p.Name,
                       Price = p.Price,
                       Picture = p.Pictures.Where(x => x.IsDefault == true).Select(x => x.Path).FirstOrDefault(),
                       Category = new CategoryDTO()
                       {
                           ID = (int)p.Category_ID,
                           Name = p.Category.Name
                       },
                       Brand = new BrandDTO()
                       {
                           ID = (int)p.Brand_ID,
                           Name = p.Brand.Name
                       }


                   };
        return result.Take(10).ToList();
        }
        //Ürün Id'ye Göre Ürünler
        public ProductDTO GetByID(int EntityId)
        {
          var result=from p in DB.Products
                     where p.ID==EntityId
                     select new ProductDTO
                     {
                         ID = p.ID,
                         Name = p.Name,
                         Stock=p.InStock,
                         Price = p.Price,
                         Discoount=p.Discount,
                         Picture = p.Pictures.Where(x => x.IsDefault == true).Select(x => x.Path).FirstOrDefault(),
                         Category = new CategoryDTO()
                         {
                             ID = (int)p.Category_ID,
                             Name = p.Category.Name
                         },
                         Brand = new BrandDTO()
                         {
                             ID = (int)p.Brand_ID,
                             Name = p.Brand.Name
                         }


                     };
          return result.FirstOrDefault();
        }
        //Kategori Id'ye Göre Ürünler 
        public List<ProductDTO> GetProductInCategory(int CategoryId)
        {
            var result = from p in DB.Products
                     where p.Category_ID==CategoryId
                         select new ProductDTO
                         {
                             ID = p.ID,
                             Name = p.Name,
                             Price = p.Price,
                             Picture = p.Pictures.Where(x => x.IsDefault == true).Select(x => x.Path).FirstOrDefault(),
                     
                             Category = new CategoryDTO()
                             {
                                 ID = (int)p.Category_ID,
                                 Name = p.Category.Name
                             },
                             Brand = new BrandDTO()
                             {
                                 ProductCount=p.Brand.Products.Count,
                                 ID = (int)p.Brand_ID,
                                 Name = p.Brand.Name
                             }


                         };
            return result.ToList();
        }
        //Kategori Id ve Marka Id'ye Göre Ürünler
        public List<ProductDTO> GetProductInCatAndBrand(int CategoryId,int BrandId)
        {
            var result = from p in DB.Products
                 where p.Category.TopCategory_ID==CategoryId && p.Brand_ID==BrandId
                         select new ProductDTO
                         {
                             ID = p.ID,
                             Name = p.Name,
                             Price = p.Price,
                             Picture = p.Pictures.Where(x => x.IsDefault == true).Select(x => x.Path).FirstOrDefault(),
                             Category = new CategoryDTO()
                             {
                                 ID = (int)p.Category_ID,
                                 Name = p.Category.Name
                             },
                             Brand = new BrandDTO()
                             {
                                 ID = (int)p.Brand_ID,
                                 Name = p.Brand.Name
                             }


                         };
            return result.ToList();
        }
        public List<ProductDTO> GetProductInCatAndBrands(int CategoryId, int BrandId)
        {
            var result = from p in DB.Products
                         where p.Category_ID == CategoryId && p.Brand_ID == BrandId
                         select new ProductDTO
                         {
                             ID = p.ID,
                             Name = p.Name,
                             Price = p.Price,
                             Picture = p.Pictures.Where(x => x.IsDefault == true).Select(x => x.Path).FirstOrDefault(),
                             Category = new CategoryDTO()
                             {
                                 ID = (int)p.Category_ID,
                                 Name = p.Category.Name
                             },
                             Brand = new BrandDTO()
                             {
                                 ID = (int)p.Brand_ID,
                                 Name = p.Brand.Name
                             }


                         };
            return result.ToList();
        }
        public int Save(ProductDTO Entity)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductDTO Entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(ProductDTO Entity)
        {
            throw new NotImplementedException();
        }
        //Ürün Adı Veya Marka Adına Göre Arama
        public List<ProductDTO> SearchProduct(string Entity)
        { 
        var result=from p in DB.Products
                   where p.Name.ToLower().Contains(Entity) || p.Brand.Name.ToLower().Contains(Entity)
                   select new ProductDTO
                   {
                       ID = p.ID,
                       Name = p.Name,
                       Price = p.Price,
                       Picture = p.Pictures.Where(x => x.IsDefault == true).Select(x => x.Path).FirstOrDefault(),
                       Category = new CategoryDTO()
                       {
                           ID = (int)p.Category_ID,
                           Name = p.Category.Name
                       },
                       Brand = new BrandDTO()
                       {
                           ID = (int)p.Brand_ID,
                           Name = p.Brand.Name
                       }


                   };
        return result.ToList();
        
        }
    }
}