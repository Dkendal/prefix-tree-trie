using System;
using System.Reflection;
using PrefixTree;

namespace PrefixTreeExtensions {
  public static class TrieDecorator {

    public static void PrintGraph(this Trie trie) {
      var node = typeof( Trie ).GetField( "root", BindingFlags.NonPublic | BindingFlags.Instance ).GetValue( trie ) as TrieNode;
      node.PrintGraph();
    }

    internal static void PrintGraph(this TrieNode node, int indent = 0) {
      foreach( char key in node.Keys ) {
        if( node[key].EndsWord )
          Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine( String.Concat( new string( ' ', indent ), key ) );
        Console.ResetColor();
        node[key].PrintGraph( indent + 1 );
      }
    }
  }
}