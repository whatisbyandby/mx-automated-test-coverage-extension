
using Mendix.StudioPro.ExtensionsAPI.UI.DockablePane;
using Mendix.StudioPro.ExtensionsAPI.UI.WebView;
using Mendix.StudioPro.ExtensionsAPI.Model;
using Mendix.StudioPro.ExtensionsAPI.Services;



namespace MyCompany.MyProject.MendixExtension;


public class MarketplaceVersionsDockablePaneViewModel : WebViewDockablePaneViewModel
{
    private readonly Uri _baseUri;
    private readonly Func<IModel?> _getCurrentApp;
    private readonly ILogService _logService;

    public MarketplaceVersionsDockablePaneViewModel(Uri baseUri, Func<IModel?> getCurrentApp, ILogService logService)
    {
        _baseUri = baseUri;
        _getCurrentApp = getCurrentApp;
        _logService = logService;
    }

    public override void InitWebView(IWebView webView)
    {
        webView.Address = new Uri(_baseUri, "index");

        webView.MessageReceived += (_, args) =>
        {
            var currentApp = _getCurrentApp();
            if (currentApp == null) return;

            // This is used to load the web dev tool for the web page loaded into the panel.
            // Uncomment in the index.htlm file to activate
            if (args.Message == "ShowDevToolsNow")
            {
                webView.ShowDevTools();
            }

            if (args.Message == "ReloadModules")
            {
                webView.Reload();               
            }
        };

        
    }

  





}
