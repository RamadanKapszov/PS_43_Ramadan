
using Welcome.Model;
using Welcome.Others;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;

internal class Program
{
    public static ActionOnError Log { get; private set; }

    private static void Main(string[] args)
    {
        try
        {
            
            //var user = new User("John Smith", "password123", UserRolesEnum.STUDENT);
            //var viewModel = new UserViewModel(user);
            //var view = new UserView(viewModel);
            //view.Display();
            //view.DisplayError();
            


            UserData userData = new UserData();
            User studentUser = new User()
            {
                Name = "student",
                Password = "123",
                Role = UserRolesEnum.STUDENT
            };

            

            User user1 = new User()
            {
                Name = "Student2",
                Password = "123",
                Role = UserRolesEnum.STUDENT
            };

            User user2 = new User()
            {

                Name = "Teacher",
                Password = "1234",
                Role = UserRolesEnum.PROFESSOR
            };

            User user3 = new User()
            {

                Name = "Admin",
                Password = "12345",
                Role = UserRolesEnum.ADMIN
            };
            userData.AddUser(studentUser);
            userData.AddUser(user1);
            userData.AddUser(user2);
            userData.AddUser(user3);

            // Prompt user to enter credentials
            Console.WriteLine("Please enter your username:");
            string username = Console.ReadLine();

            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();

            // Validate credentials
            string error = UserHelper.ValidateCredentials(userData, username, password);
            if (error != null)
            {
                throw new Exception("User not found");
            }

            // Get user
            User user = UserHelper.GetUser(userData, username, password);

            // Display user information
            Console.WriteLine(UserHelper.ToString(user));

            userData.AddUser(studentUser);
        }

        catch(Exception ex)
        {
            var log = new ActionOnError(Log);
            log(ex.Message);
        }
        finally
        {
            Console.WriteLine("Executed in any case!");
        }
    }
}