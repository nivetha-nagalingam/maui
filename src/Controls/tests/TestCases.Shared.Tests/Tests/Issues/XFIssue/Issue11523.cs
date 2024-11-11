#if TEST_FAILS_ON_CATALYST
//The test failed on MacCatalyst at App.WaitForElement("PageLoaded"), indicating that the element "PageLoaded" was not found within the timeout period.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue11523 : _IssuesUITest
{
	public Issue11523(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[Bug] FlyoutBehavior.Disabled removes back-button from navbar";

	[Test]
	[Category(UITestCategories.Shell)]
	public void BackButtonStillVisibleWhenFlyoutBehaviorDisabled()
	{
		App.WaitForElement("PageLoaded");
#if IOS
		App.Back();
#else
		App.TapBackArrow();
#endif
#if ANDROID
			App.WaitForElement(AppiumQuery.ByXPath("//android.widget.ImageButton[@content-desc='Open navigation drawer']"));
#else
		App.WaitForElement(FlyoutIconAutomationId);
#endif
	}
}
#endif