using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InleverenWeek4MobileDev.Repositories;
using InleverenWeek4MobileDev.Session;
using InleverenWeek4MobileDev.Views;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class SubmissionViewModel : ObservableObject
    {
        public Models.Submission submission { get; set; }
        public ObservableCollection<View> BottomButtons { get; private set; }
        public string CreatorProfilePicture { get; set; }
        [ObservableProperty]
        private Aspect aspectSize = Aspect.AspectFill;

        public SubmissionViewModel(int submissionId)
        {            
            BottomButtons = new ObservableCollection<View>();
            try
            {
                LoadSubmission(submissionId);
                PopulateBottomButtons();
                UserRepository userRepository = new UserRepository();
                CreatorProfilePicture = userRepository.GetUserById(submission.CreatorId).ProfilePicture;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
        }

        public SubmissionViewModel()
        {

        }

        public void LoadSubmission(int submissionId)
        {
            SubmissionRepository submissionRepository = new SubmissionRepository();
            submission = submissionRepository.GetSubmissionById(submissionId);
        }

        private void PopulateBottomButtons()
        {
            if (submission.CreatorId == UserSession.Instance.UserId)
            {
                BottomButtons.Add(new ImageButton
                {
                    Command = EditSubmissionCommand,
                    Source = "wand",
                    WidthRequest = 50,
                    HeightRequest = 50,
                    Opacity = 0.9,
                });
            }

            // Rating Button
            BottomButtons.Add(new ImageButton
            {
                Command = OpenRatingCommand,
                Source = "star_icon",
                WidthRequest = 35,
                HeightRequest = 35,
                Opacity = 0.9,
            });

            // Comment Button
            BottomButtons.Add(new ImageButton
            {
                Command = CommentsClickedCommand,
                Source = "comment_icon.svg",
                WidthRequest = 35,
                HeightRequest = 35,
                Opacity = 0.9,
                
            });
        }

        [RelayCommand]
        private void SubmissionTapped()
        {
            AspectSize = AspectSize == Aspect.AspectFill ? Aspect.AspectFit : Aspect.AspectFill;
        }

        [RelayCommand]
        public async void EditSubmission()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new EditSubmission(submission));
        }


        [RelayCommand]
        public async void ProfileClicked()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new Profile(submission.CreatorId));
        }

        [RelayCommand]
        public async void OpenRating()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new RatingModal(submission));
        }

        [RelayCommand]
        public void CommentsClicked()
        {
            App.Current.MainPage.Navigation.PushAsync(new Comments(submission.Id));
        }

    }
}
