
using Spectre.Console;

string fileName = @"D:\CSFiles_mf\Password_fake_mf_mf.txt";
string password_real = "";
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
        password_real = "";
        password_real = sr.ReadLine();
        LoginMode();
    }
}
catch (Exception Ex)
{
    Console.WriteLine(Ex.ToString());
}

void LoginMode()
{
    string password_written = AnsiConsole.Ask<string>("Write your password");

    if (password_written.Equals(password_real))
    {
        Console.WriteLine("Welcome :D");
    }
    else if (logintries > 2)
    {
        Console.WriteLine("Too many tries, reopen the program");
    }
    else if (!password_written.Equals(password_real))
    {
        Console.WriteLine("Wrong Password, " + logintries + " attemps done (Max 3)");
        logintries = logintries + 1;
        LoginMode();
    }
}