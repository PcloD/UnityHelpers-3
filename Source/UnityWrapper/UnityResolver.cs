using Contracts;
using FluentChecker;
using Microsoft.Practices.Unity;
using System;

namespace UnityWrapper
{
    /// <summary>
    /// <see cref="IResolver" /> implementation based on the Microsoft Unity framework 
    /// </summary>
    public class UnityResolver : IResolver
    {
        private readonly IUnityContainer unityContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityResolver" /> class. 
        /// </summary>
        /// <param name="unityContainer"> The unity container. </param>
        public UnityResolver(IUnityContainer unityContainer)
        {
            Check.IfIsNull(unityContainer).Throw<ArgumentNullException>(() => unityContainer);
            this.unityContainer = unityContainer;
        }

        /// <summary>
        /// Registers this instance. 
        /// </summary>
        /// <typeparam name="TDependency"> The type of the dependency. </typeparam>
        /// <typeparam name="TImplementation"> The type of the implementation. </typeparam>
        public void Register<TDependency, TImplementation>() where TImplementation : TDependency
        {
            unityContainer.RegisterType<TDependency, TImplementation>();
        }

        /// <summary>
        /// Registers the specified implementation associating it to the generic type. 
        /// </summary>
        /// <typeparam name="TDependency"> The type of the dependency. </typeparam>
        /// <param name="implementation"> The implementation. </param>
        public void Register<TDependency>(TDependency implementation)
        {
            Check.IfIsNull(implementation).Throw<ArgumentNullException>(() => implementation);
            unityContainer.RegisterInstance(implementation);
        }

        /// <summary>
        /// Resolves this instance. 
        /// </summary>
        /// <typeparam name="TDependency"> The type of the dependency. </typeparam>
        /// <returns></returns>
        public TDependency Resolve<TDependency>()
        {
            return unityContainer.Resolve<TDependency>();
        }

        /// <summary>
        /// Resolves the specified dependency type. 
        /// </summary>
        /// <param name="dependencyType"> Type of the dependency. </param>
        /// <returns></returns>
        public object Resolve(Type dependencyType)
        {
            Check.IfIsNull(dependencyType).Throw<ArgumentNullException>(() => dependencyType);

            return unityContainer.Resolve(dependencyType);
        }
    }
}