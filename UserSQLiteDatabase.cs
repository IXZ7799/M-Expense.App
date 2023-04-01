using Microsoft.Maui.Storage;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace M_Expense
{
    public class UserSQLiteDatabase
    {
        static SQLiteConnection databaseConnection;
        public const string DbFileName = "UserDB.db3";
        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache;
        public static string DatabasePath = "";
        public string CurrentState;

        public const string USER_TABLE = "User";
        public const string ID_COLUMN = "ID";
        public const string TRIPNAME_COLUMN = "TripName";
        public const string DESTINATION_COLUMN = "Destination";
        public const string TRIPDATE_COLUMN = "Trip Date";
        public const string RISKASSESSMENT_COLUMN = "RiskAssessment";
        public const string DESCRIPTION_COLUMN = "TripDesc";
        public const string PEOPLEATTENDING_COLUMN = "PeopleAttending";
        public const string TRANSPORTATION_COLUMN = "Transportation";
        public const string ImageName_COLUMN = "ImageName";

        public const string DEFAULT_IMAGE = "default_image.svg";
        public static string[] imageNames = new string[]
        {
            "earth_africa", "earth_americas", "earth_asia", "earth_europe", "earth_oceania"
    };

        public UserSQLiteDatabase()
        {
            Init();
        }

        private void Init()
        {
            try
            {
                if (databaseConnection != null)
                {
                    CurrentState = "Database exists";
                    return;
                }
                DatabasePath = System.IO.Path.Combine(FileSystem.AppDataDirectory, DbFileName);
                databaseConnection = new SQLiteConnection(DatabasePath);
                databaseConnection.CreateTable<User>();
                CurrentState = "Database created";
            }
            catch (SQLite.SQLiteException ex)
            {
                CurrentState = ex.Message;
            }
        }

        public void resetDatabase()
        {
            try
            {
                databaseConnection.DropTable<User>();
                databaseConnection.CreateTable<User>();
            }
            catch (SQLite.SQLiteException ex)
            {
                CurrentState = ex.Message;
            }
        }

        public int SaveUser(User person)
        {
            if (person.ID > 0)
            {
                return databaseConnection.Update(person);
            }
            else
            {
                return databaseConnection.Insert(person);
            }
        }

        public List<User> GetUserList()
        {
            try
            {
                return databaseConnection.Table<User>().ToList();
            }
            catch (Exception ex)
            {
                CurrentState = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return new List<User>();
        }

        public List<User> SearchUserByName(string name)
        {
            try
            {
                return databaseConnection.Query<User>("SELECT * FROM " + USER_TABLE + " WHERE " + TRIPNAME_COLUMN + " LIKE '%' || ? || '%' OR " + DESTINATION_COLUMN + " LIKE '%' || ? || '%' OR " + TRIPDATE_COLUMN + " LIKE '%' || ? || '%';", new string[] { name, name });
            }
            catch (Exception ex)
            {
                CurrentState = string.Format("Failed to retrieve data {0}", ex.Message);
            }
            return new List<User>();
        }

        public int DeleteUser(User person)
        {
            try
            {
                return databaseConnection.Delete(person);
            }
            catch (Exception ex)
            {
                CurrentState = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return 0;
        }

        public int DeleteAllUsers()
        {
            try
            {
                return databaseConnection.DeleteAll<User>();
            }
            catch (Exception ex)
            {
                CurrentState = string.Format("Failed to retrieve data {0}", ex.Message);
            }
            return 0;
        }
    }
}
