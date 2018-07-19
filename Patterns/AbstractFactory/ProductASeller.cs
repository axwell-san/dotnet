using System;

namespace AbstractFactory
{
    public class ProductASeller : IProductSeller
    {
        IProduct _productToSell;

        public ProductASeller(IProduct productToSell)
        {
            _productToSell = productToSell;
        }

        public void SellProduct()
        {
            Console.WriteLine($"I sell {_productToSell.Name}");
        }
    }
}
