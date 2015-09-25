using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UnitTestInjector;

namespace Contracts.Tests
{
    /// <summary>
    /// Base test class containing common tests for all the <see cref="IResolver" />
    /// implementations. Due to a Visual Studio defect, to allow the test explorer to find and
    /// execute the test methods, both <see cref="ResolverTest" /> and <see cref="Foo" /> classes
    /// need to be added as a link to the project containing the <see cref="IResolver" />
    /// implementation to test. An example is provided in the UnityWrapper.Tests project.
    /// </summary>
    [TestClass]
    public abstract class ResolverTest : BaseTestClass
    {
        [TestMethod]
        public void AssertGenericRegister()
        {
            var resolver = BuildResolver();

            resolver.Register<IFoo, Foo>();

            AssertResolvedValues<IFoo, Foo>(resolver);
        }

        [TestMethod]
        public void AssertRegisterInstance()
        {
            var resolver = BuildResolver();

            var foo = new Foo();

            resolver.Register<IFoo>(foo);

            AssertResolvedValues<IFoo, Foo>(resolver);

            Assert.AreEqual(foo, resolver.Resolve<IFoo>());
        }

        [TestMethod]
        public void AssertRegisterInstanceWillFailWhenInstanceIsNull()
        {
            TestExpectedArgumentException<ArgumentNullException>(() =>
            {
                var resolver = BuildResolver();

                resolver.Register<IFoo>(null);
            }, "implementation");

            TestExpectedArgumentException<ArgumentNullException>(() =>
            {
                var resolver = BuildResolver();

                resolver.Register<IFoo>(null);
            }, "implementation");
        }

        [TestMethod]
        public void AssertResolverValueIsValid()
        {
            var resolver = BuildResolver();

            Assert.IsNotNull(resolver);
        }

        protected abstract IResolver BuildResolver();

        private static void AssertResolvedValues<TDependency, TImplementation>(IResolver resolver) where TImplementation : class, TDependency
        {
            var resolvedValue = resolver.Resolve<TDependency>();
            Assert.IsNotNull(resolvedValue);
            Assert.IsInstanceOfType(resolvedValue, typeof(TImplementation));

            resolvedValue = resolver.Resolve(typeof(TDependency)) as TImplementation;

            Assert.IsNotNull(resolvedValue);
            Assert.IsInstanceOfType(resolvedValue, typeof(TImplementation));
        }
    }
}