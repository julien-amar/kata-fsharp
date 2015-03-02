# Roman Numerals Kata

## Goal

We're thinking of doing things a bit more classical. Arabic numbering systems are just so 'modern' that we don't really feel they adequately represent what our company is all about. For this project we would like you to design a program to work with Roman numerals- converting arabic numbers to their Roman numeral equivalent and vice versa, and also some rudimentary calculations.

## Description

The Romans wrote their numbers using letters; specifically the letters "I, V, X, L, C, D, and M." There were certain rules that the numerals followed which should be observed.

* The symbols 'I', 'X', 'C', and 'M' can be repeated at most 3 times in a row. 'V', 'L', and 'D' can never be repeated.
* As arabic numbers can be split into their constituent parts (1066 becomes 1 0 6 6), so too can Roman numerals, just without the zero (1066 becomes MLXVI, or M (1000) LX (60) and VI (6)).
* The '1' symbols ('I', 'X', and 'C') can only be subtracted from the 2 next highest values ('IV' and 'IX', 'XL' and 'XC', 'CD' and 'CM'). The '5' symbols ('V', 'L', and 'D') can never be subtracted.
* Only one subtraction can be made per numeral ('XC' is allowed, 'XXC' is not).

We have provided a reference table of the Roman numerals that you will have to use and their arabic number equivalents.

| Numeral | Number |
| ------- | ------ |
| I       | 1      |
| V       | 5      |
| X       | 10     |
| L       | 50     |
| C       | 100    |
| D       | 500    |
| M       | 1000   |

## Iteration 1

For the first iteration we would like to be able to convert our arabic numbers into Roman numerals. At first the only people who are going to be using this are our game designers who will be numbering their game releases and release dates.

### Implement Arabic to Roman

As a games designer  
I want to pass in an arabic number and get a Roman numeral back  
So that I can correctly label my game releases using Roman numerals 

* When an arabic number is passed, the correct Roman numeral is returned.
* Make sure all Roman numerals between 1 and 3000 are returned correctly.

_Source : http://agilekatas.co.uk/katas/romannumerals-kata.html_
