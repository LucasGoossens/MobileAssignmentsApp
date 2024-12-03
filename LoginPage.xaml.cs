namespace InleverenWeek4MobileDev;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void NavigateToRegister(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new RegistrationPage());
    }

    private async void SubmitLogin(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Frontpage());
    }
}