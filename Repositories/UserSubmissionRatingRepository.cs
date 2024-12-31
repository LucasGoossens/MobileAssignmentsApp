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

        public bool CheckIfExists(UserSubmissionRating userSubmissionRating)
        {
            return connection.Table<UserSubmissionRating>()
                .Any(usr => usr.AssignmentId == userSubmissionRating.AssignmentId
                            && usr.UserId == userSubmissionRating.UserId
                            && usr.SubmissionId == userSubmissionRating.SubmissionId);
        }

        public void AddUserSubmissionRating(UserSubmissionRating userSubmissionRating)
        {
            connection.Insert(userSubmissionRating);
        }

        public void UpdateUserSubmissionRating(UserSubmissionRating userSubmissionRating)
        {
            var userSubmissionRatingToUpdate = connection.Table<UserSubmissionRating>()
                .Where(usr => usr.AssignmentId == userSubmissionRating.AssignmentId
                            && usr.UserId == userSubmissionRating.UserId
                            && usr.SubmissionId == userSubmissionRating.SubmissionId)
                .FirstOrDefault() ;

            userSubmissionRatingToUpdate.Rating = userSubmissionRating.Rating;

            connection.Update(userSubmissionRatingToUpdate);
        }

        public void DeleteUserSubmissionRating(UserSubmissionRating userSubmissionRating)
        {
            connection.Delete(userSubmissionRating);
        }

        public UserSubmissionRating GetUserSubmissionRatingBySubmissionIdAndUserId(int submissionId, int userId)
        {
            return connection.Table<UserSubmissionRating>().Where(usr => usr.SubmissionId == submissionId && usr.UserId == userId).FirstOrDefault();
        }
        
        public List<UserSubmissionRating> GetUserSubmissionRatingsByAssignmentId( int assignmentId)
        {
            return connection.Table<UserSubmissionRating>()
                .Where(usr => usr.AssignmentId == assignmentId)
                .ToList();
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


        public UserAverage GetUserAverageBySubmissionId(int submissionId)
        {
            List<UserSubmissionRating> allSubmissions = connection.Table<UserSubmissionRating>()
                .Where(usr => usr.SubmissionId == submissionId)
                .ToList();

            UserAverage userAverage = new UserAverage();
            foreach (var submission in allSubmissions)
            {
                userAverage.Count++;
                userAverage.Average += submission.Rating;
            }

            userAverage.Average /= userAverage.Count;
            return userAverage;
        }
    }
}
