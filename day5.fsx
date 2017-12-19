open System.IO

let input = File.ReadAllLines(Path.Combine(__SOURCE_DIRECTORY__, "day5_input.txt"))

let maze = Array.map int input

let rec walk (maze: int[]) i step =
    if i >= maze.Length || i < 0 then
        step
    else
        let offset = maze.[i]
        maze.[i] <- offset + 1
        let i' = i + offset
        walk maze i' (step + 1)

let part1 () =
    walk maze 0 0

part1 () |> printfn "%d"