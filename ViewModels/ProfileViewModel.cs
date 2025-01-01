using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Models.DTO;
using InleverenWeek4MobileDev.Repositories;
using InleverenWeek4MobileDev.Session;
using System.Collections.ObjectModel;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class ProfileViewModel : ObservableObject
    {

        public User Profile { get; set; }
        public List<Challenge> CreatedChallenges { get; set; }
        public int CompletedCount { get; set; }
        public int CreatedCount { get; set; }
        public UserAverage AverageRating { get; set; }

        public ObservableCollection<string> StarEmojisCollection { get; set; } = new ObservableCollection<string>();
        public List<Models.Submission> RecentSubmissions { get; set; }

        public UserAverage Rating { get; set; }
        public ProfileViewModel()
        {
            
        }
        public ProfileViewModel(int userId)
        {
            try { 
            CreatedChallenges = new List<Challenge>();
            RecentSubmissions = new List<Models.Submission>();

            if (userId == UserSession.Instance.UserId)
            {
                Profile = UserSession.Instance.LoggedInUser;
            }
            else
            {
                UserRepository userRepository = new UserRepository();
                Profile = userRepository.GetUserById(userId);
            }

            ChallengeRepository challengeRepository = new ChallengeRepository();

            CompletedCount = challengeRepository.GetChallengeCompletedCountByUserId(userId);
            CreatedChallenges = challengeRepository.GetYourChallenges(userId);
            CreatedCount = CreatedChallenges?.Count ?? 0;

            UserSubmissionRatingRepository userSubmissionRatingRepository = new UserSubmissionRatingRepository();

            AverageRating = userSubmissionRatingRepository.GetTotalUserAverageByUserId(userId);

            SubmissionRepository submissionRepository = new SubmissionRepository();
            RecentSubmissions = submissionRepository.GetSubmissionsByCreatorId(userId);

            StarEmojisCollection.Clear();
            int starCount = (int)Math.Round(AverageRating.Average);
            
            for (int i = 0; i < starCount; i++)
            {
                StarEmojisCollection.Add("⭐");
            }

            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR :");                
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }

        }

        [RelayCommand]
        public async Task NavigateToChallenge(int challengeId)
        {
            MemberChallengeRepository memberChallengeRepository = new MemberChallengeRepository();

            if (memberChallengeRepository.CheckIfSignedUp(UserSession.Instance.UserId, challengeId))
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Assignments(challengeId));
            }
            else
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Views.ChallengeNotSignedUp(challengeId));
            }
        }


        [RelayCommand]
        public async void NavigateToSubmission(int submissionId)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Submission(submissionId));
        }

    }
}
