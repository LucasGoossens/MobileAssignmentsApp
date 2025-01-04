using InleverenWeek4MobileDev.Database;
using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Models.DTO;
using InleverenWeek4MobileDev.PixoAPI;
using InleverenWeek4MobileDev.Repositories;
using InleverenWeek4MobileDev.Session;
using System.Security.Cryptography.X509Certificates;

namespace InleverenWeek4MobileDev;

public partial class MainPage : ContentPage
{

    public string ImageSource { get; set; }

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
        //dbConnection.DeleteAll<Models.Submission>();
        //dbConnection.DeleteAll<UserSubmissionRating>();
        //dbConnection.DeleteAll<Comment>();        

        //ImageEditorTest();

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

    private async void ImageEditorTest()
    {
        ImageEditorAPIController test = new ImageEditorAPIController();        
        SubmissionRepository submissionRepository = new SubmissionRepository();
        
        Models.Submission randomSubmission = submissionRepository.GetRandomSubmission();
        string testSubmissionFilePath = randomSubmission.Image;        

        //await test.Execute(testSubmissionFilePath);
        randomSubmission.Image = test.ImageFilePath;

        if (!string.IsNullOrEmpty(test.ImageFilePath))
        {
            randomSubmission.Image = test.ImageFilePath;
            submissionRepository.UpdateSubmission(randomSubmission);
            Console.WriteLine(randomSubmission.Image);
            Console.WriteLine(randomSubmission.Id);            
            Console.WriteLine("Succesfully updated.");
            if (File.Exists(randomSubmission.Image))
            {
                Console.WriteLine("File exists and is ready to use.");
            }
            else
            {
                Console.WriteLine("File does not exist at the specified path.");
            }
        }
        else
        {
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
            Console.WriteLine("ImageFilePath is null or empty. Update failed.");
        }
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
