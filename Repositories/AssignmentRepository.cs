using InleverenWeek4MobileDev.Database;
using InleverenWeek4MobileDev.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Repositories
{
    public class AssignmentRepository
    {
        SQLiteConnection connection;
        public string? statusMessage { get; set; }
        public AssignmentRepository()
        {
            connection = new SQLiteConnection(
            Constants.DatabasePath,
            Constants.flags);
            connection.CreateTable<Assignment>();
            
        }

        public void AddAssignment(Assignment assignment)
        {
            connection.Insert(assignment);                        
        }


        public List<Assignment> GetAssignmentsByChallengeId(int challengeId)
        {
            var assignments = connection.Table<Assignment>()
                                         .Where(a => a.ChallengeId == challengeId)
                                         .ToList();

            foreach (var assignment in assignments)
            {
                if (!string.IsNullOrEmpty(assignment.GuidesJson))
                {
                    assignment.Guides = JsonSerializer.Deserialize<Dictionary<string, string>>(assignment.GuidesJson);
                }
            }

            return assignments;
        }


        public void UpdateAssignment(Assignment assignment)
        {
            connection.Update(assignment);
        }
        
        public void DeleteAssignment(Assignment assignment)
        {
            connection.Delete(assignment);
        }


    }
}
