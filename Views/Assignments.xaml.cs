using InleverenWeek4MobileDev.ViewModels;

namespace InleverenWeek4MobileDev;

public partial class Assignments : ContentPage
{
    public int ChallengeId { get; set; }
    public Assignments(int challengeId)
    {
        InitializeComponent();
        ChallengeId = challengeId;
        BindingContext = new AssignmentsViewModel(ChallengeId);

        //    for (int i = 0; i < 4; i++)
        //    {
        //        var frame = new Frame
        //        {
        //            BackgroundColor = Color.FromRgb(211, 245, 217), 
        //            CornerRadius = 10,
        //            WidthRequest = 340,
        //            HeightRequest = 50,
        //            Margin = new Thickness(0, 6, 0, 0),
        //            HasShadow = false,
        //            Padding = new Thickness(10) 
        //        };


        //        var label = new Label
        //        {
        //            Text = $"Unlocked Assignment {i + 1}", 
        //            VerticalOptions = LayoutOptions.Center,
        //            HorizontalOptions = LayoutOptions.Start,
        //            TextColor = Colors.Black,
        //            FontSize = 16
        //        };

        //        frame.Content = label;

        //        var tapGestureRecognizer = new TapGestureRecognizer();
        //        tapGestureRecognizer.Tapped += async (sender, args) =>
        //        {
        //            var tappedFrame = sender as Frame;
        //            if (tappedFrame != null)
        //            {

        //                await Navigation.PushAsync(new AssignmentTabs());
        //            }
        //        };

        //        frame.GestureRecognizers.Add(tapGestureRecognizer);
        //        UnlockedAssignments.Children.Add(frame);
        //    }

        //    for (int i = 0; i < 4; i++)
        //    {
        //        var frame = new Frame
        //        {
        //            BackgroundColor = Color.FromRgb(240, 250, 185), 
        //            CornerRadius = 10,
        //            WidthRequest = 340,
        //            HeightRequest = 50,
        //            Margin = new Thickness(0, 6, 0, 0),
        //            HasShadow = false,
        //            Padding = new Thickness(10) 
        //        };


        //        var label = new Label
        //        {
        //            Text = $"Completed Assignment {i + 1}", 
        //            VerticalOptions = LayoutOptions.Center,
        //            HorizontalOptions = LayoutOptions.Start,
        //            TextColor = Colors.Black,
        //            FontSize = 16
        //        };

        //        frame.Content = label;

        //        var tapGestureRecognizer = new TapGestureRecognizer();
        //        tapGestureRecognizer.Tapped += async (sender, args) =>
        //        {
        //            var tappedFrame = sender as Frame;
        //            if (tappedFrame != null)
        //            {
        //                await Navigation.PushAsync(new AssignmentTabs());
        //            }
        //        };

        //        frame.GestureRecognizers.Add(tapGestureRecognizer);
        //        CompletedAssignments.Children.Add(frame);
        //    }


        //    for (int i = 0; i < 4; i++)
        //    {
        //        var frame = new Frame
        //        {
        //            BackgroundColor = Colors.Grey,
        //            CornerRadius = 10,
        //            WidthRequest = 340,
        //            HeightRequest = 50,
        //            Margin = new Thickness(0, 6, 0, 0),
        //            HasShadow = false,
        //            Padding = new Thickness(10)
        //        };


        //        var label = new Label
        //        {
        //            Text = $"Locked Assignment {i + 1}",
        //            VerticalOptions = LayoutOptions.Center,
        //            HorizontalOptions = LayoutOptions.Start,
        //            TextColor = Colors.Black,
        //            FontSize = 16
        //        };

        //        frame.Content = label;

        //        var tapGestureRecognizer = new TapGestureRecognizer();
        //        tapGestureRecognizer.Tapped += async (sender, args) =>
        //        {
        //            var tappedFrame = sender as Frame;
        //            if (tappedFrame != null)
        //            {
        //                // Navigate to the AllChallenges page
        //                //await Navigation.PushAsync(new AllChallenges());
        //            }
        //        };

        //        frame.GestureRecognizers.Add(tapGestureRecognizer);
        //        LockedAssignments.Children.Add(frame);
        //    }

        //}
    }
}