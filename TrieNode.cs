using System;
using System.Collections;
using System.Collections.Generic;

public class TrieNode : Hashtable {
  private TrieNode parent;
  private char? value;

  public TrieNode(char? value = null, TrieNode parent = null)
    : base() {
    this.parent = parent;
    this.value = value;
  }

  public bool EndsWord {
    get;
    set;
  }

  public TrieNode this[char key] {
    get { return base[key] as TrieNode; }
    set { base[key] = value; }
  }

  public TrieNode FindOrCreate(char ch) {
    return this[ch] = this[ch] ?? new TrieNode( ch, this );
  }

  public void ToList(ref List<string> wordList) {
    foreach( TrieNode node in Values ) {
      if( node.EndsWord )
        wordList.Add( node.ToString() );

      node.ToList( ref wordList );
    }
  }

  public override string ToString() {
    return String.Concat( parent == null ? "" : parent.ToString(), this.value );
  }
}