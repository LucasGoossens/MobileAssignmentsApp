using InleverenWeek4MobileDev.Session;
using InleverenWeek4MobileDev.ViewModels;
using Microsoft.Maui.Controls.Shapes;
namespace InleverenWeek4MobileDev;

public partial class Profile : ContentPage
{
	public Profile()
	{
		InitializeComponent();
        BindingContext = new ProfileViewModel(UserSession.Instance.UserId);

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
        //        {
        //            CornerRadius = new CornerRadius(5, 5, 5, 5)
        //        },
        //        WidthRequest = 150,
        //        HeightRequest = 250,
        //        Margin = new Thickness(5, 3, 3, 6),
        //        Content = image
        //    };

        //    ProfileCreatedChallenges.Children.Add(border);
        //}


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
        //        {
        //            CornerRadius = new CornerRadius(5, 5, 5, 5)
        //        },
        //        WidthRequest = 150,
        //        HeightRequest = 250,
        //        Margin = new Thickness(5, 3, 3, 6),
        //        Content = image
        //    };
        //    ProfileRecentSubmissions.Children.Add(border);
        //}
    }
}