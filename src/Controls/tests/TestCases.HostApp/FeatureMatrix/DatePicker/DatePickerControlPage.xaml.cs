using System.Globalization;

namespace Maui.Controls.Sample;

public class DatePickerControlPage : NavigationPage
{
	private DatePickerViewModel _viewModel;
	public DatePickerControlPage()
	{
		_viewModel = new DatePickerViewModel();
		PushAsync(new DatePickerMainControlPage(_viewModel));
	}
}

public partial class DatePickerMainControlPage : ContentPage
{
	private DatePickerViewModel _viewModel;

	public DatePickerMainControlPage(DatePickerViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;

		// Display initial culture formatting information
		DisplayCultureSpecificDate(_viewModel.Date, _viewModel.Culture);
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		// Refresh culture display when returning to the page
		DisplayCultureSpecificDate(_viewModel.Date, _viewModel.Culture);
	}

	private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
	{
		// Reset culture to default when navigating to options page
		_viewModel.Culture = System.Globalization.CultureInfo.CurrentCulture;

		OpenedStatusLabel.Text = "Not Raised";
		ClosedStatusLabel.Text = "Not Raised";
		BindingContext = _viewModel = new DatePickerViewModel();
		await Navigation.PushAsync(new DatePickerOptionsPage(_viewModel));
	}

	private void DisplayCultureSpecificDate(DateTime date, CultureInfo culture)
	{
		if (culture != null)
		{
			// Apply the culture to the current thread
			Thread.CurrentThread.CurrentCulture = culture;
			Thread.CurrentThread.CurrentUICulture = culture;

			// Set default culture for new threads
			CultureInfo.DefaultThreadCurrentCulture = culture;
			CultureInfo.DefaultThreadCurrentUICulture = culture;
		}

		CultureFormatLabel.Text = $"Culture: {culture.Name}, Date: {date.ToString(culture)}";
	}

	public void OnDateSelected(object sender, DateChangedEventArgs e)
	{
		if (e.OldDate.Value.Date != DateTime.Now.Date && e.NewDate != e.OldDate)
		{
			OldDateSelectedLabel.Text = ((DateTime)e.OldDate).ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
			NewDateSelectedLabel.Text = ((DateTime)e.NewDate).ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
		}
	}

	private void DatePicker_Opened(object sender, EventArgs e)
	{
		OpenedStatusLabel.Text = "Raised";
	}
	private void DatePicker_Closed(object sender, EventArgs e)
	{
		ClosedStatusLabel.Text = "Raised";
	}
}
