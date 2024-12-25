using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Repositories;
using InleverenWeek4MobileDev.Session;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class CreateChallengeViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string imagePath;

        private readonly ContentPage Page;
        public CreateChallengeViewModel(ContentPage page)
        {
            Page = page;
        }
        public bool SubmitEnabled => !string.IsNullOrWhiteSpace(Title) &&
                          !string.IsNullOrWhiteSpace(Description) &&
                          !string.IsNullOrWhiteSpace(ImagePath);

        [RelayCommand(CanExecute = nameof(SubmitEnabled))]
        public async void SubmitChallenge()
        {
            ChallengeRepository challengeRepository = new ChallengeRepository();
            Challenge challenge = new Challenge();
            challenge.Title = title;
            challenge.Description = description;
            challenge.ImageSource = imagePath;
            challenge.CreatorId = UserSession.Instance.UserId;
            challengeRepository.AddOrUpdate(challenge);
            
            MemberChallengeRepository memberChallengeRepository = new MemberChallengeRepository();
            memberChallengeRepository.SignUp(UserSession.Instance.UserId, challenge.Id);

            Page.DisplayAlert("Challenge Created!", $"Created {title}!", "OK");
            await Application.Current.MainPage.Navigation.PushAsync(new AllChallenges());
        }

        [RelayCommand]
        public async void PickFromDeviceAsync()
        {            
            FileResult file = await MediaPicker.PickPhotoAsync();
            if (file == null)
                return;

            string filePath = Path.Combine(FileSystem.CacheDirectory, file.FileName);

            using Stream sourceStream = await file.OpenReadAsync();

            using FileStream localFileStream = File.OpenWrite(filePath);

            await sourceStream.CopyToAsync(localFileStream);

            ImagePath = filePath;
        }
    }
}
