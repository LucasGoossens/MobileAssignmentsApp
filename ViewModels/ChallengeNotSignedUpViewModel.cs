using Bogus;
using CommunityToolkit.Mvvm.Input;
using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Models.DTO;
using InleverenWeek4MobileDev.Repositories;
using InleverenWeek4MobileDev.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class ChallengeNotSignedUpViewModel
    {        
        public ChallengeNotSignedUpDTO Challenge { get; set; }
        public ChallengeNotSignedUpViewModel(int challengeId)
        {
            LoadChallengeData(challengeId);
        }

        public void LoadChallengeData(int challengeId)
        {
            ChallengeRepository challengeRepository = new ChallengeRepository();
            Challenge = challengeRepository.GetChallengeNotSignedUp(challengeId);
            MemberChallengeRepository memberChallengeRepository = new MemberChallengeRepository();            
        }

        [RelayCommand]
        public async void SignUp()
        {
            MemberChallengeRepository memberChallengeRepository = new MemberChallengeRepository();
            memberChallengeRepository.SignUp(UserSession.Instance.UserId, Challenge.Id);
            App.Current.MainPage.DisplayAlert("Sign Up", $"You have signed up for {Challenge.Title}!", "OK");
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
