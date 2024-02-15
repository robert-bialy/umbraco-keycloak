using AspNet.Security.OAuth.Keycloak;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Extensions;
using Umbraco.KeycloakShowcase.Web.Configuration;

namespace Umbraco.KeycloakShowcase.Web.Extensions;

public static class KeycloakAuthenticationExtension
{
    public static IUmbracoBuilder AddBackOfficeKeycloakAuthentication(this IUmbracoBuilder builder)
    {
        var configuration = new KeycloakConfiguration(builder.Config);
        builder.AddBackOfficeExternalLogins(logins =>
        {
            logins.AddBackOfficeLogin(
                backOfficeAuthenticationBuilder  =>
                {
                    var schemeName = backOfficeAuthenticationBuilder.SchemeForBackOffice(KeycloakMemberExternalLoginProviderOptions.SchemeName);
                    ArgumentNullException.ThrowIfNull(schemeName);
                    backOfficeAuthenticationBuilder.AddKeycloak(
                        schemeName,
                        options =>
                        {
                            options.BaseAddress = new Uri(configuration.BaseAddress);
                            options.ClientId = configuration.ClientId;
                            options.ClientSecret = configuration.ClientSecret;
                            options.AccessType = KeycloakAuthenticationAccessType.Confidential;
                            options.Realm = configuration.Realm;
                            options.Version = new Version(configuration.Version);
                        });
                });
        });
        return builder;
    }
}