using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class AssignmentSubmissionsViewModel
    {
        public int AssignmentId { get; }

        public AssignmentSubmissionsViewModel(int assignmentId)
        {
            AssignmentId = assignmentId;            
        }

        [RelayCommand]
        public void SubmitEntryCommand()
        {

        }
        
    }

}
