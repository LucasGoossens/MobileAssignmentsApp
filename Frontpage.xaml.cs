using InleverenWeek4MobileDev.Models;

namespace InleverenWeek4MobileDev;

public partial class Frontpage : ContentPage
{
    public Frontpage()
    {
        InitializeComponent();

        for (int i = 0; i < 4; i++)
        {
            var boxView = new BoxView
            {
                Color = Colors.CornflowerBlue,
                CornerRadius = 10,
                WidthRequest = 150,
                HeightRequest = 175,
                Margin = new Thickness(6, 3, 3, 6)
            };
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (sender, args) =>
            {
                var tappedBoxView = sender as BoxView;
                if (tappedBoxView != null)
                {
                    // Navigate to the AllChallenges page
                    await Navigation.PushAsync(new AllChallenges());               
                }
            };

            boxView.GestureRecognizers.Add(tapGestureRecognizer);
            TrendingChallengesFlexLayout.Children.Add(boxView);
        }

        for (int i = 0; i < 6; i++)
        {
            var boxView = new BoxView
            {                
                Color = Colors.AliceBlue,
                CornerRadius = 10,
                WidthRequest = 375,
                HeightRequest = 50,
                Margin = new Thickness(0,6,0,0),
                
            };
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (sender, args) =>
            {
                var tappedBoxView = sender as BoxView;
                if (tappedBoxView != null)
                {
                    // Navigate to the AllChallenges page
                    await Navigation.PushAsync(new Assignments());
                }
            };

            boxView.GestureRecognizers.Add(tapGestureRecognizer);           
            RecentChallengesFlexlayout.Children.Add(boxView);

        }




    }

    private async void Shop(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Store());
    }

    private async void Profile(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Profile());
    }

   
}