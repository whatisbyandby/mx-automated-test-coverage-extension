using Mendix.StudioPro.ExtensionsAPI.Model;
using Mendix.StudioPro.ExtensionsAPI.Services;


namespace MyCompany.MyProject.MendixExtension.Model;


public class MktplcModuleVersionStorage
{
    private readonly ILogService _logService;
    private readonly string _mktplcModuleVersionFilePath;
    private List<MktplcModule> _marketplaceModules;

    public MktplcModuleVersionStorage(IModel currentApp, ILogService logService)
    {
        _logService = logService;
        _mktplcModuleVersionFilePath = Path.Join(currentApp.Root.DirectoryPath, "marketplace-module-version-list.json");
         _marketplaceModules = currentApp.Root.GetModules()
                                            .Where(module => module.FromAppStore)
                                            .Select(module => new MktplcModule(module.Name, module.AppStoreVersion, module.AppStorePackageId))
                                            .OrderBy(module => module.Name)
                                            .ToList();

    }

    
    public MktplcModuleList LoadMarketplaceModuleList()
    {        
        return new MktplcModuleList(_marketplaceModules);
    }

  

}
