using _00_DAL;
using _01_BOL;
using BOL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class LogicProjects
    {

        public static List<Project> GetAllProjects()
        {
            string query = $"SELECT * FROM managetasks.project;";

            Func<MySqlDataReader, List<Project>> func = (reader) => {
                List<Project> projects = new List<Project>();
                while (reader.Read())
                {
                    projects.Add(new Project
                    {
                        Id = reader.GetInt32(0),
                        ProjectName = reader.GetString(1),
                        CustomerName = reader.GetString(2),
                        numHourForProject=reader.GetDecimal(3),
                        DateBegin=reader.GetDateTime(4),
                        DateEnd=reader.GetDateTime(5),
                        IsFinish=reader.GetBoolean(6),
                        IdManager =reader.GetInt32(7)
                    });
                }
                return projects;
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
