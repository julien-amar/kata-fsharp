namespace Kata.Romanize

module Romanizer =
    open Configuration
    open Utils

    let TranslateAndDecrement n m =
        let decrementedValue = Decrement n m.Threshold
        Some((decrementedValue, m))

    let rec Romanize n =
        let next =
            match n with
            | MatchSymbol m -> TranslateAndDecrement n m
            | _ -> None
        if next.IsNone then "" else snd(next.Value).Symbol + (Romanize (fst next.Value))
