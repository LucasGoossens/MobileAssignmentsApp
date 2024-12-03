namespace InleverenWeek4MobileDev;

public partial class RegistrationPage : ContentPage
{
    public RegistrationPage()
    {
        InitializeComponent();
    }

    private void SubmitRegistration(object sender, EventArgs e)
    {
    }

    private async void NavigateToLogin(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}