using DataAccess;
using Services.Interfaces;
using Models.Enums;

namespace Services.Implementations
{
    public class UIService : IUIService
    {
        private readonly IUserService _userService;
        public UIService()
        {
            _userService = new UserService();
        }
        public void Login()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please login!");
                    Console.Write("Username: ");
                    var username = Console.ReadLine();

                    Console.Write("Password: ");
                    var password = Console.ReadLine();

                    _userService.Login(username, password);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Sucessfull Login! Welcome {CurrentSession.CurrentUser.FirstName} - [{CurrentSession.CurrentUser.Role}]");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public void LogOut()
        {
            Console.WriteLine("Thanks you for using our app");
            _userService.LogOut();
        }

        public void ShowMenu()
        {
            if (CurrentSession.CurrentUser == null)
            {
                Login();
                return;
            }

            Console.WriteLine("Please select option from the meny: ");
            switch (CurrentSession.CurrentUser.Role)
            {
                case RoleEnum.Admin:
                    ShowAdminMenu();
                    break;
            }
        }

        public void ShowAdminMenu()
        {
            Console.WriteLine("1. Create new user");
            Console.WriteLine("2. Terminate user");
            Console.WriteLine("3. Log Out");
            int option = ChooseAnOption(1, 3);

            switch (option)
            {
                case 1:
                    CreateNewUser();
                    break;

            }
        }

        private int ChooseAnOption(int min, int max)
        {
            Console.Write("Please choose an option: ");
            var input = Console.ReadLine();

            while (true)
            {
                if (!int.TryParse(input, out int number))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input, try again!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                if (number >= min && number <= max)
                {
                    return number;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Wrong input, range: {min} - {max}, try again!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
            }
        }

        private void CreateNewUser()
        {
            while (true)
            {
                try { 
                Console.WriteLine("Please add info for the new userL ");
                Console.Write("First name: ");
                var firstName = Console.ReadLine();
                Console.Write("Last name: ");
                var lastName = Console.ReadLine();
                Console.Write("Username: ");
                var username = Console.ReadLine();
                Console.Write("Password: ");
                var password = Console.ReadLine();
                Console.WriteLine("Select role (1. Admin; 2. Maintenance; 3. Manager; 4.Driver): ");
                var roleNUmber = ChooseAnOption((int)RoleEnum.Admin, (int)RoleEnum.Driver);

                if (roleNUmber == (int)RoleEnum.Driver)
                {
                    Console.Write("License number: ");
                    var licenseNumber = Console.ReadLine();
                    Console.Write("License expiry date: ");
                    var licenseExpiryDate = Console.ReadLine();
                    _userService.CreateUser(firstName, lastName, username, password, licenseNumber, licenseExpiryDate);
                }
                else
                {
                    _userService.CreateUser(firstName, lastName, username, password, (RoleEnum)roleNumber);
                }
                break;
                }
                catch (Exception ex) 
                {

                }
            }
        }
        private DateTime InsertDate()
        {
            var input = Console.ReadLine();

            while (true)
            {
                if (!DateTime.TryParse(input, out DateTime number))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input, try again!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                if (date > DateTime.Now)
                {
                    return number;
                }
            }
        }
    }
}
