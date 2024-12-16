using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;

namespace InleverenWeek4MobileDev;

public partial class Comments : ContentPage
{
	public Comments()
	{
		InitializeComponent();

        for (int i = 0; i < 15; i++) // Example loop to create multiple comments
        {
            // Outer Border
            var outerBorder = new Border
            {
                StrokeThickness = 0
            };

            // HorizontalStackLayout
            var horizontalStack = new HorizontalStackLayout
            {
                Spacing = 10
            };

            // Circular Border for Image
            var imageBorder = new Border
            {
                WidthRequest = 60,
                HeightRequest = 60,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                StrokeShape = new Ellipse()
            };

            var image = new Image
            {
                Source = "ocean", // Replace with dynamic source if needed
                WidthRequest = 60,
                HeightRequest = 60,
                Aspect = Aspect.Fill,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            imageBorder.Content = image;

            // VerticalStackLayout for text
            var textStack = new VerticalStackLayout
            {
                MaximumWidthRequest = 275
            };

            var usernameLabel = new Label
            {
                Text = "Test Username", // Replace with dynamic text if needed
                TextColor = Colors.Black,
                FontAttributes = FontAttributes.Bold
            };

            var commentLabel = new Label
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut dolor nunc, faucibus eget ex sed, congue interdum est.", // Replace with dynamic text if needed
                TextColor = Colors.Black,
                FontSize = 14,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                LineBreakMode = LineBreakMode.WordWrap,
                Padding = new Thickness(0, 0, 0, 5)
            };

            // FlexLayout for icons and counts
            var flexLayout = new FlexLayout
            {
                Direction = FlexDirection.Row,
                JustifyContent = FlexJustify.End
            };

            var commentIcon = new Image
            {
                Source = "comment",
                WidthRequest = 20
            };

            var commentCount = new Label
            {
                Text = "99", // Replace with dynamic value if needed
                Padding = new Thickness(3, 0, 3, 0)
            };

            var heartIcon = new Image
            {
                Source = "heart",
                WidthRequest = 20
            };

            var likeCount = new Label
            {
                Text = "99", // Replace with dynamic value if needed
                Padding = new Thickness(3, 0, 0, 0)
            };

            // Add icons and counts to the FlexLayout
            flexLayout.Children.Add(commentIcon);
            flexLayout.Children.Add(commentCount);
            flexLayout.Children.Add(heartIcon);
            flexLayout.Children.Add(likeCount);

            // Separator BoxView
            var separator = new BoxView
            {
                HeightRequest = 1,
                WidthRequest = 400,
                BackgroundColor = Colors.LightGray,
                Margin = new Thickness(0, 8, 0, 0)
            };

            // Add elements to text stack
            textStack.Children.Add(usernameLabel);
            textStack.Children.Add(commentLabel);
            textStack.Children.Add(flexLayout);
            textStack.Children.Add(separator);

            // Add image border and text stack to horizontal stack
            horizontalStack.Children.Add(imageBorder);
            horizontalStack.Children.Add(textStack);

            // Add horizontal stack to outer border
            outerBorder.Content = horizontalStack;

            // Add the outer border to the CommentSection
            CommentSection.Children.Add(outerBorder);
        }

    }
}