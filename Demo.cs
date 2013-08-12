using System;
using PrefixTree;

internal class Demo {

  private static void Main(string[] args) {
    Trie trie = new Trie();
    trie.Add( "hello" );
    trie.Add( "foobar" );
    trie.Add( "help" );
    trie.Add( "helpers" );
    trie.Add( "hellion" );
    trie.Add( "hebro" );
    trie.Add( "nooooooo" );
    trie.Add( "yolo" );
    foreach( string word in trie.PartialLookup( "hel" ) )
      Console.WriteLine( word );
    trie.PrintGraph();
    Console.ReadKey();
  }
}