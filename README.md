# Word Wrangler
 A Unity Word Search Game <br/> <br/>
<img src="https://github.com/user-attachments/assets/8965eb27-5a11-4ab6-97bd-587e9a9287b2" width="600">
## Overview
 Word Wrangler is a word search game built in Unity. The object of the game is to drag your mouse across letter tiles to create as many words as possible within the time limit. Words must be at least three letters long, and longer words will yield more points. Compete with your friends for better scores by sharing random generation seeds! <br/> <br/>
<img src="https://github.com/user-attachments/assets/530b9da1-00ae-4f89-ba62-d66fda5d5811" width="600">
<img src="https://github.com/user-attachments/assets/6f4b6d52-d017-47d2-a7d0-9f4ac2227f85" width="600">

## Features
- Randomized grid generation
- Efficient grid validation utilizing Trie-based DFS algorithm
- Approachable UI/UX featuring sleek minimalist western aesthetic
- Comprehensive gameplay statistics
- Customizable seed generation system allowing for pseudo-multiplayer

## Trials and Tribulations
- Initially, our grid validation process was based solely on using a DFS based algorithm to compare all possible words on the grid to hashset of valid words. At best, this approach took upwards of one minute to validate the whole board, and at worst would cause the program to crash. \
  &rarr; We instead stored words into a Trie data structure, allowing the DFS to short circuit and improving efficiency greatly. Now, it takes only a trivial amount of time to validate the entire 4x4 grid for words.
  
- We wanted to implement a lightweight multiplayer system \
  &rarr; To implement this in a quick and simple way, we decided to base the grid generation on an inputted seed. By default, the seed is based on a key generated from the user's system time, however it can be overwritten with any integer value. Because of this option, you can share the seed with friends so that you can play the same board :)

