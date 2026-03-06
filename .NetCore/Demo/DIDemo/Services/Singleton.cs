namespace DIDemo.Services
{
    public class Singleton
    {
        public Guid guid;

        public Singleton()
        {
            guid = Guid.NewGuid();
        }
    }
}
