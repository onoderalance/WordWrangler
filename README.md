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
- Initially, our grid validation process was based solely on DFS comparison to hashset of valid words, which was super slow and would cause the program to crash \
  &rarr; We instead stored words into a Trie data structure, allowing the DFS to short circuit and improving efficiency greatly
- We wanted to implement a lightweight multiplayer system \
  &rarr; We decided to have the option to enter a seed number you can share with friends to play the same board :)
