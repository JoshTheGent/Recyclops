using Abp.Application.Navigation;
using Abp.Localization;
using Recyclops.Authorization;

namespace Recyclops.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class RecyclopsNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "About",
                        icon: "info"
                    )
                ).AddItem( // Menu items below is just for demonstration!
                    new MenuItemDefinition(
                        "Admin",
                        L("Admin"),
                        icon: "menu"
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Plastic,
                            L("Plastic"),
                            url: "Plastic",
                            icon: "business"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.LocationSource,
                            L("LocationSources"),
                            url: "LocationSource",
                            icon: "business"

                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Tenants,
                            L("Tenants"),
                            url: "Tenants",
                            icon: "people",
                            requiredPermissionName: PermissionNames.Pages_Tenants
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Users,
                            L("Users"),
                            url: "Users",
                            icon: "people",
                            requiredPermissionName: PermissionNames.Pages_Users
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Roles,
                            L("Roles"),
                            url: "Roles",
                            icon: "local_offer",
                            requiredPermissionName: PermissionNames.Pages_Roles
                        )
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, RecyclopsConsts.LocalizationSourceName);
        }
    }
}
