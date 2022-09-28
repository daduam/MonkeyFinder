using MonkeyFinder.Model;
using MonkeyFinder.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    private MonkeyService monkeyService;

    public MonkeysViewModel(MonkeyService monkeyService)
    {
        Title = "Monkey Finder";
        this.monkeyService = monkeyService;
        GetMonkeysCommand = new Command(async () => await GetMonkeysAsync());
    }

    public ObservableCollection<Monkey> Monkeys { get; } = new();
    public Command GetMonkeysCommand { get; }

    private async Task GetMonkeysAsync()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;

            var monkeys = await monkeyService.GetMonkeys();

            if (Monkeys.Count != 0)
            {
                Monkeys.Clear();
            }

            foreach(var monkey in monkeys)
            {
                Monkeys.Add(monkey);
            }
        }
        catch(Exception ex)
        {
            Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
