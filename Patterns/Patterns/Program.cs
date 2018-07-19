using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----- SimpleFactory -----");
            SimpleFactory.IProduct simpleFactoryProductA = SimpleFactoryClient(SimpleFactory.ProductType.A);
            SimpleFactory.IProduct simpleFactoryProductB = SimpleFactoryClient(SimpleFactory.ProductType.B);
            Console.WriteLine($"{simpleFactoryProductA.Name} created");
            Console.WriteLine($"{simpleFactoryProductB.Name} created");

            Console.WriteLine("----- FactoryMethod -----");
            FactoryMethod.IFactory factoryMethodProductAFactory = new FactoryMethod.ProductAFactory();
            FactoryMethod.IFactory factoryMethodProductBFactory = new FactoryMethod.ProductBFactory();
            FactoryMethod.IProduct factoryMethodProductA = FactoryMethodClient(factoryMethodProductAFactory);
            FactoryMethod.IProduct factoryMethodProductB = FactoryMethodClient(factoryMethodProductBFactory);
            Console.WriteLine($"{factoryMethodProductA.Name} created");
            Console.WriteLine($"{factoryMethodProductB.Name} created");

            Console.WriteLine("----- AbstractFactory -----");
            AbstractFactory.IAbstractFactory abstractFactoryProductAFactory = new AbstractFactory.ProductAFactory();
            AbstractFactory.IAbstractFactory abstractFactoryProductBFactory = new AbstractFactory.ProductBFactory();
            AbstractFactoryClient(abstractFactoryProductAFactory);
            AbstractFactoryClient(abstractFactoryProductBFactory);

            Console.ReadKey();
        }

        static SimpleFactory.IProduct SimpleFactoryClient(SimpleFactory.ProductType productType)
        {
            return SimpleFactory.ProductFactory.CreateProduct(productType);
        }

        static FactoryMethod.IProduct FactoryMethodClient(FactoryMethod.IFactory factory)
        {
            // refers the concrete implementation through an interface (vs SimpleFactory - refers Factory class directly)
            return factory.FactoryMethod();
        }

        static void AbstractFactoryClient(AbstractFactory.IAbstractFactory factory)
        {
            AbstractFactory.IProduct product;
            AbstractFactory.IProductSeller productSeller;
            product = factory.CreateProduct();
            productSeller = factory.CreateProductSeller(product);
            Console.WriteLine($"{product.Name} created");
            productSeller.SellProduct();
        }
    }
}
