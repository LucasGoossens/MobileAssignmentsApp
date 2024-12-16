namespace InleverenWeek4MobileDev;

public partial class Submission : ContentPage
{
	public Submission()
	{
		InitializeComponent();
	}

    private void ProfileClicked(object sender, EventArgs e)
    {

    }

    private async void CommentsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Comments());
    }
}