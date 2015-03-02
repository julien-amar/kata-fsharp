namespace Kata.Romanize

module Configuration =
    type RomanMapping = { Symbol:string; Threshold:int }

    let Thresholds = [
        { Symbol = "M" ; Threshold = 1000 };
        { Symbol = "CM" ; Threshold = 900 };
        { Symbol = "D" ; Threshold = 500 };
        { Symbol = "CD" ; Threshold = 400 };
        { Symbol = "C" ; Threshold = 100 };
        { Symbol = "XC" ; Threshold = 90 };
        { Symbol = "L" ; Threshold = 50 };
        { Symbol = "XL" ; Threshold = 40 };
        { Symbol = "X" ; Threshold = 10 };
        { Symbol = "IX" ; Threshold = 9 };
        { Symbol = "V" ; Threshold = 5 };
        { Symbol = "IV" ; Threshold = 4 };
        { Symbol = "I" ; Threshold = 1 }
    ]

    let (|MatchSymbol|_|) value =
        Thresholds
        |> Seq.tryFind (fun x -> x.Threshold <= value)