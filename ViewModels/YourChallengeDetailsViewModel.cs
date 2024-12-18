using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InleverenWeek4MobileDev.Database;
using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Repositories;
using System.Reflection.Metadata;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class YourChallengeDetailsViewModel : ObservableObject
    {
        private readonly ChallengeRepository _challengeRepository;
        private readonly AssignmentRepository _assignmentRepository;

        [ObservableProperty]
        private Challenge challenge;

        [ObservableProperty]
        private string newAssignmentTitle;

        [ObservableProperty]
        private string newAssignmentDescription;

        [ObservableProperty]
        private string guideTitle1;

        [ObservableProperty]
        private string guideDescription1;

        [ObservableProperty]
        private string guideTitle2;

        [ObservableProperty]
        private string guideDescription2;

        [ObservableProperty]
        private string guideTitle3;

        [ObservableProperty]
        private string guideDescription3;

        public YourChallengeDetailsViewModel(int challengeId)
        {
            _challengeRepository = new ChallengeRepository();
            _assignmentRepository = new AssignmentRepository();


            LoadChallenge(challengeId);
        }

        private void LoadChallenge(int challengeId)
        {
            // Fetch challenge details by ID and set to the Challenge property
            challenge = _challengeRepository.GetChallengeDetailsById(challengeId);
 
        }

        [RelayCommand]
        public void AddAssignment()
        {
            if (string.IsNullOrWhiteSpace(newAssignmentTitle) || string.IsNullOrWhiteSpace(newAssignmentDescription))
                return;

            // Build the Guides dictionary
            var guides = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(GuideTitle1) && !string.IsNullOrWhiteSpace(GuideDescription1))
                guides.Add(GuideTitle1, GuideDescription1);
            if (!string.IsNullOrWhiteSpace(GuideTitle2) && !string.IsNullOrWhiteSpace(GuideDescription2))
                guides.Add(GuideTitle2, GuideDescription2);
            if (!string.IsNullOrWhiteSpace(GuideTitle3) && !string.IsNullOrWhiteSpace(GuideDescription3))
                guides.Add(GuideTitle3, GuideDescription3);

            // Create the new Assignment
            var newAssignment = new Assignment
            {
                ChallengeId = Challenge.Id, // Assuming Challenge is bound and available
                Title = newAssignmentTitle,
                Description = newAssignmentDescription,
                Guides = guides
            };

            // Save to the repository
            _assignmentRepository.AddAssignment(newAssignment);

            // Clear the inputs
            newAssignmentTitle = string.Empty;
            newAssignmentDescription = string.Empty;
            GuideTitle1 = string.Empty;
            GuideDescription1 = string.Empty;
            GuideTitle2 = string.Empty;
            GuideDescription2 = string.Empty;
            GuideTitle3 = string.Empty;
            GuideDescription3 = string.Empty;

            // Optionally, reload assignments for the UI
            Challenge.Assignments = _assignmentRepository.GetAssignmentsByChallengeId(Challenge.Id);

            foreach(var assignment in Challenge.Assignments)
            {
                System.Diagnostics.Debug.WriteLine(assignment.Id);
                

                //foreach (KeyValuePair<string, string> kvp in assignment.Guides)
                //{
                //    System.Diagnostics.Debug.WriteLine(kvp.Key);
                //    System.Diagnostics.Debug.WriteLine(kvp.Value);
                //}

            }

        }

    }
}
