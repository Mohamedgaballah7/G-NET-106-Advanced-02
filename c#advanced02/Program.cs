namespace c_advanced02
{
    internal class Program
    {
        static List<Product> SearchProducts(
    List<Product> products,
    Func<Product, bool> filter)
        {
            List<Product> result = new List<Product>();

            foreach (Product product in products)
            {
                if (filter(product))
                {
                    result.Add(product);
                }
            }

            return result;
        }
        static void PrintReport(List<Product> products, Action<Product> action)
        {
            foreach (Product product in products)
            {
                action(product);
            }
        }

        static void TransformProducts(List<Product> products, Func<Product, Product> transform)
        {
            foreach (Product product in products)
            {
                transform(product);
            }
        }
        static List<Product> FilterProducts(
       List<Product> products,
       Predicate<Product> condition)
        {
            List<Product> result = new List<Product>();

            foreach (Product product in products)
            {
                if (condition(product))
                {
                    result.Add(product);
                }
            }

            return result;
        }
        static void Main(string[] args)
        {
            List<Product> catalog = new()
{
    new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
    new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
    new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
    new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
    new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
    new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
    new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
    new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
    new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
    new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }
};
            #region task01
            List<Product> electronics = SearchProducts(
                catalog,
                p => p.Category == "Electronics"
            );

            List<Product> cheaperThan50 = SearchProducts(
                catalog,
                p => p.Price < 50
            );

            List<Product> inStock = SearchProducts(
                catalog,
                p => p.Stock > 0
            );

            List<Product> clothingUnder100 = SearchProducts(
                catalog,
                p => p.Category == "Clothing" && p.Price < 100
            );

            /*
            Console.WriteLine("--- Electronics ---");

            foreach (Product product in electronics)
            {
                Console.WriteLine(
                    $"{product.Name} - ${product.Price} (Stock: {product.Stock})"
                );
            }

            Console.WriteLine("\n--- Under $50 ---");

            foreach (Product product in cheaperThan50)
            {
                Console.WriteLine(
                    $"{product.Name} - ${product.Price} (Stock: {product.Stock})"
                );
            }

            Console.WriteLine("\n--- In Stock ---");

            foreach (Product product in inStock)
            {
                Console.WriteLine(
                    $"{product.Name} - ${product.Price} (Stock: {product.Stock})"
                );
            }

            Console.WriteLine("\n--- Clothing Under $100 ---");

            foreach (Product product in clothingUnder100)
            {
                Console.WriteLine(
                    $"{product.Name} - ${product.Price} (Stock: {product.Stock})"
                );
            }
            */
            #endregion

            #region task03-3.1
            /*
            Console.WriteLine("--- Short Report ---");

            PrintReport(catalog, p =>
            {
                Console.WriteLine($"{p.Name} - ${p.Price}");
            });

            Console.WriteLine("\n--- Detailed Report ---");

            PrintReport(catalog, p =>
            {
                Console.WriteLine(
                    $"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"
                );
            });
            */
            #endregion

            #region task03-3.2
            /*
            Console.WriteLine("--- Summary List ---");
            TransformProducts(catalog, p =>
            {
                Console.WriteLine($"{p.Name} ( ${p.Price})");
                return p;
            });
            Console.WriteLine("\n--- Price labels ---");
            TransformProducts(catalog, delegate(Product p)
            {
                if(p.Price > 100)
                {
                    p.Name = $"{p.Name} : Expensive!";
                }
               
                else
                {
                    p.Name = $"{p.Name} : Affordable";
                }
                Console.WriteLine(p.Name);
                return p;
            });
            */
            #endregion
            #region task03-3.3

            Console.WriteLine("--- Low Stock Alerts ---");

            List<Product> lowStockProducts = FilterProducts(
    catalog,
    product => product.Stock < 20
);

            foreach (Product product in lowStockProducts)
            {
                Console.WriteLine($"[LOW STOCK] {product.Name}: only {product.Stock} left!");
            }
            #endregion
        }
    }
}
