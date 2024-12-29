using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Models.DTO
{
    [Table("UserSubmissionRatings")]
    public class UserSubmissionRating
    {
        public int AssignmentId { get; set; }
        public int UserId { get; set; }
        public int SubmissionId { get; set; }
        public double Rating { get; set; }

        public UserSubmissionRating(int assignmentId, int userId, int submissionId, double rating)
        {
            AssignmentId = assignmentId;
            UserId = userId;
            SubmissionId = submissionId;
            Rating = rating;
        }

        public UserSubmissionRating()
        {
            
        }

    }
}
