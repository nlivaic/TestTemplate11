using TestTemplate11.Core.Entities;
using TestTemplate11.Core.Interfaces;

namespace TestTemplate11.Data.Repositories
{
    public class FooRepository : Repository<Foo>, IFooRepository
    {
        public FooRepository(TestTemplate11DbContext context)
            : base(context)
        {
        }
    }
}
