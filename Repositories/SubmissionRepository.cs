﻿using InleverenWeek4MobileDev.Database;
using SQLite;


namespace InleverenWeek4MobileDev.Repositories
{
    public class SubmissionRepository
    {
        SQLiteConnection connection;
        public string? statusMessage { get; set; }
        public SubmissionRepository()
        {
            connection = new SQLiteConnection(
            Constants.DatabasePath,
            Constants.flags);
            connection.CreateTable<Models.Submission>();
        }

        public void AddSubmission(Models.Submission submission)
        {
            connection.Insert(submission);
        }

        public List<Models.Submission> GetSubmissionsByAssignmentId(int assignmentId)
        {            
            var submissions = connection.Table<Models.Submission>()
                                         .Where(s => s.AssignmentId == assignmentId)
                                         .ToList();            
            return submissions;
        }

        public List<Models.Submission> GetMostPopularSubmission(int assignmentId)
        {
            UserSubmissionRatingRepository userSubmissionRatingRepository = new UserSubmissionRatingRepository();
            List<int> Top5MostPopularSubmissionIds = userSubmissionRatingRepository.GetMostPopularSubmissions(assignmentId);

            if (Top5MostPopularSubmissionIds == null || !Top5MostPopularSubmissionIds.Any())
            {
                System.Diagnostics.Debug.WriteLine("No popular submission IDs found.");
                return new List<Models.Submission>();
            }

            var mostPopular = connection.Table<Models.Submission>()
                                         .Where(s => Top5MostPopularSubmissionIds.Contains(s.Id))
                                         .OrderByDescending(s => s.Rating)
                                         .ToList();

            System.Diagnostics.Debug.WriteLine("Here");
            foreach (var i in mostPopular)
            {
                System.Diagnostics.Debug.WriteLine("AssignmentId: ");
                System.Diagnostics.Debug.WriteLine(i);
            }


            if (!mostPopular.Any())
            {             
                return connection.Table<Models.Submission>()
                                 .Where(s => s.AssignmentId == assignmentId)
                                 .Take(5)
                                 .ToList();
            }

            return mostPopular;                                       
                                         
        }        


        public Models.Submission GetSubmissionById(int submissionId)
        {
            return connection.Table<Models.Submission>().Where(s => s.Id == submissionId).FirstOrDefault();
        }

        public void UpdateSubmission(Models.Submission submission)
        {
            connection.Update(submission);
        }

        public void DeleteSubmission(Models.Submission submission)
        {
            connection.Delete(submission);
        }


    }
}
