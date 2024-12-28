using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class AssignmentsTabViewModel
    {
        public Assignment Assignment { get; set; }
        public string HeaderImage { get; set; }


        public AssignmentsTabViewModel(int assignmentId)
        {
            System.Diagnostics.Debug.WriteLine("AssignmentsViewModel 1");
            LoadAssignmentData(assignmentId);
            System.Diagnostics.Debug.WriteLine("AssignmentsViewModel 5");
        }

        public void LoadAssignmentData(int assignmentId)
        {            
            AssignmentRepository assignmentRepository = new AssignmentRepository();
            Assignment = assignmentRepository.GetAssignmentById(assignmentId);
            System.Diagnostics.Debug.WriteLine("AssignmentsViewModel 2");
            GetHeaderImage();
        }

        public void GetHeaderImage()
        {
            try
            {
                SubmissionRepository submissionRepository = new SubmissionRepository();

                if (Assignment == null)
                {
                    System.Diagnostics.Debug.WriteLine("Assignment is null.");
                    HeaderImage = "fiftytwo.svg";
                    return;
                }

                if (Assignment.Id <= 0)
                {
                    System.Diagnostics.Debug.WriteLine($"Invalid Assignment.Id: {Assignment.Id}");
                    HeaderImage = "fiftytwo.svg";
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"Assignment Id: {Assignment.Id}");

                var mostPopular = submissionRepository.GetMostPopularSubmission(Assignment.Id);
                System.Diagnostics.Debug.WriteLine("Retrieved most popular submission.");

                HeaderImage = mostPopular?.Image ?? "fiftytwo.svg";
                System.Diagnostics.Debug.WriteLine($"HeaderImage set to: {HeaderImage}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in GetHeaderImage: {ex.StackTrace}");
                HeaderImage = "fiftytwo.svg"; // Fallback image
            }
        }



    }
}
