using System.Text.Json.Serialization;

namespace MyCompany.MyProject.MendixExtension.Model;

public record MktplcModuleList
{
    [JsonConstructor]
    public MktplcModuleList(List<MktplcModule> mktplcModules)
    {
        ModuleList = mktplcModules;
    }

    public List<MktplcModule> ModuleList { get; }
}
