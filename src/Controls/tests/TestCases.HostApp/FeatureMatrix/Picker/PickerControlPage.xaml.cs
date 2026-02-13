namespace Maui.Controls.Sample;

public class PickerControlPage : NavigationPage
{
	private PickerViewModel _viewModel;

	public PickerControlPage()
	{
		_viewModel = new PickerViewModel();
		PushAsync(new PickerControlMainPage(_viewModel));
	}
}

public partial class PickerControlMainPage : ContentPage
{
	private PickerViewModel _viewModel;

	public PickerControlMainPage(PickerViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}

	private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
	{
		_viewModel.ResetToDefaults();
		await Navigation.PushAsync(new PickerOptionsPage(_viewModel));
		OpenedStatusLabel.Text = string.Empty;
		ClosedStatusLabel.Text = string.Empty;

		SelectedIndexChangedStatusLabel.Text = string.Empty;
	}

	private void Picker_SelectedIndexChanged(object sender, EventArgs e)
	{
		SelectedIndexChangedStatusLabel.Text = "Triggered";
	}

	private void Picker_Opened(object sender, EventArgs e)
	{
		OpenedStatusLabel.Text = "Raised";
	}

	private void Picker_Closed(object sender, EventArgs e)
	{
		ClosedStatusLabel.Text = "Raised";
	}
}