using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InleverenWeek4MobileDev.Repositories;
using InleverenWeek4MobileDev.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class StoreViewModel : ObservableObject
    {        
        public Models.User LoggedInUser { get; set; }
        public StoreViewModel()
        {
            LoggedInUser = UserSession.Instance.LoggedInUser; 
        }

        [RelayCommand]
        public void AddOnePoint()
        {
            LoggedInUser.Credits++;
            UpdateUserCredits();
        }

        [RelayCommand]
        public void AddTenPoints()
        {
            LoggedInUser.Credits += 10;
            UpdateUserCredits();
        }

        [RelayCommand]
        public void BuySuperMember()
        {
            UserRepository userRepository = new UserRepository();
            LoggedInUser.Discriminator = "Supermember";
            userRepository.AddOrUpdate(LoggedInUser);

            UserSession.Instance.Initialize();
            LoggedInUser = UserSession.Instance.LoggedInUser;
        }
        public void UpdateUserCredits()
        {
            UserRepository userRepository = new UserRepository();
            userRepository.AddOrUpdate(LoggedInUser);

            UserSession.Instance.Initialize();
            LoggedInUser = UserSession.Instance.LoggedInUser;            
        }
    }
}
