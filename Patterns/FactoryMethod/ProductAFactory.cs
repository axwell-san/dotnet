namespace FactoryMethod
{
    public class ProductAFactory : IFactory
    {
        public IProduct FactoryMethod()
        {
            return new ProductA();
        }
    }
}
