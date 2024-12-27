using InleverenWeek4MobileDev.ViewModels;

namespace InleverenWeek4MobileDev.Models;

public partial class Store : ContentPage
{
	public Store()
	{
		InitializeComponent();
		BindingContext = new StoreViewModel();
	}
}