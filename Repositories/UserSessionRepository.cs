using InleverenWeek4MobileDev.Database;
using InleverenWeek4MobileDev.Session;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Repositories
{
    public class UserSessionRepository
    {

        public SQLiteConnection connection;
        public string? statusMessage { get; set; }

        public UserSessionRepository()
        {
            connection = new SQLiteConnection(
               Constants.DatabasePath,
               Constants.flags);
            connection.CreateTable<UserSession>();
        }

        public void LogInUser(UserSession userSession)
        {          
            int result = connection.Insert(userSession);
            statusMessage = string.Format("{0} record(s) added [UserId: {1}] [IsLoggedIn: {2}]", result, userSession.UserId, userSession.IsLoggedIn);
            System.Diagnostics.Debug.WriteLine(statusMessage);
            System.Diagnostics.Debug.WriteLine("Test 10");
        }


        public void LogOutUser()
        {
            connection.DeleteAll<UserSession>();
            statusMessage = "User logged out. All session records deleted.";
        }


        public int GetLoggedInUserId()
        {
            //var session = connection.Table<UserSession>();
            //System.Diagnostics.Debug.WriteLine("all sessions:");
            //foreach (var ses in session)
            //{
            //    System.Diagnostics.Debug.WriteLine("session:");
            //    System.Diagnostics.Debug.WriteLine(ses.UserId);
            //    System.Diagnostics.Debug.WriteLine(ses.IsLoggedIn);
            //}
            var session = connection.Table<UserSession>().FirstOrDefault(s => s.IsLoggedIn == true);
            return session?.UserId ?? 0;
        }

    }
}
