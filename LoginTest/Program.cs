
using Spectre.Console;

string fileName1 = @"D:\CSFiles_mf\Username_fake_mf_mf.txt";
string fileName = @"D:\CSFiles_mf\Password_fake_mf_mf.txt";
string username1_real = "";
string password1_real = "";
int logintries = 1;
try
{
    if (File.Exists(fileName))
    {
        File.Delete(fileName);
    }

    using (StreamWriter sw = File.CreateText(fileName))
    {
        
        sw.WriteLine("pizza");
    }

    using (StreamReader sr = File.OpenText(fileName))
    {
        password1_real = "";
        password1_real = sr.ReadLine();
        UserLogin();
    }

    using (StreamWriter sw = File.CreateText(fileName1))
    {

        sw.WriteLine("Michalox");
    }

    using (StreamReader sr = File.OpenText(fileName1))
    {
        username1_real = "";
        username1_real = sr.ReadLine();
        UserLogin();
    }
}
catch (Exception Ex)
{
    Console.WriteLine(Ex.ToString());
}

void UserLogin()
{
    string Username_written = AnsiConsole.Ask<string>("Username:");

    if (Username_written.Equals(username1_real))
    {
        Console.WriteLine("User Found");
        LoginMode();
    }
    //else if (Username_written.Equals(username2_real))
    else
    {
        Console.WriteLine("Wrong Username!");
    }


}






void LoginMode()
{
    string password_written = AnsiConsole.Ask<string>("Password");

    if (password_written.Equals(password1_real))
    {
        Console.WriteLine("Welcome :D");
    }
    else if (logintries > 2)
    {
        Console.WriteLine("Too many tries, reopen the program");
    }
    else if (!password_written.Equals(password1_real))
    {
        Console.WriteLine("Wrong Password, " + logintries + " attemps done (Max 3)");
        logintries = logintries + 1;
        LoginMode();
    }
}