using System;
using System.Linq;
using DataStorage.Data;

namespace DataStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var userRepository = new UserRepository();

                Console.WriteLine("Enter the user's first name");
                var firstName = Console.ReadLine();

                Console.WriteLine("Enter the user's last name");
                var lastName = Console.ReadLine();

                Console.WriteLine("Enter the user's password");
                var password = Console.ReadLine();

                var user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password
                };

                userRepository.Add(user);
                
                Console.WriteLine("Would you like to add another? (y/n)");
                var response = Console.ReadLine();

                if (response != "y")
                {
                    break;
                }
            }

            var otherRepository = new UserRepository();

            var users = otherRepository.GetAll()
                .Select(user => $"{user.FirstName} {user.LastName} has a password of {user.Password}");

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
    }
}
