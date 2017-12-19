open System.IO
open System

let input = File.ReadAllText(Path.Combine(__SOURCE_DIRECTORY__, "day6_input.txt"))

let banks = input.Split([|' '; '\t'; '\n'|]) |> Array.map int

let redistribute banks =
    let idx, maxBank =
        banks
        |> Array.indexed
        |> Array.maxBy snd
    let increaseBy, remain = Math.DivRem (maxBank, banks.Length)
    let banks' = Array.map (fun x -> x + increaseBy) banks
    banks'.[idx] <- banks'.[idx] - maxBank
    let rec loop (banks: int[]) i remain =
        match remain with
        | 0 -> banks'
        | _ ->
            let i = i % banks'.Length
            banks.[i] <- banks.[i] + 1
            loop banks (i+1) (remain-1)
    loop banks' (idx+1) remain

let part1 () =
    let rec loop banks traces counter =
        match Set.contains banks traces with
        | true -> counter
        | false ->
            let traces' = Set.add banks traces
            let banks' = redistribute banks
            loop banks' traces' (counter + 1)
    loop banks Set.empty 0

part1()
|> printfn "%d"