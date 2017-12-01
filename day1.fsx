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

let findMatchedHalfway input =
    let l = Array.length input
    let rec loop l (arr: 'T[]) res i =
        let recur = loop l arr
        if i >= l then res
        else
            if arr.[i] = arr.[(i + l/2) % l] then
                recur (arr.[i]::res) (i+1)
            else
                recur res (i+1)
    loop l input [] 0

let part1() =
    File.ReadAllText(Path.Combine(__SOURCE_DIRECTORY__, "day1_input.txt"))
    |> findMatchedChar
    |> List.sumBy (string >> int)
    |> printfn "%A"

let part2() =
    File.ReadAllText(Path.Combine(__SOURCE_DIRECTORY__, "day1_input.txt"))
    |> fun s -> s.ToCharArray()
    |> findMatchedHalfway
    |> List.sumBy (string >> int)
    |> printfn "%A"

part2()