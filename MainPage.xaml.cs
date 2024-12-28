using InleverenWeek4MobileDev.Database;
using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Models.DTO;
using InleverenWeek4MobileDev.Session;

namespace InleverenWeek4MobileDev;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        //var dbConnection = new SQLite.SQLiteConnection(Constants.DatabasePath);
        //dbConnection.DeleteAll<MemberChallenge>();
        //dbConnection.DeleteAll<MemberAssignment>();
        //dbConnection.DeleteAll<Models.Submission>();
        //dbConnection.DeleteAll<Challenge>();
        //dbConnection.DeleteAll<Assignment>();
        //dbConnection.DeleteAll<User>();
        //dbConnection.DeleteAll<UserSession>();

        UserSession.Instance.Initialize();

        if (UserSession.Instance.IsLoggedIn)
        {
            Task.Delay(100);
            Navigation.PushAsync(new Frontpage());
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("User is not logged in.");
            InitializeComponent();
        }

    }
    //protected override async void OnAppearing()
    //{
    //    base.OnAppearing();
    //    try
    //    {
    //        UserSession.Instance.Initialize();

    //        if (UserSession.Instance.IsLoggedIn)
    //        {
    //            await Task.Delay(100);
    //            await Navigation.PushAsync(new Frontpage());
    //        }
    //        else
    //        {
    //            System.Diagnostics.Debug.WriteLine("User is not logged in.");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        System.Diagnostics.Debug.WriteLine($"Error in OnAppearing: {ex.Message}");
    //    }
    //}



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
