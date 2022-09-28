using MonkeyFinder.Model;
using MonkeyFinder.ViewModel;

namespace MonkeyFinder.View;

public partial class MainPage : ContentPage
{

	public MainPage(MonkeysViewModel monkeysViewModel)
	{
		InitializeComponent();
		BindingContext = monkeysViewModel;
	}

	private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
		var monkey = ((VisualElement)sender).BindingContext as Monkey;
		if (monkey == null)
		{
			return;
		}
		await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object> { { "Monkey", monkey } });
	}
}
