using DGBar.Domain.DTO;
using DGBar.Tests.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Tests.Util
{
    public class Util
    {
        private static readonly Random _random = new Random();

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
        public static string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
        public static void LoadProducts(TestProductConfig _testProduct)
        {
            ProductDTO product = new ProductDTO()
            {
                Name = "Cerveja",
                Price = 5
            };
            var productResult = _testProduct.ProductController.PostProduct(product);

            ProductDTO product2 = new ProductDTO()
            {
                Name = "Conhaque",
                Price = 20
            };
            productResult = _testProduct.ProductController.PostProduct(product2);

            ProductDTO product3 = new ProductDTO()
            {
                Name = "Suco",
                Price = 50
            };
            productResult = _testProduct.ProductController.PostProduct(product3);

            ProductDTO product4 = new ProductDTO()
            {
                Name = "Agua",
                Price = 70
            };
            productResult = _testProduct.ProductController.PostProduct(product4);
        }

        internal static void LoadProducts()
        {
            throw new NotImplementedException();
        }
    }
}
