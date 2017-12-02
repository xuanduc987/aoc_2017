open System.IO



let lines = File.ReadAllLines(Path.Combine(__SOURCE_DIRECTORY__, "day2_input.txt"))

let parseLine (line: string) =
    line.Split ()
    |> Array.map int

let part1 lines =
    lines
    |> Array.map parseLine
    |> Array.map (fun arr ->
        let max' = Array.max arr
        let min' = Array.min arr
        max' - min')
    |> Array.sum

part1 lines
|> printfn "%d"
