using System;
using System.Collections.Generic;
using Infosys.DBFirstCore.DataAccessLayer;
using Infosys.DBFirstCore.DataAccessLayer.Models;

namespace Infosys.QuickKart.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            QuickKartRepository repository = new QuickKartRepository();
            var categories = repository.GetAllCategories();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("CategoryId\tCategoryName");
            Console.WriteLine("----------------------------------");
            foreach (var category in categories)
            {
                Console.WriteLine("{0}\t\t{1}", category.CategoryId, category.CategoryName);
            }

            Console.WriteLine("\n");
            byte categoryId = 1;
            List<Product> lstproducts = repository.GetProductsOnCategoryId(categoryId);
            if (lstproducts.Count == 0)
            {
                Console.WriteLine("No products available under the category = " + categoryId);
            }
            else
            {
                Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", "ProductId", "ProductName", "CategoryId", "Price", "QuantityAvailable");
                Console.WriteLine("---------------------------------------------------------------------------------------");
                foreach (var products in lstproducts)
                {
                    Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", products.ProductId, products.ProductName, products.CategoryId, products.Price, products.QuantityAvailable);
                }
            }

            Product product = repository.FilterProducts(categoryId);
            if (product == null)
            {
                Console.WriteLine("No product details available");
            }
            else
            {
                Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", "ProductId", "ProductName", "CategoryId", "Price", "QuantityAvailable");
                Console.WriteLine("---------------------------------------------------------------------------------------");
                Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", product.ProductId, product.ProductName, product.CategoryId, product.Price, product.QuantityAvailable);
            }
            Console.WriteLine();
            //Below code filters are
            string pattern = "BMW%";
            List<Product> lstProducts = repository.FilterProductsUsingLike(pattern);
            if (lstProducts.Count == 0)
            {
                Console.WriteLine("No products available with the = " + pattern);
            }
            else
            {
                Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", "ProductId", "ProductName", "CategoryId", "Price", "QuantityAvailable");
                Console.WriteLine("---------------------------------------------------------------------------------------");
                foreach (var filt in lstProducts)
                {
                    Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", filt.ProductId, filt.ProductName, filt.CategoryId, filt.Price, filt.QuantityAvailable);
                }
            }
            Console.WriteLine();
        }
    }
}
