using System;
using TestTemplate11.Common.Base;
using TestTemplate11.Common.Exceptions;

namespace TestTemplate11.Core.Entities
{
    public class Foo : BaseEntity<Guid>
    {
        public Foo(string text)
        {
            Validate(text);
            Text = text;
        }

        private Foo()
        {
        }

        public string Text { get; private set; }

        private static void Validate(string text)
        {
            if (text.Length < 5)
            {
                throw new BusinessException($"Foo text must be at least 5 characters.");
            }
        }
    }
}
