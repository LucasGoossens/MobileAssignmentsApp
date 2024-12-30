using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InleverenWeek4MobileDev.Repositories;
using InleverenWeek4MobileDev.Views;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class SubmissionViewModel : ObservableObject
    {
        public Models.Submission submission { get; set; }
        public SubmissionViewModel(int submissionId)
        {
            LoadSubmission(submissionId);
        }

        public SubmissionViewModel()
        {
            
        }

        public void LoadSubmission(int submissionId)
        {
            SubmissionRepository submissionRepository = new SubmissionRepository();
            submission = submissionRepository.GetSubmissionById(submissionId);
        }


        [RelayCommand]
        public void ProfileClicked()
        {
            // click
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
