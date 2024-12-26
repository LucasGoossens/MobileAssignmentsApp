using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Session;
using Microsoft.Maui.Controls.Shapes;

namespace InleverenWeek4MobileDev;

public partial class Frontpage : ContentPage
{
    public Frontpage()
    {
        InitializeComponent();

        //    System.Diagnostics.Debug.WriteLine("User logged in, user id: ");
        //    System.Diagnostics.Debug.WriteLine(UserSession.Instance.UserId);

        //    for (int i = 0; i < 4; i++)
        //    {
        //        var border = new Border
        //        {
        //            BackgroundColor = Colors.CornflowerBlue,
        //            Stroke = Colors.Transparent, // No border outline
        //            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(10) },
        //            WidthRequest = 150,
        //            HeightRequest = 175,
        //            Margin = new Thickness(6, 3, 3, 6)
        //        };

        //        var image = new Image
        //        {
        //            Source = i % 3 == 0 ? "trending_clownfish" : "clownfish",
        //            Aspect = Aspect.AspectFill,
        //            WidthRequest = 150,
        //            HeightRequest = 175
        //        };

        //        var tapGestureRecognizer = new TapGestureRecognizer();
        //        tapGestureRecognizer.Tapped += async (sender, args) =>
        //        {
        //            // Navigate to the AllChallenges page
        //            await Navigation.PushAsync(new AllChallenges());
        //        };

        //        border.Content = image;
        //        border.GestureRecognizers.Add(tapGestureRecognizer);

        //        TrendingChallengesFlexLayout.Children.Add(border);

        //    }

        //    for (int i = 0; i < 6; i++)
        //    {
        //        var boxView = new BoxView
        //        {
        //            Color = Colors.BlueViolet,
        //            CornerRadius = 10,
        //            WidthRequest = 375,
        //            HeightRequest = 50,
        //            Margin = new Thickness(0, 6, 0, 0),

        //        };
        //        var tapGestureRecognizer = new TapGestureRecognizer();
        //        tapGestureRecognizer.Tapped += async (sender, args) =>
        //        {
        //            var tappedBoxView = sender as BoxView;
        //            if (tappedBoxView != null)
        //            {
        //                // Navigate to the AllChallenges page
        //                await Navigation.PushAsync(new Assignments(0));
        //            }
        //        };

        //        boxView.GestureRecognizers.Add(tapGestureRecognizer);
        //        RecentChallengesFlexlayout.Children.Add(boxView);

        //    }




        //}

        //private async void Shop(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Store());
        //}

        //private async void Profile(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Profile());
        //}

        //private async void LogOut(object sender, EventArgs e)
        //{
        //    UserSession.Instance.ClearUser();
        //    await Navigation.PushAsync(new MainPage());
        //}
    }
}