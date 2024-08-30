using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Single_Responsibility_Priciple.NonSRP
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private static List<Product> ProductList = new List<Product>();

        public List<Product> Products => ProductList;

        public Product()
        {
            ProductList = new()
            {
                new(){Id=1, Name="Kalem 1"},
                new(){Id=2, Name="Kalem 2"},
                new(){Id=3, Name="Kalem 3"},
                new(){Id=4, Name="Kalem 4"},
                new(){Id=5, Name="Kalem 5"},
            };
        }


        public void SaveOrUpdate(Product product)
        {
            var hasProduct = ProductList.Any(p => p.Id == product.Id);
            if (hasProduct)
            {
                var productIndex = ProductList.FindIndex(p => p.Id == product.Id);
                ProductList[productIndex] = product;
            }

            ProductList.Add(product);
        }

        public void Delete(int id)
        {
            var hasProduct = ProductList.Find(p => p.Id == id);
            if (hasProduct != null)
            {
                ProductList.Remove(hasProduct);
            }
            throw new Exception($"Var olamayan bir değeri silemezsiniz.(Product.Id={id})");
        }

        public void WriteToConsole()
        {
            ProductList.ForEach(p =>
            {
                Console.WriteLine($"{p.Id} - {p.Name}");
            });
        }
    }
}
