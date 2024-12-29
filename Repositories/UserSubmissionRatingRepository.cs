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



    }
}
