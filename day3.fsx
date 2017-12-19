open System.IO
open System

let input = File.ReadAllText(Path.Combine(__SOURCE_DIRECTORY__, "day3_input.txt"))

let indexToPosition n =
    let d = float n |> sqrt |> ceil |> int
    let d = if d % 2 = 0 then d+1 else d
    let r = d / 2
    let minInLayer = d*d - 4*(d - 1) + 1
    let group, index = Math.DivRem (n - minInLayer,  d - 1)
    let h = -r + index + 1
    match group with
    | 0 -> r, h
    | 1 -> -h, r
    | 2 -> -r, -h
    | 3 -> h, -r
    | _ -> failwith "imposible"

let part1 input =
    let N = int input
    let x, y = indexToPosition N
    abs x + abs y

let neighbors (x, y) =
    [ x+1, y
      x+1, y+1
      x,   y+1
      x-1, y+1
      x-1, y
      x-1, y-1
      x,   y-1
      x+1, y-1 ]

let rec fillIn index dic = seq {
    let pos = indexToPosition index
    let value =
        neighbors pos
        |> List.sumBy (fun p -> Map.tryFind p dic |> Option.defaultValue 0)
    yield value
    let dic' = Map.add pos value dic
    yield! fillIn (index+1) dic'
}

let part2 input =
    let n = int input
    fillIn 2 (Map.add (0,0) 1 Map.empty)
    |> Seq.skipWhile (fun x -> x <= n)
    |> Seq.head

part2 input
|> printfn "%d"
