namespace PokerHand

module Types =
    type Figure = 
        | Two  
        | Three 
        | Four 
        | Five 
        | Six  
        | Seven 
        | Eight 
        | Nine 
        | Ten  
        | Jack  
        | Queen 
        | King 
        | Ace

    type Suit =
        | Diamonds
        | Spades
        | Hearts
        | Clubs

    type Card = Figure * Suit

    type Hand = Card list
