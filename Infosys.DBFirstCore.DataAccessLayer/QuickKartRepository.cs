using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infosys.DBFirstCore.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Infosys.DBFirstCore.DataAccessLayer
{
    public class QuickKartRepository
    {
        QuickKartDBContext context;
        public QuickKartRepository()
        {
            QuickKartDBContext conn;
            context = new QuickKartDBContext();
        }
        public List<Category> GetAllCategories()
        {
           var categoriesList = context.Categories
                            .OrderBy(c => c.CategoryId)
                            .ToList();
           return categoriesList;
        }

        public List<Product> GetProductsOnCategoryId(byte categoryId)
        {
            List<Product> lstProducts = null;
            try
            {
                lstProducts = context.Products.Where(p => p.CategoryId == categoryId).ToList();
            }
            catch (Exception ex)
            {
                lstProducts = null;
            }
            return lstProducts;
        }
        public Product FilterProducts(byte categoryId)
        {
            Product product = null;
            try
            {
                product = context.Products.Where(p => p.CategoryId == categoryId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                product = null;
            }
            return product;
        }
        public List<Product> FilterProductsUsingLike(string pattern)
        {
            List<Product> lstProduct = null;
            try
            {
                lstProduct = context.Products.Where(p => EF.Functions.Like(p.ProductName, pattern)).ToList();
            }
            catch (Exception ex)
            {
                lstProduct = null;
            }
            return lstProduct;
        }


    }
}
