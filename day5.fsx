open System.IO

let input = File.ReadAllLines(Path.Combine(__SOURCE_DIRECTORY__, "day5_input.txt"))

let maze = Array.map int input


let rec walk changeOffset (maze: int[]) i step =
    if i >= maze.Length || i < 0 then
        step
    else
        let offset = maze.[i]
        maze.[i] <- changeOffset offset
        let i' = i + offset
        walk changeOffset maze i' (step + 1)

let part1 () =
    walk (fun x -> x + 1) maze 0 0

let part2 () =
    walk (fun x -> if x >= 3 then x - 1 else x + 1) maze 0 0

part2 () |> printfn "%d"