using InleverenWeek4MobileDev.Repositories;
using InleverenWeek4MobileDev.Session;
using Microsoft.Extensions.Logging.Abstractions;
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
        string username = LoginEntry.Text;
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

        int loggedInUserId = LoginUser(username, password);
        
        if (loggedInUserId != 0)
        {
            await DisplayAlert("Success", "User logged in", "OK");

            System.Diagnostics.Debug.WriteLine("Test 1");
            UserSession.Instance.SetUser(loggedInUserId);
            System.Diagnostics.Debug.WriteLine("LogInPage: complete.");
            System.Diagnostics.Debug.WriteLine(UserSession.Instance.UserId);
            System.Diagnostics.Debug.WriteLine(UserSession.Instance.IsLoggedIn);

            await Navigation.PushAsync(new Frontpage());
        }
        else
        {
            await DisplayAlert("Error", "Login failed. Please try again.", "OK");
        }

    }

    public int LoginUser(string username, string password)
    {
        UserRepository userRepository = new UserRepository();        
        return(userRepository.LoginUser(username, password));

    }
}