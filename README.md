# Word Wrangler
 A Unity Word Search Game

## Overview
 Word Wrangler is a word search game built in Unity. The object of the game is to drag your mouse across letter tiles to create as many words as possible within the time limit. Words must be at least three letters long, and longer words will yield more points. Compete with your friends for better scores by sharing random generation seeds!

## Features
- Randomized grid generation
- Efficient grid validation utilizing Trie-based DFS algorithm
- Approachable UI/UX featuring sleek minimalist western aesthetic
- Comprehensive gameplay statistics
- Customizable seed generation system allowing for pseudo-multiplayer

## Trials and Tribulations
- Initially, our grid validation process was based solely on using a DFS based algorithm to compare all possible words on the grid to hashset of valid words. At best, this approach took upwards of one minute to validate the whole board, and at worst would cause the program to crash. \
  &rarr; We instead stored words into a Trie data structure, allowing the DFS to short circuit and improving efficiency greatly. Now, it takes only a second or two to validate the entire 4x4 grid for words.
- We wanted to implement a lightweight multiplayer system \
  &rarr; To implement this in a quick and simple way, we decided to base the grid generation on an inputted seed. By default, the seed is based on a key generated from the user's system time, however it can be overwritten with any integer value. Because of this option, you can share the seed with friends so that you can play the same board :)
