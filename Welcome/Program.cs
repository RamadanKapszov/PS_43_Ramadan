using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;

namespace PS_43_Ramadan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Ramadan","123456",UserRolesEnum.ADMIN);
            UserViewModel userViewModel = new UserViewModel(user);
            UserView userView = new UserView(userViewModel);

            userView.Display();
            Console.ReadKey();
        }
    }
}