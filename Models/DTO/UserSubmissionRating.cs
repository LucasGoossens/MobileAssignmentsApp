using SQLite;

namespace InleverenWeek4MobileDev.Models.DTO
{
    [Table("UserSubmissionRatings")]
    public class UserSubmissionRating
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
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
