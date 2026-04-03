namespace MinimalAPIDemo
{
    public class Data
    {
        public static List<Product> products = new List<Product>() 
        {
            new Product() {id=1,name="prod1",description="product1",price=100},
            new Product() {id=2,name="prod2",description="product2",price=200},
            new Product() {id=3,name="prod3",description="product3",price=300},
        };
    }
}
