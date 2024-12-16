using InleverenWeek4MobileDev.Repositories;
namespace InleverenWeek4MobileDev.Views;

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
        string username = EmailEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrEmpty(username))
        {
            await DisplayAlert("Error", "Please enter a username.", "OK");
            return;
        }       

        if (string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "Please enter a password.", "OK");
            return;
        }

        bool isSuccess = LoginUser(username, password);

        if (isSuccess)
        {
            await DisplayAlert("Success", "User logged in", "OK");

            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            await DisplayAlert("Error", "Login failed. Please try again.", "OK");
        }

    }

    public bool LoginUser(string username, string password)
    {
        UserRepository userRepository = new UserRepository();
        return(userRepository.LoginUser(username, password));

    }
}