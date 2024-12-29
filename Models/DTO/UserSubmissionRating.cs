using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Models.DTO
{
    public class UserSubmissionRating
    {
        public int UserId { get; set; }
        public int SubmissionId { get; set; }
        public double Rating { get; set; }

        public UserSubmissionRating(int userId, int submissionId, double rating)
        {
            UserId = userId;
            SubmissionId = submissionId;
            Rating = rating;
        }
        
    }
}
