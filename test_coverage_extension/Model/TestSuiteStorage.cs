using Mendix.StudioPro.ExtensionsAPI.Model;
using Mendix.StudioPro.ExtensionsAPI.Services;


namespace Paradigm.AutomatedTesting.TestCoverage.Model;


public class TestSuiteStorage
{
    private readonly ILogService _logService;
    private readonly string _testSuiteFilePath;
    private List<TestSuite> _testSuites;

    public TestSuiteStorage(IModel currentApp, ILogService logService)
    {
        _logService = logService;
        _testSuiteFilePath = Path.Join(currentApp.Root.DirectoryPath, "testSuites.json");
        _testSuites = currentApp.Root.GetModules()
                                            .Where(module => !module.FromAppStore)
                                            .Select(module => new TestSuite(module.Name, module.AppStoreVersion, module.AppStorePackageId))
                                            .OrderBy(module => module.Name)
                                            .ToList();

    }

    
    public TestSuiteList LoadTestSuiteList()
    {        
        return new TestSuiteList(_testSuites);
    }

  

}
