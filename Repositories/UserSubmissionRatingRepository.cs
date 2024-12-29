using InleverenWeek4MobileDev.Database;
using InleverenWeek4MobileDev.Models.DTO;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Repositories
{
    public class UserSubmissionRatingRepository
    {
        SQLiteConnection connection;
        public string? statusMessage { get; set; }
        public UserSubmissionRatingRepository()
        {
            connection = new SQLiteConnection(
            Constants.DatabasePath,
            Constants.flags);
            connection.CreateTable<UserSubmissionRating>();
        }

        public void AddUserSubmissionRating(UserSubmissionRating userSubmissionRating)
        {
            connection.Insert(userSubmissionRating);
        }

        public void UpdateUserSubmissionRating(UserSubmissionRating userSubmissionRating)
        {
            connection.Update(userSubmissionRating);
        }

        public void DeleteUserSubmissionRating(UserSubmissionRating userSubmissionRating)
        {
            connection.Delete(userSubmissionRating);
        }

        public List<UserSubmissionRating> GetUserSubmissionRatingsByAssignmentId( int assignmentId)
        {
            return connection.Table<UserSubmissionRating>()
                .Where(usr => usr.AssignmentId == assignmentId)
                .ToList();
        }

        public class UserAverage
        {
            public int Count;
            public double Average;
            public UserAverage()
            {

            }
        }

        public List<int> GetMostPopularSubmissions(int assignmentId)
        {
            List<UserSubmissionRating> allSubmissions = GetUserSubmissionRatingsByAssignmentId(assignmentId);

            Dictionary<int, UserAverage> averageRatings = new Dictionary<int, UserAverage>();

            foreach (var submission in allSubmissions)
            {
                if (!averageRatings.ContainsKey(submission.SubmissionId))
                {
                    averageRatings[submission.SubmissionId] = new UserAverage
                    {
                        Count = 1,
                        Average = submission.Rating
                    };
                }
                else
                {
                    var current = averageRatings[submission.SubmissionId];
                    current.Count++;
                    
                    current.Average = (current.Average * (current.Count - 1) + submission.Rating) / current.Count;

                    averageRatings[submission.SubmissionId] = current;
                }
            }
            
            List<int> mostPopularSubmissions = averageRatings
                .OrderByDescending(ar => ar.Value.Average) 
                .ThenByDescending(ar => ar.Value.Count)  
                .Take(5)
                .Select(ar => ar.Key)                    
                .ToList();

            return mostPopularSubmissions;
        }
    }
}
