using CommunityToolkit.Mvvm.ComponentModel;
using MonkeyFinder.Model;

namespace MonkeyFinder.ViewModel;

[QueryProperty(nameof(Monkey), "Monkey")]
public partial class MonkeyDetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    Monkey monkey;
}
