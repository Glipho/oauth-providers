﻿<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="c1d9cc96-e196-4f9e-aa15-1c495fd4ab6d" namespace="Glipho.OAuth.Providers.Configuration" xmlSchemaNamespace="urn:Glipho.OAuth.Configuration" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSectionGroup name="glipho.oAuth">
      <configurationSectionProperties>
        <configurationSectionProperty>
          <containedConfigurationSection>
            <configurationSectionMoniker name="/c1d9cc96-e196-4f9e-aa15-1c495fd4ab6d/ServiceProvider" />
          </containedConfigurationSection>
        </configurationSectionProperty>
      </configurationSectionProperties>
    </configurationSectionGroup>
    <configurationSection name="ServiceProvider" codeGenOptions="None" xmlSectionName="serviceProvider">
      <attributeProperties>
        <attributeProperty name="TokenProvider" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="tokenProvider" isReadOnly="false" defaultValue="false">
          <type>
            <externalTypeMoniker name="/c1d9cc96-e196-4f9e-aa15-1c495fd4ab6d/Boolean" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="Endpoints" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="endpoints" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/c1d9cc96-e196-4f9e-aa15-1c495fd4ab6d/Endpoints" />
          </type>
        </elementProperty>
        <elementProperty name="Nonces" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="nonces" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/c1d9cc96-e196-4f9e-aa15-1c495fd4ab6d/Nonces" />
          </type>
        </elementProperty>
        <elementProperty name="RoleProvider" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="roleProvider" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/c1d9cc96-e196-4f9e-aa15-1c495fd4ab6d/RoleProvider" />
          </type>
        </elementProperty>
        <elementProperty name="ExemptUrls" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="exemptUrls" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/c1d9cc96-e196-4f9e-aa15-1c495fd4ab6d/ExemptUrls" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElement name="Endpoint">
      <attributeProperties>
        <attributeProperty name="Url" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="url" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/c1d9cc96-e196-4f9e-aa15-1c495fd4ab6d/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="Endpoints">
      <elementProperties>
        <elementProperty name="AccessToken" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="accessToken" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/c1d9cc96-e196-4f9e-aa15-1c495fd4ab6d/Endpoint" />
          </type>
        </elementProperty>
        <elementProperty name="RequestToken" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="requestToken" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/c1d9cc96-e196-4f9e-aa15-1c495fd4ab6d/Endpoint" />
          </type>
        </elementProperty>
        <elementProperty name="UserAuthorisation" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="userAuthorisation" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/c1d9cc96-e196-4f9e-aa15-1c495fd4ab6d/Endpoint" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="Nonces">
      <attributeProperties>
        <attributeProperty name="ClearingInterval" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="clearingInterval" isReadOnly="false" defaultValue="&quot;00:10:00&quot;">
          <type>
            <externalTypeMoniker name="/c1d9cc96-e196-4f9e-aa15-1c495fd4ab6d/TimeSpan" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="RoleProvider">
      <attributeProperties>
        <attributeProperty name="EnableCustomRoleProvider" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="enableCustomRoleProvider" isReadOnly="true" defaultValue="false">
          <type>
            <externalTypeMoniker name="/c1d9cc96-e196-4f9e-aa15-1c495fd4ab6d/Boolean" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElementCollection name="ExemptUrls" collectionType="AddRemoveClearMap" xmlItemName="exemptUrl" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/c1d9cc96-e196-4f9e-aa15-1c495fd4ab6d/ExemptUrl" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="ExemptUrl">
      <attributeProperties>
        <attributeProperty name="Url" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="url" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/c1d9cc96-e196-4f9e-aa15-1c495fd4ab6d/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>