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

}