
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
                        UserId = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        Password = reader.GetString(2),
                        Email = reader.GetString(3),
                        UserComputer = reader.GetString(4),
                        NumHoursWork = reader.GetDecimal(5)

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
            string query = $"UPDATE managetasks.user SET UserName='{user.UserName}',Password='{user.Password}',Email='{user.Email}',UserComputer='{user.UserComputer}',NumHoursWork={user.NumHoursWork}  WHERE UserId={user.UserId} ";
            return DBAccess.RunNonQuery(query) == 1;
        }

        public static bool AddUser(User user)
        {
            //TODO:איזה דפרטמנט
            string query = $"INSERT INTO `managetasks`.`user`(`userName`,`userComputer`,`password`,`email`,`numHoursWork`) VALUES('{user.UserName}','{user.UserComputer}','{user.Password}',{user.Email},{user.NumHoursWork}); ";
            return DBAccess.RunNonQuery(query) == 1;
        }
    }

   
}