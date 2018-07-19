namespace AbstractFactory
{
    public class ProductBFactory : IAbstractFactory
    {
        public IProduct CreateProduct()
        {
            return new ProductB();
        }

        public IProductSeller CreateProductSeller(IProduct product)
        {
            return new ProductBSeller(product);
        }
    }
}