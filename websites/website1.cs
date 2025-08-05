public class website1 : Iwebsite
{

    private string domain = "Website One";
    private int IP = 19216811;
    private bool status = true;

    public string getDomain() { return this.domain; }
    public int getIP() { return this.IP; }
    public bool ping() { return this.status; }
    

}