using System.ComponentModel.Composition;
using Mendix.StudioPro.ExtensionsAPI.UI.Menu;
using Mendix.StudioPro.ExtensionsAPI.UI.Services;

namespace Paradigm.AutomatedTesting.TestCoverage;

[method: ImportingConstructor]
[Export(typeof(MenuExtension))]
public class ParadigmMenuExtension(IDockingWindowService dockingWindowService) : MenuExtension
{
    public override IEnumerable<MenuViewModel> GetMenus()
    {
        yield return new MenuViewModel("Test Coverage", () => dockingWindowService.OpenPane(TestCoverageDockablePaneExtension.PaneId));

    }
}