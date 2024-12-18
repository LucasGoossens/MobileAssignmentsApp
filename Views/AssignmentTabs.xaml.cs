using InleverenWeek4MobileDev.ViewModels;

namespace InleverenWeek4MobileDev;

public partial class AssignmentTabs : TabbedPage
{
    public int AssignmentId { get; set; }
    public AssignmentTabs(int assignmentId)
	{
		InitializeComponent();
        AssignmentId = assignmentId;
        BindingContext = new AssignmentsTabViewModel(AssignmentId);


    }
}