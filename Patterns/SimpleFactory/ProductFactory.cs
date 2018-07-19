using System;

namespace SimpleFactory
{
    public enum ProductType
    {
        A,
        B
    }

    public class ProductFactory
    {
        // violates the Open-Closed SOLID Principle (vs FactoryMethod)
        public static IProduct CreateProduct(ProductType productType)
        {
            switch (productType)
            {
                case ProductType.A:
                    return new ProductA();
                case ProductType.B:
                    return new ProductB();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
