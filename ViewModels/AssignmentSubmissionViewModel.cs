using CommunityToolkit.Mvvm.Input;
using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Repositories;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class AssignmentSubmissionsViewModel
    {
        public List<Models.Submission> submissions { get; set; }
        public List<Models.Submission> trendingSubmissions { get; set; }
        public int AssignmentId { get; set; }
        public AssignmentSubmissionsViewModel(int assignmentId)
        {
            AssignmentId = assignmentId;
            LoadSubmissions();
        }

        public AssignmentSubmissionsViewModel()
        {
            
        }

        [RelayCommand]
        public async void SubmitEntry()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new PhotoPickerModal(AssignmentId));
        }

        [RelayCommand]
        public async void NavigateToSubmission(int submissionId)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Submission(submissionId));
        }

        public void LoadSubmissions()
        {
            SubmissionRepository submissionRepository = new SubmissionRepository();
            submissions = submissionRepository.GetSubmissionsByAssignmentId(AssignmentId);
            trendingSubmissions = submissions.OrderByDescending(s => s.Likes).Take(5).ToList();
        }
    }
}
