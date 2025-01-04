using InleverenWeek4MobileDev.ViewModels;

namespace InleverenWeek4MobileDev;

public partial class EditSubmission : ContentPage
{
	public EditSubmission(Models.Submission submission)
	{
		InitializeComponent();
		BindingContext = new EditSubmissionViewModel(submission);
	}
}