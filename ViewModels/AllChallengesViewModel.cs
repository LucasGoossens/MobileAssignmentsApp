﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Repositories;
using InleverenWeek4MobileDev.Session;
using InleverenWeek4MobileDev.Views;
using System.Windows.Input;

namespace InleverenWeek4MobileDev.ViewModels
{

    public partial class AllChallengesViewModel : ObservableObject
    {
        public List<Challenge> TrendingChallenges { get; set; }
        public List<Challenge> NewChallenges { get; set; }
        public ICommand NavigateToCreateChallengeCommand { get; set; }

        public bool Supermember { get; set; } = false;

        public AllChallengesViewModel()
        {
            if(UserSession.Instance.LoggedInUser.Discriminator == "Supermember") {
                Supermember = true;
            }
            NavigateToCreateChallengeCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new CreateChallenge());
            });
            LoadChallenges();
        }

        [RelayCommand]
        public async Task NavigateToAssignments(object parameter)
        {
            if (parameter is int challengeId)
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
        }



        [RelayCommand]
        public async void NavigateToYourChallenges()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new YourChallenges());
        }
        public void LoadChallenges()
        {
            ChallengeRepository challengeRepository = new ChallengeRepository();
            try
            {
                NewChallenges = challengeRepository.GetAllChallenges();
                TrendingChallenges = NewChallenges.OrderByDescending(nc => nc.Participants.Count).Take(5).ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                throw;
            }

        }
    }
}
