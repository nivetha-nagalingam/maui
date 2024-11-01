using Maui.Controls.Sample.Issues;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Maui.Controls.Sample
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var appBuilder = MauiApp.CreateBuilder();

#if IOS || ANDROID
			appBuilder.UseMauiMaps();
#endif
			appBuilder.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("FontAwesome.ttf", "FA");
					fonts.AddFont("ionicons.ttf", "Ion");
				})
				.RenderingPerformanceAddMappers()
				.Issue21109AddMappers()
				.Issue18720AddMappers()
				.Issue18720EditorAddMappers()
				.Issue18720DatePickerAddMappers()
				.Issue18720TimePickerAddMappers();

#if IOS || MACCATALYST

			appBuilder.ConfigureMauiHandlers(handlers =>
				{
					handlers.AddHandler<Microsoft.Maui.Controls.CollectionView, Microsoft.Maui.Controls.Handlers.Items2.CollectionViewHandler2>();
					handlers.AddHandler<Microsoft.Maui.Controls.CarouselView, Microsoft.Maui.Controls.Handlers.Items2.CarouselViewHandler2>();
				});
				
#endif

			appBuilder.Services.AddTransient<TransientPage>();
			appBuilder.Services.AddScoped<ScopedPage>();
			return appBuilder.Build();
		}
	}
}