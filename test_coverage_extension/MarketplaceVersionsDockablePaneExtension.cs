
using System.ComponentModel.Composition;
using Mendix.StudioPro.ExtensionsAPI.Services;
using Mendix.StudioPro.ExtensionsAPI.UI.DockablePane;

namespace Paradigm.AutomatedTesting.TestCoverage;


[Export(typeof(DockablePaneExtension))]
public class TestCoverageDockablePaneExtension : DockablePaneExtension
{
    private readonly ILogService _logService;
    public const string PaneId = "CoverageReport";
    public const string PaneTitle = "Coverage Report";

    [ImportingConstructor]
    public TestCoverageDockablePaneExtension(ILogService logService)
    {
        _logService = logService;
    }

    public override string Id => PaneId;

    public override DockablePaneViewModelBase Open()
    {
        return new TestCoverageDockablePaneViewModel(WebServerBaseUrl, () => CurrentApp, _logService) { Title = PaneTitle };
    }

}
