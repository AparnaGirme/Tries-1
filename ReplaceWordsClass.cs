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
    public string ReplaceWords(IList<string> dictionary, string sentence)
    {
        if (string.IsNullOrEmpty(sentence))
        {
            return string.Empty;
        }

        root = new TrieNode();
        foreach (var str in dictionary)
        {
            Insert(str);
        }
        StringBuilder result = new StringBuilder();
        string[] sentenceArray = sentence.Split(' ');
        for (int i = 0; i < sentenceArray.Length; i++)
        {
            if (i != 0)
            {
                result.Append(" ");
            }
            var curr = root;
            StringBuilder sb = new StringBuilder();
            foreach (var str in sentenceArray[i])
            {
                var index = str - 'a';
                if (curr.children[index] == null || curr.isEnd)
                {
                    break;
                }
                sb.Append(str);
                curr = curr.children[index];
            }
            if (curr.isEnd)
            {
                result.Append(sb.ToString());
                continue;
            }
            result.Append(sentenceArray[i]);
        }
        return result.ToString();
    }
}