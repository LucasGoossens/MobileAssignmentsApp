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
                HeightRequest = 200,
                Margin = new Thickness(6, 3, 3, 6)
            };
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
                    await Navigation.PushAsync(new AllChallenges());
                }
            };

            boxView.GestureRecognizers.Add(tapGestureRecognizer);
            RecentChallengesFlexlayout.Children.Add(boxView);

        }




    }
}