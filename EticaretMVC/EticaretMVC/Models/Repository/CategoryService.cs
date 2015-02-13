using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EticaretMVC.Models.DTO;

namespace EticaretMVC.Models.Repository
{
    public class CategoryService:ServiceBase,IService<CategoryDTO>
    {
        //Ana Kategorileri Getirir
        public List<CategoryDTO> GetALL()
        {
            var result = from c in DB.Categories
                         where c.Category1 == null
                         select new CategoryDTO
                         {
                             ID = c.ID,
                             Name = c.Name,

                         };
            return result.ToList();
        }
        //Alt Kategorileri Getirir
        public List<CategoryDTO> GetALLTopCategories(int Catid)
        {
            var result = from c in DB.Categories
                         where c.TopCategory_ID==Catid
                         select new CategoryDTO
                         {
                             ID = c.ID,
                             Name = c.Name,
                             ProductCount=c.Products.Count

                         };
            return result.ToList();
        }
        //Ana Kategori Id'ye Göre Markaları Getirir
        public List<BrandDTO> GetAllBrandInCategory(int catid) {

            var result = from p in DB.Products
                         where p.Category.TopCategory_ID == catid 
                         group p by p.Brand into g
                         select new BrandDTO
                         {
                             ID = g.Key.ID,
                             Name = g.Key.Name,
                             ProductCount = g.Count()
                         };
            return result.ToList();
        }
        public CategoryDTO GetByID(int EntityId)
        {
            throw new NotImplementedException();
        }

        public int Save(CategoryDTO Entity)
        {
            throw new NotImplementedException();
        }

        public int Update(CategoryDTO Entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(CategoryDTO Entity)
        {
            throw new NotImplementedException();
        }
        public List<BrandDTO> GetAllBrandInTopCategory(int catid)
        {

            var result = from p in DB.Products
                         where p.Category_ID == catid
                         group p by p.Brand into g
                         select new BrandDTO
                         {
                             ID = g.Key.ID,
                             Name = g.Key.Name,
                             ProductCount = g.Count()

                         };
                         
            return result.ToList();
        }
    }
}