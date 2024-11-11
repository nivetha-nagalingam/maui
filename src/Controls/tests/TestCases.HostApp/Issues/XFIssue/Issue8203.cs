namespace Maui.Controls.Sample.Issues
{
	[Issue(IssueTracker.Github, 8203,
	"CollectionView fires SelectionChanged x (number of items selected +1) times, while incrementing SelectedItems from 0 " +
	"to number of items each time",
	PlatformAffected.UWP)]

	public class Issue8203 : TestContentPage
	{
		int _raisedCount;
		Label _eventRaisedCount;

		protected override void Init()
		{
			var instructions = new Label
			{
				Text = "Select an item below. Then select another one. The SelectionChanged " +
				"event should have been raised twice. If not, this test has failed."
			};

			_eventRaisedCount = new Label
			{
				AutomationId = "EventRaisedCount"
			};

			var layout = new StackLayout();
			var cv = new CollectionView();

			var source = new List<string> { "one", "two", "three" };

			cv.ItemTemplate = new DataTemplate(() =>
			{
				var label = new Label();
				label.SetBinding(Label.TextProperty, ".");
				label.SetBinding(AutomationIdProperty, new Binding(".", stringFormat: "{0}"));
				return label;
			});

			cv.ItemsSource = source;
			cv.SelectionMode = SelectionMode.Multiple;
			cv.SelectionChanged += SelectionChangedHandler;

			layout.Add(instructions);
			layout.Add(_eventRaisedCount);
			layout.Add(cv);

			Content = layout;
		}

		void UpdateRaisedCount()
		{
			_eventRaisedCount.Text = $"SelectionChanged has been raised {_raisedCount} times.";
		}

		void SelectionChangedHandler(object sender, SelectionChangedEventArgs e)
		{
			_raisedCount += 1;
			UpdateRaisedCount();
		}
	}
}
