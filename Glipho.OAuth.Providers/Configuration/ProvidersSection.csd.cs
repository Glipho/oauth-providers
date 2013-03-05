//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Glipho.OAuth.Providers.Configuration
{
    
    
    /// <summary>
    /// The ServiceProvider Configuration Section.
    /// </summary>
    public partial class ServiceProvider : global::System.Configuration.ConfigurationSection
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region TokenProvider Property
        /// <summary>
        /// The XML name of the <see cref="TokenProvider"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string TokenProviderPropertyName = "tokenProvider";
        
        /// <summary>
        /// Gets or sets the TokenProvider.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The TokenProvider.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Providers.Configuration.ServiceProvider.TokenProviderPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false, DefaultValue=false)]
        public virtual bool TokenProvider
        {
            get
            {
                return ((bool)(base[global::Glipho.OAuth.Providers.Configuration.ServiceProvider.TokenProviderPropertyName]));
            }
            set
            {
                base[global::Glipho.OAuth.Providers.Configuration.ServiceProvider.TokenProviderPropertyName] = value;
            }
        }
        #endregion
        
        #region Endpoints Property
        /// <summary>
        /// The XML name of the <see cref="Endpoints"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string EndpointsPropertyName = "endpoints";
        
        /// <summary>
        /// Gets or sets the Endpoints.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The Endpoints.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Providers.Configuration.ServiceProvider.EndpointsPropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Glipho.OAuth.Providers.Configuration.Endpoints Endpoints
        {
            get
            {
                return ((global::Glipho.OAuth.Providers.Configuration.Endpoints)(base[global::Glipho.OAuth.Providers.Configuration.ServiceProvider.EndpointsPropertyName]));
            }
            set
            {
                base[global::Glipho.OAuth.Providers.Configuration.ServiceProvider.EndpointsPropertyName] = value;
            }
        }
        #endregion
        
        #region Nonces Property
        /// <summary>
        /// The XML name of the <see cref="Nonces"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string NoncesPropertyName = "nonces";
        
        /// <summary>
        /// Gets or sets the Nonces.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The Nonces.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Providers.Configuration.ServiceProvider.NoncesPropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Glipho.OAuth.Providers.Configuration.Nonces Nonces
        {
            get
            {
                return ((global::Glipho.OAuth.Providers.Configuration.Nonces)(base[global::Glipho.OAuth.Providers.Configuration.ServiceProvider.NoncesPropertyName]));
            }
            set
            {
                base[global::Glipho.OAuth.Providers.Configuration.ServiceProvider.NoncesPropertyName] = value;
            }
        }
        #endregion
        
        #region RoleProvider Property
        /// <summary>
        /// The XML name of the <see cref="RoleProvider"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string RoleProviderPropertyName = "roleProvider";
        
        /// <summary>
        /// Gets or sets the RoleProvider.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The RoleProvider.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Providers.Configuration.ServiceProvider.RoleProviderPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Glipho.OAuth.Providers.Configuration.RoleProvider RoleProvider
        {
            get
            {
                return ((global::Glipho.OAuth.Providers.Configuration.RoleProvider)(base[global::Glipho.OAuth.Providers.Configuration.ServiceProvider.RoleProviderPropertyName]));
            }
            set
            {
                base[global::Glipho.OAuth.Providers.Configuration.ServiceProvider.RoleProviderPropertyName] = value;
            }
        }
        #endregion
    }
}
namespace Glipho.OAuth.Providers.Configuration
{
    
    
    /// <summary>
    /// The Endpoint Configuration Element.
    /// </summary>
    public partial class Endpoint : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region Url Property
        /// <summary>
        /// The XML name of the <see cref="Url"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string UrlPropertyName = "url";
        
        /// <summary>
        /// Gets or sets the Url.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The Url.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Providers.Configuration.Endpoint.UrlPropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false)]
        public virtual string Url
        {
            get
            {
                return ((string)(base[global::Glipho.OAuth.Providers.Configuration.Endpoint.UrlPropertyName]));
            }
            set
            {
                base[global::Glipho.OAuth.Providers.Configuration.Endpoint.UrlPropertyName] = value;
            }
        }
        #endregion
    }
}
namespace Glipho.OAuth.Providers.Configuration
{
    
    
    /// <summary>
    /// The Endpoints Configuration Element.
    /// </summary>
    public partial class Endpoints : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region AccessToken Property
        /// <summary>
        /// The XML name of the <see cref="AccessToken"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string AccessTokenPropertyName = "accessToken";
        
        /// <summary>
        /// Gets or sets the AccessToken.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The AccessToken.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Providers.Configuration.Endpoints.AccessTokenPropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Glipho.OAuth.Providers.Configuration.Endpoint AccessToken
        {
            get
            {
                return ((global::Glipho.OAuth.Providers.Configuration.Endpoint)(base[global::Glipho.OAuth.Providers.Configuration.Endpoints.AccessTokenPropertyName]));
            }
            set
            {
                base[global::Glipho.OAuth.Providers.Configuration.Endpoints.AccessTokenPropertyName] = value;
            }
        }
        #endregion
        
        #region RequestToken Property
        /// <summary>
        /// The XML name of the <see cref="RequestToken"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string RequestTokenPropertyName = "requestToken";
        
        /// <summary>
        /// Gets or sets the RequestToken.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The RequestToken.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Providers.Configuration.Endpoints.RequestTokenPropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Glipho.OAuth.Providers.Configuration.Endpoint RequestToken
        {
            get
            {
                return ((global::Glipho.OAuth.Providers.Configuration.Endpoint)(base[global::Glipho.OAuth.Providers.Configuration.Endpoints.RequestTokenPropertyName]));
            }
            set
            {
                base[global::Glipho.OAuth.Providers.Configuration.Endpoints.RequestTokenPropertyName] = value;
            }
        }
        #endregion
        
        #region UserAuthorisation Property
        /// <summary>
        /// The XML name of the <see cref="UserAuthorisation"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string UserAuthorisationPropertyName = "userAuthorisation";
        
        /// <summary>
        /// Gets or sets the UserAuthorisation.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The UserAuthorisation.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Providers.Configuration.Endpoints.UserAuthorisationPropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Glipho.OAuth.Providers.Configuration.Endpoint UserAuthorisation
        {
            get
            {
                return ((global::Glipho.OAuth.Providers.Configuration.Endpoint)(base[global::Glipho.OAuth.Providers.Configuration.Endpoints.UserAuthorisationPropertyName]));
            }
            set
            {
                base[global::Glipho.OAuth.Providers.Configuration.Endpoints.UserAuthorisationPropertyName] = value;
            }
        }
        #endregion
    }
}
namespace Glipho.OAuth.Providers.Configuration
{
    
    
    /// <summary>
    /// The Nonces Configuration Element.
    /// </summary>
    public partial class Nonces : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region ClearingInterval Property
        /// <summary>
        /// The XML name of the <see cref="ClearingInterval"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string ClearingIntervalPropertyName = "clearingInterval";
        
        /// <summary>
        /// Gets or sets the ClearingInterval.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The ClearingInterval.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Providers.Configuration.Nonces.ClearingIntervalPropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false, DefaultValue="00:10:00")]
        public virtual global::System.TimeSpan ClearingInterval
        {
            get
            {
                return ((global::System.TimeSpan)(base[global::Glipho.OAuth.Providers.Configuration.Nonces.ClearingIntervalPropertyName]));
            }
            set
            {
                base[global::Glipho.OAuth.Providers.Configuration.Nonces.ClearingIntervalPropertyName] = value;
            }
        }
        #endregion
    }
}
namespace Glipho.OAuth.Providers.Configuration
{
    
    
    /// <summary>
    /// The RoleProvider Configuration Element.
    /// </summary>
    public partial class RoleProvider : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region EnableCustomRoleProvider Property
        /// <summary>
        /// The XML name of the <see cref="EnableCustomRoleProvider"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string EnableCustomRoleProviderPropertyName = "enableCustomRoleProvider";
        
        /// <summary>
        /// Gets the EnableCustomRoleProvider.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The EnableCustomRoleProvider.")]
        [global::System.ComponentModel.ReadOnlyAttribute(true)]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Providers.Configuration.RoleProvider.EnableCustomRoleProviderPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false, DefaultValue=false)]
        public virtual bool EnableCustomRoleProvider
        {
            get
            {
                return ((bool)(base[global::Glipho.OAuth.Providers.Configuration.RoleProvider.EnableCustomRoleProviderPropertyName]));
            }
        }
        #endregion
    }
}
