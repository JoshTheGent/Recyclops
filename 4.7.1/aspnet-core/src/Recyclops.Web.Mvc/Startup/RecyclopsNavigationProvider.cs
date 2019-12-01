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
                        PageNames.Order,
                        L("Order"),
                        url: "Order",
                        icon: "home",
                        requiresAuthentication: true
                    )
                ).AddItem( // Menu items below is just for demonstration!
                    new MenuItemDefinition(
                        "Management",
                        L("Management"),
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
                            PageNames.PlasticSpool,
                            L("PlasticSpool"),
                            url: "PlasticSpool",
                            icon: "business"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.PrintableObject,
                            L("PrintableObject"),
                            url: "PrintableObject",
                            icon: "business"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.LocationSource,
                            L("LocationSources"),
                            url: "LocationSource",
                            icon: "business"

                        ))).AddItem( // Menu items below is just for demonstration!
                    new MenuItemDefinition(
                        "Admin",
                        L("Admin"),
                        icon: "menu"
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
