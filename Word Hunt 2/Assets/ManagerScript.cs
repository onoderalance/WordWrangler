using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public Trie validWordsTrie;

    // Start is called before the first frame update
    void Awake()
    {
        validWordsTrie = new Trie();
        LoadWordsIntoTrie();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // load words from the text file into the Trie
    public void LoadWordsIntoTrie()
    {
        TextAsset wordFile = Resources.Load<TextAsset>("words");
        string[] words = wordFile.text.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            validWordsTrie.Insert(word.ToUpper());
        }
        Debug.Log($"Loaded {words.Length} words into the Trie.");
    }

    public bool isWordValid(string word)
    {
        if (word.Length <= 2) // Word must be at least 3 characters long
            return false;
        return validWordsTrie.Search(word.ToUpper());
    }

    public Trie GetTrie()
    {
        return validWordsTrie;
    }
}