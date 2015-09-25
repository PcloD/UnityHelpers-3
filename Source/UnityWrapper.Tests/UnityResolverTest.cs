using Contracts;
using Contracts.Tests;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnityWrapper.Tests
{
    [TestClass]
    public class UnityResolverTest : ResolverTest
    {
        [TestMethod]
        protected override IResolver BuildResolver()
        {
            return new UnityResolver(new UnityContainer());
        }
    }
}