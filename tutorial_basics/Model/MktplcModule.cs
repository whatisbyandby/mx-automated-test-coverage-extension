
using System.Text.Json.Serialization;


namespace MyCompany.MyProject.MendixExtension.Model;

public record MktplcModule
{
    [JsonConstructor]
    public MktplcModule(string id, string name, string appStoreVersion, int appStorePackageld)
    {
        Id = id;
        Name = name;
        AppStoreVersion = appStoreVersion;
        AppStorePackageld = appStorePackageld;
    }

    public MktplcModule(string name, string appStoreVersion, int appStorePackageld)
        : this(Guid.NewGuid().ToString(), name, appStoreVersion, appStorePackageld)
    {
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string AppStoreVersion { get; set; }
    public int AppStorePackageld { get; set; }
}
