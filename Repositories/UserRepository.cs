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
    public class UserRepository
    {

        public SQLiteConnection connection;
        public string? statusMessage { get; set; }

        public UserRepository()
        {
            connection = new SQLiteConnection(
               Constants.DatabasePath,
               Constants.flags);

            connection.CreateTable<User>();

        }

        public void AddOrUpdate(User member)
        {
            int result = 0;        
            if (member.Id == 0)
            {
                member.Discriminator = "Member";
                result = connection.Insert(member);
                statusMessage = string.Format("{0} record(s) added [Name: {1})", result, member.Name);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("User updated." );
                result = connection.Update(member);
                statusMessage = string.Format("{0} record(s) updated [Name: {1})", result, member.Name);
            }
        }


        public int LoginUser(string username, string password)
        {            
            var users = connection.Table<User>();           

            foreach (var user in users)
            {
                System.Diagnostics.Debug.WriteLine("user.Name");
                System.Diagnostics.Debug.WriteLine(user.Name);

                System.Diagnostics.Debug.WriteLine("user.Password");
                System.Diagnostics.Debug.WriteLine(user.Password);
            }

            var loggedInUser = connection.Table<User>()
                .FirstOrDefault(u => u.Name == username && u.Password == password);
            

            if(loggedInUser == null)
            {                
                return 0;
            }

            return loggedInUser.Id;
        }

        public User GetUserById(int userId)
        {
            return connection.Table<User>().FirstOrDefault(u => u.Id == userId);
        }


    }
}
