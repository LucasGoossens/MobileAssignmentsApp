using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InleverenWeek4MobileDev.Models.DTO;
using InleverenWeek4MobileDev.Repositories;
using InleverenWeek4MobileDev.Session;
using System.Collections.ObjectModel;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class RatingModalViewModel : ObservableObject
    {
        public partial class Star : ObservableObject
        {
            public int Id { get; set; }

            [ObservableProperty]
            private string? imageSource;
        }

        Models.Submission Submission { get; set; }
        public double SubmittedRating { get; set; }

        [ObservableProperty]
        private ObservableCollection<Star> stars;
        public RatingModalViewModel()
        {

        }
        public RatingModalViewModel(Models.Submission submission)
        {
            Submission = submission;

            UserSubmissionRatingRepository userSubmissionRatingRepository = new UserSubmissionRatingRepository();
            
            Stars = new ObservableCollection<Star>
                {
                    new Star { Id = 1, ImageSource = "star_nofill" },
                    new Star { Id = 2, ImageSource = "star_nofill" },
                    new Star { Id = 3, ImageSource = "star_nofill" },
                    new Star { Id = 4, ImageSource = "star_nofill" },
                    new Star { Id = 5, ImageSource = "star_nofill" }
                };

            if (userSubmissionRatingRepository.CheckIfExists(new UserSubmissionRating(Submission.AssignmentId, UserSession.Instance.UserId, Submission.Id, 0)))
            {
                SubmittedRating = userSubmissionRatingRepository.GetUserSubmissionRatingBySubmissionIdAndUserId(Submission.Id, UserSession.Instance.UserId).Rating;
                StarTapped((int)SubmittedRating);
            }          

        }

        [RelayCommand]
        public void StarTapped(int starId)
        {
            for (int i = 0; i < stars.Count; i++)
            {
                stars[i].ImageSource = i < starId ? "star_icon" : "star_nofill";
            }

            SubmittedRating = starId;
        }

        [RelayCommand]
        private async Task CloseModal()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        [RelayCommand]
        public void RateSubmitted()
        {
            UserSubmissionRating userSubmissionRating = new UserSubmissionRating(Submission.AssignmentId, UserSession.Instance.UserId, Submission.Id, SubmittedRating);

            UserSubmissionRatingRepository userSubmissionRatingRepository = new UserSubmissionRatingRepository();

            if (userSubmissionRatingRepository.CheckIfExists(userSubmissionRating))
            {
                userSubmissionRatingRepository.UpdateUserSubmissionRating(userSubmissionRating);
            }
            else
            {
                userSubmissionRatingRepository.AddUserSubmissionRating(userSubmissionRating);
            }

            Application.Current.MainPage.DisplayAlert("Submitted", "Rating submitted!", "OK");
        }

    }
}
