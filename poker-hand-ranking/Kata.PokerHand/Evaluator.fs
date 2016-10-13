namespace PokerHand

open Types
open Utils

module Evaluators =
    type Evaluator() = 
        let GroupCardsOf (hand: Hand, groupBy) =
            hand
            |> Seq.groupBy groupBy
            |> Seq.map (fun x -> (Seq.length (snd x), (fst x)))
            |> Seq.sortByDescending (fun x -> fst x)
            |> Seq.toList

        let (|IsOnePair|_|) (hand: Hand) =
            match GroupCardsOf (hand, ByFigure) with
            | (2, pair) :: _ -> Some(pair)
            | _ -> None

        let (|IsTwoPair|_|) (hand: Hand) =
            match GroupCardsOf (hand, ByFigure) with
            | (2, firstCards) :: (2, lastCards) :: _ -> Some((firstCards, lastCards))
            | _ -> None

        let (|IsThreeOfKind|_|) (hand: Hand) =
            match GroupCardsOf (hand, ByFigure) with
            | (3, firstCards) :: _ -> Some(firstCards)
            | _ -> None

        let (|IsFlush|_|) (hand: Hand) =
            match GroupCardsOf (hand, BySuit) with
            | (5, cardColor) :: _ -> Some(cardColor)
            | _ -> None

        let (|IsFullHouse|_|) (hand: Hand) =
            match GroupCardsOf (hand, ByFigure) with
            | (3, firstCards) :: (2, lastCards) :: _ -> Some((firstCards, lastCards))
            | _ -> None

        let (|IsFourOfKind|_|) (hand: Hand) =
            match GroupCardsOf (hand, ByFigure) with
            | (4, firstCards) :: _ -> Some(firstCards)
            | _ -> None

        let (|IsStraight|_|) (hand: Hand) =
            let straight = 
                hand
                |> Seq.map ByFigure
                |> Seq.sort
                |> Seq.toArray

            let firstCard = straight.[0];
            // TODO : Translate
            let handSize = straight.Length
            let previousLastCard = straight.[3];
            let lastCard = straight.[4];

            let straightLength = 
                straight
                |> Seq.pairwise
                |> Seq.filter (fun x -> compare(snd x)(fst x) = 1)
                |> Seq.length

            match straightLength with
            | 4 -> Some((firstCard, lastCard))
            | 3 when firstCard = Two && lastCard = Ace -> Some((lastCard, previousLastCard))
            | _ -> None

        let (|IsStraightFlush|_|) (hand: Hand) =
            match (hand) with
            | IsFlush suit & IsStraight (firstCard, lastCard) ->  Some((suit, (firstCard, lastCard)))
            | _ -> None

        member this.Evaluate (hand: Hand) =
            match (hand) with
            | IsStraightFlush (suit, (firstCard, lastCard)) -> sprintf "Straight flush (%A -> %A of %A)" firstCard lastCard suit
            | IsFourOfKind figure -> sprintf "Four of a kind (%A)" figure
            | IsFullHouse (firstCards, lastCards) -> sprintf "Full house (%A, %A)" firstCards lastCards
            | IsFlush suit -> sprintf "Flush (%A)" suit
            | IsStraight (firstCard, lastCard) -> sprintf "Straigth (%A -> %A)" firstCard lastCard
            | IsThreeOfKind firstCards -> sprintf "Three of a kind (%A)" firstCards
            | IsTwoPair (firstCards, lastCards) -> sprintf "Two pairs (%A, %A)" firstCards lastCards
            | IsOnePair firstCards -> sprintf "One pair (%A)" firstCards
            | _ ->  "Nothing"
