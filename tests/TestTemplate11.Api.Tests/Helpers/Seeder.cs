using System.Collections.Generic;
using TestTemplate11.Core.Entities;
using TestTemplate11.Data;

namespace TestTemplate11.Api.Tests.Helpers
{
    public static class Seeder
    {
        public static void Seed(this TestTemplate11DbContext ctx)
        {
            ctx.Foos.AddRange(
                new List<Foo>
                {
                    new ("Text 1"),
                    new ("Text 2"),
                    new ("Text 3")
                });
            ctx.SaveChanges();
        }
    }
}
