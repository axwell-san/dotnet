using System;

namespace AbstractFactory
{
    public class ProductBSeller : IProductSeller
    {
        IProduct _productToSell;

        public ProductBSeller(IProduct productToSell)
        {
            _productToSell = productToSell;
        }

        public void SellProduct()
        {
            Console.WriteLine($"I sell {_productToSell.Name}");
        }
    }
}
