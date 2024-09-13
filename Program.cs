using User_login_page;

ProfileController controller = new ProfileController();

controller.SignUp();

Console.Write("Enter Email to sign in: ");
string email = Console.ReadLine();

Console.Write("Enter Password: ");
string password = Console.ReadLine();

Profile signedInUser = controller.SignIn(email, password);

if (signedInUser != null)
{
    controller.Update(signedInUser);

    Console.WriteLine("Do you want to delete your profile? (yes/no)");
    if (Console.ReadLine().ToLower() == "yes")
    {
        controller.Delete(signedInUser);
    }
}
