namespace Glipho.OAuth.Providers.Ninject
{
    using global::Ninject.Modules;

    /// <summary>
    /// Default MongoDB bindings for the <see cref="Glipho.OAuth.Providers"/> project.
    /// </summary>
    public class DefaultMongoBindings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel. 
        /// </summary>
        public override void Load()
        {
            this.Bind<Database.IConsumers>().To<Database.Mongo.Consumers>();
            this.Bind<Database.IIssuedTokens>().To<Database.Mongo.IssuedTokens>();
            this.Bind<Database.INonces>().To<Database.Mongo.Nonces>();
        }
    }
}
