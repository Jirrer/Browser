
class BK_Tree
{
    private BK_Node root;

    private int getDistance(string wordInDict, string targetWord)
    {
        int m = wordInDict.Length;
        int n = targetWord.Length;

        int[,] dp = new int[m + 1, n + 1];

        for (int i = 0; i <= m; i++)
            dp[i, 0] = i;
        for (int j = 0; j <= n; j++)
            dp[0, j] = j;

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                int cost = (wordInDict[i - 1] == targetWord[j - 1]) ? 0 : 1;

                dp[i, j] = Math.Min(
                    Math.Min(
                        dp[i - 1, j] + 1,
                        dp[i, j - 1] + 1),
                    dp[i - 1, j - 1] + cost);
            }
        }

        return dp[m, n];
    }

    public BK_Tree(String rootInput)
    {
        this.root = new BK_Node(rootInput);
    }

    public void Add(string word)
    {
        AddRecursive(this.root, word);

    }

    private void AddRecursive(BK_Node currentNode, string word)
    {
        int distance = getDistance(currentNode.name, word);

        if (!currentNode.children.ContainsKey(distance))
        {
            currentNode.children[distance] = new BK_Node(word);
        }
        else
        {
            AddRecursive(currentNode.children[distance], word);
        }

    }


    public List<string> Search(string target, int maxDistance)
    {
        var results = new List<string>();
        SearchRecursive(root, target, maxDistance, results);
        return results;
    }

    private void SearchRecursive(BK_Node node, string target, int maxDistance, List<string> results)
    {
        if (node == null) return;

        int dist = getDistance(node.name, target);

        if (dist <= maxDistance)
            results.Add(node.name);

        int start = dist - maxDistance;
        int end = dist + maxDistance;

        foreach (var child in node.children)
        {
            int childDist = child.Key;
            if (childDist >= start && childDist <= end)
            {
                SearchRecursive(child.Value, target, maxDistance, results);
            }
        }
    }

 
    
    
}

class BK_Node
{
    public string name { get; }
    public Dictionary<int, BK_Node> children { get; }

    public BK_Node(string nodeInput)
    {
        this.name = nodeInput;
        this.children = new Dictionary<int, BK_Node>();
    }
}