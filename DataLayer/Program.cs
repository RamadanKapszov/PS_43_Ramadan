using DataLayer.Database;
using DataLayer.Model;
using Welcome.Others;

using (var context = new DatabaseContext()) 
{ 
    context.Database.EnsureCreated();
    context.Add<DatabaseUser>(new DatabaseUser()

    {
        Name = "user", 
        Password = "password", 
        Expires = DateTime.Now, 
        Role = UserRolesEnum.STUDENT 
    });

    Console.WriteLine("Please enter your username:");
    string username = Console.ReadLine();

    Console.WriteLine("Please enter your password:");
    string password = Console.ReadLine();

    if (context.Users.Any(u => u.Name.Equals(username) && u.Password.Equals(password))){

        Console.WriteLine("Валиден потребител");
    }
    else
    {
        Console.WriteLine("Невалидни данни");
    }

    context.SaveChanges() ; 
    var users = context.Users.ToList();
    Console.ReadKey(); 

} 