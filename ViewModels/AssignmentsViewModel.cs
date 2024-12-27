using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Repositories;
using InleverenWeek4MobileDev.Session;
using System.Collections.ObjectModel;

namespace InleverenWeek4MobileDev.ViewModels;

public partial class AssignmentsViewModel : ObservableObject
{

    public AssignmentsViewModel(int challengeId)
    {
        UnlockedAssignments = new ObservableCollection<Assignment>();
        CompletedAssignments = new ObservableCollection<Assignment>();
        LockedAssignments = new ObservableCollection<Assignment>();
        LoadChallengeData(challengeId);
    }


    public Challenge Challenge { get; set; }

    [ObservableProperty]
    private ObservableCollection<Assignment> unlockedAssignments;

    [ObservableProperty]
    private ObservableCollection<Assignment> completedAssignments;

    [ObservableProperty]
    private ObservableCollection<Assignment> lockedAssignments;

    private void LoadChallengeData(int challengeId)
    {        
        UnlockedAssignments.Clear();
        CompletedAssignments.Clear();
        LockedAssignments.Clear();

        ChallengeRepository challengeRepository = new ChallengeRepository();
        Challenge = challengeRepository.GetChallengeDetailsById(challengeId);

        MemberAssignmentRepository memberAssignmentRepository = new MemberAssignmentRepository();

        for (int i = 0; i < Challenge.Assignments.Count; i++)
        {
            Challenge.Assignments[i].Number = i + 1;

            string status = memberAssignmentRepository.GetAssignmentStatus(UserSession.Instance.UserId, Challenge.Assignments[i].Id);

            Challenge.Assignments[i].Status = status == null ? "Locked" : status;

            switch (Challenge.Assignments[i].Status)
            {
                case "Locked":
                    LockedAssignments.Add(Challenge.Assignments[i]);
                    break;
                case "Unlocked":
                    UnlockedAssignments.Add(Challenge.Assignments[i]);
                    break;
                case "Completed":
                    CompletedAssignments.Add(Challenge.Assignments[i]);
                    break;
            }
        }
    }


    [RelayCommand]
    public async void NavigateToAssignmentsTab(object parameter)
    {
        if (parameter is int Id)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AssignmentTabs(Id));
        }
    }


    [RelayCommand]
    public async void UnlockAssignment(Assignment assignment)
    {
        if (UserSession.Instance.LoggedInUser.Credits < 1)
        {
            await App.Current.MainPage.DisplayAlert(
                "Insufficient credits",
                "Not enough credits to unlock this assignment, please purchase more in our store.",
                "Close");
            return;
        }

        bool confirm = await App.Current.MainPage.DisplayAlert(
            $"Unlock {assignment.Title}?",
            "Spend 1 credit to unlock this assignment?",
            "Unlock",
            "Cancel");

        if (confirm)
        {
            // Deduct credits and unlock assignment
            UserSession.Instance.LoggedInUser.Credits -= 1;
            assignment.UnlockAssignment();

            // Update the collections dynamically
            LockedAssignments.Remove(assignment);
            UnlockedAssignments.Add(assignment);
        }
    }

}