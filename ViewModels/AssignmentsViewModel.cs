using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Repositories;
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

    
    public Challenge Challenge { get;set; }

    [ObservableProperty]
    private ObservableCollection<Assignment> unlockedAssignments;

    [ObservableProperty]
    private ObservableCollection<Assignment> completedAssignments;

    [ObservableProperty]
    private ObservableCollection<Assignment> lockedAssignments;

    private void LoadChallengeData(int challengeId)
    {
        ChallengeRepository challengeRepository = new ChallengeRepository();
        Challenge = challengeRepository.GetChallengeDetailsById(challengeId);        
        
        for (int i = 0; i < Challenge.Assignments.Count; i++)
        {    
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


    //// Mock Challenge
    //Challenge = new Challenge
    //{
    //    Description = "This is a sample challenge with various assignments.",
    //    Assignments = new List<Assignment>
    //    {
    //        new Assignment { Title = "Unlocked Assignment 1", Description = "This is unlocked 1" },
    //        new Assignment { Title = "Unlocked Assignment 2", Description = "This is unlocked 2" },
    //        new Assignment { Title = "Completed Assignment 1", Description = "This is completed 1" },
    //        new Assignment { Title = "Locked Assignment 1", Description = "This is locked 1" }
    //    }
    //};

    //// Separate Assignments into categories
    //UnlockedAssignments = new ObservableCollection<Assignment>(Challenge.Assignments.Where(a => a.Title.Contains("Unlocked")));
    //CompletedAssignments = new ObservableCollection<Assignment>(Challenge.Assignments.Where(a => a.Title.Contains("Completed")));
    //LockedAssignments = new ObservableCollection<Assignment>(Challenge.Assignments.Where(a => a.Title.Contains("Locked")));
}

