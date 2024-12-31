using InleverenWeek4MobileDev.Database;
using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Models.DTO;
using InleverenWeek4MobileDev.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SQLite.SQLite3;

namespace InleverenWeek4MobileDev.Repositories
{
    public class ChallengeRepository
    {
        SQLiteConnection connection;
        public string? statusMessage { get; set; }

        public ChallengeRepository()
        {
            connection = new SQLiteConnection(
               Constants.DatabasePath,
               Constants.flags);
            connection.CreateTable<Challenge>();
        }


        public async void AddOrUpdate(Challenge challenge)
        {
            int result = 0;
            if (challenge.Id == 0)
            {
                result = connection.Insert(challenge);
                statusMessage = string.Format("{0} record(s) added [Name: {1})", result, challenge.Title);
            }
            else
            {
                result = connection.Update(challenge);
                statusMessage = string.Format("{0} record(s) updated [Name: {1})", result, challenge.Title);

            }


        }

        public List<Challenge> GetAllChallenges()
        {
            // Fetch all challenges
            var challenges = connection.Table<Challenge>().ToList();

            foreach (var challenge in challenges)
            {
                // For each challenge, fetch its participants
                challenge.Participants = GetParticipantsByChallengeId(challenge.Id);
            }

            return challenges;
        }


        public List<User> GetParticipantsByChallengeId(int challengeId)
        {
            return connection.Query<User>(
                @"SELECT u.* 
          FROM Users u
          JOIN MemberChallenge mc ON u.Id = mc.MemberId
          WHERE mc.ChallengeId = ?",
                challengeId);
        }


        public List<Challenge> GetYourChallenges(int creatorId)
        {
            var challenges = connection.Table<Challenge>()
                .Where(c => c.CreatorId == creatorId)
                .ToList();

            if (challenges.Count == 0)
            {
                return null;
            }

            return challenges;

        }

        public Challenge GetChallengeDetailsById(int id)
        {
            Challenge challenge = connection.Table<Challenge>().FirstOrDefault(c => c.Id == id);

            AssignmentRepository assignmentRepository = new AssignmentRepository();
            challenge.Assignments = assignmentRepository.GetAssignmentsByChallengeId(id);

            return challenge;
        }
        public ChallengeNotSignedUpDTO GetChallengeNotSignedUp(int challengeId)
        {
            Challenge challenge = connection.Table<Challenge>().FirstOrDefault(c => c.Id == challengeId);
            ChallengeNotSignedUpDTO challengeNotSignedUpDTO = new ChallengeNotSignedUpDTO(challenge.Id, challenge.Title, challenge.ImageSource, challenge.Description);
            return challengeNotSignedUpDTO;

        }


        public int GetChallengeCompletedCountByUserId(int userId)
        {
            MemberChallengeRepository memberChallengeRepository = new MemberChallengeRepository();
            List<int> signedUpChallengesIds = memberChallengeRepository.GetAllSignedUpChallengesByUserId(userId);

            int completedCount = 0;

            MemberAssignmentRepository memberAssignmentRepository = new MemberAssignmentRepository();

            foreach (var challengeId in signedUpChallengesIds)
            {               
                List<Assignment> assignments = GetChallengeDetailsById(challengeId).Assignments;

                foreach (var assignment in assignments)
                {
                    assignment.Status = memberAssignmentRepository.GetAssignmentStatus(userId, assignment.Id);
                }

                if (assignments.All(a => a.Status == "Completed"))                
                {                    
                    completedCount++;
                }                
            }


            return completedCount;
        }

        public async void DeleteChallenge(int challengeId)
        {
            var challenge = connection.Find<Challenge>(challengeId);
            if (challenge != null)
            {
                connection.Delete(challenge);
            }
        }

    }
}
