using CommunityToolkit.Mvvm.ComponentModel;
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
            submissions = new List<Models.Submission>();
            trendingSubmissions = new List<Models.Submission>();
            LoadSubmissions();
        }

        public AssignmentSubmissionsViewModel()
        {

        }

        [RelayCommand]
        public async void SubmitEntry()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new PhotoPickerModal(AssignmentId));
            LoadSubmissions();
        }

        [RelayCommand]
        public async void NavigateToSubmission(int submissionId)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Submission(submissionId));
        }

        public void LoadSubmissions()
        {
            SubmissionRepository submissionRepository = new SubmissionRepository();
            submissions.Clear();
            submissions = submissionRepository.GetSubmissionsByAssignmentId(AssignmentId);
            trendingSubmissions.Clear();
            trendingSubmissions = submissions.OrderByDescending(s => s.Likes).Take(5).ToList();
        }
    }
}