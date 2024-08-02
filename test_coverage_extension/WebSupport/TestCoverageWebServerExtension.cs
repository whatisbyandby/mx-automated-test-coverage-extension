using System.ComponentModel.Composition;
using System.Net;
using System.Text.Json;
using Mendix.StudioPro.ExtensionsAPI.Services;
using Mendix.StudioPro.ExtensionsAPI.UI.WebServer;
using Paradigm.AutomatedTesting.TestCoverage.Model;


namespace Paradigm.AutomatedTesting.TestCoverage.WebSupport;


[Export(typeof(WebServerExtension))]
public class TestCoverageWebServerExtension : WebServerExtension
{
    private readonly IExtensionFileService _extensionFileService;
    private readonly ILogService _logService;

    [ImportingConstructor]
    public TestCoverageWebServerExtension(IExtensionFileService extensionFileService, ILogService logService)
    {
        _extensionFileService = extensionFileService;
        _logService = logService;
    }

    public override void InitializeWebServer(IWebServer webServer)
    {
        webServer.AddRoute("index", ServeIndex);
        webServer.AddRoute("main.js", ServeMainJs);
        webServer.AddRoute("test-suites", ServeTestSuites);
    }

    private async Task ServeIndex(HttpListenerRequest request, HttpListenerResponse response, CancellationToken ct)
    {
        var indexFilePath = _extensionFileService.ResolvePath("wwwroot", "index.html");
        await response.SendFileAndClose("text/html", indexFilePath, ct);
    }

    private async Task ServeMainJs(HttpListenerRequest request, HttpListenerResponse response, CancellationToken ct)
    {
        var indexFilePath = _extensionFileService.ResolvePath("wwwroot", "main.js");
        await response.SendFileAndClose("text/javascript", indexFilePath, ct);
    }

    private async Task ServeTestSuites(HttpListenerRequest request, HttpListenerResponse response, CancellationToken ct)
    {
        if (CurrentApp == null)
        {
            response.SendNoBodyAndClose(404);
            return;
        }

        var testSuiteList = new TestSuiteStorage(CurrentApp, _logService).LoadTestSuiteList();
        var jsonStream = new MemoryStream();
        await JsonSerializer.SerializeAsync(jsonStream, testSuiteList, cancellationToken: ct);

        response.SendJsonAndClose(jsonStream);
    }
}
