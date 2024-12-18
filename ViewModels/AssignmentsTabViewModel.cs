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


        public AssignmentsTabViewModel(int assignmentId)
        {
            LoadAssignmentData(assignmentId);   
        }

        public void LoadAssignmentData(int assignmentId)
        {
            AssignmentRepository assignmentRepository = new AssignmentRepository();
            Assignment = assignmentRepository.GetAssignmentById(assignmentId);
        }
    }
}
