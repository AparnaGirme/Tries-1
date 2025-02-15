// TC -> O(n)
// SC -> O(n)

public class Solution
{
    public class TrieNode
    {
        public TrieNode[] children;
        public bool isEnd;

        public TrieNode()
        {
            children = new TrieNode[26];
            isEnd = false;
        }
    }

    TrieNode root;
    // Dictionary<int, List<string>> lookup = new();
    int maxIsEnd = 0;
    string longestString = "";
    // int maxLength = 0;

    public void Insert(string word)
    {
        var curr = root;
        foreach (var c in word)
        {
            var index = c - 'a';
            if (curr.children[index] == null)
            {
                curr.children[index] = new TrieNode();
            }
            curr = curr.children[index];
        }
        curr.isEnd = true;
    }
    public string LongestWord(string[] words)
    {
        if (words == null || words.Length == 0)
        {
            return string.Empty;
        }

        root = new TrieNode();
        Array.Sort(words);
        foreach (var word in words)
        {
            Insert(word);
        }

        string result = "";
        foreach (var word in words)
        {
            if (IsValid(word) && word.Length > result.Length)
            {
                result = word;
            }
        }
        return result;
    }

    public bool IsValid(string word)
    {
        var curr = root;
        foreach (var w in word)
        {
            var index = w - 'a';
            if (curr.children[index] == null || !curr.children[index].isEnd)
            {
                return false;
            }
            curr = curr.children[index];
        }
        return true;
    }
}