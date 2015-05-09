using NUnit.Framework;

namespace LittleEventBus.Testing.Infrastructure
{
    [TestFixture]
    public abstract class Specification
    {
        [TestFixtureSetUp]
        public virtual void TestFixtureSetUp()
        {
            
        }


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
