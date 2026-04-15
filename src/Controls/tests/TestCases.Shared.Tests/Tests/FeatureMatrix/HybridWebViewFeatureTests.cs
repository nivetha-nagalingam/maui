using Microsoft.Maui.Controls.Shapes;
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests;

public class HybridWebViewFeatureTests : _GalleryUITest
{
	public const string HybridWebViewFeatureMatrix = "HybridWebView Feature Matrix";

	public override string GalleryPageName => HybridWebViewFeatureMatrix;


	public HybridWebViewFeatureTests(TestDevice device)
		: base(device)
	{
	}

	[Test, Order(1)]
	[Category(UITestCategories.WebView)]
	public void VerifyHybridWebView_DefaultValues()
	{
		App.WaitForElement("HybridRootLabel");
		var hybridRootLabel = App.FindElement("HybridRootLabel").GetText();
		Assert.That(hybridRootLabel, Is.EqualTo("HybridWebView1"), "Hybrid Root label should be displayed correctly.");
		var hybridDefaultFile = App.FindElement("DefaultFileLabel").GetText();
		Assert.That(hybridDefaultFile, Is.EqualTo("index.html"), "Default file should be index.Html.");
	}

	[Test, Order(2)]
	[Category(UITestCategories.WebView)]
	public void VerifyHybridWebView_SameHybridRootWithDifferentDefaultFile()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");
		App.WaitForElement("HybridWebView1Button");
		App.Tap("HybridWebView1Button");
		App.WaitForElement("ImageHtmlButton");
		App.Tap("ImageHtmlButton");
		App.WaitForElement("HybridRootLabel");
		var hybridRootLabel = App.FindElement("HybridRootLabel").GetText();
		Assert.That(hybridRootLabel, Is.EqualTo("HybridWebView1"), "Hybrid Root label should be displayed correctly.");
		var hybridDefaultFile = App.FindElement("DefaultFileLabel").GetText();
		Assert.That(hybridDefaultFile, Is.EqualTo("image.html"), "Default file should be index.Html.");
	}

	[Test, Order(3)]
	[Category(UITestCategories.WebView)]
	public void VerifyHybridWebView_SameDefaultFileWithDifferentHybridRoot()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");
		App.WaitForElement("HybridWebView2Button");
		App.Tap("HybridWebView2Button");
		App.WaitForElement("HybridRootLabel");
		var hybridRootLabel = App.FindElement("HybridRootLabel").GetText();
		Assert.That(hybridRootLabel, Is.EqualTo("HybridWebView2"), "Hybrid Root label should be displayed correctly.");
		var hybridDefaultFile = App.FindElement("DefaultFileLabel").GetText();
		Assert.That(hybridDefaultFile, Is.EqualTo("index.html"), "Default file should be index.Html.");
	}

#if TEST_FAILS_ON_CATALYST // Issue Link: https://github.com/dotnet/maui/issues/32721

	[Test, Order(4)]
	[Category(UITestCategories.WebView)]
	public void VerifyHybridWebView_EvaluateJavaScriptWithDifferentHybridRoot()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");
		App.WaitForElement("HybridWebView1Button");
		App.Tap("HybridWebView1Button");
		Thread.Sleep(2000); // Allow time for the UI to update
		App.WaitForElement("EvaluateJavaScriptButton");
		App.Tap("EvaluateJavaScriptButton");
		App.WaitForElement("StatusLabel");
		var result = App.FindElement("StatusLabel").GetText();
		Assert.That(result, Is.EqualTo("EvaluateJavaScriptAsync Result: HybridWebView1"), "JavaScript evaluation should return the correct title for HybridWebview1.");

		App.WaitForElement("HybridWebView2Button");
		App.Tap("HybridWebView2Button");
		Thread.Sleep(2000); // Allow time for the UI to update
		App.WaitForElement("EvaluateJavaScriptButton");
		App.Tap("EvaluateJavaScriptButton");
		App.WaitForElement("StatusLabel");
		var result2 = App.FindElement("StatusLabel").GetText();
		Assert.That(result2, Is.EqualTo("EvaluateJavaScriptAsync Result: HybridWebView2"), "JavaScript evaluation should return the correct title for HybridWebview2.");
	}

	[Test, Order(5)]
	[Category(UITestCategories.WebView)]
	public void VerifyHybridWebView_EvaluateJavaScriptWithDifferentDefaultFile()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");
		App.WaitForElement("HybridWebView1Button");
		App.Tap("HybridWebView1Button");
		App.WaitForElement("ImageHtmlButton");
		App.Tap("ImageHtmlButton");
		Thread.Sleep(2000); // Allow time for the UI to update
		App.WaitForElement("EvaluateJavaScriptButton");
		App.Tap("EvaluateJavaScriptButton");
		App.WaitForElement("StatusLabel");
		var result = App.FindElement("StatusLabel").GetText();
		Assert.That(result, Is.EqualTo("EvaluateJavaScriptAsync Result: HybridWebView Image Page"));

		App.WaitForElement("NavigationHtmlButton");
		App.Tap("NavigationHtmlButton");
		Thread.Sleep(2000); // Allow time for the UI to update
		App.WaitForElement("EvaluateJavaScriptButton");
		App.Tap("EvaluateJavaScriptButton");
		App.WaitForElement("StatusLabel");
		var result2 = App.FindElement("StatusLabel").GetText();
		Assert.That(result2, Is.EqualTo("EvaluateJavaScriptAsync Result: HybridWebView Navigation Page"));
	}

	[Test, Order(9)]
	[Category(UITestCategories.WebView)]
	public void VerifyHybridWebViewWithShadow()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");
		App.WaitForElement("ShadowCheckBox");
		App.Tap("ShadowCheckBox");
		Thread.Sleep(2000); // Allow time for the UI to update
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}
#endif

	[Test, Order(8)]
	[Category(UITestCategories.WebView)]
	public void VerifyHybridWebViewWithIsVisibleFalse()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");
		App.WaitForElement("IsVisibleCheckBox");
		App.Tap("IsVisibleCheckBox");
		App.WaitForNoElement("HybridWebViewControl");
	}

#if TEST_FAILS_ON_CATALYST // Issue Link: https://github.com/dotnet/maui/issues/32721

	[Test, Order(7)]
	[Category(UITestCategories.WebView)]
	public void VerifyHybridWebView_SendMessageToJavaScript()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");
		App.WaitForElement("HybridWebView2Button");
		App.Tap("HybridWebView2Button");
		App.WaitForElement("IndexHtmlButton");
		App.Tap("IndexHtmlButton");
		App.WaitForElement("SendMessageButton");
		App.Tap("SendMessageButton");
		App.WaitForElement("StatusLabel");
		var message = App.FindElement("StatusLabel").GetText();
		Assert.That(message, Is.EqualTo("Message sent successfully. Result: Message received"), "JavaScript should receive the message sent from C#.");
	}
#endif

#if TEST_FAILS_ON_WINDOWS && TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS // Issue Link: https://github.com/dotnet/maui/issues/30575, https://github.com/dotnet/maui/issues/30605
	[Test, Order(10)]
	[Category(UITestCategories.WebView)]
	public void VerifyHybridWebViewWithFlowDirection()
	{
		App.WaitForElement("ResetButton");
		App.Tap("ResetButton");
		App.WaitForElement("FlowDirectionCheckBox");
		App.Tap("FlowDirectionCheckBox");
		Thread.Sleep(2000); // Allow time for the UI to update
		VerifyScreenshot(tolerance: 0.5, retryTimeout: TimeSpan.FromSeconds(2));
	}
#endif

	[Test, Order(20)]
	[Category(UITestCategories.WebView)]
	public void Verify_WebViewInitializing_Event_And_Arguments()
	{
		App.WaitForElement("WebViewInitializingLabel");

		var initializingText = App.FindElement("WebViewInitializingLabel").GetText();
		Assert.That(initializingText, Does.Contain("Fired"));

		var platformArgs = App.FindElement("WebViewInitializingPlatformArgsLabel").GetText();
		Assert.That(platformArgs, Does.Not.Contain("null"));
	}

	[Test, Order(21)]
	[Category(UITestCategories.WebView)]
	public void Verify_WebViewInitialized_Event_And_Arguments()
	{
		App.WaitForElement("WebViewInitializedLabel");

		var initializedText = App.FindElement("WebViewInitializedLabel").GetText();
		Assert.That(initializedText, Does.Contain("Fired"));

		var platformArgs = App.FindElement("WebViewInitializedPlatformArgsLabel").GetText();
		Assert.That(platformArgs, Does.Not.Contain("null"));
	}

	[Test, Order(22)]
	[Category(UITestCategories.WebView)]
	public void Verify_WebResourceRequested_Event_Fires()
	{
		App.WaitForElement("WebResourceRequestedLabel");

		var text = App.FindElement("WebResourceRequestedLabel").GetText();
		Assert.That(text, Does.Contain("Fired"));
	}

	[Test, Order(23)]
	[Category(UITestCategories.WebView)]
	public void Verify_WebResourceRequested_Uri()
	{
		var uri = App.FindElement("WebResourceRequestedUriLabel").GetText();

		Assert.That(uri, Is.Not.Empty);
		Assert.That(uri, Does.Contain("app://"));
	}

	[Test, Order(24)]
	[Category(UITestCategories.WebView)]
	public void Verify_WebResourceRequested_Method()
	{
		var method = App.FindElement("WebResourceRequestedMethodLabel").GetText();

		Assert.That(method, Does.Contain("GET"));
	}

	[Test, Order(25)]
	[Category(UITestCategories.WebView)]
	public void Verify_WebResourceRequested_Handled_IsFalse()
	{
		var handled = App.FindElement("WebResourceRequestedHandledLabel").GetText();

		Assert.That(handled, Does.Contain("False"));
	}

	[Test, Order(26)]
	[Category(UITestCategories.WebView)]
	public void Verify_WebResourceRequested_Headers()
	{
		var headers = App.FindElement("WebResourceRequestedHeadersLabel").GetText();

		Assert.That(headers, Is.Not.Empty);
		Assert.That(headers, Does.Not.Contain("None"));
	}

	[Test, Order(27)]
	[Category(UITestCategories.WebView)]
	public void Verify_WebResourceRequested_QueryParameters_Default()
	{
		var query = App.FindElement("WebResourceRequestedQueryParamsLabel").GetText();

		Assert.That(query, Does.Contain("None"));
	}

	[Test, Order(28)]
	[Category(UITestCategories.WebView)]
	public void Verify_WebResourceRequested_PlatformArgs()
	{
		var platformArgs = App.FindElement("WebResourceRequestedPlatformArgsLabel").GetText();

		Assert.That(platformArgs, Does.Not.Contain("null"));
	}

}