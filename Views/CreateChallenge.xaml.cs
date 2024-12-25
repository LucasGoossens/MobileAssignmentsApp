using InleverenWeek4MobileDev.ViewModels;

namespace InleverenWeek4MobileDev.Views;

public partial class CreateChallenge : ContentPage
{
	public CreateChallenge()
	{
		InitializeComponent();
        BindingContext = new CreateChallengeViewModel(this);
    }
}