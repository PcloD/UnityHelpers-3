using System;

namespace Contracts
{
    /// <summary>
    /// Allows to associate a dependency (AKA an interface) to a specific implementation and
    /// resolves the necessary dependencies when requested
    /// </summary>
    public interface IResolver
    {
        /// <summary>
        /// Associate the TImplementation type to a TDependency interface. 
        /// </summary>
        /// <typeparam name="TDependency"> The type of the dependency. </typeparam>
        /// <typeparam name="TImplementation"> The type of the implementation. </typeparam>
        void Register<TDependency, TImplementation>() where TImplementation : TDependency;

        /// <summary>
        /// Associate an instance to a TDependency. interface. 
        /// </summary>
        /// <typeparam name="TDependency"> The type of the dependency. </typeparam>
        /// <param name="implementation"> The implementation. </param>
        void Register<TDependency>(TDependency implementation);

        /// <summary>
        /// Resolves the dependency requested returning an instance of a class that implements the
        /// specified interface, based on the current configuration.
        /// </summary>
        /// <typeparam name="TDependency"> The type of the dependency. </typeparam>
        /// <returns></returns>
        TDependency Resolve<TDependency>();

        /// <summary>
        /// Resolves the dependency requested returning an instance of a class that implements the
        /// specified interface, based on the current configuration.
        /// </summary>
        /// <param name="dependencyType"> Type of the dependency. </param>
        /// <returns></returns>
        object Resolve(Type dependencyType);
    }
}