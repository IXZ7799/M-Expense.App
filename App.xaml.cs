namespace M_Expense;

public partial class App : Application
{
    public User selectedUser;
    private static UserSQLiteDatabase UserDB;
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    public static UserSQLiteDatabase UserDatabase
    {
        get
        {
            if (userDB == null)
            {
                userDB = new UserSQLiteDatabase();
            }
            return userDB;
        }
    }
}
