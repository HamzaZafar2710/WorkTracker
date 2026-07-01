using Microsoft.Maui.Storage;
using WorkTracker.ViewModels;
using WorkTracker.Models;
using WorkTracker.Helpers;
using WorkTracker.Resources.Localization;

namespace WorkTracker.Views;

public partial class LiveStatusPage : ContentPage
{
    private readonly LiveStatusViewModel viewModel;

    // Prevents the Picker event from firing during page initialization
    private bool isInitializing = true;

    public LiveStatusPage()
    {
        InitializeComponent();
        LanguagePicker.Items.Clear();

        LanguagePicker.Items.Add(AppResources.English);
        LanguagePicker.Items.Add(AppResources.Urdu);
        LanguagePicker.Items.Add(AppResources.French);
        LanguagePicker.Items.Add(AppResources.Persian);

        viewModel = new LiveStatusViewModel();
        BindingContext = viewModel;

        DateLabel.Text = viewModel.CurrentDate.ToString("dd MMM yyyy");

        string savedLanguage = Preferences.Default.Get("SelectedLanguage", "en");

        LanguagePicker.SelectedIndex = savedLanguage switch
        {
            "en" => 0,
            "ur" => 1,
            "fr" => 2,
            "fa" => 3,
            _ => 0
        };

        // Initialization finished
        isInitializing = false;
    }

    private void PreviousDateTapped(object sender, EventArgs e)
    {
        viewModel.PreviousDate();
        DateLabel.Text = viewModel.CurrentDate.ToString("dd MMM yyyy");
    }

    private void NextDateTapped(object sender, EventArgs e)
    {
        viewModel.NextDate();
        DateLabel.Text = viewModel.CurrentDate.ToString("dd MMM yyyy");
    }

    private async void EmployeeRefreshView_Refreshing(object sender, EventArgs e)
    {
        await Task.Delay(1000);
        EmployeeRefreshView.IsRefreshing = false;
    }

    private void StatusTapped(object sender, TappedEventArgs e)
    {
        Label label = (Label)sender;
        Employee employee = (Employee)label.BindingContext;

        if (employee.Status == AppResources.NotClockedIn)
        {
            employee.Status = AppResources.ClockedIn;
            employee.StatusColor = "Green";
        }
        else if (employee.Status == AppResources.ClockedIn)
        {
            employee.Status = AppResources.Exception;
            employee.StatusColor = "Red";
        }
        else
        {
            employee.Status = AppResources.NotClockedIn;
            employee.StatusColor = "Orange";
        }
    }

    private void LanguagePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Ignore the event while restoring the saved language
        if (isInitializing)
            return;

        if (LanguagePicker.SelectedItem == null)
            return;

        int selectedIndex = LanguagePicker.SelectedIndex;

        string cultureCode = selectedIndex switch
        {
            0 => "en",
            1 => "ur",
            2 => "fr",
            3 => "fa",
            _ => "en"
        };

        Preferences.Default.Set("SelectedLanguage", cultureCode);

        LocalizationManager.SetLanguage(cultureCode);

        // Reload the application only when the user actually changes the language
        Application.Current!.Windows[0].Page = new AppShell();
    }
}