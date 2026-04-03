using DIDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace DIDemo.Repository
{
    public class PrintRepository
    {
        private Transiant transiant;
        private Scoped scoped;
        private Singleton singleton;
        public PrintRepository(Transiant t, Scoped s, Singleton S)
        {
            transiant = t;
            scoped = s;
            singleton = S;
        }

        public object print()
        {
            return (new
            {
                ptransiant = transiant.guid,
                pscoped = scoped.guid,
                psingleton = singleton.guid,
            });
        }
    }
}
