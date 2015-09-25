using Contracts;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnityWrapper.Tests
{
    [TestClass]
    public class UnityResolverFactoryTests
    {
        [TestMethod]
        public void AssertIResolverResolvedValue()
        {
            var resolver = CreateClassToTestInstance();

            var unityResolver = (UnityResolver)resolver;

            Assert.AreEqual(unityResolver.Resolve<IResolver>(), unityResolver.Resolve<IResolver>(), "It was expected to retrieve the same instance at each Resolve call.");
        }

        [TestMethod]
        public void AssertIUnityContainerResolvedValue()
        {
            var resolver = CreateClassToTestInstance();

            var unityResolver = (UnityResolver)resolver;

            var unityContainer = unityResolver.Resolve<IUnityContainer>();

            Assert.IsNotNull(unityContainer);
            Assert.AreEqual(unityContainer, unityResolver.Resolve<UnityContainer>());
        }

        [TestMethod]
        public void AssertResolverIsOfExpectedType()
        {
            var resolver = CreateClassToTestInstance();

            var unityResolver = resolver as UnityResolver;
            Assert.IsNotNull(unityResolver, "The variable unityResolver is expected to be from type UnityResolver, but is not. Check: unityResolver != null");
        }

        private static IResolver CreateClassToTestInstance()
        {
            var factory = new UnityResolverFactory();

            var resolver = factory.Build();

            Assert.IsNotNull(resolver);

            return resolver;
        }
    }
}