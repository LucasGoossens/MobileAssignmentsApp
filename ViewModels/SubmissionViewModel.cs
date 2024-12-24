using InleverenWeek4MobileDev.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class SubmissionViewModel
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

    }
}
