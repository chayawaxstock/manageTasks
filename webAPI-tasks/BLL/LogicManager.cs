
using _00_DAL;
using _01_BOL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace _02_BLL
{
    public static class LogicManager
    {

        public static List<User> GetAllUsers()
        {
            string query = $"SELECT * FROM managetasks.user;";

            Func<MySqlDataReader, List<User>> func = (reader) => {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                       UserName = reader.GetString(0),
                       Password=reader.GetString(1)
                    });
                }
                return users;
            };

            return DBAccess.RunReader(query, func);
        }

        public static string GetUserName(int id)
        {
            string query = $"SELECT Name FROM managetasks.user WHERE id={id}";
            return DBAccess.RunScalar(query).ToString();
        }

        public static bool RemoveUser(int id)
        {
            string query = $"DELETE FROM managetasks.user WHERE id={id}";
            return DBAccess.RunNonQuery(query) == 1;
        }

        public static bool UpdateUser(User user)
        {
            string query = $"UPDATE managetasks.user SET UserName='{user.UserName}'  WHERE Password={user.Password} ";
            return DBAccess.RunNonQuery(query) == 1;
        }

        public static bool AddUser(User user)
        {
            //TODO:איזה דפרטמנט
            string query = $"INSERT INTO `managetasks`.`user`(`userName`,`userComputer`,`password`,`email`) VALUES('{user.UserName}','{user.UserComputer}','{user.Password}',{user.Email}); ";
            return DBAccess.RunNonQuery(query) == 1;
        }
    }

   
}