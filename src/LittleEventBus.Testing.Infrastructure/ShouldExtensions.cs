using System;
using NUnit.Framework;

namespace LittleEventBus.Testing.Infrastructure
{
    public static class ShouldExtensions
    {
        public static void ShouldBeOfType(this object actual, Type expected)
        {
            Assert.IsInstanceOf(expected, actual);
        }

        public static void ShouldEqual<T>(this T actual, T expected)
        {
            Assert.AreEqual(expected, actual);
        }
    }
}
