using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Repositories;
using InleverenWeek4MobileDev.ViewModels;
namespace InleverenWeek4MobileDev.Views
{
    public partial class YourChallengesDetails : ContentPage
    {
        public int ChallengeId { get; set; }
        public YourChallengesDetails(int challengeId)
        {
            InitializeComponent();
            ChallengeId = challengeId;
            BindingContext = new YourChallengeDetailsViewModel(challengeId);
        }
    }
}

