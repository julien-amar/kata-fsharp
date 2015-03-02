#load "Utils.fs"
#load "Configuration.fs"
#load "Romanizer.fs"

open Kata.Romanize.Romanizer

[0 .. 1000]
|> Seq.iter (fun x -> printfn "%d :\t%s" x (Romanize x))
