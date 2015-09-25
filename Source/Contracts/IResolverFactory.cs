namespace Contracts
{
    /// <summary>
    /// Factory class for the <see cref="IResolver" /> interface. 
    /// </summary>
    public interface IResolverFactory
    {
        /// <summary>
        /// Creates a new instance of a class that implements <see cref="IResolver" />. 
        /// </summary>
        IResolver Build();
    }
}