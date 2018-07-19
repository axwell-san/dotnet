namespace AbstractFactory
{
    public class ProductAFactory : IAbstractFactory
    {
        public IProduct CreateProduct()
        {
            return new ProductA();
        }

        public IProductSeller CreateProductSeller(IProduct product)
        {
            return new ProductASeller(product);
        }
    }
}
