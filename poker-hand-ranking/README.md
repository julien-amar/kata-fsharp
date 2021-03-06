# Poker Hand Ranking

## Goal

Evaluate a poker hand made of 5 different cards.

## Description

A poker deck contains 52 cards (no Jokers).  
The cards are split into four suits (clubs, diamonds, hearts, spades), each of which has 13 cards (2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King, Ace). In terms of scoring the suits are unordered, while the cards in each suit are ordered from 2 at the low end to A at the high.  
  
A poker hand consists of 5 cards. Hands are ranked by the following order:  
  
* **High Card**: Hands which do not fit any higher category are ranked by the value of their highest card. If the highest cards have the same value, the hands are ranked by the next highest, and so on.
* **Pair**: 2 of the 5 cards in the hand have the same value. Hands which both contain a pair are ranked by the value of the cards forming the pair. If these values are the same, the hands are ranked by the values of the cards not forming the pair, in decreasing order.
* **Two Pairs**: The hand contains 2 different pairs. Hands which both contain 2 pairs are ranked by the value of their highest pair. Hands with the same highest pair are ranked by the value of their other pair. If these values are the same the hands are ranked by the value of the remaining card.
* **Three of a Kind**: Three of the cards in the hand have the same value. Hands which both contain three of a kind are ranked by the value of the 3 cards.
* **Straight**: Hand contains 5 cards with consecutive values. Hands which both contain a straight are ranked by their highest card.
* **Flush**: Hand contains 5 cards of the same suit. Hands which are both flushes are ranked using the rules for High Card.
* **Full House**: 3 cards of the same value, with the remaining 2 cards forming a pair. Ranked by the value of the 3 cards.
* **Four of a kind**: 4 cards with the same value. Ranked by the value of the 4 cards.
* **Straight flush**: 5 cards of the same suit with consecutive values. Ranked by the highest card in the hand.
* **Royal flush**: A straight flush with the values ace to 10

_Source : http://codingdojo.org/cgi-bin/index.pl?KataPokerHands