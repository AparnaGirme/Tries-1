public class Trie
{
    class TrieNode
    {
        public TrieNode[] children;
        public bool isEnd;

        public TrieNode()
        {
            children = new TrieNode[26];
            isEnd = false;
        }
    }
    private TrieNode root;
    public Trie()
    {
        root = new TrieNode();
    }

    public void Insert(string word)
    {
        TrieNode curr = root;
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

    public bool Search(string word)
    {
        TrieNode curr = root;
        foreach (var c in word)
        {
            var index = c - 'a';
            if (curr.children[index] == null)
            {
                return false;
            }
            curr = curr.children[index];
        }
        return curr.isEnd;
    }

    public bool StartsWith(string prefix)
    {
        TrieNode curr = root;
        foreach (var c in prefix)
        {
            var index = c - 'a';
            if (curr.children[index] == null)
            {
                return false;
            }
            curr = curr.children[index];
        }
        return true;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */