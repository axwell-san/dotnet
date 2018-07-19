namespace FactoryMethod
{
    public class ProductBFactory : IFactory
    {
        public IProduct FactoryMethod()
        {
            return new ProductB();
        }
    }
}
