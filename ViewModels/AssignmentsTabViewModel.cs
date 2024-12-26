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
            LoadAssignmentData(assignmentId);
        }

        public void LoadAssignmentData(int assignmentId)
        {
            AssignmentRepository assignmentRepository = new AssignmentRepository();
            Assignment = assignmentRepository.GetAssignmentById(assignmentId);
            GetHeaderImage();
        }

        public void GetHeaderImage()
        {
            SubmissionRepository submissionRepository = new SubmissionRepository();
            Models.Submission mostPopular = submissionRepository.GetMostPopularSubmission(Assignment.Id);
           
            if(mostPopular == null)
            {
                HeaderImage = "fiftytwo.svg";
            }
            else
            {
                HeaderImage = mostPopular.Image;
            }
        }
    }
}
