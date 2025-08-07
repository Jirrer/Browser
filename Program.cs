using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

class Program
{
    private static List<Website> websites = new List<Website>();
    private static Dictionary<string, Website> registeredDomains = new Dictionary<string, Website>();
    private static Dictionary<string, Dictionary<string, LoginCacheNodes>> cache = new Dictionary<string, Dictionary<string, LoginCacheNodes>>();

    static void constructCache()
    {
        Program.cache["loginStatus"] = new Dictionary<string, LoginCacheNodes>();

    }

    static void constructWebsite()
    {
        websites.Add(new Website(3232235777, "bluefalconnet"));
        websites.Add(new Website(167772161, "techspirehub"));
        websites.Add(new Website(2886729728, "neonfoxmedia"));
        websites.Add(new Website(3232236030, "ironcladsecure"));
        websites.Add(new Website(3232235786, "rapidcloudworks"));
        websites.Add(new Website(2154959208, "midnightpixel"));
        websites.Add(new Website(3405803777, "stormbytezone"));
        websites.Add(new Website(3232235521, "quietlynova"));
        websites.Add(new Website(167837953, "zenithforge"));
        websites.Add(new Website(2886794753, "emberframe"));

        foreach (Website website in websites)
        {
            Program.registeredDomains[website.getDomain()] = website;
        }
    }

    static void Main(string[] args)
    {
        constructWebsite();
        while (true)
        {
            Console.Write("Search: ");
            string? name = Console.ReadLine();

            if (name != null)
            {
                List<string> results = search(name);
                showSearch(results);
            }
        }
    }


    static List<string> search(string targetWord)
    {
        int maxDistance = 5;

        BK_Tree searchAlgorithm = new BK_Tree(registeredDomains.First().Key);
        foreach (string domain in registeredDomains.Keys.Skip(1)) { searchAlgorithm.Add(domain); }

        List<string> results = searchAlgorithm.Search(targetWord, maxDistance);
        return results;
    }
    static void showSearch(List<string> results)
    {
        int pageCount = 0;
        foreach (string page in results)
        {
            Console.WriteLine($"{pageCount} - {page}");
            pageCount++;
        }

        Console.Write("Enter Web Page #: ");
        string? action = Console.ReadLine();

        int actionNumber;

        if (int.TryParse(action, out actionNumber) && actionNumber >= 0 && actionNumber < results.Count)
        {
            if (actionNumber < 0) { Environment.Exit(0); }
            else { Console.WriteLine($"\nVisiting - {results[actionNumber]}"); vistedPage(registeredDomains[results[actionNumber]]); }
        }
    }

    static void vistedPage(Website website)
    {  
        if (website.login("", ""))
        {
            cache["loginStatus"][website.getDomain()] = new LoginCacheNodes(true);


        }


    }
}
