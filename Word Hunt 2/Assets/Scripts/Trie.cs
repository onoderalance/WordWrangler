using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; private set; }
    public bool IsEndOfWord { get; set; }

    public TrieNode()
    {
        Children = new Dictionary<char, TrieNode>();
        IsEndOfWord = false;
    }
}

public class Trie
{
    private TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    // Insert a word into the Trie
    public void Insert(string word)
    {
        var currentNode = root;
        foreach (var ch in word)
        {
            if (!currentNode.Children.ContainsKey(ch))
            {
                currentNode.Children[ch] = new TrieNode();
            }
            currentNode = currentNode.Children[ch];
        }
        currentNode.IsEndOfWord = true;
    }

    // Search for a word in the Trie
    public bool Search(string word)
    {
        var currentNode = root;
        foreach (var ch in word)
        {
            if (!currentNode.Children.ContainsKey(ch))
            {
                return false;
            }
            currentNode = currentNode.Children[ch];
        }
        return currentNode.IsEndOfWord;
    }

    // Check if there's any word in the Trie that starts with the given prefix
    public bool StartsWith(string prefix)
    {
        var currentNode = root;
        foreach (var ch in prefix)
        {
            if (!currentNode.Children.ContainsKey(ch))
            {
                return false;
            }
            currentNode = currentNode.Children[ch];
        }
        return true;
    }
}