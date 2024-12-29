using InleverenWeek4MobileDev.Database;
using InleverenWeek4MobileDev.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Repositories
{
    public class CommentRepository
    {
        SQLiteConnection connection;
        public string? statusMessage { get; set; }
        public CommentRepository()
        {
            connection = new SQLiteConnection(
            Constants.DatabasePath,
            Constants.flags);
            connection.CreateTable<Comment>();
        }

        public void AddComment(Comment comment)
        {
            connection.Insert(comment);
        }
        public void UpdateComment(Comment comment)
        {
            connection.Update(comment);
        }

        public void DeleteComment(Comment comment)
        {
            connection.Delete(comment);
        }

        public List<Comment> GetAllCommentsBySubmissionId(int submissionId)
        {
            var comments = connection.Table<Comment>()
                .Where(c => c.SubmissionId == submissionId)
                .ToList();            

            if (comments == null || comments.Count == 0)
            {
                return new List<Comment>();
            }

            var userIds = comments.Select(c => c.UserId).Distinct().ToList();            

            var users = connection.Table<User>()
                .Where(u => userIds.Contains(u.Id))
                .ToList();
            
            foreach (var comment in comments)
            {
                comment.User = users.FirstOrDefault(u => u.Id == comment.UserId);
            }

            return comments;
        }



    }
}
