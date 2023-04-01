using System.Collections.ObjectModel;

namespace M_Expense;

public class UserCollection
{
    public static int IdUser = 0;
    public ObservableCollection<User> UserList;
    public const string DEFAULT_IMAGE = "default_image.svg";
    public static string[] imageNames = new string[] { "earth_africa", "earth_americas", "earth_asia", "earth_europe", "earth_oceania" };

    public UserCollection()
    {
        UserList = new ObservableCollection<User>();
    }
}