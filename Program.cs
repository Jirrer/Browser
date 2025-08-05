using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("     ___Browser Name___     ");
        Console.WriteLine("|----------------------------------------------------------------------------------------------------------------|");
        Console.WriteLine("|                                                                                                                |");

        int inputY = Console.CursorTop;
        int inputX = 3;

        Console.WriteLine("|----------------------------------------------------------------------------------------------------------------|");

        Console.SetCursorPosition(inputX, inputY - 2);

        string name = Console.ReadLine();


        if (name != null) { Console.SetCursorPosition(0, inputY); search(name);}

    }

    static void search(string targetWord)
    {
        int maxDistance = 5;
        String[] registeredDomains = { "Website One", "Test website", "web two", "Number Four" }; // make file

        BK_Tree searchAlgorithm = new BK_Tree(registeredDomains[0]);
        for (int index = 1; index < registeredDomains.Length; index++)
        {
            searchAlgorithm.Add(registeredDomains[index]);
        }

        List<string> results = searchAlgorithm.Search(targetWord, maxDistance);

        foreach (string word in results) {
            Console.WriteLine(word);
        }
    }
}