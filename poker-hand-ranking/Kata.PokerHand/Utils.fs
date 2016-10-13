namespace PokerHand

open Types

module Utils =
    let ByFigure (card: Card) = fst card
    let BySuit (card: Card) = snd card
