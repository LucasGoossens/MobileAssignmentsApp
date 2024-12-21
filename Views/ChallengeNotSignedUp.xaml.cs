using InleverenWeek4MobileDev.ViewModels;

namespace InleverenWeek4MobileDev.Views;

public partial class ChallengeNotSignedUp : ContentPage
{
	public ChallengeNotSignedUp(int challengeId)
	{
        InitializeComponent();
        BindingContext = new ChallengeNotSignedUpViewModel(challengeId);
    }


}