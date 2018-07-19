namespace AbstractFactory
{
    // Provide an interface for creating families of related or dependent objects without specifying their concrete classes.
    public interface IAbstractFactory
    {
        IProduct CreateProduct();
        IProductSeller CreateProductSeller(IProduct product);
    }
}
