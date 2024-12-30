using InleverenWeek4MobileDev.ViewModels;

namespace InleverenWeek4MobileDev;

public partial class RatingModal : ContentPage
{
	public RatingModal(Models.Submission submission)
    {
		InitializeComponent();
		this.BindingContext = new RatingModalViewModel(submission);
    }
}