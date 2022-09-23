namespace Athenaeum.Tree
{
    public class PrefixTreeStartsWith
    {
        private readonly TrieNode _root = new();

        public void Insert(string word)
        {
            if (string.IsNullOrEmpty(word)) return;

            foreach (var character in word)
            {
                _root[character] ??= new TrieNode();
            }

            _root.Tail = true;
        }

        public bool StartsWith(string prefix)
        {
            if (string.IsNullOrEmpty(prefix)) return false;

            var current = _root;

            foreach (var character in prefix)
            {
                var trieNode = current[character];

                if (trieNode == null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}