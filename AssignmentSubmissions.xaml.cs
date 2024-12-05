namespace InleverenWeek4MobileDev;

public partial class AssignmentSubmissions : ContentPage
{
    public string AssignmentTitle { get; set; } = "Binding Test";
    public AssignmentSubmissions()
    {
        InitializeComponent();
        BindingContext = this;
        for (int i = 0; i < 4; i++)
        {
            var frame = new Frame
            {
                CornerRadius = 10,
                Padding = 0,
                Margin = new Thickness(3, 0, 3, 0),
                WidthRequest = 150,
                HeightRequest = 280,
                HasShadow = false,
            };
            var image = new Image
            {
                Source = "clownfish.jpg",
                Aspect = Aspect.AspectFill,             
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (sender, args) =>
            {
                var tappedFrame = sender as Frame;
                if (tappedFrame != null)
                {
                    // Navigate or handle tap event
                    // await Navigation.PushAsync(new PopularSubmissionDetailsPage());
                }
            };
            frame.Content = image;
            frame.GestureRecognizers.Add(tapGestureRecognizer);
            PopularSubmissions.Children.Add(frame);
        }

        for (int i = 0; i < 6; i++)
        {
            var frame = new Frame
            {
                CornerRadius = 10,
                Padding = 0,
                Margin = new Thickness(3, 0, 3, 3),
                WidthRequest = 160,
                HeightRequest = 280,
                HasShadow = false,
            };
            var image = new Image
            {
                Source = "clownfish.jpg",
                Aspect = Aspect.AspectFill,
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (sender, args) =>
            {
                var tappedFrame = sender as Frame;
                if (tappedFrame != null)
                {
                    // Navigate or handle tap event
                    // await Navigation.PushAsync(new PopularSubmissionDetailsPage());
                }
            };
            frame.Content = image;
            frame.GestureRecognizers.Add(tapGestureRecognizer);
            NewSubmissions.Children.Add(frame);
        }
    }

}