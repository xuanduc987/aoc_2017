open System.IO

let input = File.ReadAllLines(Path.Combine(__SOURCE_DIRECTORY__, "day4_input.txt"))

let isValid (passphrase: string) =
    let words = passphrase.Split(' ')
    words
    |> Array.countBy id
    |> Array.forall (fun (_, c) -> c = 1)

let isValid' (passphrase: string) =
    let words = passphrase.Split(' ')
    words
    |> Array.countBy (fun s -> s.ToCharArray() |> Array.sort)
    |> Array.forall (fun (_, c) -> c = 1)

let part1 input =
    input
    |> Array.sumBy (fun s -> if isValid s then 1 else 0)

let part2 input =
    input
    |> Array.sumBy (fun s -> if isValid' s then 1 else 0)

part2 input
|> printfn "%d"