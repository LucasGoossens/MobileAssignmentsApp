using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InleverenWeek4MobileDev.Database;
using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Repositories;
using InleverenWeek4MobileDev.Session;
using SQLiteBrowser;
using System.Windows.Input;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class FrontpageViewModel : ObservableObject
    {
        public List<Challenge> TrendingChallenges { get; set; }
        public List<Challenge> RecentChallenges { get; set; }

        public string ProfilePicture { get; set; }

        public ICommand ShopCommand { get; }
        public ICommand ProfileCommand { get; }
        public ICommand LogOutCommand { get; }

        public FrontpageViewModel()
        {
            TrendingChallenges = new List<Challenge>();
            RecentChallenges = new List<Challenge>();
            ProfilePicture = UserSession.Instance.LoggedInUser.ProfilePicture;

            ShopCommand = new Command(async () => await GoToShop());
            ProfileCommand = new Command(async () => await GoToProfile());
            LogOutCommand = new Command(async () => await LogOut());

            LoadChallenges();
        }

        private void LoadChallenges()
        {
            ChallengeRepository challengeRepository = new ChallengeRepository();
            try
            {
                List<Challenge> allChallenges = challengeRepository.GetAllChallenges();
                RecentChallenges = allChallenges.Where(c => c.Participants.Any(p => p.Id == UserSession.Instance.UserId)).Take(6).ToList();

                TrendingChallenges = allChallenges.OrderByDescending(nc => nc.Participants.Count).Take(4).ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                throw;
            }

        }

        [RelayCommand]
        private async Task NavigateToSQLiteBrowser()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new DatabaseBrowserPage(Constants.DatabasePath));
        }


        [RelayCommand]
        private async Task NavigateToAssignments(int id)
        {
            MemberChallengeRepository memberChallengeRepository = new MemberChallengeRepository();

            if (memberChallengeRepository.CheckIfSignedUp(UserSession.Instance.UserId, id))
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Assignments(id));
            }
            else
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Views.ChallengeNotSignedUp(id));
            }

        }


        [RelayCommand]
        private async Task NavigateToAllChallenges()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AllChallenges());
        }



        private async Task GoToShop() => await Application.Current.MainPage.Navigation.PushAsync(new Store());
        private async Task GoToProfile() => await Application.Current.MainPage.Navigation.PushAsync(new Profile(UserSession.Instance.UserId));
        private async Task LogOut()
        {
            UserSession.Instance.ClearUser();
            await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        }
    }
}
