using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Linq;

namespace User_login_page
{
    internal class ProfileController
    {
        public ArrayList Profiles { get; set; }

        public ProfileController()
        {
            Profiles = new ArrayList();
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool IsValidPassword(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }

            bool hasUpperCase = password.Any(char.IsUpper);
            return hasUpperCase;
        }

        public void SignUp()
        {
            string name, surname, email, password;
            int age;

            Console.Write("Enter Name: ");
            name = Console.ReadLine();

            Console.Write("Enter Surname: ");
            surname = Console.ReadLine();

            Console.Write("Enter Age: ");
            age = int.Parse(Console.ReadLine());

            // Validate email
            do
            {
                Console.Write("Enter Email: ");
                email = Console.ReadLine();
                if (!IsValidEmail(email))
                {
                    Console.WriteLine("Invalid email format. Please enter a valid email (e.g., example@gmail.com).");
                }
            } while (!IsValidEmail(email));

            // Validate password
            do
            {
                Console.Write("Enter Password (at least 8 characters and one uppercase letter): ");
                password = Console.ReadLine();
                if (!IsValidPassword(password))
                {
                    Console.WriteLine("Password must be at least 8 characters long and contain at least one uppercase letter.");
                }
            } while (!IsValidPassword(password));


            Profile newProfile = new Profile(name, surname, age, email, password, UserRole.user);
            Profiles.Add(newProfile);

            Console.WriteLine($"{name} {surname} has signed up successfully.");
        }

        public Profile SignIn(string email, string password)
        {
            foreach (Profile profile in Profiles)
            {
                if (profile.Email == email && profile.Password == password)
                {
                    Console.WriteLine($"Sign in successful. Welcome {profile.Name} {profile.Surname}.");
                    return profile;
                }
            }

            Console.WriteLine("Invalid email or password.");
            return null;
        }

        public void Update(Profile profile)
        {
            Console.WriteLine("What would you like to update? (1. Name, 2. Surname, 3. Age, 4. Email, 5. Password)");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter new name: ");
                    profile.Name = Console.ReadLine();
                    break;
                case "2":
                    Console.Write("Enter new surname: ");
                    profile.Surname = Console.ReadLine();
                    break;
                case "3":
                    Console.Write("Enter new age: ");
                    profile.Age = int.Parse(Console.ReadLine());
                    break;
                case "4":
                    Console.Write("Enter new email: ");
                    profile.Email = Console.ReadLine();
                    break;
                case "5":
                    Console.Write("Enter new password: ");
                    profile.Password = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine("Profile updated successfully.");
        }

        public void Delete(Profile profile)
        {
            Profiles.Remove(profile);
            Console.WriteLine("Profile deleted successfully.");
        }
    }
}
