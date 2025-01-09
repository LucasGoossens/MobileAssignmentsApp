using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Repositories;
using System.Collections.ObjectModel;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class AssignmentSubmissionsViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<Models.Submission> submissions;
        [ObservableProperty]
        private List<Models.Submission> trendingSubmissions;

        [ObservableProperty]
        private bool isRefreshing;
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
        public async Task Refresh()
        {
            try
            {
                // Refresh the submissions
                LoadSubmissions();
            }
            finally
            {
                // End the refreshing animation
                IsRefreshing = false;
            }
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
            Submissions.Clear();
            Submissions = submissionRepository.GetSubmissionsByAssignmentId(AssignmentId);

            UserSubmissionRatingRepository userSubmissionRatingRepository = new UserSubmissionRatingRepository();
            UserRepository userRepository = new UserRepository();

            foreach (var submission in submissions)
            {
                submission.Rating = userSubmissionRatingRepository.GetUserAverageBySubmissionId(submission.Id);
                submission.Creator = userRepository.GetUserById(submission.CreatorId);
            }

            TrendingSubmissions.Clear();
            TrendingSubmissions = submissionRepository.GetMostPopularSubmission(AssignmentId);

            foreach (var submission in trendingSubmissions)
            {
                submission.Rating = userSubmissionRatingRepository.GetUserAverageBySubmissionId(submission.Id);
                submission.Creator = userRepository.GetUserById(submission.CreatorId);
            }

        }
    }
}