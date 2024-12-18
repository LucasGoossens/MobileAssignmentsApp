using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Repositories;
using InleverenWeek4MobileDev.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class YourChallengesViewModel : ObservableObject
    {
        public List<Challenge> YourChallenges { get; set; }
        public YourChallengesViewModel()
        {
            LoadChallenges();
        }

        public void LoadChallenges()
        {
            ChallengeRepository challengeRepository = new ChallengeRepository();
            YourChallenges = challengeRepository.GetYourChallenges();
        }

        [RelayCommand]
        public async void NavigateToDetails(Challenge challenge){
            if (challenge == null) return;
            await Application.Current.MainPage.Navigation.PushAsync(new YourChallengesDetails(challenge.Id));
        }

        [RelayCommand]
        public async void NavigateToAssignmentsTest()
        {            
            await Application.Current.MainPage.Navigation.PushAsync(new TestAssignments());
        }

        [RelayCommand]
        public async void DeleteChallenge(Challenge challenge)
        {
            ChallengeRepository challengeRepository = new ChallengeRepository();
            challengeRepository.DeleteChallenge(challenge.Id);

        }
    }

}
