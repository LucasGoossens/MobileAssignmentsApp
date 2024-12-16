namespace InleverenWeek4MobileDev;

public partial class MainPage : ContentPage
{       

    public MainPage()
    {
        InitializeComponent();
    }

    private async void NavigateToTrending(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Frontpage());
    }

    private async void NavigateToLogin(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.LoginPage());
    }

    private async void NavigateToRegister(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistrationPage());
    }
}
