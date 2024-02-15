# Umbraco.Keycloak Showcase
The project shows how to add Keycloak as external identity provider for Umbraco backoffice.

It includes pieces of code from Umbraco's official help documents which you can find [here](https://docs.umbraco.com/umbraco-cms/reference/security/external-login-providers).

## Requirements
- Any IDE (Visual Studio / Rider)
- .NET 8.0

## Important notes
The repository utilizes the NuGet package AspNet.Security.OAuth.Keycloak for connecting to Keycloak. It's extremely important to specify the Keycloak version in the configuration.

Starting with version 18.0, Keycloak has shifted to a different endpoint for authorization. This change caused me a lot of headaches, so please be aware of it.

## Usage
To use this repository, after you setup a project, you need to populate configuration with your Keycloak details. 

Please fill appsettings.json with your Keycloak details:

    "Keycloak": {
        "BaseAddress": "{keycloak-address}",
        "ClientId": "{client-id}",
        "ClientSecret": "{secret}",
        "Realm": "{your-realm}",
        "Version": "{keycloak-version}"
    }