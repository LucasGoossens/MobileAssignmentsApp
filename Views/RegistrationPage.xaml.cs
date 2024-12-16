using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Repositories;

namespace InleverenWeek4MobileDev;

public partial class RegistrationPage : ContentPage
{
    public RegistrationPage()
    {
        InitializeComponent();
    }

    private async void SubmitRegistration(object sender, EventArgs e)
    {        
        string username = NameEntry.Text?.Trim();
        string email = EmailEntry.Text?.Trim();
        string password = PasswordEntry.Text;
        string confirmPassword = ConfirmPasswordEntry.Text;
        if (string.IsNullOrEmpty(username))
        {
            await DisplayAlert("Error", "Please enter a username.", "OK");
            return;
        }

        if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
        {
            await DisplayAlert("Error", "Please enter a valid email address.", "OK");
            return;
        }

        if (string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "Please enter a password.", "OK");
            return;
        }

        if (password != confirmPassword)
        {
            await DisplayAlert("Error", "Passwords do not match.", "OK");
            return;
        }

        // Perform your registration logic here (e.g., save to database or call an API)
        bool isSuccess = RegisterUser(username, email, password);

        if (isSuccess)
        {
            await DisplayAlert("Success", "Account created successfully!", "OK");

            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            await DisplayAlert("Error", "Registration failed. Please try again.", "OK");
        }

    }
    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    private bool RegisterUser(string username, string email, string password)
    {
       User newUser = new User
       {
           Name = username,
           Email = email,
           Password = password
       };

        UserRepository userRepository = new UserRepository();
        userRepository.AddOrUpdate(newUser);

        return true;
    }

    private async void NavigateToLogin(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.LoginPage());
    }
}