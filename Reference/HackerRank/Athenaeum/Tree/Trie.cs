namespace Athenaeum.Tree
{
    public class Trie
    {
        private readonly TrieNode _head;

        public Trie()
        {
            _head = new TrieNode();
        }

        /// <summary>
        /// O(N) where N is the length of the word
        /// O(N) where N is the length of thr word
        /// </summary>
        /// <param name="word"></param>
        public void Insert(string word)
        {
            var current = _head;

            foreach (var letter in word)
            {
                current = current[letter] ??= new TrieNode();
            }

            current.Tail = true;
        }

        /// <summary>
        /// O(N) where N is the length of the word
        /// O(N) where N is the length of thr word
        /// </summary>
        /// <param name="word"></param>
        public bool Search(string word)
        {
            var node = SearchToTail(word);
            return node?.Tail ?? false;
        }

        public bool StartsWith(string prefix)
        {
            return SearchToTail(prefix) != null;
        }

        private TrieNode SearchToTail(string prefix)
        {
            var current = _head;

            foreach (var letter in prefix)
            {
                current = current[letter];

                if (current == null)
                {
                    return null;
                }
            }

            return current;
        }
    }

    internal class TrieNode
    {
        private readonly TrieNode[] _suffixes = new TrieNode[26];

        internal TrieNode this[char c]
        {
            get => _suffixes[c - 'a'];
            set => _suffixes[c - 'a'] = value;
        }

        internal bool Tail { get; set; }
    }
}