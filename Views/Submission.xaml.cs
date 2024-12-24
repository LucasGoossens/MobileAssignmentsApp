using InleverenWeek4MobileDev.ViewModels;

namespace InleverenWeek4MobileDev;

public partial class Submission : ContentPage
{
    public int SubmissionId { get; set; }
    public Submission(int submissionId)
	{
        InitializeComponent();
        SubmissionId = submissionId;
        BindingContext = new SubmissionViewModel(submissionId);
	}

    private void ProfileClicked(object sender, EventArgs e)
    {

    }

    private async void CommentsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Comments());
    }
}