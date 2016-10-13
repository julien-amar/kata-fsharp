namespace PokerHand.Tests

open NUnit.Framework
open FsUnit

open PokerHand.Types
open PokerHand.Evaluators

[<TestFixture>]
type EvaluatorTests() = 
    let Evaluator = new Evaluator()

    let Shuffle (hand: Hand) =
        hand
        |> Seq.sortBy (fun x -> System.Guid.NewGuid())
        |> Seq.toList

    [<Test>] member this.NoValuableHand() =
        [(Two, Diamonds); (Three, Clubs); (Five, Spades); (Ten, Hearts); (Queen, Diamonds)]
        |> Shuffle
        |> Evaluator.Evaluate
        |> should equal "Nothing"

    [<Test>] member this.HandContainsOnePair() =
        [(Two, Diamonds); (Two, Clubs); (Five, Spades); (Ten, Hearts); (Queen, Diamonds)]
        |> Shuffle
        |> Evaluator.Evaluate
        |> should equal "One pair (Two)"

    [<Test>] member this.HandContainsTwoPair() =
        [(Two, Diamonds); (Two, Clubs);(Ace, Diamonds); (Ace, Clubs); (Queen, Diamonds)]
        |> Shuffle
        |> Evaluator.Evaluate
        |> should equal "Two pairs (Two, Ace)"

    [<Test>] member this.HandContainsThreeOfKind() =
        [(Two, Diamonds); (Two, Clubs); (Two, Spades); (Ace, Clubs); (Queen, Diamonds)]
        |> Shuffle
        |> Evaluator.Evaluate
        |> should equal "Three of a kind (Two)"

    [<Test>] member this.HandContainsHighStraight() =
        [(Ten, Diamonds); (Jack, Clubs); (Queen, Spades); (King, Clubs); (Ace, Diamonds)]
        |> Shuffle
        |> Evaluator.Evaluate
        |> should equal "Straigth (Ten -> Ace)"

    [<Test>] member this.HandContainsLowStraight() =
        [(Two, Diamonds); (Three, Clubs); (Four, Spades); (Five, Clubs); (Ace, Diamonds)]
        |> Shuffle
        |> Evaluator.Evaluate
        |> should equal "Straigth (Ace -> Five)"

    [<Test>] member this.HandContainsFlush() =
        [(Two, Diamonds); (Three, Diamonds); (Five, Diamonds); (Ten, Diamonds); (Queen, Diamonds)]
        |> Shuffle
        |> Evaluator.Evaluate
        |> should equal "Flush (Diamonds)"

    [<Test>] member this.HandContainsFullHouse() =
        [(Two, Diamonds); (Two, Clubs); (Two, Spades); (Ace, Clubs); (Ace, Diamonds)]
        |> Shuffle
        |> Evaluator.Evaluate
        |> should equal "Full house (Two, Ace)"

    [<Test>] member this.HandContainsFourOfKind() =
        [(Two, Diamonds); (Two, Clubs); (Two, Spades); (Two, Hearts); (Ace, Diamonds)]
        |> Shuffle
        |> Evaluator.Evaluate
        |> should equal "Four of a kind (Two)"

    [<Test>] member this.HandContainsHighStraightFlush() =
        [(Ten, Diamonds); (Jack, Diamonds); (Queen, Diamonds); (King, Diamonds); (Ace, Diamonds)]
        |> Shuffle
        |> Evaluator.Evaluate
        |> should equal "Straight flush (Ten -> Ace of Diamonds)"

    [<Test>] member this.HandContainsLowStraightFlush() =
        [(Two, Diamonds); (Three, Diamonds); (Four, Diamonds); (Five, Diamonds); (Ace, Diamonds)]
        |> Shuffle
        |> Evaluator.Evaluate
        |> should equal "Straight flush (Ace -> Five of Diamonds)"
