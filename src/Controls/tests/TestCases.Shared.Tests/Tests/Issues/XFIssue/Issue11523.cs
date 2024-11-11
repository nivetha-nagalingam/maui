#if TEST_FAILS_ON_IOS && TEST_FAILS_ON_CATALYST
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
			App.Tap(AppiumQuery.ByXPath("//android.widget.ImageButton[@content-desc='Open navigation drawer']"));
#else
		App.Tap(FlyoutIconAutomationId);
#endif
	}
}
#endif