
using System.Text.Json.Serialization;


namespace Paradigm.AutomatedTesting.TestCoverage.Model;

public record TestSuite
{
    [JsonConstructor]
    public TestSuite(string id, string name, string appStoreVersion, int appStorePackageld)
    {
        Id = id;
        Name = name;
        AppStoreVersion = appStoreVersion;
        AppStorePackageld = appStorePackageld;
    }

    public TestSuite(string name, string appStoreVersion, int appStorePackageld)
        : this(Guid.NewGuid().ToString(), name, appStoreVersion, appStorePackageld)
    {
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string AppStoreVersion { get; set; }
    public int AppStorePackageld { get; set; }
}
