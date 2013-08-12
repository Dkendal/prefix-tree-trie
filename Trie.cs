using System.Collections.Generic;

public class Trie {
  private TrieNode root;

  public Trie() {
    root = new TrieNode();
  }

  private TrieNode this[string key] {
    get {
      var node = root;
      foreach( char ch in key ) {
        if( node.ContainsKey( ch ) )
          node = node[ch];
        else
          return null;
      }
      return node;
    }
  }

  public void Add(string word) {
    var node = root;
    foreach( char ch in word ) {
      node = node.FindOrCreate( ch );
    }
    node.EndsWord = true;
  }

  public List<string> PartialLookup(string partial) {
    var wordList = new List<string>();
    var node = this[partial];
    if (node != null)
      node.ToList( ref wordList );
    return wordList;
  }
}