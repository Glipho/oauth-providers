namespace Glipho.OAuth.Providers.Ninject
{
    using global::Ninject.Modules;

    /// <summary>
    /// Default bindings for the <see cref="Glipho.OAuth.Providers"/> project.
    /// </summary>
    public class DefaultBindings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel. 
        /// </summary>
        public override void Load()
        {
            this.Bind<IConsumers>().To<Consumers>();
        }
    }
}
