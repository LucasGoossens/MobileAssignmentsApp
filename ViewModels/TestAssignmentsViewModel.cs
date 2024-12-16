using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Repositories;
using System.Collections.ObjectModel;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class TestAssignmentsViewModel : ObservableObject
    {
        private readonly AssignmentRepository _assignmentRepository;

        public TestAssignmentsViewModel()
        {
            _assignmentRepository = new AssignmentRepository();
            Assignments = new ObservableCollection<AssignmentDisplay>();
        }

        // Properties for new assignment inputs
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

        // Properties for filtering assignments
        [ObservableProperty]
        private string filterChallengeId;

        // Observable collection to bind the retrieved assignments
        public ObservableCollection<AssignmentDisplay> Assignments { get; set; }

        // Command to add a new assignment
        [RelayCommand]
        public void AddAssignment()
        {
            if (string.IsNullOrWhiteSpace(NewAssignmentTitle) || string.IsNullOrWhiteSpace(NewAssignmentDescription))
                return;

            // Build Guides dictionary
            var guides = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(GuideTitle1) && !string.IsNullOrWhiteSpace(GuideDescription1))
                guides.Add(GuideTitle1, GuideDescription1);
            if (!string.IsNullOrWhiteSpace(GuideTitle2) && !string.IsNullOrWhiteSpace(GuideDescription2))
                guides.Add(GuideTitle2, GuideDescription2);
            if (!string.IsNullOrWhiteSpace(GuideTitle3) && !string.IsNullOrWhiteSpace(GuideDescription3))
                guides.Add(GuideTitle3, GuideDescription3);

            // Create and save assignment
            var newAssignment = new Assignment
            {
                ChallengeId = int.Parse(FilterChallengeId), // Use filter ID as ChallengeId
                Title = NewAssignmentTitle,
                Description = NewAssignmentDescription,
                Guides = guides
            };

            _assignmentRepository.AddAssignment(newAssignment);

            // Clear inputs
            NewAssignmentTitle = string.Empty;
            NewAssignmentDescription = string.Empty;
            GuideTitle1 = string.Empty;
            GuideDescription1 = string.Empty;
            GuideTitle2 = string.Empty;
            GuideDescription2 = string.Empty;
            GuideTitle3 = string.Empty;
            GuideDescription3 = string.Empty;

            // Reload assignments
            LoadAssignments();
        }

        // Command to load assignments
        [RelayCommand]
        public void LoadAssignments()
        {
            if (!int.TryParse(FilterChallengeId, out int challengeId))
                return;

            var assignments = _assignmentRepository.GetAssignmentsByChallengeId(challengeId);

            // Clear and repopulate observable collection
            Assignments.Clear();
            foreach (var assignment in assignments)
            {
                Assignments.Add(new AssignmentDisplay
                {
                    Title = assignment.Title,
                    Description = assignment.Description,
                    GuidesDisplay = string.Join(", ", assignment.Guides.Select(g => $"{g.Key}: {g.Value}"))
                });
            }
        }

        // Helper class for displaying assignments
        public class AssignmentDisplay
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string GuidesDisplay { get; set; }
        }
    }
}
