using System.Text.Json.Serialization;

namespace Paradigm.AutomatedTesting.TestCoverage.Model;

public record TestSuiteList
{
    [JsonConstructor]
    public TestSuiteList(List<TestSuite> testSuites)
    {
        ModuleList = testSuites;
    }

    public List<TestSuite> ModuleList { get; }
}
