
using System.ComponentModel.Composition;
using Mendix.StudioPro.ExtensionsAPI.Services;
using Mendix.StudioPro.ExtensionsAPI.UI.DockablePane;

namespace MyCompany.MyProject.MendixExtension;


[Export(typeof(DockablePaneExtension))]
public class MarketplaceVersionsDockablePaneExtension : DockablePaneExtension
{
    private readonly ILogService _logService;
    public const string PaneId = "MarketplaceVersions";
    public const string PaneTitle = "Marketplace Versions";

    [ImportingConstructor]
    public MarketplaceVersionsDockablePaneExtension(ILogService logService)
    {
        _logService = logService;
    }

    public override string Id => PaneId;

    public override DockablePaneViewModelBase Open()
    {
        return new MarketplaceVersionsDockablePaneViewModel(WebServerBaseUrl, () => CurrentApp, _logService) { Title = PaneTitle };
    }

}
