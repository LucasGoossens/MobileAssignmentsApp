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

            foreach (var submission in trendingSubmissions)
            {
                System.Diagnostics.Debug.WriteLine("Count and average");
                System.Diagnostics.Debug.WriteLine(submission.Rating.Count);
                System.Diagnostics.Debug.WriteLine(submission.Rating.Average);
            }
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

            UserSubmissionRatingRepository userSubmissionRatingRepository = new UserSubmissionRatingRepository();

            foreach (var submission in submissions)
            {
                submission.Rating = userSubmissionRatingRepository.GetUserAverageBySubmissionId(submission.Id);
            }

            trendingSubmissions.Clear();
            trendingSubmissions = submissionRepository.GetMostPopularSubmission(AssignmentId);

            foreach (var submission in trendingSubmissions)
            {               
                    submission.Rating = userSubmissionRatingRepository.GetUserAverageBySubmissionId(submission.Id);                
            }

        }
    }
}