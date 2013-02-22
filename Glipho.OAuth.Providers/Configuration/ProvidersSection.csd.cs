//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Glipho.OAuth.Configuration
{
    
    
    /// <summary>
    /// The ServiceProvider Configuration Section.
    /// </summary>
    public partial class ServiceProvider : global::System.Configuration.ConfigurationSection
    {
        
        #region Singleton Instance
        /// <summary>
        /// The XML name of the ServiceProvider Configuration Section.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string ServiceProviderSectionName = "serviceProvider";
        
        /// <summary>
        /// Gets the ServiceProvider instance.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public static global::Glipho.OAuth.Configuration.ServiceProvider Instance
        {
            get
            {
                return ((global::Glipho.OAuth.Configuration.ServiceProvider)(global::System.Configuration.ConfigurationManager.GetSection(global::Glipho.OAuth.Configuration.ServiceProvider.ServiceProviderSectionName)));
            }
        }
        #endregion
        
        #region Xmlns Property
        /// <summary>
        /// The XML name of the <see cref="Xmlns"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string XmlnsPropertyName = "xmlns";
        
        /// <summary>
        /// Gets the XML namespace of this Configuration Section.
        /// </summary>
        /// <remarks>
        /// This property makes sure that if the configuration file contains the XML namespace,
        /// the parser doesn't throw an exception because it encounters the unknown "xmlns" attribute.
        /// </remarks>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Configuration.ServiceProvider.XmlnsPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public string Xmlns
        {
            get
            {
                return ((string)(base[global::Glipho.OAuth.Configuration.ServiceProvider.XmlnsPropertyName]));
            }
        }
        #endregion
        
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
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Configuration.ServiceProvider.TokenProviderPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false, DefaultValue=false)]
        public virtual bool TokenProvider
        {
            get
            {
                return ((bool)(base[global::Glipho.OAuth.Configuration.ServiceProvider.TokenProviderPropertyName]));
            }
            set
            {
                base[global::Glipho.OAuth.Configuration.ServiceProvider.TokenProviderPropertyName] = value;
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
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Configuration.ServiceProvider.EndpointsPropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Glipho.OAuth.Configuration.Endpoints Endpoints
        {
            get
            {
                return ((global::Glipho.OAuth.Configuration.Endpoints)(base[global::Glipho.OAuth.Configuration.ServiceProvider.EndpointsPropertyName]));
            }
            set
            {
                base[global::Glipho.OAuth.Configuration.ServiceProvider.EndpointsPropertyName] = value;
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
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Configuration.ServiceProvider.NoncesPropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Glipho.OAuth.Configuration.Nonces Nonces
        {
            get
            {
                return ((global::Glipho.OAuth.Configuration.Nonces)(base[global::Glipho.OAuth.Configuration.ServiceProvider.NoncesPropertyName]));
            }
            set
            {
                base[global::Glipho.OAuth.Configuration.ServiceProvider.NoncesPropertyName] = value;
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
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Configuration.ServiceProvider.RoleProviderPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Glipho.OAuth.Configuration.RoleProvider RoleProvider
        {
            get
            {
                return ((global::Glipho.OAuth.Configuration.RoleProvider)(base[global::Glipho.OAuth.Configuration.ServiceProvider.RoleProviderPropertyName]));
            }
            set
            {
                base[global::Glipho.OAuth.Configuration.ServiceProvider.RoleProviderPropertyName] = value;
            }
        }
        #endregion
    }
}
namespace Glipho.OAuth.Configuration
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
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Configuration.Endpoint.UrlPropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false)]
        public virtual string Url
        {
            get
            {
                return ((string)(base[global::Glipho.OAuth.Configuration.Endpoint.UrlPropertyName]));
            }
            set
            {
                base[global::Glipho.OAuth.Configuration.Endpoint.UrlPropertyName] = value;
            }
        }
        #endregion
    }
}
namespace Glipho.OAuth.Configuration
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
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Configuration.Endpoints.AccessTokenPropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Glipho.OAuth.Configuration.Endpoint AccessToken
        {
            get
            {
                return ((global::Glipho.OAuth.Configuration.Endpoint)(base[global::Glipho.OAuth.Configuration.Endpoints.AccessTokenPropertyName]));
            }
            set
            {
                base[global::Glipho.OAuth.Configuration.Endpoints.AccessTokenPropertyName] = value;
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
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Configuration.Endpoints.RequestTokenPropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Glipho.OAuth.Configuration.Endpoint RequestToken
        {
            get
            {
                return ((global::Glipho.OAuth.Configuration.Endpoint)(base[global::Glipho.OAuth.Configuration.Endpoints.RequestTokenPropertyName]));
            }
            set
            {
                base[global::Glipho.OAuth.Configuration.Endpoints.RequestTokenPropertyName] = value;
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
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Configuration.Endpoints.UserAuthorisationPropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Glipho.OAuth.Configuration.Endpoint UserAuthorisation
        {
            get
            {
                return ((global::Glipho.OAuth.Configuration.Endpoint)(base[global::Glipho.OAuth.Configuration.Endpoints.UserAuthorisationPropertyName]));
            }
            set
            {
                base[global::Glipho.OAuth.Configuration.Endpoints.UserAuthorisationPropertyName] = value;
            }
        }
        #endregion
    }
}
namespace Glipho.OAuth.Configuration
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
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Configuration.Nonces.ClearingIntervalPropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false, DefaultValue="00:10:00")]
        public virtual global::System.TimeSpan ClearingInterval
        {
            get
            {
                return ((global::System.TimeSpan)(base[global::Glipho.OAuth.Configuration.Nonces.ClearingIntervalPropertyName]));
            }
            set
            {
                base[global::Glipho.OAuth.Configuration.Nonces.ClearingIntervalPropertyName] = value;
            }
        }
        #endregion
    }
}
namespace Glipho.OAuth.Configuration
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
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Glipho.OAuth.Configuration.RoleProvider.EnableCustomRoleProviderPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false, DefaultValue=false)]
        public virtual bool EnableCustomRoleProvider
        {
            get
            {
                return ((bool)(base[global::Glipho.OAuth.Configuration.RoleProvider.EnableCustomRoleProviderPropertyName]));
            }
        }
        #endregion
    }
}
