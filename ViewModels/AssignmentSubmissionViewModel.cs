using CommunityToolkit.Mvvm.Input;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class AssignmentSubmissionsViewModel
    {
        public int AssignmentId { get; }

        public AssignmentSubmissionsViewModel(int assignmentId)
        {
            AssignmentId = assignmentId;            
        }


        [RelayCommand]
        public async void SubmitEntry()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new PhotoPickerModal(AssignmentId));

        }

    }

}
