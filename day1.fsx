open System.IO

let findMatchedChar str =
    let folder (res, last) c =
        if last = c then (last::res, c)
        else (res, c)
    let head = Seq.head str
    seq {
        yield! Seq.skip 1 str
        yield head }
    |> Seq.fold folder ([], head)
    |> fst

File.ReadAllText(Path.Combine(__SOURCE_DIRECTORY__, "day1_input.txt"))
|> findMatchedChar
|> List.sumBy (string >> int)
|> printfn "%A"