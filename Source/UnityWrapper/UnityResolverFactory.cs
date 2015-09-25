using Contracts;
using Microsoft.Practices.Unity;

namespace UnityWrapper
{
    /// <summary>
    /// Factory class for the <see cref="UnityResolver" /> 
    /// </summary>
    public class UnityResolverFactory : IResolverFactory
    {
        /// <summary>
        /// Builds this instance. 
        /// </summary>
        /// <returns></returns>
        public IResolver Build()
        {
            var unityContainer = new UnityContainer();

            unityContainer.RegisterInstance<IUnityContainer>(unityContainer);
            unityContainer.RegisterInstance(unityContainer);

            // ContainerControlledLifetimeManager specifies that the dependency will be managed as a
            // Singleton, so each resolve will return the same instance.
            unityContainer.RegisterType<IResolver, UnityResolver>(new ContainerControlledLifetimeManager());

            return unityContainer.Resolve<IResolver>();
        }
    }
}