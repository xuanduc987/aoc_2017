open System.IO

let input = File.ReadAllText(Path.Combine(__SOURCE_DIRECTORY__, "day3_input.txt"))

let part1 input =
    let N = int input

    let R =
        N
        |> float
        |> sqrt
        |> ceil
        |> int

    let n = 4*(R - 1)
    let minValue = R * R - n + 1

    let index = (N - minValue) % (R - 1)

    R/2 + abs (-R/2 + 1 + index)

part1 input
|> printfn "%d"
