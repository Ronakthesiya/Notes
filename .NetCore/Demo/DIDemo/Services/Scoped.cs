namespace DIDemo.Services
{
    public class Scoped
    {
        public Guid guid;

        public Scoped()
        {
            guid = Guid.NewGuid();
        }
    }
}
