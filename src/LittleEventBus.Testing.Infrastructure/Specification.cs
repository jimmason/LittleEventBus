using NUnit.Framework;

namespace LittleEventBus.Testing.Infrastructure
{
    public abstract class Specification
    {

        [SetUp]
        public void SetUp()
        {
            this.Given();
            this.When();
        }

        protected virtual void Given()
        {
        }

        protected virtual void When()
        {
        }
    }
}
