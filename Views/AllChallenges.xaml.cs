using Microsoft.Maui.Controls.Shapes;
namespace InleverenWeek4MobileDev;

public partial class AllChallenges : ContentPage
{
    public AllChallenges()
    {
        InitializeComponent();
        //for (int i = 0; i < 4; i++)
        //{
        //    var image = new Image
        //    {
        //        Source = "trending_clownfish", 
        //        Aspect = Aspect.AspectFill 
        //    };

        //    var border = new Border
        //    {
        //        Stroke = Colors.CornflowerBlue,
        //        StrokeThickness = 2,
        //        BackgroundColor = Colors.LightGray,
        //        StrokeShape = new RoundRectangle
        //            {
        //                CornerRadius = new CornerRadius(5, 5, 5, 5)
        //            },
        //        WidthRequest = 180,
        //        HeightRequest = 300,
        //        Margin = new Thickness(3, 3, 3, 6),
        //        Content = image 
        //    };

        //    TrendingChallengesFlexLayoutAllChallenges.Children.Add(border);
        //}


        for (int i = 0; i < 6; i++)
        {
            var boxView = new BoxView
            {
                Color = Colors.DarkBlue,
                CornerRadius = 10,
                WidthRequest = 180,
                HeightRequest = 300,
                Margin = new Thickness(3, 3, 3, 6)

            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (sender, args) =>
            {
                var tappedBoxView = sender as BoxView;
                if (tappedBoxView != null)
                {
                    // Navigate to the AllChallenges page
                    await Navigation.PushAsync(new Assignments(1));
                }
            };

            boxView.GestureRecognizers.Add(tapGestureRecognizer);
            NewChallengesFlexlayoutAllChallenges.Children.Add(boxView);
        }
    }
}