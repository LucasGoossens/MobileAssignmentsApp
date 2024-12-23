using InleverenWeek4MobileDev.ViewModels;

namespace InleverenWeek4MobileDev;

public partial class AssignmentTabs : TabbedPage
{
    public int AssignmentId { get; set; }
    public AssignmentTabs(int assignmentId)
	{
		InitializeComponent();
        AssignmentId = assignmentId;       

        // Set BindingContext for the TabbedPage
        BindingContext = new AssignmentsTabViewModel(AssignmentId);        
        Children.Add(new AssignmentSubmissions(AssignmentId) { Title = "SUBMISSIONS" });
    }
}