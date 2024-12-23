namespace InleverenWeek4MobileDev;

public partial class PhotoPickerModal : ContentPage
{
	public PhotoPickerModal(int assignmentId)
	{
		InitializeComponent();
        BindingContext = new ViewModels.PhotoPickerModalViewModel(assignmentId);
    }
}