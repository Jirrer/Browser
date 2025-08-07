using System.Formats.Asn1;

public class Website
{
    private uint ip;
    private string domain;
    private string username = "";
    private string password = "";


    public bool logginStatus = false;
    
    public Website(uint ipInput, string domainInput)
    {
        this.ip = ipInput;
        this.domain = domainInput;
    }

    public string getDomain() { return this.domain; }

    public bool setPassword(string oldUser, string oldPassword) {
        if (login(oldUser, oldPassword))
        {
            Console.Write("Enter new user: "); string? username = Console.ReadLine();
            Console.Write("Enter new password: "); string? password = Console.ReadLine();

            this.username = username;
            this.password = password;

            return true;
        }

        return false;
    }
    public bool login(string username, string password)
    {
        if (username == this.username && password == this.password) { logginStatus = true;  return true; }
        else { return false; }
    }

}